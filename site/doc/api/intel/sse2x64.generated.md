---
title: Intel Sse2X64 Intrinsics
url: /doc/api/intel/sse2x64/
---

## mm_cvtsd_si64

`mm_cvtsd_si64`

Convert the lower double-precision (64-bit) floating-point element in "a" to a 64-bit integer, and store the result in "dst".

__int64 _mm_cvtsd_si64 (__m128d a)
CVTSD2SI r64, xmm/m64

## mm_cvtsi128_si64

`mm_cvtsi128_si64`

Copy the lower 64-bit integer in "a" to "dst".

__int64 _mm_cvtsi128_si64 (__m128i a)
MOVQ reg/m64, xmm

## mm_cvtsi64_sd

`mm_cvtsi64_sd`

Convert the 64-bit integer "b" to a double-precision (64-bit) floating-point element, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cvtsi64_sd (__m128d a, __int64 b)
CVTSI2SD xmm, reg/m64

## mm_cvtsi64_si128

`mm_cvtsi64_si128`

Copy 64-bit integer "a" to the lower element of "dst", and zero the upper element.

__m128i _mm_cvtsi64_si128 (__int64 a)
MOVQ xmm, reg/m64

## mm_cvttsd_si64

`mm_cvttsd_si64`

Convert the lower double-precision (64-bit) floating-point element in "a" to a 64-bit integer with truncation, and store the result in "dst".

__int64 _mm_cvttsd_si64 (__m128d a)
CVTTSD2SI reg, xmm/m64

## mm_stream_si64

`mm_stream_si64`

Store 64-bit integer "a" into memory using a non-temporal hint to minimize cache pollution. If the cache line containing address "mem_addr" is already in the cache, the cache will be updated.

void _mm_stream_si64(__int64 *p, __int64 a)
MOVNTI m64, r64
