---
title: Intel Sse41 Intrinsics
url: /doc/api/intel/sse41/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Sse41` features.

{{end}}


## mm_blend_epi16

`mm_blend_epi16`

Blend packed 16-bit integers from "a" and "b" using control mask "imm8", and store the results in "dst".

__m128i _mm_blend_epi16 (__m128i a, __m128i b, const int imm8)
PBLENDW xmm, xmm/m128 imm8

## mm_blend_pd

`mm_blend_pd`

Blend packed double-precision (64-bit) floating-point elements from "a" and "b" using control mask "imm8", and store the results in "dst".

__m128d _mm_blend_pd (__m128d a, __m128d b, const int imm8)
BLENDPD xmm, xmm/m128, imm8

## mm_blend_ps

`mm_blend_ps`

Blend packed single-precision (32-bit) floating-point elements from "a" and "b" using control mask "imm8", and store the results in "dst".

__m128 _mm_blend_ps (__m128 a, __m128 b, const int imm8)
BLENDPS xmm, xmm/m128, imm8

## mm_blendv_epi8

`mm_blendv_epi8`

Blend packed 8-bit integers from "a" and "b" using "mask", and store the results in "dst".

__m128i _mm_blendv_epi8 (__m128i a, __m128i b, __m128i mask)
PBLENDVB xmm, xmm/m128, xmm

## mm_blendv_pd

`mm_blendv_pd`

Blend packed double-precision (64-bit) floating-point elements from "a" and "b" using "mask", and store the results in "dst".

__m128d _mm_blendv_pd (__m128d a, __m128d b, __m128d mask)
BLENDVPD xmm, xmm/m128, xmm0

## mm_blendv_ps

`mm_blendv_ps`

Blend packed single-precision (32-bit) floating-point elements from "a" and "b" using "mask", and store the results in "dst".

__m128 _mm_blendv_ps (__m128 a, __m128 b, __m128 mask)
BLENDVPS xmm, xmm/m128, xmm0

## mm_ceil_pd

`mm_ceil_pd`

Round the packed double-precision (64-bit) floating-point elements in "a" up to an integer value, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_ceil_pd (__m128d a)
ROUNDPD xmm, xmm/m128, imm8(10)

## mm_ceil_ps

`mm_ceil_ps`

Round the packed single-precision (32-bit) floating-point elements in "a" up to an integer value, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_ceil_ps (__m128 a)
ROUNDPS xmm, xmm/m128, imm8(10)

## mm_ceil_sd

`mm_ceil_sd`

Round the lower double-precision (64-bit) floating-point element in "b" up to an integer value, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_ceil_sd (__m128d a, __m128d b)
ROUNDSD xmm, xmm/m128, imm8(10)

## mm_ceil_sd1

`mm_ceil_sd1`

Round the lower double-precision (64-bit) floating-point element in "b" up to an integer value, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_ceil_sd (__m128d a)
ROUNDSD xmm, xmm/m128, imm8(10)

## mm_ceil_ss

`mm_ceil_ss`

Round the lower single-precision (32-bit) floating-point element in "b" up to an integer value, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_ceil_ss (__m128 a, __m128 b)
ROUNDSS xmm, xmm/m128, imm8(10)

## mm_cmpeq_epi64

`mm_cmpeq_epi64`

Compare packed 64-bit integers in "a" and "b" for equality, and store the results in "dst".

__m128i _mm_cmpeq_epi64 (__m128i a, __m128i b)
PCMPEQQ xmm, xmm/m128

## mm_cvtepi16_epi32

`mm_cvtepi16_epi32`

Sign extend packed 16-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm_cvtepi16_epi32 (__m128i a)
PMOVSXWD xmm, xmm/m64

## mm_cvtepi16_epi64

`mm_cvtepi16_epi64`

Sign extend packed 16-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m128i _mm_cvtepi16_epi64 (__m128i a)
PMOVSXWQ xmm, xmm/m32

## mm_cvtepi32_epi64

`mm_cvtepi32_epi64`

Sign extend packed 32-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m128i _mm_cvtepi32_epi64 (__m128i a)
PMOVSXDQ xmm, xmm/m64

## mm_cvtepi8_epi16

`mm_cvtepi8_epi16`

Sign extend packed 8-bit integers in "a" to packed 16-bit integers, and store the results in "dst".

__m128i _mm_cvtepi8_epi16 (__m128i a)
PMOVSXBW xmm, xmm/m64

## mm_cvtepi8_epi32

`mm_cvtepi8_epi32`

Sign extend packed 8-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm_cvtepi8_epi32 (__m128i a)
PMOVSXBD xmm, xmm/m32

## mm_cvtepi8_epi64

`mm_cvtepi8_epi64`

Sign extend packed 8-bit integers in the low 8 bytes of "a" to packed 64-bit integers, and store the results in "dst".

__m128i _mm_cvtepi8_epi64 (__m128i a)
PMOVSXBQ xmm, xmm/m16

## mm_cvtepu16_epi32

`mm_cvtepu16_epi32`

Zero extend packed unsigned 16-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm_cvtepu16_epi32 (__m128i a)
PMOVZXWD xmm, xmm/m64

## mm_cvtepu16_epi64

`mm_cvtepu16_epi64`

Zero extend packed unsigned 16-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m128i _mm_cvtepu16_epi64 (__m128i a)
PMOVZXWQ xmm, xmm/m32

## mm_cvtepu32_epi64

`mm_cvtepu32_epi64`

Zero extend packed unsigned 32-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m128i _mm_cvtepu32_epi64 (__m128i a)
PMOVZXDQ xmm, xmm/m64

## mm_cvtepu8_epi16

`mm_cvtepu8_epi16`

Zero extend packed unsigned 8-bit integers in "a" to packed 16-bit integers, and store the results in "dst".

__m128i _mm_cvtepu8_epi16 (__m128i a)
PMOVZXBW xmm, xmm/m64

## mm_cvtepu8_epi32

`mm_cvtepu8_epi32`

Zero extend packed unsigned 8-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm_cvtepu8_epi32 (__m128i a)
PMOVZXBD xmm, xmm/m32

## mm_cvtepu8_epi64

`mm_cvtepu8_epi64`

Zero extend packed unsigned 8-bit integers in the low 8 byte sof "a" to packed 64-bit integers, and store the results in "dst".

__m128i _mm_cvtepu8_epi64 (__m128i a)
PMOVZXBQ xmm, xmm/m16

## mm_dp_pd

`mm_dp_pd`

Conditionally multiply the packed double-precision (64-bit) floating-point elements in "a" and "b" using the high 4 bits in "imm8", sum the four products, and conditionally store the sum in "dst" using the low 4 bits of "imm8".

__m128d _mm_dp_pd (__m128d a, __m128d b, const int imm8)
DPPD xmm, xmm/m128, imm8

## mm_dp_ps

`mm_dp_ps`

Conditionally multiply the packed single-precision (32-bit) floating-point elements in "a" and "b" using the high 4 bits in "imm8", sum the four products, and conditionally store the sum in "dst" using the low 4 bits of "imm8".

__m128 _mm_dp_ps (__m128 a, __m128 b, const int imm8)
DPPS xmm, xmm/m128, imm8

## mm_extract_epi32

`mm_extract_epi32`

Extract a 32-bit integer from "a", selected with "imm8", and store the result in "dst".

int _mm_extract_epi32 (__m128i a, const int imm8)
PEXTRD reg/m32, xmm, imm8

## mm_extract_epi8

`mm_extract_epi8`

Extract an 8-bit integer from "a", selected with "imm8", and store the result in the lower element of "dst".

int _mm_extract_epi8 (__m128i a, const int imm8)
PEXTRB reg/m8, xmm, imm8

## mm_extract_ps

`mm_extract_ps`

Extract a single-precision (32-bit) floating-point element from "a", selected with "imm8", and store the result in "dst".

int _mm_extract_ps (__m128 a, const int imm8)
EXTRACTPS xmm, xmm/m32, imm8

## mm_floor_pd

`mm_floor_pd`

Round the packed double-precision (64-bit) floating-point elements in "a" down to an integer value, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_floor_pd (__m128d a)
ROUNDPD xmm, xmm/m128, imm8(9)

## mm_floor_ps

`mm_floor_ps`

Round the packed single-precision (32-bit) floating-point elements in "a" down to an integer value, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_floor_ps (__m128 a)
ROUNDPS xmm, xmm/m128, imm8(9)

## mm_floor_sd

`mm_floor_sd`

Round the lower double-precision (64-bit) floating-point element in "b" down to an integer value, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_floor_sd (__m128d a, __m128d b)
ROUNDSD xmm, xmm/m128, imm8(9)

## mm_floor_sd1

`mm_floor_sd1`

Round the lower double-precision (64-bit) floating-point element in "b" down to an integer value, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_floor_sd (__m128d a)
ROUNDSD xmm, xmm/m128, imm8(9)

## mm_floor_ss

`mm_floor_ss`

Round the lower single-precision (32-bit) floating-point element in "b" down to an integer value, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_floor_ss (__m128 a, __m128 b)
ROUNDSS xmm, xmm/m128, imm8(9)

## mm_insert_epi32

`mm_insert_epi32`

Copy "a" to "dst", and insert the 32-bit integer "i" into "dst" at the location specified by "imm8".

__m128i _mm_insert_epi32 (__m128i a, int i, const int imm8)
PINSRD xmm, reg/m32, imm8

## mm_insert_epi8

`mm_insert_epi8`

Copy "a" to "dst", and insert the lower 8-bit integer from "i" into "dst" at the location specified by "imm8".

__m128i _mm_insert_epi8 (__m128i a, int i, const int imm8)
PINSRB xmm, reg/m8, imm8

## mm_insert_ps

`mm_insert_ps`

Copy "a" to "tmp", then insert a single-precision (32-bit) floating-point element from "b" into "tmp" using the control in "imm8". Store "tmp" to "dst" using the mask in "imm8" (elements are zeroed out when the corresponding bit is set).

__m128 _mm_insert_ps (__m128 a, __m128 b, const int imm8)
INSERTPS xmm, xmm/m32, imm8

## mm_max_epi32

`mm_max_epi32`

Compare packed 32-bit integers in "a" and "b", and store packed maximum values in "dst".

__m128i _mm_max_epi32 (__m128i a, __m128i b)
PMAXSD xmm, xmm/m128

## mm_max_epi8

`mm_max_epi8`

Compare packed 8-bit integers in "a" and "b", and store packed maximum values in "dst".

__m128i _mm_max_epi8 (__m128i a, __m128i b)
PMAXSB xmm, xmm/m128

## mm_max_epu16

`mm_max_epu16`

Compare packed unsigned 16-bit integers in "a" and "b", and store packed maximum values in "dst".

__m128i _mm_max_epu16 (__m128i a, __m128i b)
PMAXUW xmm, xmm/m128

## mm_max_epu32

`mm_max_epu32`

Compare packed unsigned 32-bit integers in "a" and "b", and store packed maximum values in "dst".

__m128i _mm_max_epu32 (__m128i a, __m128i b)
PMAXUD xmm, xmm/m128

## mm_min_epi32

`mm_min_epi32`

Compare packed 32-bit integers in "a" and "b", and store packed minimum values in "dst".

__m128i _mm_min_epi32 (__m128i a, __m128i b)
PMINSD xmm, xmm/m128

## mm_min_epi8

`mm_min_epi8`

Compare packed 8-bit integers in "a" and "b", and store packed minimum values in "dst".

__m128i _mm_min_epi8 (__m128i a, __m128i b)
PMINSB xmm, xmm/m128

## mm_min_epu16

`mm_min_epu16`

Compare packed unsigned 16-bit integers in "a" and "b", and store packed minimum values in "dst".

__m128i _mm_min_epu16 (__m128i a, __m128i b)
PMINUW xmm, xmm/m128

## mm_min_epu32

`mm_min_epu32`

Compare packed unsigned 32-bit integers in "a" and "b", and store packed minimum values in "dst".

__m128i _mm_min_epu32 (__m128i a, __m128i b)
PMINUD xmm, xmm/m128

## mm_minpos_epu16

`mm_minpos_epu16`

Horizontally compute the minimum amongst the packed unsigned 16-bit integers in "a", store the minimum and index in "dst", and zero the remaining bits in "dst".

__m128i _mm_minpos_epu16 (__m128i a)
PHMINPOSUW xmm, xmm/m128

## mm_mpsadbw_epu8

`mm_mpsadbw_epu8`

Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in "a" compared to those in "b", and store the 16-bit results in "dst".
	Eight SADs are performed using one quadruplet from "b" and eight quadruplets from "a". One quadruplet is selected from "b" starting at on the offset specified in "imm8". Eight quadruplets are formed from sequential 8-bit integers selected from "a" starting at the offset specified in "imm8".

__m128i _mm_mpsadbw_epu8 (__m128i a, __m128i b, const int imm8)
MPSADBW xmm, xmm/m128, imm8

## mm_mul_epi32

`mm_mul_epi32`

Multiply the low 32-bit integers from each packed 64-bit element in "a" and "b", and store the signed 64-bit results in "dst".

__m128i _mm_mul_epi32 (__m128i a, __m128i b)
PMULDQ xmm, xmm/m128

## mm_mullo_epi32

`mm_mullo_epi32`

Multiply the packed 32-bit integers in "a" and "b", producing intermediate 64-bit integers, and store the low 32 bits of the intermediate integers in "dst".

__m128i _mm_mullo_epi32 (__m128i a, __m128i b)
PMULLD xmm, xmm/m128

## mm_packus_epi32

`mm_packus_epi32`

Convert packed 32-bit integers from "a" and "b" to packed 16-bit integers using unsigned saturation, and store the results in "dst".

__m128i _mm_packus_epi32 (__m128i a, __m128i b)
PACKUSDW xmm, xmm/m128

## mm_round_pd1

`mm_round_pd1`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_round_pd (__m128d a, _MM_FROUND_CUR_DIRECTION); ROUNDPD xmm, xmm/m128, imm8(4)

## mm_round_pd1_to_nearest_integer

`mm_round_pd1_to_nearest_integer`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_round_pd (__m128d a, int rounding)
ROUNDPD xmm, xmm/m128, imm8(8)
            _MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC

## mm_round_pd1_to_negative_infinity

`mm_round_pd1_to_negative_infinity`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_round_pd (__m128d a, _MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC); ROUNDPD xmm, xmm/m128, imm8(9)

## mm_round_pd1_to_positive_infinity

`mm_round_pd1_to_positive_infinity`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_round_pd (__m128d a, _MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC); ROUNDPD xmm, xmm/m128, imm8(10)

## mm_round_pd1_to_zero

`mm_round_pd1_to_zero`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m128d _mm_round_pd (__m128d a, _MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC); ROUNDPD xmm, xmm/m128, imm8(11)

## mm_round_ps

`mm_round_ps`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_round_ps (__m128 a, _MM_FROUND_CUR_DIRECTION); ROUNDPS xmm, xmm/m128, imm8(4)

## mm_round_ps_to_nearest_integer

`mm_round_ps_to_nearest_integer`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_round_ps (__m128 a, int rounding)
ROUNDPS xmm, xmm/m128, imm8(8)
            _MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC

## mm_round_ps_to_negative_infinity

`mm_round_ps_to_negative_infinity`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_round_ps (__m128 a, _MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC); ROUNDPS xmm, xmm/m128, imm8(9)

## mm_round_ps_to_positive_infinity

`mm_round_ps_to_positive_infinity`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_round_ps (__m128 a, _MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC); ROUNDPS xmm, xmm/m128, imm8(10)

## mm_round_ps_to_zero

`mm_round_ps_to_zero`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m128 _mm_round_ps (__m128 a, _MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC); ROUNDPS xmm, xmm/m128, imm8(11)

## mm_round_sd

`mm_round_sd`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, __m128d b, _MM_FROUND_CUR_DIRECTION)
ROUNDSD xmm, xmm/m128, imm8(4)

## mm_round_sd1

`mm_round_sd1`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, _MM_FROUND_CUR_DIRECTION)
ROUNDSD xmm, xmm/m128, imm8(4)

## mm_round_sd1_to_nearest_integer_scalar

`mm_round_sd1_to_nearest_integer_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, _MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(8)

## mm_round_sd1_to_negative_infinity_scalar

`mm_round_sd1_to_negative_infinity_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, _MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(9)

## mm_round_sd1_to_positive_infinity_scalar

`mm_round_sd1_to_positive_infinity_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, _MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(10)

## mm_round_sd1_to_zero_scalar

`mm_round_sd1_to_zero_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, _MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(11)

## mm_round_sd_to_nearest_integer_scalar

`mm_round_sd_to_nearest_integer_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, __m128d b, _MM_FROUND_TO_NEAREST_INT |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(8)

## mm_round_sd_to_negative_infinity_scalar

`mm_round_sd_to_negative_infinity_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, __m128d b, _MM_FROUND_TO_NEG_INF |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(9)

## mm_round_sd_to_positive_infinity_scalar

`mm_round_sd_to_positive_infinity_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, __m128d b, _MM_FROUND_TO_POS_INF |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(10)

## mm_round_sd_to_zero_scalar

`mm_round_sd_to_zero_scalar`

Round the lower double-precision (64-bit) floating-point element in "b" using the "rounding" parameter, store the result as a double-precision floating-point element in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_round_sd (__m128d a, __m128d b, _MM_FROUND_TO_ZERO |_MM_FROUND_NO_EXC)
ROUNDSD xmm, xmm/m128, imm8(11)

## mm_round_ss

`mm_round_ss`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, __m128 b, _MM_FROUND_CUR_DIRECTION)
ROUNDSS xmm, xmm/m128, imm8(4)

## mm_round_ss1

`mm_round_ss1`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, _MM_FROUND_CUR_DIRECTION)
ROUNDSS xmm, xmm/m128, imm8(4)

## mm_round_ss1_to_nearest_integer_scalar

`mm_round_ss1_to_nearest_integer_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(8)

## mm_round_ss1_to_negative_infinity_scalar

`mm_round_ss1_to_negative_infinity_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, _MM_FROUND_TO_NEG_INF | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(9)

## mm_round_ss1_to_positive_infinity_scalar

`mm_round_ss1_to_positive_infinity_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, _MM_FROUND_TO_POS_INF | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(10)

## mm_round_ss1_to_zero_scalar

`mm_round_ss1_to_zero_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(11)

## mm_round_ss_to_nearest_integer_scalar

`mm_round_ss_to_nearest_integer_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, __m128 b, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(8)

## mm_round_ss_to_negative_infinity_scalar

`mm_round_ss_to_negative_infinity_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, __m128 b, _MM_FROUND_TO_NEG_INF | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(9)

## mm_round_ss_to_positive_infinity_scalar

`mm_round_ss_to_positive_infinity_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, __m128 b, _MM_FROUND_TO_POS_INF | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(10)

## mm_round_ss_to_zero_scalar

`mm_round_ss_to_zero_scalar`

Round the lower single-precision (32-bit) floating-point element in "b" using the "rounding" parameter, store the result as a single-precision floating-point element in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_round_ss (__m128 a, __m128 b, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)
ROUNDSS xmm, xmm/m128, imm8(11)

## mm_stream_load_si128

`mm_stream_load_si128`

Load 128-bits of integer data from memory into "dst" using a non-temporal memory hint.
	"mem_addr" must be aligned on a 16-byte boundary or a general-protection exception may be generated.

__m128i _mm_stream_load_si128 (const __m128i* mem_addr)
MOVNTDQA xmm, m128

## mm_testc_si128

`mm_testc_si128`

Compute the bitwise AND of 128 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return the "CF" value.

int _mm_testc_si128 (__m128i a, __m128i b)
PTEST xmm, xmm/m128

## mm_testnzc_si128

`mm_testnzc_si128`

Compute the bitwise AND of 128 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return 1 if both the "ZF" and "CF" values are zero, otherwise return 0.

int _mm_testnzc_si128 (__m128i a, __m128i b)
PTEST xmm, xmm/m128

## mm_testz_si128

`mm_testz_si128`

Compute the bitwise AND of 128 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return the "ZF" value.

int _mm_testz_si128 (__m128i a, __m128i b)
PTEST xmm, xmm/m128
