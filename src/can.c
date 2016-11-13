#include "can.h"

typedef __packed struct {
	uint16_t PutIndex;
	uint16_t GetIndex;
	uint16_t Size;
} CanRingBuffer_t;

CanTxMsgTypeDef Can_Tx_Messages[8];
CanRxMsgTypeDef Can_Rx_Messages[16];

CAN_HandleTypeDef hcan;
CAN_FilterConfTypeDef filter;

void can_init(void)
{
    filter.FilterIdHigh = 0;
    filter.FilterIdLow = 0;
    filter.FilterMaskIdHigh = 0;
    filter.FilterMaskIdLow = 0;
    filter.FilterMode = CAN_FILTERMODE_IDMASK;
    filter.FilterScale = CAN_FILTERSCALE_32BIT;
    filter.FilterNumber = 0;
    filter.FilterFIFOAssignment = CAN_FIFO0;
    filter.BankNumber = 0;
    filter.FilterActivation = ENABLE;

    // default to 125 kbit/s
    hcan.Init.Prescaler = 48;
	hcan.Init.Mode = CAN_MODE_NORMAL;

    hcan.Instance = CAN;

	hcan.Init.SJW = CAN_SJW_1TQ;
	hcan.Init.BS1 = CAN_BS1_4TQ;
	hcan.Init.BS2 = CAN_BS2_3TQ;
	hcan.Init.TTCM = DISABLE;
	hcan.Init.ABOM = DISABLE;
	hcan.Init.AWUM = DISABLE;
	hcan.Init.NART = ENABLE;
	hcan.Init.RFLM = DISABLE;
	hcan.Init.TXFP = DISABLE;
	hcan.pTxMsg = NULL;
}

HAL_StatusTypeDef can_enable(void)
{
	HAL_StatusTypeDef result = HAL_OK;

	if (hcan.State == HAL_CAN_STATE_RESET)
	{
		if (HAL_OK == (result = HAL_CAN_Init(&hcan)))
		{
			if (HAL_OK != (result = HAL_CAN_ConfigFilter(&hcan, &filter)))
				HAL_CAN_DeInit(&hcan);
		}
    }
	return result;
}

void can_disable(void)
{
	HAL_CAN_DeInit(&hcan);
}

HAL_StatusTypeDef can_set_bitrate(enum can_bitrate bitrate)
{
	uint32_t prescaler = 48;

	// cannot set bitrate while on bus
	if (hcan.State != HAL_CAN_STATE_RESET)
		return HAL_ERROR;

	switch (bitrate)
	{
		case CAN_BITRATE_10K:
			prescaler = 600;
			break;
		case CAN_BITRATE_20K:
			prescaler = 300;
			break;
		case CAN_BITRATE_50K:
			prescaler = 120;
			break;
		case CAN_BITRATE_100K:
			prescaler = 60;
			break;
		case CAN_BITRATE_125K:
			prescaler = 48;
			break;
		case CAN_BITRATE_250K:
			prescaler = 24;
			break;
		case CAN_BITRATE_500K:
			prescaler = 12;
			break;
		case CAN_BITRATE_750K:
			prescaler = 8;
			break;
		case CAN_BITRATE_1000K:
			prescaler = 6;
			break;
		default:
			return HAL_ERROR;
	}
	hcan.Init.Prescaler = prescaler;
	return HAL_OK;
}

void can_set_loopback(void)
{
	// cannot set silent mode while on bus
    if (hcan.State == HAL_CAN_STATE_RESET)
	{
		hcan.Init.Mode = CAN_MODE_LOOPBACK;
	}
}

void can_set_silent(uint8_t silent)
{
	// cannot set silent mode while on bus
    if (hcan.State == HAL_CAN_STATE_RESET)
	{
		if (silent)
			hcan.Init.Mode = CAN_MODE_SILENT;
		else
			hcan.Init.Mode = CAN_MODE_NORMAL;
	}
}

HAL_StatusTypeDef can_tx(CanTxMsgTypeDef *tx_msg, uint32_t timeout)
{
    HAL_StatusTypeDef status;

    // transmit can frame
    hcan.pTxMsg = tx_msg;
    status = HAL_CAN_Transmit(&hcan, timeout);

	LED3_pulse();
    return status;
}

HAL_StatusTypeDef can_rx(CanRxMsgTypeDef *rx_msg, uint32_t timeout)
{
    HAL_StatusTypeDef status;
    hcan.pRxMsg = rx_msg;
    status = HAL_CAN_Receive(&hcan, CAN_FIFO0, timeout);

	LED2_pulse();
    return status;
}

bool is_can_msg_pending(uint8_t fifo)
{
	if (hcan.State == HAL_CAN_STATE_RESET)
		return false;
	return (__HAL_CAN_MSG_PENDING(&hcan, fifo) > 0);
}
