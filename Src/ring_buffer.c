#include "ring_buffer.h"

uint32_t IrqDisableCounter = 0;
/*
#define ATOMIC_BLOCK_START				\
	{									\
		__disable_irq();				\
		IrqDisableCounter++

#define ATOMIC_BLOCK_END				\
		if (IrqDisableCounter != 0)		\
		{								\
			--IrqDisableCounter;		\
			if (IrqDisableCounter == 0)	\
				__enable_irq();			\
		}								\
	}
*/
#define ATOMIC_BLOCK_START				\
	do {								\
		int se = __disable_irq()

#define ATOMIC_BLOCK_END				\
		if (se != 0)					\
			__enable_irq();				\
	} while(0)

void ring_init(RingBuffer_t * rb)
{
	ATOMIC_BLOCK_START;

	rb->PutIndex = 0;
	rb->GetIndex = 0;
	
	ATOMIC_BLOCK_END;
}

bool ring_put(RingBuffer_t * rb, uint8_t data)
{
	uint16_t next = rb->PutIndex + 1;
	if (next == rb->Size)
		next = 0;
	if (next != rb->GetIndex)
	{
		rb->Buffer[rb->PutIndex] = data;
		rb->PutIndex = next;
		return true;
	}
	return false;
}

bool ring_available(RingBuffer_t * rb)
{
	return (rb->GetIndex != rb->PutIndex);
}

bool ring_get(RingBuffer_t * rb, uint8_t * data)
{
	uint16_t next = rb->GetIndex;
	if (next != rb->PutIndex)
	{
		*data = rb->Buffer[next];
		next++;
		if (next == rb->Size)
			next = 0;
		rb->GetIndex = next;
		return true;
	}
	return false;
}

