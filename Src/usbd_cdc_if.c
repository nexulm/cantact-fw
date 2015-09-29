#include "usbd_cdc_if.h"

#include "can.h"
#include "slcan.h"

/** @defgroup USBD_CDC_Private_Defines
  * @{
  */ 
  /* USER CODE BEGIN 1 */
/* Define size for the receive and transmit buffer over CDC */
/* It's up to user to redefine and/or remove those define */
#define APP_RX_DATA_SIZE  32
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
/* Received Data over USB are stored in this buffer	   */
uint8_t UserRxBufferFS[APP_RX_DATA_SIZE];

/* Send Data over USB CDC are stored in this buffer	   */
uint8_t UserTxBufferFS[APP_TX_DATA_SIZE];

/* USB handler declaration */
/* Handle for USB Full Speed IP */
USBD_HandleTypeDef  *hUsbDevice_0;

extern USBD_HandleTypeDef hUsbDeviceFS;

/**
  * @}
  */ 
  
/** @defgroup USBD_CDC_Private_FunctionPrototypes
  * @{
  */
static int8_t CDC_Init_FS		(void);
static int8_t CDC_DeInit_FS		(void);
static int8_t CDC_Control_FS	(uint8_t cmd, uint8_t* pbuf, uint16_t length);
static int8_t CDC_Receive_FS	(uint8_t* pbuf, uint32_t *Len);

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
static int8_t CDC_Control_FS  (uint8_t cmd, uint8_t* pbuf, uint16_t length)
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
	/* 0	  | dwDTERate   |   4  | Number |Data terminal rate, in bits per second	*/
	/* 4	  | bCharFormat |   1  | Number | Stop bits								*/
	/*											0 - 1 Stop bit						*/
	/*											1 - 1.5 Stop bits					*/
	/*											2 - 2 Stop bits						*/
	/* 5	  | bParityType |  1   | Number | Parity								*/
	/*											0 - None							*/
	/*											1 - Odd								*/
	/*											2 - Even							*/
	/*											3 - Mark							*/
	/*											4 - Space							*/
	/* 6	  | bDataBits  |   1   | Number Data bits (5, 6, 7, 8 or 16).			*/
	/********************************************************************************/
		case CDC_SET_LINE_CODING:
			break;
		case CDC_GET_LINE_CODING:
			pbuf[0] = (uint8_t)(115200);
			pbuf[1] = (uint8_t)(115200 >> 8);
			pbuf[2] = (uint8_t)(115200 >> 16);
			pbuf[3] = (uint8_t)(115200 >> 24);
			pbuf[4] = 0; // stop bits (1)
			pbuf[5] = 0; // parity (none)
			pbuf[6] = 8; // number of bits (8)
			break;

		case CDC_SET_CONTROL_LINE_STATE:
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
static int8_t CDC_Receive_FS (uint8_t * Buf, uint32_t * Len)
{
	/* USER CODE BEGIN 6 */
	static uint8_t slcan_str[SLCAN_MTU];
	static uint8_t slcan_str_index = 0;

	uint8_t n = *Len;
	uint8_t i;

	for (i = 0; i < n; i++)
	{
		if (Buf[i] == '\r')
		{
			LED1_pulse();
			slcan_parse_str((char *) &slcan_str, slcan_str_index);
			slcan_str_index = 0;
		}
		else
		{
			slcan_str[slcan_str_index++] = Buf[i];
		}
	}

	// prepare for next read
	USBD_CDC_ReceivePacket(hUsbDevice_0);
	return (USBD_OK);
	/* USER CODE END 6 */
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
uint8_t CDC_Transmit_FS(uint8_t* Buf, uint16_t Len)
{
	/* USER CODE BEGIN 7 */
	uint8_t result;
	int i = 0;
	while (i < Len && i < sizeof(UserTxBufferFS))
	{
		UserTxBufferFS[i] = Buf[i];
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

