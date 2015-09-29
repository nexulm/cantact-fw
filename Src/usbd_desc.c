#include "usbd_core.h"
#include "usbd_desc.h"
#include "usbd_conf.h"

#define USBD_VID						0x0483
#define USBD_PID_FS						0x5740
#define USBD_LANGID_STRING				0x0409
#define USBD_MANUFACTURER_STRING		"X893"
#define USBD_PRODUCT_STRING_FS			"CANtact Com Port"
#define USBD_SERIALNUMBER_STRING_FS		"00000000001A"
#define USBD_CONFIGURATION_STRING_FS	"CDC Config"
#define USBD_INTERFACE_STRING_FS		"CDC Interface"

uint8_t * USBD_FS_DeviceDescriptor(uint16_t *length);
uint8_t * USBD_FS_LangIDStrDescriptor(uint16_t *length);
uint8_t * USBD_FS_ManufacturerStrDescriptor (uint16_t *length);
uint8_t * USBD_FS_ProductStrDescriptor (uint16_t *length);
uint8_t * USBD_FS_SerialStrDescriptor(uint16_t *length);
uint8_t * USBD_FS_ConfigStrDescriptor(uint16_t *length);
uint8_t * USBD_FS_InterfaceStrDescriptor(uint16_t *length);

#ifdef USB_SUPPORT_USER_STRING_DESC
uint8_t *	 USBD_FS_USRStringDesc (USBD_SpeedTypeDef speed, uint8_t idx , uint16_t *length);
#endif /* USB_SUPPORT_USER_STRING_DESC */  

USBD_DescriptorsTypeDef FS_Desc =
{
	USBD_FS_DeviceDescriptor,
	USBD_FS_LangIDStrDescriptor, 
	USBD_FS_ManufacturerStrDescriptor,
	USBD_FS_ProductStrDescriptor,
	USBD_FS_SerialStrDescriptor,
	USBD_FS_ConfigStrDescriptor,
	USBD_FS_InterfaceStrDescriptor,
};

#if defined ( __ICCARM__ ) /*!< IAR Compiler */
	#pragma data_alignment=4   
#endif

/* USB Standard Device Descriptor */
__ALIGN_BEGIN uint8_t USBD_FS_DeviceDesc[USB_LEN_DEV_DESC] __ALIGN_END =
{
	0x12,					/*bLength */
	USB_DESC_TYPE_DEVICE,	/*bDescriptorType*/
	0x00,					/* bcdUSB */  
	0x02,
	0x00,					/*bDeviceClass*/
	0x00,					/*bDeviceSubClass*/
	0x00,					/*bDeviceProtocol*/
	USB_MAX_EP0_SIZE,		/*bMaxPacketSize*/
	LOBYTE(USBD_VID),		/*idVendor*/
	HIBYTE(USBD_VID),		/*idVendor*/
	LOBYTE(USBD_PID_FS),	/*idVendor*/
	HIBYTE(USBD_PID_FS),	/*idVendor*/
	0x00,					/*bcdDevice rel. 2.00*/
	0x02,
	USBD_IDX_MFC_STR,		/*Index of manufacturer  string*/
	USBD_IDX_PRODUCT_STR,	/*Index of product string*/
	USBD_IDX_SERIAL_STR,	/*Index of serial number string*/
	USBD_MAX_NUM_CONFIGURATION	/*bNumConfigurations*/
} ; 
/* USB_DeviceDescriptor */

#if defined ( __ICCARM__ ) /*!< IAR Compiler */
	#pragma data_alignment=4
#endif

/* USB Standard Device Descriptor */
__ALIGN_BEGIN uint8_t USBD_LangIDDesc[USB_LEN_LANGID_STR_DESC] __ALIGN_END =
{
	USB_LEN_LANGID_STR_DESC,		 
	USB_DESC_TYPE_STRING,	   
	LOBYTE(USBD_LANGID_STRING),
	HIBYTE(USBD_LANGID_STRING), 
};

#if defined ( __ICCARM__ ) /*!< IAR Compiler */
	#pragma data_alignment=4   
#endif
__ALIGN_BEGIN uint8_t USBD_StrDesc[USBD_MAX_STR_DESC_SIZ] __ALIGN_END;

/**
 * @brief  USBD_FS_DeviceDescriptor 
 *		 return the device descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_DeviceDescriptor(uint16_t *length)
{
	*length = sizeof(USBD_FS_DeviceDesc);
	return USBD_FS_DeviceDesc;
}

/**
 * @brief  USBD_FS_LangIDStrDescriptor 
 *		 return the LangID string descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_LangIDStrDescriptor(uint16_t *length)
{
	*length =  sizeof(USBD_LangIDDesc);
	return USBD_LangIDDesc;
}

/**
 * @brief  USBD_FS_ProductStrDescriptor 
 *		 return the product string descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_ProductStrDescriptor(uint16_t *length)
{
	USBD_GetString((uint8_t *)USBD_PRODUCT_STRING_FS, USBD_StrDesc, length);
	return USBD_StrDesc;
}

/**
 * @brief  USBD_FS_ManufacturerStrDescriptor 
 *		 return the manufacturer string descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_ManufacturerStrDescriptor(uint16_t *length)
{
	USBD_GetString ((uint8_t *)USBD_MANUFACTURER_STRING, USBD_StrDesc, length);
	return USBD_StrDesc;
}

/**
 * @brief  USBD_FS_SerialStrDescriptor 
 *		 return the serial number string descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_SerialStrDescriptor(uint16_t *length)
{
	USBD_GetString ((uint8_t *)USBD_SERIALNUMBER_STRING_FS, USBD_StrDesc, length);	
	return USBD_StrDesc;
}

/**
 * @brief  USBD_FS_ConfigStrDescriptor 
 *		 return the configuration string descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_ConfigStrDescriptor(uint16_t *length)
{
	USBD_GetString ((uint8_t *)USBD_CONFIGURATION_STRING_FS, USBD_StrDesc, length); 
	return USBD_StrDesc;
}

/**
 * @brief  USBD_HS_InterfaceStrDescriptor 
 *		 return the interface string descriptor
 * @param  speed : current device speed
 * @param  length : pointer to data length variable
 * @retval pointer to descriptor buffer
 */
uint8_t *  USBD_FS_InterfaceStrDescriptor(uint16_t *length)
{
	USBD_GetString ((uint8_t *)USBD_INTERFACE_STRING_FS, USBD_StrDesc, length);
	return USBD_StrDesc;  
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
