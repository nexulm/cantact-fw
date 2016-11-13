#ifndef __RING_BUFFER_H__
#define __RING_BUFFER_H__

#ifdef __cplusplus
extern "C" {
#endif

#include <stdbool.h>
#include <stdint.h>

typedef struct {
	uint16_t PutIndex;
	uint16_t GetIndex;
	uint16_t Size;
	uint8_t * Buffer;
} RingBuffer_t;

void ring_init(RingBuffer_t * rb);
bool ring_put(RingBuffer_t * rb, uint8_t data);
bool ring_available(RingBuffer_t * rb);
bool ring_get(RingBuffer_t * rb, uint8_t * data);

#ifdef __cplusplus
}
#endif

#endif
