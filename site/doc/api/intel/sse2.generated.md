---
title: Intel Sse2 Intrinsics
url: /doc/api/intel/sse2/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Sse2` features.

{{end}}


## mm_add_epi16

`mm_add_epi16`

Add packed 16-bit integers in "a" and "b", and store the results in "dst".

__m128i _mm_add_epi16 (__m128i a,  __m128i b)
PADDW xmm, xmm/m128

## mm_add_epi32

`mm_add_epi32`

Add packed 32-bit integers in "a" and "b", and store the results in "dst".

__m128i _mm_add_epi32 (__m128i a,  __m128i b)
PADDD xmm, xmm/m128

## mm_add_epi64

`mm_add_epi64`

Add packed 64-bit integers in "a" and "b", and store the results in "dst".

__m128i _mm_add_epi64 (__m128i a,  __m128i b)
PADDQ xmm, xmm/m128

## mm_add_epi8

`mm_add_epi8`

Add packed 8-bit integers in "a" and "b", and store the results in "dst".

__m128i _mm_add_epi8 (__m128i a,  __m128i b)
PADDB xmm, xmm/m128

## mm_add_pd

`mm_add_pd`

Add packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128d _mm_add_pd (__m128d a,  __m128d b)
ADDPD xmm, xmm/m128

## mm_add_sd

`mm_add_sd`

Add the lower double-precision (64-bit) floating-point element in "a" and "b", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_add_sd (__m128d a,  __m128d b)
ADDSD xmm, xmm/m64

## mm_adds_epi16

`mm_adds_epi16`

Add packed 16-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m128i _mm_adds_epi16 (__m128i a,  __m128i b)
PADDSW xmm, xmm/m128

## mm_adds_epi8

`mm_adds_epi8`

Add packed 8-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m128i _mm_adds_epi8 (__m128i a,  __m128i b)
PADDSB xmm, xmm/m128

## mm_adds_epu16

`mm_adds_epu16`

Add packed unsigned 16-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m128i _mm_adds_epu16 (__m128i a,  __m128i b)
PADDUSW xmm, xmm/m128

## mm_adds_epu8

`mm_adds_epu8`

Add packed unsigned 8-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m128i _mm_adds_epu8 (__m128i a,  __m128i b)
PADDUSB xmm, xmm/m128

## mm_and_pd

`mm_and_pd`

Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128d _mm_and_pd (__m128d a, __m128d b)
ANDPD xmm, xmm/m128

## mm_and_si128

`mm_and_si128`

Compute the bitwise AND of 128 bits (representing integer data) in "a" and "b", and store the result in "dst".

__m128i _mm_and_si128 (__m128i a,  __m128i b)
PAND xmm, xmm/m128

## mm_andnot_pd

`mm_andnot_pd`

Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in "a" and then AND with "b", and store the results in "dst".

__m128d _mm_andnot_pd (__m128d a, __m128d b)
ADDNPD xmm, xmm/m128

## mm_andnot_si128

`mm_andnot_si128`

Compute the bitwise NOT of 128 bits (representing integer data) in "a" and then AND with "b", and store the result in "dst".

__m128i _mm_andnot_si128 (__m128i a,  __m128i b)
PANDN xmm, xmm/m128

## mm_avg_epu16

`mm_avg_epu16`

Average packed unsigned 16-bit integers in "a" and "b", and store the results in "dst".

__m128i _mm_avg_epu16 (__m128i a,  __m128i b)
PAVGW xmm, xmm/m128

## mm_avg_epu8

`mm_avg_epu8`

Average packed unsigned 8-bit integers in "a" and "b", and store the results in "dst".

__m128i _mm_avg_epu8 (__m128i a,  __m128i b)
PAVGB xmm, xmm/m128

## mm_bslli_si128

`mm_bslli_si128`

Shift "a" left by "imm8" bytes while shifting in zeros, and store the results in "dst".

__m128i _mm_bslli_si128 (__m128i a, int imm8)
PSLLDQ xmm, imm8

## mm_bsrli_si128

`mm_bsrli_si128`

Shift "a" right by "imm8" bytes while shifting in zeros, and store the results in "dst".

__m128i _mm_bsrli_si128 (__m128i a, int imm8)
PSRLDQ xmm, imm8

## mm_cmpeq_epi16

`mm_cmpeq_epi16`

Compare packed 16-bit integers in "a" and "b" for equality, and store the results in "dst".

__m128i _mm_cmpeq_epi16 (__m128i a,  __m128i b)
PCMPEQW xmm, xmm/m128

## mm_cmpeq_epi32

`mm_cmpeq_epi32`

Compare packed 32-bit integers in "a" and "b" for equality, and store the results in "dst".

__m128i _mm_cmpeq_epi32 (__m128i a,  __m128i b)
PCMPEQD xmm, xmm/m128

## mm_cmpeq_epi8

`mm_cmpeq_epi8`

Compare packed 8-bit integers in "a" and "b" for equality, and store the results in "dst".

__m128i _mm_cmpeq_epi8 (__m128i a,  __m128i b)
PCMPEQB xmm, xmm/m128

## mm_cmpeq_pd

`mm_cmpeq_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for equality, and store the results in "dst".

__m128d _mm_cmpeq_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(0)

## mm_cmpeq_sd

`mm_cmpeq_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for equality, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpeq_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(0)

## mm_cmpge_pd

`mm_cmpge_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for greater-than-or-equal, and store the results in "dst".

__m128d _mm_cmpge_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(5)

## mm_cmpge_sd

`mm_cmpge_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for greater-than-or-equal, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpge_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(5)

## mm_cmpgt_epi16

`mm_cmpgt_epi16`

Compare packed 16-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m128i _mm_cmpgt_epi16 (__m128i a,  __m128i b)
PCMPGTW xmm, xmm/m128

## mm_cmpgt_epi32

`mm_cmpgt_epi32`

Compare packed 32-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m128i _mm_cmpgt_epi32 (__m128i a,  __m128i b)
PCMPGTD xmm, xmm/m128

## mm_cmpgt_epi8

`mm_cmpgt_epi8`

Compare packed 8-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m128i _mm_cmpgt_epi8 (__m128i a,  __m128i b)
PCMPGTB xmm, xmm/m128

## mm_cmpgt_pd

`mm_cmpgt_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for greater-than, and store the results in "dst".

__m128d _mm_cmpgt_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(6)

## mm_cmpgt_sd

`mm_cmpgt_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for greater-than, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpgt_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(6)

## mm_cmple_pd

`mm_cmple_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for less-than-or-equal, and store the results in "dst".

__m128d _mm_cmple_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(2)

## mm_cmple_sd

`mm_cmple_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for less-than-or-equal, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmple_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(2)

## mm_cmplt_epi16

`mm_cmplt_epi16`

Compare packed 16-bit integers in "a" and "b" for less-than, and store the results in "dst". Note: This intrinsic emits the pcmpgtw instruction with the order of the operands switched.

__m128i _mm_cmplt_epi16 (__m128i a,  __m128i b)
PCMPGTW xmm, xmm/m128

## mm_cmplt_epi32

`mm_cmplt_epi32`

Compare packed 32-bit integers in "a" and "b" for less-than, and store the results in "dst". Note: This intrinsic emits the pcmpgtd instruction with the order of the operands switched.

__m128i _mm_cmplt_epi32 (__m128i a,  __m128i b)
PCMPGTD xmm, xmm/m128

## mm_cmplt_epi8

`mm_cmplt_epi8`

Compare packed 8-bit integers in "a" and "b" for less-than, and store the results in "dst". Note: This intrinsic emits the pcmpgtb instruction with the order of the operands switched.

__m128i _mm_cmplt_epi8 (__m128i a,  __m128i b)
PCMPGTB xmm, xmm/m128

## mm_cmplt_pd

`mm_cmplt_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for less-than, and store the results in "dst".

__m128d _mm_cmplt_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(1)

## mm_cmplt_sd

`mm_cmplt_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for less-than, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmplt_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(1)

## mm_cmpneq_pd

`mm_cmpneq_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for not-equal, and store the results in "dst".

__m128d _mm_cmpneq_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(4)

## mm_cmpneq_sd

`mm_cmpneq_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for not-equal, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpneq_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(4)

## mm_cmpnge_pd

`mm_cmpnge_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for not-greater-than-or-equal, and store the results in "dst".

__m128d _mm_cmpnge_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(1)

## mm_cmpnge_sd

`mm_cmpnge_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for not-greater-than-or-equal, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpnge_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(1)

## mm_cmpngt_pd

`mm_cmpngt_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for not-greater-than, and store the results in "dst".

__m128d _mm_cmpngt_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(2)

## mm_cmpngt_sd

`mm_cmpngt_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for not-greater-than, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpngt_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(2)

## mm_cmpnle_pd

`mm_cmpnle_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for not-less-than-or-equal, and store the results in "dst".

__m128d _mm_cmpnle_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(6)

## mm_cmpnle_sd

`mm_cmpnle_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for not-less-than-or-equal, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpnle_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(6)

## mm_cmpnlt_pd

`mm_cmpnlt_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" for not-less-than, and store the results in "dst".

__m128d _mm_cmpnlt_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(5)

## mm_cmpnlt_sd

`mm_cmpnlt_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" for not-less-than, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpnlt_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(5)

## mm_cmpord_pd

`mm_cmpord_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" to see if neither is NaN, and store the results in "dst".

__m128d _mm_cmpord_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(7)

## mm_cmpord_sd

`mm_cmpord_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" to see if neither is NaN, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpord_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(7)

## mm_cmpunord_pd

`mm_cmpunord_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" to see if either is NaN, and store the results in "dst".

__m128d _mm_cmpunord_pd (__m128d a,  __m128d b)
CMPPD xmm, xmm/m128, imm8(3)

## mm_cmpunord_sd

`mm_cmpunord_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b" to see if either is NaN, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmpunord_sd (__m128d a,  __m128d b)
CMPSD xmm, xmm/m64, imm8(3)

## mm_comieq_sd

`mm_comieq_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for equality, and return the boolean result (0 or 1).

int _mm_comieq_sd (__m128d a, __m128d b)
COMISD xmm, xmm/m64

## mm_comige_sd

`mm_comige_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for greater-than-or-equal, and return the boolean result (0 or 1).

int _mm_comige_sd (__m128d a, __m128d b)
COMISD xmm, xmm/m64

## mm_comigt_sd

`mm_comigt_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for greater-than, and return the boolean result (0 or 1).

int _mm_comigt_sd (__m128d a, __m128d b)
COMISD xmm, xmm/m64

## mm_comile_sd

`mm_comile_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for less-than-or-equal, and return the boolean result (0 or 1).

int _mm_comile_sd (__m128d a, __m128d b)
COMISD xmm, xmm/m64

## mm_comilt_sd

`mm_comilt_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for less-than, and return the boolean result (0 or 1).

int _mm_comilt_sd (__m128d a, __m128d b)
COMISD xmm, xmm/m64

## mm_comineq_sd

`mm_comineq_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for not-equal, and return the boolean result (0 or 1).

int _mm_comineq_sd (__m128d a, __m128d b)
COMISD xmm, xmm/m64

## mm_cvtepi32_pd

`mm_cvtepi32_pd`

Convert packed 32-bit integers in "a" to packed double-precision (64-bit) floating-point elements, and store the results in "dst".

__m128d _mm_cvtepi32_pd (__m128i a)
CVTDQ2PD xmm, xmm/m128

## mm_cvtepi32_ps

`mm_cvtepi32_ps`

Convert packed 32-bit integers in "a" to packed single-precision (32-bit) floating-point elements, and store the results in "dst".

__m128 _mm_cvtepi32_ps (__m128i a)
CVTDQ2PS xmm, xmm/m128

## mm_cvtpd_epi32

`mm_cvtpd_epi32`

Convert packed double-precision (64-bit) floating-point elements in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm_cvtpd_epi32 (__m128d a)
CVTPD2DQ xmm, xmm/m128

## mm_cvtpd_ps

`mm_cvtpd_ps`

Convert packed double-precision (64-bit) floating-point elements in "a" to packed single-precision (32-bit) floating-point elements, and store the results in "dst".

__m128 _mm_cvtpd_ps (__m128d a)
CVTPD2PS xmm, xmm/m128

## mm_cvtps_epi32

`mm_cvtps_epi32`

Convert packed single-precision (32-bit) floating-point elements in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm_cvtps_epi32 (__m128 a)
CVTPS2DQ xmm, xmm/m128

## mm_cvtps_pd

`mm_cvtps_pd`

Convert packed single-precision (32-bit) floating-point elements in "a" to packed double-precision (64-bit) floating-point elements, and store the results in "dst".

__m128d _mm_cvtps_pd (__m128 a)
CVTPS2PD xmm, xmm/m128

## mm_cvtsd_si32

`mm_cvtsd_si32`

Convert the lower double-precision (64-bit) floating-point element in "a" to a 32-bit integer, and store the result in "dst".

int _mm_cvtsd_si32 (__m128d a)
CVTSD2SI r32, xmm/m64

## mm_cvtsd_ss

`mm_cvtsd_ss`

Convert the lower double-precision (64-bit) floating-point element in "b" to a single-precision (32-bit) floating-point element, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128 _mm_cvtsd_ss (__m128 a, __m128d b)
CVTSD2SS xmm, xmm/m64

## mm_cvtsi128_si32

`mm_cvtsi128_si32`

Copy the lower 32-bit integer in "a" to "dst".

int _mm_cvtsi128_si32 (__m128i a)
MOVD reg/m32, xmm

## mm_cvtsi32_sd

`mm_cvtsi32_sd`

Convert the 32-bit integer "b" to a double-precision (64-bit) floating-point element, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cvtsi32_sd (__m128d a, int b)
CVTSI2SD xmm, reg/m32

## mm_cvtsi32_si128

`mm_cvtsi32_si128`

Copy 32-bit integer "a" to the lower elements of "dst", and zero the upper elements of "dst".

__m128i _mm_cvtsi32_si128 (int a)
MOVD xmm, reg/m32

## mm_cvtss_sd

`mm_cvtss_sd`

Convert the lower single-precision (32-bit) floating-point element in "b" to a double-precision (64-bit) floating-point element, store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cvtss_sd (__m128d a, __m128 b)
CVTSS2SD xmm, xmm/m32

## mm_cvttpd_epi32

`mm_cvttpd_epi32`

Convert packed double-precision (64-bit) floating-point elements in "a" to packed 32-bit integers with truncation, and store the results in "dst".

__m128i _mm_cvttpd_epi32 (__m128d a)
CVTTPD2DQ xmm, xmm/m128

## mm_cvttps_epi32

`mm_cvttps_epi32`

Convert packed single-precision (32-bit) floating-point elements in "a" to packed 32-bit integers with truncation, and store the results in "dst".

__m128i _mm_cvttps_epi32 (__m128 a)
CVTTPS2DQ xmm, xmm/m128

## mm_cvttsd_si32

`mm_cvttsd_si32`

Convert the lower double-precision (64-bit) floating-point element in "a" to a 32-bit integer with truncation, and store the result in "dst".

int _mm_cvttsd_si32 (__m128d a)
CVTTSD2SI reg, xmm/m64

## mm_div_pd

`mm_div_pd`

Divide packed double-precision (64-bit) floating-point elements in "a" by packed elements in "b", and store the results in "dst".

__m128d _mm_div_pd (__m128d a,  __m128d b)
DIVPD xmm, xmm/m128

## mm_div_sd

`mm_div_sd`

Divide the lower double-precision (64-bit) floating-point element in "a" by the lower double-precision (64-bit) floating-point element in "b", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_div_sd (__m128d a,  __m128d b)
DIVSD xmm, xmm/m64

## mm_extract_epi16

`mm_extract_epi16`

Extract a 16-bit integer from "a", selected with "imm8", and store the result in the lower element of "dst".

int _mm_extract_epi16 (__m128i a,  int immediate)
PEXTRW reg, xmm, imm8

## mm_insert_epi16

`mm_insert_epi16`

Copy "a" to "dst", and insert the 16-bit integer "i" into "dst" at the location specified by "imm8".

__m128i _mm_insert_epi16 (__m128i a,  int i, int immediate)
PINSRW xmm, reg/m16, imm8

## mm_load_pd

`mm_load_pd`

Load 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) from memory into "dst".
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

__m128d _mm_load_pd (double const* mem_address)
MOVAPD xmm, m128

## mm_load_sd

`mm_load_sd`

Load a double-precision (64-bit) floating-point element from memory into the lower of "dst", and zero the upper element. "mem_addr" does not need to be aligned on any particular boundary.

__m128d _mm_load_sd (double const* mem_address)
MOVSD xmm, m64

## mm_load_si128

`mm_load_si128`

Load 128-bits of integer data from memory into "dst". 
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

__m128i _mm_load_si128 (__m128i const* mem_address)
MOVDQA xmm, m128

## mm_loadh_pd

`mm_loadh_pd`

Load a double-precision (64-bit) floating-point element from memory into the upper element of "dst", and copy the lower element from "a" to "dst". "mem_addr" does not need to be aligned on any particular boundary.

__m128d _mm_loadh_pd (__m128d a, double const* mem_addr)
MOVHPD xmm, m64

## mm_loadl_epi32

`mm_loadl_epi32`

__m128i _mm_loadl_epi32 (__m128i const* mem_addr)
MOVD xmm, reg/m32

## mm_loadl_epi64

`mm_loadl_epi64`

Load 64-bit integer from memory into the first element of "dst".

__m128i _mm_loadl_epi64 (__m128i const* mem_addr)
MOVQ xmm, reg/m64

## mm_loadl_pd

`mm_loadl_pd`

Load a double-precision (64-bit) floating-point element from memory into the lower element of "dst", and copy the upper element from "a" to "dst". "mem_addr" does not need to be aligned on any particular boundary.

__m128d _mm_loadl_pd (__m128d a, double const* mem_addr)
MOVLPD xmm, m64

## mm_loadu_pd

`mm_loadu_pd`

Load 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) from memory into "dst".
	"mem_addr" does not need to be aligned on any particular boundary.

__m128d _mm_loadu_pd (double const* mem_address)
MOVUPD xmm, m128

## mm_loadu_si128

`mm_loadu_si128`

Load 128-bits of integer data from memory into "dst".
	"mem_addr" does not need to be aligned on any particular boundary.

__m128i _mm_loadu_si128 (__m128i const* mem_address)
MOVDQU xmm, m128

## mm_madd_epi16

`mm_madd_epi16`

Multiply packed signed 16-bit integers in "a" and "b", producing intermediate signed 32-bit integers. Horizontally add adjacent pairs of intermediate 32-bit integers, and pack the results in "dst".

__m128i _mm_madd_epi16 (__m128i a,  __m128i b)
PMADDWD xmm, xmm/m128

## mm_maskmoveu_si128

`mm_maskmoveu_si128`

Conditionally store 8-bit integer elements from "a" into memory using "mask" (elements are not stored when the highest bit is not set in the corresponding element) and a non-temporal memory hint. "mem_addr" does not need to be aligned on any particular boundary.

void _mm_maskmoveu_si128 (__m128i a,  __m128i mask, char* mem_address)
MASKMOVDQU xmm, xmm

## mm_max_epi16

`mm_max_epi16`

Compare packed 16-bit integers in "a" and "b", and store packed maximum values in "dst".

__m128i _mm_max_epi16 (__m128i a,  __m128i b)
PMAXSW xmm, xmm/m128

## mm_max_epu8

`mm_max_epu8`

Compare packed unsigned 8-bit integers in "a" and "b", and store packed maximum values in "dst".

__m128i _mm_max_epu8 (__m128i a,  __m128i b)
PMAXUB xmm, xmm/m128

## mm_max_pd

`mm_max_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b", and store packed maximum values in "dst".

__m128d _mm_max_pd (__m128d a,  __m128d b)
MAXPD xmm, xmm/m128

## mm_max_sd

`mm_max_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b", store the maximum value in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_max_sd (__m128d a,  __m128d b)
MAXSD xmm, xmm/m64

## mm_min_epi16

`mm_min_epi16`

Compare packed 16-bit integers in "a" and "b", and store packed minimum values in "dst".

__m128i _mm_min_epi16 (__m128i a,  __m128i b)
PMINSW xmm, xmm/m128

## mm_min_epu8

`mm_min_epu8`

Compare packed unsigned 8-bit integers in "a" and "b", and store packed minimum values in "dst".

__m128i _mm_min_epu8 (__m128i a,  __m128i b)
PMINUB xmm, xmm/m128

## mm_min_pd

`mm_min_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b", and store packed minimum values in "dst".

__m128d _mm_min_pd (__m128d a,  __m128d b)
MINPD xmm, xmm/m128

## mm_min_sd

`mm_min_sd`

Compare the lower double-precision (64-bit) floating-point elements in "a" and "b", store the minimum value in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_min_sd (__m128d a,  __m128d b)
MINSD xmm, xmm/m64

## mm_move_epi64

`mm_move_epi64`

Copy the lower 64-bit integer in "a" to the lower element of "dst", and zero the upper element.

__m128i _mm_move_epi64 (__m128i a)
MOVQ xmm, xmm

## mm_move_sd

`mm_move_sd`

Move the lower double-precision (64-bit) floating-point element from "b" to the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_move_sd (__m128d a, __m128d b)
MOVSD xmm, xmm

## mm_movemask_epi8

`mm_movemask_epi8`

Create mask from the most significant bit of each 8-bit element in "a", and store the result in "dst".

int _mm_movemask_epi8 (__m128i a)
PMOVMSKB reg, xmm

## mm_movemask_pd

`mm_movemask_pd`

Set each bit of mask "dst" based on the most significant bit of the corresponding packed double-precision (64-bit) floating-point element in "a".

int _mm_movemask_pd (__m128d a)
MOVMSKPD reg, xmm

## mm_mul_epu32

`mm_mul_epu32`

Multiply the low unsigned 32-bit integers from each packed 64-bit element in "a" and "b", and store the unsigned 64-bit results in "dst".

__m128i _mm_mul_epu32 (__m128i a,  __m128i b)
PMULUDQ xmm, xmm/m128

## mm_mul_pd

`mm_mul_pd`

Multiply packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128d _mm_mul_pd (__m128d a,  __m128d b)
MULPD xmm, xmm/m128

## mm_mul_sd

`mm_mul_sd`

Multiply the lower double-precision (64-bit) floating-point element in "a" and "b", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_mul_sd (__m128d a,  __m128d b)
MULSD xmm, xmm/m64

## mm_mulhi_epi16

`mm_mulhi_epi16`

Multiply the packed 16-bit integers in "a" and "b", producing intermediate 32-bit integers, and store the high 16 bits of the intermediate integers in "dst".

__m128i _mm_mulhi_epi16 (__m128i a,  __m128i b)
PMULHW xmm, xmm/m128

## mm_mulhi_epu16

`mm_mulhi_epu16`

Multiply the packed unsigned 16-bit integers in "a" and "b", producing intermediate 32-bit integers, and store the high 16 bits of the intermediate integers in "dst".

__m128i _mm_mulhi_epu16 (__m128i a,  __m128i b)
PMULHUW xmm, xmm/m128

## mm_mullo_epi16

`mm_mullo_epi16`

Multiply the packed 16-bit integers in "a" and "b", producing intermediate 32-bit integers, and store the low 16 bits of the intermediate integers in "dst".

__m128i _mm_mullo_epi16 (__m128i a,  __m128i b)
PMULLW xmm, xmm/m128

## mm_or_pd

`mm_or_pd`

Compute the bitwise OR of packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128d _mm_or_pd (__m128d a,  __m128d b)
ORPD xmm, xmm/m128

## mm_or_si128

`mm_or_si128`

Compute the bitwise OR of 128 bits (representing integer data) in "a" and "b", and store the result in "dst".

__m128i _mm_or_si128 (__m128i a,  __m128i b)
POR xmm, xmm/m128

## mm_packs_epi16

`mm_packs_epi16`

Convert packed 16-bit integers from "a" and "b" to packed 8-bit integers using signed saturation, and store the results in "dst".

__m128i _mm_packs_epi16 (__m128i a,  __m128i b)
PACKSSWB xmm, xmm/m128

## mm_packs_epi32

`mm_packs_epi32`

Convert packed 32-bit integers from "a" and "b" to packed 16-bit integers using signed saturation, and store the results in "dst".

__m128i _mm_packs_epi32 (__m128i a,  __m128i b)
PACKSSDW xmm, xmm/m128

## mm_packus_epi16

`mm_packus_epi16`

Convert packed 16-bit integers from "a" and "b" to packed 8-bit integers using unsigned saturation, and store the results in "dst".

__m128i _mm_packus_epi16 (__m128i a,  __m128i b)
PACKUSWB xmm, xmm/m128

## mm_sad_epu8

`mm_sad_epu8`

Compute the absolute differences of packed unsigned 8-bit integers in "a" and "b", then horizontally sum each consecutive 8 differences to produce two unsigned 16-bit integers, and pack these unsigned 16-bit integers in the low 16 bits of 64-bit elements in "dst".

__m128i _mm_sad_epu8 (__m128i a,  __m128i b)
PSADBW xmm, xmm/m128

## mm_shuffle_epi32

`mm_shuffle_epi32`

Shuffle 32-bit integers in "a" using the control in "imm8", and store the results in "dst".

__m128i _mm_shuffle_epi32 (__m128i a,  int immediate)
PSHUFD xmm, xmm/m128, imm8

## mm_shuffle_pd

`mm_shuffle_pd`

Shuffle double-precision (64-bit) floating-point elements using the control in "imm8", and store the results in "dst".

__m128d _mm_shuffle_pd (__m128d a,  __m128d b, int immediate)
SHUFPD xmm, xmm/m128, imm8

## mm_shufflehi_epi16

`mm_shufflehi_epi16`

Shuffle 16-bit integers in the high 64 bits of "a" using the control in "imm8". Store the results in the high 64 bits of "dst", with the low 64 bits being copied from from "a" to "dst".

__m128i _mm_shufflehi_epi16 (__m128i a,  int immediate)
PSHUFHW xmm, xmm/m128, imm8

## mm_shufflelo_epi16

`mm_shufflelo_epi16`

Shuffle 16-bit integers in the low 64 bits of "a" using the control in "imm8". Store the results in the low 64 bits of "dst", with the high 64 bits being copied from from "a" to "dst".

__m128i _mm_shufflelo_epi16 (__m128i a,  int control)
PSHUFLW xmm, xmm/m128, imm8

## mm_sll_epi16

`mm_sll_epi16`

Shift packed 16-bit integers in "a" left by "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_sll_epi16 (__m128i a, __m128i count)
PSLLW xmm, xmm/m128

## mm_sll_epi32

`mm_sll_epi32`

Shift packed 32-bit integers in "a" left by "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_sll_epi32 (__m128i a, __m128i count)
PSLLD xmm, xmm/m128

## mm_sll_epi64

`mm_sll_epi64`

Shift packed 64-bit integers in "a" left by "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_sll_epi64 (__m128i a, __m128i count)
PSLLQ xmm, xmm/m128

## mm_slli_epi16

`mm_slli_epi16`

Shift packed 16-bit integers in "a" left by "imm8" while shifting in zeros, and store the results in "dst".

__m128i _mm_slli_epi16 (__m128i a,  int immediate)
PSLLW xmm, imm8

## mm_slli_epi32

`mm_slli_epi32`

Shift packed 32-bit integers in "a" left by "imm8" while shifting in zeros, and store the results in "dst".

__m128i _mm_slli_epi32 (__m128i a,  int immediate)
PSLLD xmm, imm8

## mm_slli_epi64

`mm_slli_epi64`

Shift packed 64-bit integers in "a" left by "imm8" while shifting in zeros, and store the results in "dst".

__m128i _mm_slli_epi64 (__m128i a,  int immediate)
PSLLQ xmm, imm8

## mm_sqrt_pd

`mm_sqrt_pd`

Compute the square root of packed double-precision (64-bit) floating-point elements in "a", and store the results in "dst".

__m128d _mm_sqrt_pd (__m128d a)
SQRTPD xmm, xmm/m128

## mm_sqrt_sd

`mm_sqrt_sd`

Compute the square root of the lower double-precision (64-bit) floating-point element in "b", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_sqrt_sd (__m128d a, __m128d b)
SQRTSD xmm, xmm/64

## mm_sqrt_sd1

`mm_sqrt_sd1`

Compute the square root of the lower double-precision (64-bit) floating-point element in "b", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_sqrt_sd (__m128d a)
SQRTSD xmm, xmm/64

## mm_sra_epi16

`mm_sra_epi16`

Shift packed 16-bit integers in "a" right by "count" while shifting in sign bits, and store the results in "dst".

__m128i _mm_sra_epi16 (__m128i a, __m128i count)
PSRAW xmm, xmm/m128

## mm_sra_epi32

`mm_sra_epi32`

Shift packed 32-bit integers in "a" right by "count" while shifting in sign bits, and store the results in "dst".

__m128i _mm_sra_epi32 (__m128i a, __m128i count)
PSRAD xmm, xmm/m128

## mm_srai_epi16

`mm_srai_epi16`

Shift packed 16-bit integers in "a" right by "imm8" while shifting in sign bits, and store the results in "dst".

__m128i _mm_srai_epi16 (__m128i a,  int immediate)
PSRAW xmm, imm8

## mm_srai_epi32

`mm_srai_epi32`

Shift packed 32-bit integers in "a" right by "imm8" while shifting in sign bits, and store the results in "dst".

__m128i _mm_srai_epi32 (__m128i a,  int immediate)
PSRAD xmm, imm8

## mm_srl_epi16

`mm_srl_epi16`

Shift packed 16-bit integers in "a" right by "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_srl_epi16 (__m128i a, __m128i count)
PSRLW xmm, xmm/m128

## mm_srl_epi32

`mm_srl_epi32`

Shift packed 32-bit integers in "a" right by "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_srl_epi32 (__m128i a, __m128i count)
PSRLD xmm, xmm/m128

## mm_srl_epi64

`mm_srl_epi64`

Shift packed 64-bit integers in "a" right by "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_srl_epi64 (__m128i a, __m128i count)
PSRLQ xmm, xmm/m128

## mm_srli_epi16

`mm_srli_epi16`

Shift packed 16-bit integers in "a" right by "imm8" while shifting in zeros, and store the results in "dst".

__m128i _mm_srli_epi16 (__m128i a,  int immediate)
PSRLW xmm, imm8

## mm_srli_epi32

`mm_srli_epi32`

Shift packed 32-bit integers in "a" right by "imm8" while shifting in zeros, and store the results in "dst".

__m128i _mm_srli_epi32 (__m128i a,  int immediate)
PSRLD xmm, imm8

## mm_srli_epi64

`mm_srli_epi64`

Shift packed 64-bit integers in "a" right by "imm8" while shifting in zeros, and store the results in "dst".

__m128i _mm_srli_epi64 (__m128i a,  int immediate)
PSRLQ xmm, imm8

## mm_store_pd

`mm_store_pd`

Store 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) from "a" into memory.
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

void _mm_store_pd (double* mem_addr, __m128d a)
MOVAPD m128, xmm

## mm_store_sd

`mm_store_sd`

Store the lower double-precision (64-bit) floating-point element from "a" into memory. "mem_addr" does not need to be aligned on any particular boundary.

void _mm_store_sd (double* mem_addr, __m128d a)
MOVSD m64, xmm

## mm_store_si128

`mm_store_si128`

Store 128-bits of integer data from "a" into memory. 
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

void _mm_store_si128 (__m128i* mem_addr, __m128i a)
MOVDQA m128, xmm

## mm_storeh_pd

`mm_storeh_pd`

Store the upper double-precision (64-bit) floating-point element from "a" into memory.

void _mm_storeh_pd (double* mem_addr, __m128d a)
MOVHPD m64, xmm

## mm_storel_epi64

`mm_storel_epi64`

Store 64-bit integer from the first element of "a" into memory.

void _mm_storel_epi64 (__m128i* mem_addr, __m128i a)
MOVQ m64, xmm

## mm_storel_pd

`mm_storel_pd`

Store the lower double-precision (64-bit) floating-point element from "a" into memory.

void _mm_storel_pd (double* mem_addr, __m128d a)
MOVLPD m64, xmm

## mm_storeu_pd

`mm_storeu_pd`

Store 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) from "a" into memory.
	"mem_addr" does not need to be aligned on any particular boundary.

void _mm_storeu_pd (double* mem_addr, __m128d a)
MOVUPD m128, xmm

## mm_storeu_si128

`mm_storeu_si128`

Store 128-bits of integer data from "a" into memory.
	"mem_addr" does not need to be aligned on any particular boundary.

void _mm_storeu_si128 (__m128i* mem_addr, __m128i a)
MOVDQU m128, xmm

## mm_storeu_si32

`mm_storeu_si32`

Store 32-bit integer from the first element of "a" into memory. "mem_addr" does not need to be aligned on any particular boundary.

void _mm_storeu_si32 (void* mem_addr, __m128i a) MOVD m32, xmm

## mm_stream_pd

`mm_stream_pd`

Store 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) from "a" into memory using a non-temporal memory hint.
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

void _mm_stream_pd (double* mem_addr, __m128d a)
MOVNTPD m128, xmm

## mm_stream_si128

`mm_stream_si128`

Store 128-bits of integer data from "a" into memory using a non-temporal memory hint. 
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

void _mm_stream_si128 (__m128i* mem_addr, __m128i a)
MOVNTDQ m128, xmm

## mm_stream_si32

`mm_stream_si32`

Store 32-bit integer "a" into memory using a non-temporal hint to minimize cache pollution. If the cache line containing address "mem_addr" is already in the cache, the cache will be updated.

void _mm_stream_si32(int *p, int a)
MOVNTI m32, r32

## mm_sub_epi16

`mm_sub_epi16`

Subtract packed 16-bit integers in "b" from packed 16-bit integers in "a", and store the results in "dst".

__m128i _mm_sub_epi16 (__m128i a,  __m128i b)
PSUBW xmm, xmm/m128

## mm_sub_epi32

`mm_sub_epi32`

Subtract packed 32-bit integers in "b" from packed 32-bit integers in "a", and store the results in "dst".

__m128i _mm_sub_epi32 (__m128i a,  __m128i b)
PSUBD xmm, xmm/m128

## mm_sub_epi64

`mm_sub_epi64`

Subtract packed 64-bit integers in "b" from packed 64-bit integers in "a", and store the results in "dst".

__m128i _mm_sub_epi64 (__m128i a,  __m128i b)
PSUBQ xmm, xmm/m128

## mm_sub_epi8

`mm_sub_epi8`

Subtract packed 8-bit integers in "b" from packed 8-bit integers in "a", and store the results in "dst".

__m128i _mm_sub_epi8 (__m128i a,  __m128i b)
PSUBB xmm, xmm/m128

## mm_sub_pd

`mm_sub_pd`

Subtract packed double-precision (64-bit) floating-point elements in "b" from packed double-precision (64-bit) floating-point elements in "a", and store the results in "dst".

__m128d _mm_sub_pd (__m128d a, __m128d b)
SUBPD xmm, xmm/m128

## mm_sub_sd

`mm_sub_sd`

Subtract the lower double-precision (64-bit) floating-point element in "b" from the lower double-precision (64-bit) floating-point element in "a", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_sub_sd (__m128d a, __m128d b)
SUBSD xmm, xmm/m64

## mm_subs_epi16

`mm_subs_epi16`

Subtract packed 16-bit integers in "b" from packed 16-bit integers in "a" using saturation, and store the results in "dst".

__m128i _mm_subs_epi16 (__m128i a,  __m128i b)
PSUBSW xmm, xmm/m128

## mm_subs_epi8

`mm_subs_epi8`

Subtract packed 8-bit integers in "b" from packed 8-bit integers in "a" using saturation, and store the results in "dst".

__m128i _mm_subs_epi8 (__m128i a,  __m128i b)
PSUBSB xmm, xmm/m128

## mm_subs_epu16

`mm_subs_epu16`

Subtract packed unsigned 16-bit integers in "b" from packed unsigned 16-bit integers in "a" using saturation, and store the results in "dst".

__m128i _mm_subs_epu16 (__m128i a,  __m128i b)
PSUBUSW xmm, xmm/m128

## mm_subs_epu8

`mm_subs_epu8`

Subtract packed unsigned 8-bit integers in "b" from packed unsigned 8-bit integers in "a" using saturation, and store the results in "dst".

__m128i _mm_subs_epu8 (__m128i a,  __m128i b)
PSUBUSB xmm, xmm/m128

## mm_ucomieq_sd

`mm_ucomieq_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for equality, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomieq_sd (__m128d a, __m128d b)
UCOMISD xmm, xmm/m64

## mm_ucomige_sd

`mm_ucomige_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for greater-than-or-equal, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomige_sd (__m128d a, __m128d b)
UCOMISD xmm, xmm/m64

## mm_ucomigt_sd

`mm_ucomigt_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for greater-than, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomigt_sd (__m128d a, __m128d b)
UCOMISD xmm, xmm/m64

## mm_ucomile_sd

`mm_ucomile_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for less-than-or-equal, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomile_sd (__m128d a, __m128d b)
UCOMISD xmm, xmm/m64

## mm_ucomilt_sd

`mm_ucomilt_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for less-than, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomilt_sd (__m128d a, __m128d b)
UCOMISD xmm, xmm/m64

## mm_ucomineq_sd

`mm_ucomineq_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" for not-equal, and return the boolean result (0 or 1). This instruction will not signal an exception for QNaNs.

int _mm_ucomineq_sd (__m128d a, __m128d b)
UCOMISD xmm, xmm/m64

## mm_unpackhi_epi16

`mm_unpackhi_epi16`

Unpack and interleave 16-bit integers from the high half of "a" and "b", and store the results in "dst".

__m128i _mm_unpackhi_epi16 (__m128i a,  __m128i b)
PUNPCKHWD xmm, xmm/m128

## mm_unpackhi_epi32

`mm_unpackhi_epi32`

Unpack and interleave 32-bit integers from the high half of "a" and "b", and store the results in "dst".

__m128i _mm_unpackhi_epi32 (__m128i a,  __m128i b)
PUNPCKHDQ xmm, xmm/m128

## mm_unpackhi_epi64

`mm_unpackhi_epi64`

Unpack and interleave 64-bit integers from the high half of "a" and "b", and store the results in "dst".

__m128i _mm_unpackhi_epi64 (__m128i a,  __m128i b)
PUNPCKHQDQ xmm, xmm/m128

## mm_unpackhi_epi8

`mm_unpackhi_epi8`

Unpack and interleave 8-bit integers from the high half of "a" and "b", and store the results in "dst".

__m128i _mm_unpackhi_epi8 (__m128i a,  __m128i b)
PUNPCKHBW xmm, xmm/m128

## mm_unpackhi_pd

`mm_unpackhi_pd`

Unpack and interleave double-precision (64-bit) floating-point elements from the high half of "a" and "b", and store the results in "dst".

__m128d _mm_unpackhi_pd (__m128d a,  __m128d b)
UNPCKHPD xmm, xmm/m128

## mm_unpacklo_epi16

`mm_unpacklo_epi16`

Unpack and interleave 16-bit integers from the low half of "a" and "b", and store the results in "dst".

__m128i _mm_unpacklo_epi16 (__m128i a,  __m128i b)
PUNPCKLWD xmm, xmm/m128

## mm_unpacklo_epi32

`mm_unpacklo_epi32`

Unpack and interleave 32-bit integers from the low half of "a" and "b", and store the results in "dst".

__m128i _mm_unpacklo_epi32 (__m128i a,  __m128i b)
PUNPCKLDQ xmm, xmm/m128

## mm_unpacklo_epi64

`mm_unpacklo_epi64`

Unpack and interleave 64-bit integers from the low half of "a" and "b", and store the results in "dst".

__m128i _mm_unpacklo_epi64 (__m128i a,  __m128i b)
PUNPCKLQDQ xmm, xmm/m128

## mm_unpacklo_epi8

`mm_unpacklo_epi8`

Unpack and interleave 8-bit integers from the low half of "a" and "b", and store the results in "dst".

__m128i _mm_unpacklo_epi8 (__m128i a,  __m128i b)
PUNPCKLBW xmm, xmm/m128

## mm_unpacklo_pd

`mm_unpacklo_pd`

Unpack and interleave double-precision (64-bit) floating-point elements from the low half of "a" and "b", and store the results in "dst".

__m128d _mm_unpacklo_pd (__m128d a,  __m128d b)
UNPCKLPD xmm, xmm/m128

## mm_xor_pd

`mm_xor_pd`

Compute the bitwise XOR of packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m128d _mm_xor_pd (__m128d a,  __m128d b)
XORPD xmm, xmm/m128

## mm_xor_si128

`mm_xor_si128`

Compute the bitwise XOR of 128 bits (representing integer data) in "a" and "b", and store the result in "dst".

__m128i _mm_xor_si128 (__m128i a,  __m128i b)
PXOR xmm, xmm/m128
