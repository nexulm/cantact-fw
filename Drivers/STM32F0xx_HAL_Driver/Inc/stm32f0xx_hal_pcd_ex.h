/**
  ******************************************************************************
  * @file    stm32f0xx_hal_pcd_ex.h
  * @author  MCD Application Team
  * @version V1.2.1
  * @date    09-January-2015
  * @brief   Header file of PCD HAL Extension module.
  ******************************************************************************
  */ 
#ifndef __STM32L0xx_HAL_PCD_EX_H
#define __STM32L0xx_HAL_PCD_EX_H

#ifdef __cplusplus
extern "C" {
#endif

#if defined(STM32F042x6) || defined(STM32F048xx) || defined(STM32F072xB) || defined(STM32F078xx)|| defined(STM32F070xB)|| defined(STM32F070x6)

#include "stm32f0xx_hal_def.h"  
#include "stm32f0xx_hal_pcd.h"

/** @addtogroup STM32F0xx_HAL_Driver
  * @{
  */

/** @addtogroup PCDEx
  * @{
  */ 

/* Exported types ------------------------------------------------------------*/
/* Exported constants --------------------------------------------------------*/
/* Exported macros -----------------------------------------------------------*/
/* Internal macros -----------------------------------------------------------*/
/* Exported functions --------------------------------------------------------*/

/** @addtogroup PCDEx_Exported_Functions
  * @{
  */
  
/** @addtogroup PCDEx_Exported_Functions_Group2
  * @{
  */
HAL_StatusTypeDef HAL_PCDEx_PMAConfig(
	PCD_HandleTypeDef * hpcd,
	uint16_t ep_addr,
#ifdef PCD_DBL_BUF
	uint16_t ep_kind,
#endif
	uint32_t pmaadress);
/**
  * @}
  */ 
  
/**
  * @}
  */ 

/**
  * @}
  */

/**
  * @}
  */   

#endif /* STM32F042x6 || STM32F072xB || STM32F078xx || STM32F070xB || STM32F070x6*/

#ifdef __cplusplus
}
#endif


#endif /* __STM32F0xx_HAL_PCD_EX_H */

/************************ (C) COPYRIGHT STMicroelectronics *****END OF FILE****/
