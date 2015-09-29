#ifndef _CAN_H
#define _CAN_H

#include <stdbool.h>

#include "stm32f0xx_hal.h"

enum can_bitrate {
    CAN_BITRATE_10K,
    CAN_BITRATE_20K,
    CAN_BITRATE_50K,
    CAN_BITRATE_100K,
    CAN_BITRATE_125K,
    CAN_BITRATE_250K,
    CAN_BITRATE_500K,
    CAN_BITRATE_750K,
    CAN_BITRATE_1000K,
};

typedef enum {
    OFF_BUS,
    ON_BUS
} CAN_BUS_State_t;

void can_init(void);
void can_disable(void);

HAL_StatusTypeDef can_enable(void);
HAL_StatusTypeDef can_set_bitrate(enum can_bitrate bitrate);
HAL_StatusTypeDef can_tx(CanTxMsgTypeDef *tx_msg, uint32_t timeout);
HAL_StatusTypeDef can_rx(CanRxMsgTypeDef *rx_msg, uint32_t timeout);
bool is_can_msg_pending(uint8_t fifo);

void can_set_silent(uint8_t silent);
void can_set_loopback(void);

void LED1_on(void);
void LED1_off(void);
void LED1_toggle(void);
void LED1_pulse(void);

void LED2_on(void);
void LED2_off(void);
void LED2_toggle(void);
void LED2_pulse(void);

void LED3_on(void);
void LED3_off(void);
void LED3_toggle(void);
void LED3_pulse(void);

#endif // _CAN_H
