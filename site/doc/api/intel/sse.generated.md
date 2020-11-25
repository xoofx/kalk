---
title: Intel Sse Intrinsics
url: /doc/api/intel/sse/
---

## mm_add_ps

`mm_add_ps`

Add packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128 _mm_add_ps (__m128 a,  __m128 b)
ADDPS xmm, xmm/m128

## mm_add_ss

`mm_add_ss`

Add the lower single-precision (32-bit) floating-point element in "a" and "b", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_add_ss (__m128 a,  __m128 b)
ADDSS xmm, xmm/m32

## mm_and_ps

`mm_and_ps`

Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128 _mm_and_ps (__m128 a, __m128 b)
ANDPS xmm, xmm/m128

## mm_andnot_ps

`mm_andnot_ps`

Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in "a" and then AND with "b", and store the results in "dst".

__m128 _mm_andnot_ps (__m128 a, __m128 b)
ANDNPS xmm, xmm/m128

## mm_cmpeq_ps

`mm_cmpeq_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for equality, and store the results in "dst".

__m128 _mm_cmpeq_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(0)

## mm_cmpeq_ss

`mm_cmpeq_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for equality, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpeq_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(0)

## mm_cmpge_ps

`mm_cmpge_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for greater-than-or-equal, and store the results in "dst".

__m128 _mm_cmpge_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(5)

## mm_cmpge_ss

`mm_cmpge_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for greater-than-or-equal, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpge_ss (__m128 a,  __m128 b)
CMPPS xmm, xmm/m32, imm8(5)

## mm_cmpgt_ps

`mm_cmpgt_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for greater-than, and store the results in "dst".

__m128 _mm_cmpgt_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(6)

## mm_cmpgt_ss

`mm_cmpgt_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for greater-than, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpgt_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(6)

## mm_cmple_ps

`mm_cmple_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for less-than-or-equal, and store the results in "dst".

__m128 _mm_cmple_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(2)

## mm_cmple_ss

`mm_cmple_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for less-than-or-equal, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmple_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(2)

## mm_cmplt_ps

`mm_cmplt_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for less-than, and store the results in "dst".

__m128 _mm_cmplt_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(1)

## mm_cmplt_ss

`mm_cmplt_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for less-than, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmplt_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(1)

## mm_cmpneq_ps

`mm_cmpneq_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for not-equal, and store the results in "dst".

__m128 _mm_cmpneq_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(4)

## mm_cmpneq_ss

`mm_cmpneq_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for not-equal, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpneq_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(4)

## mm_cmpnge_ps

`mm_cmpnge_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for not-greater-than-or-equal, and store the results in "dst".

__m128 _mm_cmpnge_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(1)

## mm_cmpnge_ss

`mm_cmpnge_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for not-greater-than-or-equal, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpnge_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(1)

## mm_cmpngt_ps

`mm_cmpngt_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for not-greater-than, and store the results in "dst".

__m128 _mm_cmpngt_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(2)

## mm_cmpngt_ss

`mm_cmpngt_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for not-greater-than, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpngt_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(2)

## mm_cmpnle_ps

`mm_cmpnle_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for not-less-than-or-equal, and store the results in "dst".

__m128 _mm_cmpnle_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(6)

## mm_cmpnle_ss

`mm_cmpnle_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for not-less-than-or-equal, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpnle_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(6)

## mm_cmpnlt_ps

`mm_cmpnlt_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" for not-less-than, and store the results in "dst".

__m128 _mm_cmpnlt_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(5)

## mm_cmpnlt_ss

`mm_cmpnlt_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" for not-less-than, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpnlt_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(5)

## mm_cmpord_ps

`mm_cmpord_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" to see if neither is NaN, and store the results in "dst".

__m128 _mm_cmpord_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(7)

## mm_cmpord_ss

`mm_cmpord_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" to see if neither is NaN, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpord_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(7)

## mm_cmpunord_ps

`mm_cmpunord_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" to see if either is NaN, and store the results in "dst".

__m128 _mm_cmpunord_ps (__m128 a,  __m128 b)
CMPPS xmm, xmm/m128, imm8(3)

## mm_cmpunord_ss

`mm_cmpunord_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b" to see if either is NaN, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmpunord_ss (__m128 a,  __m128 b)
CMPSS xmm, xmm/m32, imm8(3)

## mm_comieq_ss

`mm_comieq_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for equality, and return the boolean result (0 or 1).

int _mm_comieq_ss (__m128 a, __m128 b)
COMISS xmm, xmm/m32

## mm_comige_ss

`mm_comige_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for greater-than-or-equal, and return the boolean result (0 or 1).

int _mm_comige_ss (__m128 a, __m128 b)
COMISS xmm, xmm/m32

## mm_comigt_ss

`mm_comigt_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for greater-than, and return the boolean result (0 or 1).

int _mm_comigt_ss (__m128 a, __m128 b)
COMISS xmm, xmm/m32

## mm_comile_ss

`mm_comile_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for less-than-or-equal, and return the boolean result (0 or 1).

int _mm_comile_ss (__m128 a, __m128 b)
COMISS xmm, xmm/m32

## mm_comilt_ss

`mm_comilt_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for less-than, and return the boolean result (0 or 1).

int _mm_comilt_ss (__m128 a, __m128 b)
COMISS xmm, xmm/m32

## mm_comineq_ss

`mm_comineq_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for not-equal, and return the boolean result (0 or 1).

int _mm_comineq_ss (__m128 a, __m128 b)
COMISS xmm, xmm/m32

## mm_cvtsi32_ss

`mm_cvtsi32_ss`

Convert the 32-bit integer "b" to a single-precision (32-bit) floating-point element, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cvtsi32_ss (__m128 a, int b)
CVTSI2SS xmm, reg/m32

## mm_cvtss_si32

`mm_cvtss_si32`

Convert the lower single-precision (32-bit) floating-point element in "a" to a 32-bit integer, and store the result in "dst".

int _mm_cvtss_si32 (__m128 a)
CVTSS2SI r32, xmm/m32

## mm_cvttss_si32

`mm_cvttss_si32`

Convert the lower single-precision (32-bit) floating-point element in "a" to a 32-bit integer with truncation, and store the result in "dst".

int _mm_cvttss_si32 (__m128 a)
CVTTSS2SI r32, xmm/m32

## mm_div_ps

`mm_div_ps`

Divide packed single-precision (32-bit) floating-point elements in "a" by packed elements in "b", and store the results in "dst".

__m128 _mm_div_ps (__m128 a,  __m128 b)
DIVPS xmm, xmm/m128

## mm_div_ss

`mm_div_ss`

Divide the lower single-precision (32-bit) floating-point element in "a" by the lower single-precision (32-bit) floating-point element in "b", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_div_ss (__m128 a,  __m128 b)
DIVSS xmm, xmm/m32

## mm_load_ps

`mm_load_ps`

Load 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) from memory into "dst".
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

__m128 _mm_load_ps (float const* mem_address)
MOVAPS xmm, m128

## mm_load_ss

`mm_load_ss`

Load a single-precision (32-bit) floating-point element from memory into the lower of "dst", and zero the upper 3 elements. "mem_addr" does not need to be aligned on any particular boundary.

__m128 _mm_load_ss (float const* mem_address)
MOVSS xmm, m32

## mm_loadh_pi

`mm_loadh_pi`

Load 2 single-precision (32-bit) floating-point elements from memory into the upper 2 elements of "dst", and copy the lower 2 elements from "a" to "dst". "mem_addr" does not need to be aligned on any particular boundary.

__m128 _mm_loadh_pi (__m128 a, __m64 const* mem_addr)
MOVHPS xmm, m64

## mm_loadl_pi

`mm_loadl_pi`

Load 2 single-precision (32-bit) floating-point elements from memory into the lower 2 elements of "dst", and copy the upper 2 elements from "a" to "dst". "mem_addr" does not need to be aligned on any particular boundary.

__m128 _mm_loadl_pi (__m128 a, __m64 const* mem_addr)
MOVLPS xmm, m64

## mm_loadu_ps

`mm_loadu_ps`

Load 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) from memory into "dst".
	"mem_addr" does not need to be aligned on any particular boundary.

__m128 _mm_loadu_ps (float const* mem_address)
MOVUPS xmm, m128

## mm_max_ps

`mm_max_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b", and store packed maximum values in "dst".

__m128 _mm_max_ps (__m128 a,  __m128 b)
MAXPS xmm, xmm/m128

## mm_max_ss

`mm_max_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b", store the maximum value in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128 _mm_max_ss (__m128 a,  __m128 b)
MAXSS xmm, xmm/m32

## mm_min_ps

`mm_min_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b", and store packed minimum values in "dst".

__m128 _mm_min_ps (__m128 a,  __m128 b)
MINPS xmm, xmm/m128

## mm_min_ss

`mm_min_ss`

Compare the lower single-precision (32-bit) floating-point elements in "a" and "b", store the minimum value in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128 _mm_min_ss (__m128 a,  __m128 b)
MINSS xmm, xmm/m32

## mm_move_ss

`mm_move_ss`

Move the lower single-precision (32-bit) floating-point element from "b" to the lower element of "dst", and copy the upper 3 elements from "a" to the upper elements of "dst".

__m128 _mm_move_ss (__m128 a, __m128 b)
MOVSS xmm, xmm

## mm_movehl_ps

`mm_movehl_ps`

Move the upper 2 single-precision (32-bit) floating-point elements from "b" to the lower 2 elements of "dst", and copy the upper 2 elements from "a" to the upper 2 elements of "dst".

__m128 _mm_movehl_ps (__m128 a,  __m128 b)
MOVHLPS xmm, xmm

## mm_movelh_ps

`mm_movelh_ps`

Move the lower 2 single-precision (32-bit) floating-point elements from "b" to the upper 2 elements of "dst", and copy the lower 2 elements from "a" to the lower 2 elements of "dst".

__m128 _mm_movelh_ps (__m128 a,  __m128 b)
MOVLHPS xmm, xmm

## mm_movemask_ps

`mm_movemask_ps`

Set each bit of mask "dst" based on the most significant bit of the corresponding packed single-precision (32-bit) floating-point element in "a".

int _mm_movemask_ps (__m128 a)
MOVMSKPS reg, xmm

## mm_mul_ps

`mm_mul_ps`

Multiply packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128 _mm_mul_ps (__m128 a, __m128 b)
MULPS xmm, xmm/m128

## mm_mul_ss

`mm_mul_ss`

Multiply the lower single-precision (32-bit) floating-point element in "a" and "b", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_mul_ss (__m128 a, __m128 b)
MULPS xmm, xmm/m32

## mm_or_ps

`mm_or_ps`

Compute the bitwise OR of packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128 _mm_or_ps (__m128 a,  __m128 b)
ORPS xmm, xmm/m128

## mm_prefetch0

`mm_prefetch0`

Fetch the line of data from memory that contains address "p" to a location in the cache heirarchy specified by the locality hint "i".

void _mm_prefetch(char* p, int i)
PREFETCHT0 m8

## mm_prefetch1

`mm_prefetch1`

Fetch the line of data from memory that contains address "p" to a location in the cache heirarchy specified by the locality hint "i".

void _mm_prefetch(char* p, int i)
PREFETCHT1 m8

## mm_prefetch2

`mm_prefetch2`

Fetch the line of data from memory that contains address "p" to a location in the cache heirarchy specified by the locality hint "i".

void _mm_prefetch(char* p, int i)
PREFETCHT2 m8

## mm_prefetchnta

`mm_prefetchnta`

Fetch the line of data from memory that contains address "p" to a location in the cache heirarchy specified by the locality hint "i".

void _mm_prefetch(char* p, int i)
PREFETCHNTA m8

## mm_rcp_ps

`mm_rcp_ps`

Compute the approximate reciprocal of packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m128 _mm_rcp_ps (__m128 a)
RCPPS xmm, xmm/m128

## mm_rcp_ss

`mm_rcp_ss`

Compute the approximate reciprocal of the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m128 _mm_rcp_ss (__m128 a, __m128 b)
RCPSS xmm, xmm/m32

## mm_rcp_ss1

`mm_rcp_ss1`

Compute the approximate reciprocal of the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m128 _mm_rcp_ss (__m128 a)
RCPSS xmm, xmm/m32

## mm_rsqrt_ps

`mm_rsqrt_ps`

Compute the approximate reciprocal square root of packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m128 _mm_rsqrt_ps (__m128 a)
RSQRTPS xmm, xmm/m128

## mm_rsqrt_ss

`mm_rsqrt_ss`

Compute the approximate reciprocal square root of the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m128 _mm_rsqrt_ss (__m128 a, __m128 b)
RSQRTSS xmm, xmm/m32

## mm_rsqrt_ss1

`mm_rsqrt_ss1`

Compute the approximate reciprocal square root of the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m128 _mm_rsqrt_ss (__m128 a)
RSQRTSS xmm, xmm/m32

## mm_shuffle_ps

`mm_shuffle_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" using the control in "imm8", and store the results in "dst".

__m128 _mm_shuffle_ps (__m128 a,  __m128 b, unsigned int control)
SHUFPS xmm, xmm/m128, imm8

## mm_sqrt_ps

`mm_sqrt_ps`

Compute the square root of packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst".

__m128 _mm_sqrt_ps (__m128 a)
SQRTPS xmm, xmm/m128

## mm_sqrt_ss

`mm_sqrt_ss`

Compute the square root of the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_sqrt_ss (__m128 a, __m128 b)
SQRTSS xmm, xmm/m32

## mm_sqrt_ss1

`mm_sqrt_ss1`

Compute the square root of the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_sqrt_ss (__m128 a)
SQRTSS xmm, xmm/m32

## mm_store_ps

`mm_store_ps`

Store 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) from "a" into memory.
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

void _mm_store_ps (float* mem_addr, __m128 a)
MOVAPS m128, xmm

## mm_store_ss

`mm_store_ss`

Store the lower single-precision (32-bit) floating-point element from "a" into memory. "mem_addr" does not need to be aligned on any particular boundary.

void _mm_store_ss (float* mem_addr, __m128 a)
MOVSS m32, xmm

## mm_storeh_pi

`mm_storeh_pi`

Store the upper 2 single-precision (32-bit) floating-point elements from "a" into memory.

void _mm_storeh_pi (__m64* mem_addr, __m128 a)
MOVHPS m64, xmm

## mm_storel_pi

`mm_storel_pi`

Store the lower 2 single-precision (32-bit) floating-point elements from "a" into memory.

void _mm_storel_pi (__m64* mem_addr, __m128 a)
MOVLPS m64, xmm

## mm_storeu_ps

`mm_storeu_ps`

Store 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) from "a" into memory.
	"mem_addr" does not need to be aligned on any particular boundary.

void _mm_storeu_ps (float* mem_addr, __m128 a)
MOVUPS m128, xmm

## mm_stream_ps

`mm_stream_ps`

Store 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) from "a" into memory using a non-temporal memory hint.
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

void _mm_stream_ps (float* mem_addr, __m128 a)
MOVNTPS m128, xmm

## mm_sub_ps

`mm_sub_ps`

Subtract packed single-precision (32-bit) floating-point elements in "b" from packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst".

__m128d _mm_sub_ps (__m128d a, __m128d b)
SUBPS xmm, xmm/m128

## mm_sub_ss

`mm_sub_ss`

Subtract the lower single-precision (32-bit) floating-point element in "b" from the lower single-precision (32-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_sub_ss (__m128 a, __m128 b)
SUBSS xmm, xmm/m32

## mm_ucomieq_ss

`mm_ucomieq_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for equality, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomieq_ss (__m128 a, __m128 b)
UCOMISS xmm, xmm/m32

## mm_ucomige_ss

`mm_ucomige_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for greater-than-or-equal, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomige_ss (__m128 a, __m128 b)
UCOMISS xmm, xmm/m32

## mm_ucomigt_ss

`mm_ucomigt_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for greater-than, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomigt_ss (__m128 a, __m128 b)
UCOMISS xmm, xmm/m32

## mm_ucomile_ss

`mm_ucomile_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for less-than-or-equal, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomile_ss (__m128 a, __m128 b)
UCOMISS xmm, xmm/m32

## mm_ucomilt_ss

`mm_ucomilt_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for less-than, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomilt_ss (__m128 a, __m128 b)
UCOMISS xmm, xmm/m32

## mm_ucomineq_ss

`mm_ucomineq_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" for not-equal, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomineq_ss (__m128 a, __m128 b)
UCOMISS xmm, xmm/m32

## mm_unpackhi_ps

`mm_unpackhi_ps`

Unpack and interleave single-precision (32-bit) floating-point elements from the high half "a" and "b", and store the results in "dst".

__m128 _mm_unpackhi_ps (__m128 a,  __m128 b)
UNPCKHPS xmm, xmm/m128

## mm_unpacklo_ps

`mm_unpacklo_ps`

Unpack and interleave single-precision (32-bit) floating-point elements from the low half of "a" and "b", and store the results in "dst".

__m128 _mm_unpacklo_ps (__m128 a,  __m128 b)
UNPCKLPS xmm, xmm/m128

## mm_xor_ps

`mm_xor_ps`

Compute the bitwise XOR of packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128 _mm_xor_ps (__m128 a,  __m128 b)
XORPS xmm, xmm/m128
