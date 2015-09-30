#include "stm32f0xx_hal.h"
#include "can.h"
#include "slcan.h"

int8_t slcan_parse_frame(char *buf, CanRxMsgTypeDef *frame)
{
	uint8_t i = 0;
	uint8_t id_len, j;
	uint32_t tmp;

	// add character for frame type
	if (frame->RTR == CAN_RTR_DATA)
		j = 't';
	else if (frame->RTR == CAN_RTR_REMOTE)
		j = 'r';

	// check if extended
	if (frame->IDE == CAN_ID_EXT)
	{
		// convert first char to upper case for extended frame
		j -= ('t' - 'T');
		id_len = SLCAN_EXT_ID_LEN;
		tmp = frame->ExtId;
	}
	else
	{
		// assume standard identifier
		id_len = SLCAN_STD_ID_LEN;
		tmp = frame->StdId;
	}
	buf[i++] = j;

	// add identifier to buffer
	for(j = id_len; j > 0; j--)
	{
		// add nibble to buffer
		buf[j] = (tmp & 0xF);
		tmp >>= 4;
		i++;
	}

	// add DLC to buffer
	buf[i++] = (frame->DLC & 0x0F);

	// add data bytes
	for (j = 0; j < frame->DLC; j++)
	{
		buf[i++] = ((frame->Data[j] >> 4) & 0xF);
		buf[i++] = (frame->Data[j] & 0x0F);
	}

	// convert to ASCII (2nd character to end)
	for (j = 1; j < i; j++)
	{
		if (buf[j] < 0xA)
			buf[j] += '0';
		else
			buf[j] += ('A' - 0xA);
	}

	// add carrage return (slcan EOL)
	buf[i++] = '\r';
	buf[i++] = '\n';

	// return number of bytes in string
	return i;
}

/**
 * @retval	0 normal
 *			-1 bad parameters
 *			-55	reboot
 */
int8_t slcan_parse_str(char *buf)
{
	CanTxMsgTypeDef frame;
	uint8_t i = 1;
	char ch;

	if (buf == NULL || *buf == '\0')
		return (-1);

	LED1_pulse();
	// convert from ASCII (2nd character to end)
	while ((ch = buf[i]) != '\0')
	{
		if (ch < 'A')	ch -= '0';
		else			ch -= ('A' - 0xA);
		buf[i] = ch;
		i++;
	}
	ch = buf[0];

	if (ch == 'O')
	{	// open channel command
		can_enable();
		return 0;
	}
	else if (ch == 'C')
	{	// close channel command
		can_disable();
		return 0;
	}
	else if (ch == 'S')
	{	// set bitrate command
		switch(buf[1])
		{
		case 0:
			can_set_bitrate(CAN_BITRATE_10K);
			break;
		case 1:
			can_set_bitrate(CAN_BITRATE_20K);
			break;
		case 2:
			can_set_bitrate(CAN_BITRATE_50K);
			break;
		case 3:
			can_set_bitrate(CAN_BITRATE_100K);
			break;
		case 4:
			can_set_bitrate(CAN_BITRATE_125K);
			break;
		case 5:
			can_set_bitrate(CAN_BITRATE_250K);
			break;
		case 6:
			can_set_bitrate(CAN_BITRATE_500K);
			break;
		case 7:
			can_set_bitrate(CAN_BITRATE_750K);
			break;
		case 8:
			can_set_bitrate(CAN_BITRATE_1000K);
			break;
		default:
			// invalid setting
			return (-1);
		}
		return 0;
	}
	else if (ch == 'm' || ch == 'M')
	{
		if (buf[1] == 1)	// mode 1: silent mode
			can_set_silent(1);
		else				// default to normal mode
			can_set_silent(0);
		return 0;
	}
	else if (ch == 't' || ch == 'T')
		// transmit data frame command
		frame.RTR = CAN_RTR_DATA;
	else if (ch == 'r' || ch == 'R')
		// transmit remote frame command
		frame.RTR = CAN_RTR_REMOTE;
#ifdef STM32F042x6
	else if (ch == 'B' && buf[1] == 0x0D && buf[2] == 0x0E && buf[3] == 0x0A && buf[4] == 0x0D)
		return (-2);
#endif
	else
		// error, unknown command
		return -1;

	if (ch == 't' || ch == 'r')
		frame.IDE = CAN_ID_STD;
	else if (ch == 'T' || ch == 'R')
		frame.IDE = CAN_ID_EXT;
	else	// error
		return -1;

	frame.StdId = 0;
	frame.ExtId = 0;
	i = 1;
	if (frame.IDE == CAN_ID_EXT)
	{
		while (i <= SLCAN_EXT_ID_LEN)
		{
			frame.ExtId <<= 4;
			frame.ExtId |= buf[i++];
		}
	}
	else
	{
		while (i <= SLCAN_STD_ID_LEN)
		{
			frame.StdId <<= 4;
			frame.StdId |= buf[i++];
		}
	}

	frame.DLC = buf[i++];
	if (frame.DLC > 8)
		return -1;

	uint8_t j;
	for (j = 0; j < frame.DLC; j++)
	{
		frame.Data[j] = (buf[i] << 4) | buf[i+1];
		i += 2;
	}

	// send the message
	can_tx(&frame, 10);

	return 0;
}
