#include "stm32f0xx_hal.h"
#include "usb_device.h"

#include "usbd_cdc_if.h"
#include "can.h"
#include "slcan.h"

//#define INTERNAL_OSCILLATOR
#define EXTERNAL_OSCILLATOR

CanRxMsgTypeDef rx_msg;
CanTxMsgTypeDef tx_msg;

uint8_t msg_buf[SLCAN_MTU];

void system_clock_config(void);
static void gpio_config(void);

//	1 ms SysTick
#define TICK_MS(ms)		(ms)

typedef struct {
	uint8_t LED1_delay;
	uint8_t LED2_delay;
	uint8_t LED3_delay;
} systick_context_t;

systick_context_t systick_context;

void LED1_on(void)		{	HAL_GPIO_WritePin (GPIOB, GPIO_PIN_14, GPIO_PIN_SET);	}
void LED1_off(void)		{	HAL_GPIO_WritePin (GPIOB, GPIO_PIN_14, GPIO_PIN_RESET);	}
void LED1_toggle(void)	{	HAL_GPIO_TogglePin(GPIOB, GPIO_PIN_14);					}
void LED1_pulse(void)
{
	LED1_on();
	systick_context.LED1_delay = TICK_MS(100);
}

void LED2_on(void)		{	HAL_GPIO_WritePin (GPIOB, GPIO_PIN_1, GPIO_PIN_SET);	}
void LED2_off(void)		{	HAL_GPIO_WritePin (GPIOB, GPIO_PIN_1, GPIO_PIN_RESET);	}
void LED2_toggle(void)	{	HAL_GPIO_TogglePin(GPIOB, GPIO_PIN_1);					}
void LED2_pulse(void)
{
	LED2_on();
	systick_context.LED2_delay = TICK_MS(100);
}

void LED3_on(void)		{	HAL_GPIO_WritePin (GPIOB, GPIO_PIN_0, GPIO_PIN_SET);	}
void LED3_off(void)		{	HAL_GPIO_WritePin (GPIOB, GPIO_PIN_0, GPIO_PIN_RESET);	}
void LED3_toggle(void)	{	HAL_GPIO_TogglePin(GPIOB, GPIO_PIN_0);					}
void LED3_pulse(void)
{
	LED3_on();
	systick_context.LED3_delay = TICK_MS(100);
}

void HAL_SYSTICK_Callback(void)
{
	systick_context_t * ctx = &systick_context;

	if (ctx->LED3_delay != 0)
	{
		ctx->LED3_delay--;
		if (ctx->LED3_delay == 0)
			LED3_off();
	}
	if (ctx->LED2_delay != 0)
	{
		ctx->LED2_delay--;
		if (ctx->LED2_delay == 0)
			LED2_off();
	}
	if (ctx->LED1_delay != 0)
	{
		ctx->LED1_delay--;
		if (ctx->LED1_delay == 0)
			LED1_off();
	}
}

#define SYSTEM_BOOT_START	0x1FFFC400

typedef  void (*pFunction)(void);
pFunction Jump_To_Application;

int main(void)
{
	HAL_Init();

	gpio_config();
	LED1_on();
	LED2_on();
	LED3_on();
	system_clock_config();
	
	can_init();
	usb_device_init();

	// CAN default initialization
	can_set_bitrate(CAN_BITRATE_500K);
	can_enable();

	{
		systick_context_t * ctx = &systick_context;
		ctx->LED1_delay = 1;
		ctx->LED2_delay = 1;
		ctx->LED3_delay = 1;
	}
		
	while (1)
	{
		if (slcan_parse_str(CDC_Receive_Line()) == -2)
			break;

		if (is_can_msg_pending(CAN_FIFO0)
		&&	can_rx(&rx_msg, 2) == HAL_OK)
		{
			CDC_Transmit_FS(
				msg_buf,
				slcan_parse_frame((char *)&msg_buf, &rx_msg)
			);
		}
	}

	can_disable();
	usb_device_deinit();
	HAL_Delay(500);

	SysTick->CTRL = 0;
	SysTick->LOAD = 0;
	SysTick->VAL  = 0;

	HAL_RCC_DeInit();
	HAL_DeInit();

	__SYSCFG_CLK_ENABLE();
	__HAL_REMAPMEMORY_SYSTEMFLASH();

	Jump_To_Application = (pFunction)(*(__IO uint32_t*)(SYSTEM_BOOT_START + 4));
	__set_MSP(*(__IO uint32_t *)(SYSTEM_BOOT_START + 0));
	Jump_To_Application();
}

/**
  * @brief	System Clock Configuration
  */
void system_clock_config(void)
{
	RCC_OscInitTypeDef osc_init;
	RCC_ClkInitTypeDef clk_init;
	RCC_PeriphCLKInitTypeDef periph_clk_init;

	osc_init.OscillatorType = RCC_OSCILLATORTYPE_HSE;
	osc_init.HSEState = RCC_HSE_ON;
	osc_init.PLL.PLLState = RCC_PLL_ON;
	osc_init.PLL.PLLSource = RCC_PLLSOURCE_HSE;
	osc_init.PLL.PLLMUL = RCC_PLL_MUL6;
	osc_init.PLL.PREDIV = RCC_PREDIV_DIV1;
	HAL_RCC_OscConfig(&osc_init);

	clk_init.ClockType = RCC_CLOCKTYPE_SYSCLK;
	clk_init.SYSCLKSource = RCC_SYSCLKSOURCE_PLLCLK;
	clk_init.AHBCLKDivider = RCC_SYSCLK_DIV1;
	clk_init.APB1CLKDivider = RCC_HCLK_DIV1;
	HAL_RCC_ClockConfig(&clk_init, FLASH_LATENCY_1);

	periph_clk_init.PeriphClockSelection = RCC_PERIPHCLK_USB;
	periph_clk_init.UsbClockSelection = RCC_USBCLKSOURCE_PLLCLK;
	HAL_RCCEx_PeriphCLKConfig(&periph_clk_init);

	HAL_SYSTICK_Config(HAL_RCC_GetHCLKFreq() / 1000);
	HAL_SYSTICK_CLKSourceConfig(SYSTICK_CLKSOURCE_HCLK);
}

/**
  * @brief	Configure pins
  */
void gpio_config(void)
{
	GPIO_InitTypeDef gpio_init;

	/* GPIO Ports Clock Enable */
	__GPIOF_CLK_ENABLE();
	__GPIOB_CLK_ENABLE();
	__GPIOA_CLK_ENABLE();

	/*Configure GPIO pins : PB0 PB1 PB14 */
	gpio_init.Pin = GPIO_PIN_0 | GPIO_PIN_1 | GPIO_PIN_14;
	gpio_init.Mode = GPIO_MODE_OUTPUT_PP;
	gpio_init.Pull = GPIO_NOPULL;
	gpio_init.Speed = GPIO_SPEED_LOW;
	HAL_GPIO_Init(GPIOB, &gpio_init);
}

#ifdef USE_FULL_ASSERT

/**
   * @brief Reports the name of the source file and the source line number
   * where the assert_param error has occurred.
   * @param file: pointer to the source file name
   * @param line: assert_param error line source number
   * @retval None
   */
void assert_failed(uint8_t* file, uint32_t line)
{
  /* USER CODE BEGIN 6 */
	/* User can add his own implementation to report the file name and line number,
	   ex: printf("Wrong parameters value: file %s on line %d\r\n", file, line) */
  /* USER CODE END 6 */

}

#endif
