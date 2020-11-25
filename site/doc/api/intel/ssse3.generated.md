---
title: Intel Ssse3 Intrinsics
url: /doc/api/intel/ssse3/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Ssse3` features.

{{end}}


## mm_abs_epi16

`mm_abs_epi16`

Compute the absolute value of packed 16-bit integers in "a", and store the unsigned results in "dst".

__m128i _mm_abs_epi16 (__m128i a)
PABSW xmm, xmm/m128

## mm_abs_epi32

`mm_abs_epi32`

Compute the absolute value of packed 32-bit integers in "a", and store the unsigned results in "dst".

__m128i _mm_abs_epi32 (__m128i a)
PABSD xmm, xmm/m128

## mm_abs_epi8

`mm_abs_epi8`

Compute the absolute value of packed 8-bit integers in "a", and store the unsigned results in "dst".

__m128i _mm_abs_epi8 (__m128i a)
PABSB xmm, xmm/m128

## mm_alignr_epi8

`mm_alignr_epi8`

Concatenate 16-byte blocks in "a" and "b" into a 32-byte temporary result, shift the result right by "count" bytes, and store the low 16 bytes in "dst".

__m128i _mm_alignr_epi8 (__m128i a, __m128i b, int count)
PALIGNR xmm, xmm/m128, imm8

## mm_hadd_epi16

`mm_hadd_epi16`

Horizontally add adjacent pairs of 16-bit integers in "a" and "b", and pack the signed 16-bit results in "dst".

__m128i _mm_hadd_epi16 (__m128i a, __m128i b)
PHADDW xmm, xmm/m128

## mm_hadd_epi32

`mm_hadd_epi32`

Horizontally add adjacent pairs of 32-bit integers in "a" and "b", and pack the signed 32-bit results in "dst".

__m128i _mm_hadd_epi32 (__m128i a, __m128i b)
PHADDD xmm, xmm/m128

## mm_hadds_epi16

`mm_hadds_epi16`

Horizontally add adjacent pairs of 16-bit integers in "a" and "b" using saturation, and pack the signed 16-bit results in "dst".

__m128i _mm_hadds_epi16 (__m128i a, __m128i b)
PHADDSW xmm, xmm/m128

## mm_hsub_epi16

`mm_hsub_epi16`

Horizontally subtract adjacent pairs of 16-bit integers in "a" and "b", and pack the signed 16-bit results in "dst".

__m128i _mm_hsub_epi16 (__m128i a, __m128i b)
PHSUBW xmm, xmm/m128

## mm_hsub_epi32

`mm_hsub_epi32`

Horizontally subtract adjacent pairs of 32-bit integers in "a" and "b", and pack the signed 32-bit results in "dst".

__m128i _mm_hsub_epi32 (__m128i a, __m128i b)
PHSUBD xmm, xmm/m128

## mm_hsubs_epi16

`mm_hsubs_epi16`

Horizontally subtract adjacent pairs of 16-bit integers in "a" and "b" using saturation, and pack the signed 16-bit results in "dst".

__m128i _mm_hsubs_epi16 (__m128i a, __m128i b)
PHSUBSW xmm, xmm/m128

## mm_maddubs_epi16

`mm_maddubs_epi16`

Vertically multiply each unsigned 8-bit integer from "a" with the corresponding signed 8-bit integer from "b", producing intermediate signed 16-bit integers. Horizontally add adjacent pairs of intermediate signed 16-bit integers, and pack the saturated results in "dst".

__m128i _mm_maddubs_epi16 (__m128i a, __m128i b)
PMADDUBSW xmm, xmm/m128

## mm_mulhrs_epi16

`mm_mulhrs_epi16`

Multiply packed 16-bit integers in "a" and "b", producing intermediate signed 32-bit integers. Truncate each intermediate integer to the 18 most significant bits, round by adding 1, and store bits [16:1] to "dst".

__m128i _mm_mulhrs_epi16 (__m128i a, __m128i b)
PMULHRSW xmm, xmm/m128

## mm_shuffle_epi8

`mm_shuffle_epi8`

Shuffle packed 8-bit integers in "a" according to shuffle control mask in the corresponding 8-bit element of "b", and store the results in "dst".

__m128i _mm_shuffle_epi8 (__m128i a, __m128i b)
PSHUFB xmm, xmm/m128

## mm_sign_epi16

`mm_sign_epi16`

Negate packed 16-bit integers in "a" when the corresponding signed 16-bit integer in "b" is negative, and store the results in "dst". Element in "dst" are zeroed out when the corresponding element in "b" is zero.

__m128i _mm_sign_epi16 (__m128i a, __m128i b)
PSIGNW xmm, xmm/m128

## mm_sign_epi32

`mm_sign_epi32`

Negate packed 32-bit integers in "a" when the corresponding signed 32-bit integer in "b" is negative, and store the results in "dst". Element in "dst" are zeroed out when the corresponding element in "b" is zero.

__m128i _mm_sign_epi32 (__m128i a, __m128i b)
PSIGND xmm, xmm/m128

## mm_sign_epi8

`mm_sign_epi8`

Negate packed 8-bit integers in "a" when the corresponding signed 8-bit integer in "b" is negative, and store the results in "dst". Element in "dst" are zeroed out when the corresponding element in "b" is zero.

__m128i _mm_sign_epi8 (__m128i a, __m128i b)
PSIGNB xmm, xmm/m128
