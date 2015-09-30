#include "usbd_cdc_if.h"
#include "ring_buffer.h"
#include "can.h"
#include "slcan.h"

/** @defgroup USBD_CDC_Private_Defines
  * @{
  */ 
  /* USER CODE BEGIN 1 */
/* Define size for the receive and transmit buffer over CDC */
/* It's up to user to redefine and/or remove those define */
#define APP_RX_DATA_SIZE  128
#define APP_TX_DATA_SIZE  32
  /* USER CODE END 1 */  
/**
  * @}
  */ 

/** @defgroup USBD_CDC_Private_Macros
  * @{
  */ 
  /* USER CODE BEGIN 2 */ 
  /* USER CODE END 2 */
/**
  * @}
  */ 

/** @defgroup USBD_CDC_Private_Variables
  * @{
  */
/* Create buffer for reception and transmission		   */
/* It's up to user to redefine and/or remove those define */
/* Received Data over USB are stored in this buffer		*/
uint8_t UserRxBufferFS[APP_RX_DATA_SIZE];

/* Send Data over USB CDC are stored in this buffer	   */
uint8_t UserTxBufferFS[APP_TX_DATA_SIZE];

/* USB handler declaration */
/* Handle for USB Full Speed IP */
USBD_HandleTypeDef  *hUsbDevice_0;

extern USBD_HandleTypeDef hUsbDeviceFS;

typedef union {
	uint16_t U16;
	uint8_t  UU8[2];
} UU16_t;

typedef union {
	uint32_t U32;
	UU16_t UU16[2];
} UU32_t;

typedef struct {
	UU32_t	Baudrate;
	uint8_t StopBits;
	uint8_t Parity;
	uint8_t Length;
	uint8_t State;	/* 0x01 DTR, 0x02 RTS */
} LineConfig_t;

LineConfig_t LineConfig = { 115200, 0, 0, 8, 0 };
RingBuffer_t CDC_Ring_Receive = { 0, 0, APP_RX_DATA_SIZE, UserRxBufferFS };

/**
  * @}
  */ 
  
/** @defgroup USBD_CDC_Private_FunctionPrototypes
  * @{
  */
static int8_t CDC_Init_FS	(void);
static int8_t CDC_DeInit_FS	(void);
static int8_t CDC_Control_FS(uint8_t cmd, uint8_t * pbuf, uint16_t length);
static int8_t CDC_Receive_FS(uint8_t * pbuf, uint16_t * length);

USBD_CDC_ItfTypeDef USBD_Interface_fops_FS =
{
	CDC_Init_FS,
	CDC_DeInit_FS,
	CDC_Control_FS,  
	CDC_Receive_FS
};

/* Private functions ---------------------------------------------------------*/
/**
  * @brief  CDC_Init_FS
  *		 Initializes the CDC media low layer over the FS USB IP
  * @param  None
  * @retval Result of the operation: USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_Init_FS(void)
{
	hUsbDevice_0 = &hUsbDeviceFS;
	/* USER CODE BEGIN 3 */ 
	/* Create buffer for reception and transmission		   */
	/* It's up to user to redefine and/or remove those define */
	/* Received Data over USB are stored in this buffer	   */
	USBD_CDC_SetRxBuffer(hUsbDevice_0, UserRxBufferFS);
	return (USBD_OK);
	/* USER CODE END 3 */
}

/**
  * @brief  CDC_DeInit_FS
  *		 DeInitializes the CDC media low layer
  * @param  None
  * @retval Result of the operation: USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_DeInit_FS(void)
{
	/* USER CODE BEGIN 4 */ 
	return (USBD_OK);
	/* USER CODE END 4 */ 
}

/**
  * @brief  CDC_Control_FS
  *		 Manage the CDC class requests
  * @param  cmd: Command code			
  * @param  pbuf: Buffer containing command data (request parameters)
  * @param  length: Number of data to be sent (in bytes)
  * @retval Result of the operation: USBD_OK if all operations are OK else USBD_FAIL
  */
static int8_t CDC_Control_FS  (uint8_t cmd, uint8_t * pbuf, uint16_t length)
{
	/* USER CODE BEGIN 5 */
	switch (cmd)
	{
	case CDC_SEND_ENCAPSULATED_COMMAND:
		break;
	case CDC_GET_ENCAPSULATED_RESPONSE:
		break;
	case CDC_SET_COMM_FEATURE:
		break;
	case CDC_GET_COMM_FEATURE:
		break;
	case CDC_CLEAR_COMM_FEATURE:
		break;
	/********************************************************************************/
	/* Line Coding Structure														*/
	/*------------------------------------------------------------------------------*/
	/* Offset | Field		| Size | Value  | Description							*/
	/* 0	  | dwDTERate   |  4   | Number |Data terminal rate, in bits per second	*/
	/* 4	  | bCharFormat |  1   | Number | Stop bits								*/
	/*											0 - 1 Stop bit						*/
	/*											1 - 1.5 Stop bits					*/
	/*											2 - 2 Stop bits						*/
	/* 5	  | bParityType |  1   | Number | Parity								*/
	/*											0 - None							*/
	/*											1 - Odd								*/
	/*											2 - Even							*/
	/*											3 - Mark							*/
	/*											4 - Space							*/
	/* 6	  | bDataBits  |   1   | Number | Data bits (5, 6, 7, 8 or 16).			*/
	/********************************************************************************/
	case CDC_SET_LINE_CODING:
		LineConfig.Baudrate.UU16[0].UU8[0] = pbuf[0];
		LineConfig.Baudrate.UU16[0].UU8[1] = pbuf[1];
		LineConfig.Baudrate.UU16[1].UU8[0] = pbuf[2];
		LineConfig.Baudrate.UU16[1].UU8[1] = pbuf[3];
		LineConfig.StopBits = pbuf[4];
		LineConfig.Parity = pbuf[5];
		LineConfig.Length = pbuf[6];
		break;
	case CDC_GET_LINE_CODING:
		pbuf[0] = LineConfig.Baudrate.UU16[0].UU8[0];
		pbuf[1] = LineConfig.Baudrate.UU16[0].UU8[1];
		pbuf[2] = LineConfig.Baudrate.UU16[1].UU8[0];
		pbuf[3] = LineConfig.Baudrate.UU16[1].UU8[1];
		pbuf[4] = LineConfig.StopBits;
		pbuf[5] = LineConfig.Parity;
		pbuf[6] = LineConfig.Length;
		break;

	case CDC_SET_CONTROL_LINE_STATE:
		LineConfig.State = pbuf[0];
		break;
	case CDC_SEND_BREAK:
		break;
	default:
		break;
	}
	return (USBD_OK);
	/* USER CODE END 5 */
}

/**
 * @brief  CDC_Receive_FS
 *		 Data received over USB OUT endpoint are sent over CDC interface 
 *		 through this function.
 *		   
 *		 @note
 *		 This function will block any OUT packet reception on USB endpoint 
 *		 untill exiting this function. If you exit this function before transfer
 *		 is complete on CDC interface (ie. using DMA controller) it will result 
 *		 in receiving more data while previous ones are still not sent.
 *				 
 * @param  Buf: Buffer of data to be received
 * @param  Len: Number of data received (in bytes)
 * @retval Result of the operation: USBD_OK if all operations are OK else USBD_FAIL
 */
static int8_t CDC_Receive_FS(uint8_t * pbuf, uint16_t * length)
{
	/* USER CODE BEGIN 6 */

	uint32_t n = *length;
	while (n != 0)
	{
		--n;
		if (!ring_put(&CDC_Ring_Receive, *pbuf++))
			break;	// No space in buffer
	}
	// prepare for next read
	USBD_CDC_ReceivePacket(hUsbDevice_0);
	return (USBD_OK);
	/* USER CODE END 6 */
}

static char CDC_Line[SLCAN_MTU];
static uint8_t CDC_Line_Index = 0;

char * CDC_Receive_Line(void)
{
	uint8_t data;
	while (ring_get(&CDC_Ring_Receive, &data))
	{
		if (CDC_Line_Index == 0xFF)
		{
			if (data == '\r')
				CDC_Line_Index = 0;
			continue;
		}

		if (data == '\r')
		{
			if (CDC_Line_Index > 0)
			{
				CDC_Line[CDC_Line_Index] = 0;
				CDC_Line_Index = 0;
				return CDC_Line;
			}
		}
		else if (CDC_Line_Index < (sizeof(CDC_Line) - 1))
		{
			CDC_Line[CDC_Line_Index] = data;
			CDC_Line_Index++;
		}
		else
			CDC_Line_Index = 0xFF;
	}
	return NULL;
}

/**
  * @brief	CDC_Transmit_FS
  *			Data send over USB IN endpoint are sent over CDC interface 
  *			through this function.		   
  *			@note
  *
  * @param	Buf: Buffer of data to be send
  * @param	Len: Number of data to be send (in bytes)
  * @retval	Result of the operation: USBD_OK if all operations are OK else USBD_FAIL or USBD_BUSY
  */
uint8_t CDC_Transmit_FS(uint8_t * src, uint16_t length)
{
	/* USER CODE BEGIN 7 */
	uint8_t result;
	int i = 0;
	while (i < length && i < sizeof(UserTxBufferFS))
	{
		UserTxBufferFS[i] = src[i];
		i++;
	}

	USBD_CDC_SetTxBuffer(hUsbDevice_0, UserTxBufferFS, i);
	result = USBD_CDC_TransmitPacket(hUsbDevice_0);
	LED1_pulse();
	return result;
	/* USER CODE END 7 */
}

/**
  * @}
  */ 

/**
  * @}
  */ 

/**
  * @}
  */ 

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/

