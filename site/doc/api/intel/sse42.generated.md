---
title: Intel Sse42 Intrinsics
url: /doc/api/intel/sse42/
---

## mm_cmpgt_epi64

`mm_cmpgt_epi64`

Compare packed 64-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m128i _mm_cmpgt_epi64 (__m128i a, __m128i b)
PCMPGTQ xmm, xmm/m128

## mm_crc32_u16

`mm_crc32_u16`

Starting with the initial value in "crc", accumulates a CRC32 value for unsigned 16-bit integer "v", and stores the result in "dst".

unsigned int _mm_crc32_u16 (unsigned int crc, unsigned short v)
CRC32 reg, reg/m16

## mm_crc32_u32

`mm_crc32_u32`

Starting with the initial value in "crc", accumulates a CRC32 value for unsigned 32-bit integer "v", and stores the result in "dst".

unsigned int _mm_crc32_u32 (unsigned int crc, unsigned int v)
CRC32 reg, reg/m32

## mm_crc32_u8

`mm_crc32_u8`

Starting with the initial value in "crc", accumulates a CRC32 value for unsigned 8-bit integer "v", and stores the result in "dst".

unsigned int _mm_crc32_u8 (unsigned int crc, unsigned char v)
CRC32 reg, reg/m8
