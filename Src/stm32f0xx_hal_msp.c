#include "stm32f0xx_hal.h"

/**
  * Initializes the Global MSP.
  */
void HAL_MspInit(void)
{
	__SYSCFG_CLK_ENABLE();

	/* System interrupt init*/
	/* SysTick_IRQn interrupt configuration */
	HAL_NVIC_SetPriority(SysTick_IRQn, 0, 0);
}

void HAL_CAN_MspInit(CAN_HandleTypeDef* hcan)
{
	GPIO_InitTypeDef gpio_init;

	if(hcan->Instance == CAN)
	{
		/* Peripheral clock enable */
		__CAN_CLK_ENABLE();
  
		/**CAN GPIO Configuration
		PB8     ------> CAN_RX
		PB9     ------> CAN_TX
		*/
		gpio_init.Pin = GPIO_PIN_8 | GPIO_PIN_9;
		gpio_init.Mode = GPIO_MODE_AF_PP;
		gpio_init.Pull = GPIO_NOPULL;
		gpio_init.Speed = GPIO_SPEED_HIGH;
		gpio_init.Alternate = GPIO_AF4_CAN;
		HAL_GPIO_Init(GPIOB, &gpio_init);
	}
}

void HAL_CAN_MspDeInit(CAN_HandleTypeDef* hcan)
{
	GPIO_InitTypeDef gpio_init;

	if(hcan->Instance == CAN)
	{
		hcan->Instance->MCR |= CAN_MCR_RESET;

		/* Peripheral clock disable */
		__CAN_CLK_DISABLE();

		/**CAN GPIO Configuration    
		PB8     ------> CAN_RX
		PB9     ------> CAN_TX 
		*/
		gpio_init.Pin = GPIO_PIN_8 | GPIO_PIN_9;
		gpio_init.Mode = GPIO_MODE_INPUT;
		gpio_init.Pull = GPIO_NOPULL;
		HAL_GPIO_Init(GPIOB, &gpio_init);
	}
}
