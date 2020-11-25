---
title: Intel Avx2 Intrinsics
url: /doc/api/intel/avx2/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Avx2` features.

{{end}}


## mm256_abs_epi16

`mm256_abs_epi16`

Compute the absolute value of packed 16-bit integers in "a", and store the unsigned results in "dst".

__m256i _mm256_abs_epi16 (__m256i a)
VPABSW ymm, ymm/m256

## mm256_abs_epi32

`mm256_abs_epi32`

Compute the absolute value of packed 32-bit integers in "a", and store the unsigned results in "dst".

__m256i _mm256_abs_epi32 (__m256i a)
VPABSD ymm, ymm/m256

## mm256_abs_epi8

`mm256_abs_epi8`

Compute the absolute value of packed 8-bit integers in "a", and store the unsigned results in "dst".

__m256i _mm256_abs_epi8 (__m256i a)
VPABSB ymm, ymm/m256

## mm256_add_epi16

`mm256_add_epi16`

Add packed 16-bit integers in "a" and "b", and store the results in "dst".

__m256i _mm256_add_epi16 (__m256i a, __m256i b)
VPADDW ymm, ymm, ymm/m256

## mm256_add_epi32

`mm256_add_epi32`

Add packed 32-bit integers in "a" and "b", and store the results in "dst".

__m256i _mm256_add_epi32 (__m256i a, __m256i b)
VPADDD ymm, ymm, ymm/m256

## mm256_add_epi64

`mm256_add_epi64`

Add packed 64-bit integers in "a" and "b", and store the results in "dst".

__m256i _mm256_add_epi64 (__m256i a, __m256i b)
VPADDQ ymm, ymm, ymm/m256

## mm256_add_epi8

`mm256_add_epi8`

Add packed 8-bit integers in "a" and "b", and store the results in "dst".

__m256i _mm256_add_epi8 (__m256i a, __m256i b)
VPADDB ymm, ymm, ymm/m256

## mm256_adds_epi16

`mm256_adds_epi16`

Add packed 16-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m256i _mm256_adds_epi16 (__m256i a, __m256i b)
VPADDSW ymm, ymm, ymm/m256

## mm256_adds_epi8

`mm256_adds_epi8`

Add packed 8-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m256i _mm256_adds_epi8 (__m256i a, __m256i b)
VPADDSB ymm, ymm, ymm/m256

## mm256_adds_epu16

`mm256_adds_epu16`

Add packed unsigned 16-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m256i _mm256_adds_epu16 (__m256i a, __m256i b)
VPADDUSW ymm, ymm, ymm/m256

## mm256_adds_epu8

`mm256_adds_epu8`

Add packed unsigned 8-bit integers in "a" and "b" using saturation, and store the results in "dst".

__m256i _mm256_adds_epu8 (__m256i a, __m256i b)
VPADDUSB ymm, ymm, ymm/m256

## mm256_alignr_epi8

`mm256_alignr_epi8`

Concatenate pairs of 16-byte blocks in "a" and "b" into a 32-byte temporary result, shift the result right by "count" bytes, and store the low 16 bytes in "dst".

__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
VPALIGNR ymm, ymm, ymm/m256, imm8

## mm256_and_si256

`mm256_and_si256`

Compute the bitwise AND of 256 bits (representing integer data) in "a" and "b", and store the result in "dst".

__m256i _mm256_and_si256 (__m256i a, __m256i b)
VPAND ymm, ymm, ymm/m256

## mm256_andnot_si256

`mm256_andnot_si256`

Compute the bitwise NOT of 256 bits (representing integer data) in "a" and then AND with "b", and store the result in "dst".

__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
VPANDN ymm, ymm, ymm/m256

## mm256_avg_epu16

`mm256_avg_epu16`

Average packed unsigned 16-bit integers in "a" and "b", and store the results in "dst".

__m256i _mm256_avg_epu16 (__m256i a, __m256i b)
VPAVGW ymm, ymm, ymm/m256

## mm256_avg_epu8

`mm256_avg_epu8`

Average packed unsigned 8-bit integers in "a" and "b", and store the results in "dst".

__m256i _mm256_avg_epu8 (__m256i a, __m256i b)
VPAVGB ymm, ymm, ymm/m256

## mm256_blend_epi16

`mm256_blend_epi16`

Blend packed 16-bit integers from "a" and "b" within 128-bit lanes using control mask "imm8", and store the results in "dst".

__m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
VPBLENDW ymm, ymm, ymm/m256, imm8

## mm256_blend_epi32

`mm256_blend_epi32`

Blend packed 32-bit integers from "a" and "b" using control mask "imm8", and store the results in "dst".

__m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
VPBLENDD ymm, ymm, ymm/m256, imm8

## mm256_blendv_epi8

`mm256_blendv_epi8`

Blend packed 8-bit integers from "a" and "b" using "mask", and store the results in "dst".

__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
VPBLENDVB ymm, ymm, ymm/m256, ymm

## mm256_broadcastb_epi8

`mm256_broadcastb_epi8`

Broadcast the low packed 8-bit integer from "a" to all elements of "dst".

__m256i _mm256_broadcastb_epi8 (__m128i a)
VPBROADCASTB ymm, m8

## mm256_broadcastd_epi32

`mm256_broadcastd_epi32`

Broadcast the low packed 32-bit integer from "a" to all elements of "dst".

__m256i _mm256_broadcastd_epi32 (__m128i a)
VPBROADCASTD ymm, m32

## mm256_broadcastq_epi64

`mm256_broadcastq_epi64`

Broadcast the low packed 64-bit integer from "a" to all elements of "dst".

__m256i _mm256_broadcastq_epi64 (__m128i a)
VPBROADCASTQ ymm, m64

## mm256_broadcastsd_pd

`mm256_broadcastsd_pd`

Broadcast the low double-precision (64-bit) floating-point element from "a" to all elements of "dst".

__m256d _mm256_broadcastsd_pd (__m128d a)
VBROADCASTSD ymm, xmm

## mm256_broadcastsi128_si256

`mm256_broadcastsi128_si256`

Broadcast 128 bits of integer data from "a" to all 128-bit lanes in "dst".

__m256i _mm256_broadcastsi128_si256 (__m128i a)
VBROADCASTI128 ymm, m128

## mm256_broadcastss_ps

`mm256_broadcastss_ps`

Broadcast the low single-precision (32-bit) floating-point element from "a" to all elements of "dst".

__m256 _mm256_broadcastss_ps (__m128 a)
VBROADCASTSS ymm, xmm

## mm256_broadcastw_epi16

`mm256_broadcastw_epi16`

Broadcast the low packed 16-bit integer from "a" to all elements of "dst".

__m256i _mm256_broadcastw_epi16 (__m128i a)
VPBROADCASTW ymm, m16

## mm256_bslli_epi128

`mm256_bslli_epi128`

Shift 128-bit lanes in "a" left by "imm8" bytes while shifting in zeros, and store the results in "dst".

__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
VPSLLDQ ymm, ymm, imm8

## mm256_bsrli_epi128

`mm256_bsrli_epi128`

Shift 128-bit lanes in "a" right by "imm8" bytes while shifting in zeros, and store the results in "dst".

__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
VPSRLDQ ymm, ymm, imm8

## mm256_cmpeq_epi16

`mm256_cmpeq_epi16`

Compare packed 16-bit integers in "a" and "b" for equality, and store the results in "dst".

__m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
VPCMPEQW ymm, ymm, ymm/m256

## mm256_cmpeq_epi32

`mm256_cmpeq_epi32`

Compare packed 32-bit integers in "a" and "b" for equality, and store the results in "dst".

__m256i _mm256_cmpeq_epi32 (__m256i a, __m256i b)
VPCMPEQD ymm, ymm, ymm/m256

## mm256_cmpeq_epi64

`mm256_cmpeq_epi64`

Compare packed 64-bit integers in "a" and "b" for equality, and store the results in "dst".

__m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
VPCMPEQQ ymm, ymm, ymm/m256

## mm256_cmpeq_epi8

`mm256_cmpeq_epi8`

Compare packed 8-bit integers in "a" and "b" for equality, and store the results in "dst".

__m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b)
VPCMPEQB ymm, ymm, ymm/m256

## mm256_cmpgt_epi16

`mm256_cmpgt_epi16`

Compare packed 16-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m256i _mm256_cmpgt_epi16 (__m256i a, __m256i b)
VPCMPGTW ymm, ymm, ymm/m256

## mm256_cmpgt_epi32

`mm256_cmpgt_epi32`

Compare packed 32-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b)
VPCMPGTD ymm, ymm, ymm/m256

## mm256_cmpgt_epi64

`mm256_cmpgt_epi64`

Compare packed 64-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b)
VPCMPGTQ ymm, ymm, ymm/m256

## mm256_cmpgt_epi8

`mm256_cmpgt_epi8`

Compare packed 8-bit integers in "a" and "b" for greater-than, and store the results in "dst".

__m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b)
VPCMPGTB ymm, ymm, ymm/m256

## mm256_cvtepi16_epi32

`mm256_cvtepi16_epi32`

Sign extend packed 16-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m256i _mm256_cvtepi16_epi32 (__m128i a)
VPMOVSXWD ymm, xmm/m128

## mm256_cvtepi16_epi64

`mm256_cvtepi16_epi64`

Sign extend packed 16-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m256i _mm256_cvtepi16_epi64 (__m128i a)
VPMOVSXWQ ymm, xmm/m128

## mm256_cvtepi32_epi64

`mm256_cvtepi32_epi64`

Sign extend packed 32-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m256i _mm256_cvtepi32_epi64 (__m128i a)
VPMOVSXDQ ymm, xmm/m128

## mm256_cvtepi8_epi16

`mm256_cvtepi8_epi16`

Sign extend packed 8-bit integers in "a" to packed 16-bit integers, and store the results in "dst".

__m256i _mm256_cvtepi8_epi16 (__m128i a)
VPMOVSXBW ymm, xmm/m128

## mm256_cvtepi8_epi32

`mm256_cvtepi8_epi32`

Sign extend packed 8-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m256i _mm256_cvtepi8_epi32 (__m128i a)
VPMOVSXBD ymm, xmm/m128

## mm256_cvtepi8_epi64

`mm256_cvtepi8_epi64`

Sign extend packed 8-bit integers in the low 8 bytes of "a" to packed 64-bit integers, and store the results in "dst".

__m256i _mm256_cvtepi8_epi64 (__m128i a)
VPMOVSXBQ ymm, xmm/m128

## mm256_cvtepu16_epi32

`mm256_cvtepu16_epi32`

Zero extend packed unsigned 16-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m256i _mm256_cvtepu16_epi32 (__m128i a)
VPMOVZXWD ymm, xmm

## mm256_cvtepu16_epi64

`mm256_cvtepu16_epi64`

Zero extend packed unsigned 16-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m256i _mm256_cvtepu16_epi64 (__m128i a)
VPMOVZXWQ ymm, xmm

## mm256_cvtepu32_epi64

`mm256_cvtepu32_epi64`

Zero extend packed unsigned 32-bit integers in "a" to packed 64-bit integers, and store the results in "dst".

__m256i _mm256_cvtepu32_epi64 (__m128i a)
VPMOVZXDQ ymm, xmm

## mm256_cvtepu8_epi16

`mm256_cvtepu8_epi16`

Zero extend packed unsigned 8-bit integers in "a" to packed 16-bit integers, and store the results in "dst".

__m256i _mm256_cvtepu8_epi16 (__m128i a)
VPMOVZXBW ymm, xmm

## mm256_cvtepu8_epi32

`mm256_cvtepu8_epi32`

Zero extend packed unsigned 8-bit integers in "a" to packed 32-bit integers, and store the results in "dst".

__m256i _mm256_cvtepu8_epi32 (__m128i a)
VPMOVZXBD ymm, xmm

## mm256_cvtepu8_epi64

`mm256_cvtepu8_epi64`

Zero extend packed unsigned 8-bit integers in the low 8 byte sof "a" to packed 64-bit integers, and store the results in "dst".

__m256i _mm256_cvtepu8_epi64 (__m128i a)
VPMOVZXBQ ymm, xmm

## mm256_cvtsi256_si32

`mm256_cvtsi256_si32`

Copy the lower 32-bit integer in "a" to "dst".

int _mm256_cvtsi256_si32 (__m256i a)
MOVD reg/m32, xmm

## mm256_extracti128_si256

`mm256_extracti128_si256`

Extract 128 bits (composed of integer data) from "a", selected with "imm8", and store the result in "dst".

__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
VEXTRACTI128 xmm, ymm, imm8

## mm256_hadd_epi16

`mm256_hadd_epi16`

Horizontally add adjacent pairs of 16-bit integers in "a" and "b", and pack the signed 16-bit results in "dst".

__m256i _mm256_hadd_epi16 (__m256i a, __m256i b)
VPHADDW ymm, ymm, ymm/m256

## mm256_hadd_epi32

`mm256_hadd_epi32`

Horizontally add adjacent pairs of 32-bit integers in "a" and "b", and pack the signed 32-bit results in "dst".

__m256i _mm256_hadd_epi32 (__m256i a, __m256i b)
VPHADDD ymm, ymm, ymm/m256

## mm256_hadds_epi16

`mm256_hadds_epi16`

Horizontally add adjacent pairs of 16-bit integers in "a" and "b" using saturation, and pack the signed 16-bit results in "dst".

__m256i _mm256_hadds_epi16 (__m256i a, __m256i b)
VPHADDSW ymm, ymm, ymm/m256

## mm256_hsub_epi16

`mm256_hsub_epi16`

Horizontally subtract adjacent pairs of 16-bit integers in "a" and "b", and pack the signed 16-bit results in "dst".

__m256i _mm256_hsub_epi16 (__m256i a, __m256i b)
VPHSUBW ymm, ymm, ymm/m256

## mm256_hsub_epi32

`mm256_hsub_epi32`

Horizontally subtract adjacent pairs of 32-bit integers in "a" and "b", and pack the signed 32-bit results in "dst".

__m256i _mm256_hsub_epi32 (__m256i a, __m256i b)
VPHSUBD ymm, ymm, ymm/m256

## mm256_hsubs_epi16

`mm256_hsubs_epi16`

Horizontally subtract adjacent pairs of 16-bit integers in "a" and "b" using saturation, and pack the signed 16-bit results in "dst".

__m256i _mm256_hsubs_epi16 (__m256i a, __m256i b)
VPHSUBSW ymm, ymm, ymm/m256

## mm256_i32gather_epi32

`mm256_i32gather_epi32`

Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
VPGATHERDD ymm, vm32y, ymm

## mm256_i32gather_epi64

`mm256_i32gather_epi64`

Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
VPGATHERDQ ymm, vm32y, ymm

## mm256_i32gather_pd

`mm256_i32gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m256d _mm256_i32gather_pd (double const* base_addr, __m128i vindex, const int scale)
VGATHERDPD ymm, vm32y, ymm

## mm256_i32gather_ps

`mm256_i32gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m256 _mm256_i32gather_ps (float const* base_addr, __m256i vindex, const int scale)
VGATHERDPS ymm, vm32y, ymm

## mm256_i64gather_epi32

`mm256_i64gather_epi32`

Gather 32-bit integers from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128i _mm256_i64gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
VPGATHERQD xmm, vm64y, xmm

## mm256_i64gather_epi64

`mm256_i64gather_epi64`

Gather 64-bit integers from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale)
VPGATHERQQ ymm, vm64y, ymm

## mm256_i64gather_pd

`mm256_i64gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m256d _mm256_i64gather_pd (double const* base_addr, __m256i vindex, const int scale)
VGATHERQPD ymm, vm64y, ymm

## mm256_i64gather_ps

`mm256_i64gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128 _mm256_i64gather_ps (float const* base_addr, __m256i vindex, const int scale)
VGATHERQPS xmm, vm64y, xmm

## mm256_inserti128_si256

`mm256_inserti128_si256`

Copy "a" to "dst", then insert 128 bits (composed of integer data) from "b" into "dst" at the location specified by "imm8".

__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
VINSERTI128 ymm, ymm, xmm, imm8

## mm256_madd_epi16

`mm256_madd_epi16`

Multiply packed signed 16-bit integers in "a" and "b", producing intermediate signed 32-bit integers. Horizontally add adjacent pairs of intermediate 32-bit integers, and pack the results in "dst".

__m256i _mm256_madd_epi16 (__m256i a, __m256i b)
VPMADDWD ymm, ymm, ymm/m256

## mm256_maddubs_epi16

`mm256_maddubs_epi16`

Vertically multiply each unsigned 8-bit integer from "a" with the corresponding signed 8-bit integer from "b", producing intermediate signed 16-bit integers. Horizontally add adjacent pairs of intermediate signed 16-bit integers, and pack the saturated results in "dst".

__m256i _mm256_maddubs_epi16 (__m256i a, __m256i b)
VPMADDUBSW ymm, ymm, ymm/m256

## mm256_mask_i32gather_epi32

`mm256_mask_i32gather_epi32`

Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m256i _mm256_mask_i32gather_epi32 (__m256i src, int const* base_addr, __m256i vindex, __m256i mask, const int scale)
VPGATHERDD ymm, vm32y, ymm

## mm256_mask_i32gather_epi64

`mm256_mask_i32gather_epi64`

Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m256i _mm256_mask_i32gather_epi64 (__m256i src, __int64 const* base_addr, __m128i vindex, __m256i mask, const int scale)
VPGATHERDQ ymm, vm32y, ymm

## mm256_mask_i32gather_pd

`mm256_mask_i32gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m256d _mm256_mask_i32gather_pd (__m256d src, double const* base_addr, __m128i vindex, __m256d mask, const int scale)
VPGATHERDPD ymm, vm32y, ymm

## mm256_mask_i32gather_ps

`mm256_mask_i32gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m256 _mm256_mask_i32gather_ps (__m256 src, float const* base_addr, __m256i vindex, __m256 mask, const int scale)
VPGATHERDPS ymm, vm32y, ymm

## mm256_mask_i64gather_epi32

`mm256_mask_i64gather_epi32`

Gather 32-bit integers from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale)
VPGATHERQD xmm, vm32y, xmm

## mm256_mask_i64gather_epi64

`mm256_mask_i64gather_epi64`

Gather 64-bit integers from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m256i _mm256_mask_i64gather_epi64 (__m256i src, __int64 const* base_addr, __m256i vindex, __m256i mask, const int scale)
VPGATHERQQ ymm, vm32y, ymm

## mm256_mask_i64gather_pd

`mm256_mask_i64gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m256d _mm256_mask_i64gather_pd (__m256d src, double const* base_addr, __m256i vindex, __m256d mask, const int scale)
VGATHERQPD ymm, vm32y, ymm

## mm256_mask_i64gather_ps

`mm256_mask_i64gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128 _mm256_mask_i64gather_ps (__m128 src, float const* base_addr, __m256i vindex, __m128 mask, const int scale)
VGATHERQPS xmm, vm32y, xmm

## mm256_maskload_epi32

`mm256_maskload_epi32`

Load packed 32-bit integers from memory into "dst" using "mask" (elements are zeroed out when the highest bit is not set in the corresponding element).

__m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask)
VPMASKMOVD ymm, ymm, m256

## mm256_maskload_epi64

`mm256_maskload_epi64`

Load packed 64-bit integers from memory into "dst" using "mask" (elements are zeroed out when the highest bit is not set in the corresponding element).

__m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask)
VPMASKMOVQ ymm, ymm, m256

## mm256_maskstore_epi32

`mm256_maskstore_epi32`

Store packed 32-bit integers from "a" into memory using "mask" (elements are not stored when the highest bit is not set in the corresponding element).

void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a)
VPMASKMOVD m256, ymm, ymm

## mm256_maskstore_epi64

`mm256_maskstore_epi64`

Store packed 64-bit integers from "a" into memory using "mask" (elements are not stored when the highest bit is not set in the corresponding element).

void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a)
VPMASKMOVQ m256, ymm, ymm

## mm256_max_epi16

`mm256_max_epi16`

Compare packed 16-bit integers in "a" and "b", and store packed maximum values in "dst".

__m256i _mm256_max_epi16 (__m256i a, __m256i b)
VPMAXSW ymm, ymm, ymm/m256

## mm256_max_epi32

`mm256_max_epi32`

Compare packed 32-bit integers in "a" and "b", and store packed maximum values in "dst".

__m256i _mm256_max_epi32 (__m256i a, __m256i b)
VPMAXSD ymm, ymm, ymm/m256

## mm256_max_epi8

`mm256_max_epi8`

Compare packed 8-bit integers in "a" and "b", and store packed maximum values in "dst".

__m256i _mm256_max_epi8 (__m256i a, __m256i b)
VPMAXSB ymm, ymm, ymm/m256

## mm256_max_epu16

`mm256_max_epu16`

Compare packed unsigned 16-bit integers in "a" and "b", and store packed maximum values in "dst".

__m256i _mm256_max_epu16 (__m256i a, __m256i b)
VPMAXUW ymm, ymm, ymm/m256

## mm256_max_epu32

`mm256_max_epu32`

Compare packed unsigned 32-bit integers in "a" and "b", and store packed maximum values in "dst".

__m256i _mm256_max_epu32 (__m256i a, __m256i b)
VPMAXUD ymm, ymm, ymm/m256

## mm256_max_epu8

`mm256_max_epu8`

Compare packed unsigned 8-bit integers in "a" and "b", and store packed maximum values in "dst".

__m256i _mm256_max_epu8 (__m256i a, __m256i b)
VPMAXUB ymm, ymm, ymm/m256

## mm256_min_epi16

`mm256_min_epi16`

Compare packed 16-bit integers in "a" and "b", and store packed minimum values in "dst".

__m256i _mm256_min_epi16 (__m256i a, __m256i b)
VPMINSW ymm, ymm, ymm/m256

## mm256_min_epi32

`mm256_min_epi32`

Compare packed 32-bit integers in "a" and "b", and store packed minimum values in "dst".

__m256i _mm256_min_epi32 (__m256i a, __m256i b)
VPMINSD ymm, ymm, ymm/m256

## mm256_min_epi8

`mm256_min_epi8`

Compare packed 8-bit integers in "a" and "b", and store packed minimum values in "dst".

__m256i _mm256_min_epi8 (__m256i a, __m256i b)
VPMINSB ymm, ymm, ymm/m256

## mm256_min_epu16

`mm256_min_epu16`

Compare packed unsigned 16-bit integers in "a" and "b", and store packed minimum values in "dst".

__m256i _mm256_min_epu16 (__m256i a, __m256i b)
VPMINUW ymm, ymm, ymm/m256

## mm256_min_epu32

`mm256_min_epu32`

Compare packed unsigned 32-bit integers in "a" and "b", and store packed minimum values in "dst".

__m256i _mm256_min_epu32 (__m256i a, __m256i b)
VPMINUD ymm, ymm, ymm/m256

## mm256_min_epu8

`mm256_min_epu8`

Compare packed unsigned 8-bit integers in "a" and "b", and store packed minimum values in "dst".

__m256i _mm256_min_epu8 (__m256i a, __m256i b)
VPMINUB ymm, ymm, ymm/m256

## mm256_movemask_epi8

`mm256_movemask_epi8`

Create mask from the most significant bit of each 8-bit element in "a", and store the result in "dst".

int _mm256_movemask_epi8 (__m256i a)
VPMOVMSKB reg, ymm

## mm256_mpsadbw_epu8

`mm256_mpsadbw_epu8`

Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in "a" compared to those in "b", and store the 16-bit results in "dst".
	Eight SADs are performed for each 128-bit lane using one quadruplet from "b" and eight quadruplets from "a". One quadruplet is selected from "b" starting at on the offset specified in "imm8". Eight quadruplets are formed from sequential 8-bit integers selected from "a" starting at the offset specified in "imm8".

__m256i _mm256_mpsadbw_epu8 (__m256i a, __m256i b, const int imm8)
VMPSADBW ymm, ymm, ymm/m256, imm8

## mm256_mul_epi32

`mm256_mul_epi32`

Multiply the low 32-bit integers from each packed 64-bit element in "a" and "b", and store the signed 64-bit results in "dst".

__m256i _mm256_mul_epi32 (__m256i a, __m256i b)
VPMULDQ ymm, ymm, ymm/m256

## mm256_mul_epu32

`mm256_mul_epu32`

Multiply the low unsigned 32-bit integers from each packed 64-bit element in "a" and "b", and store the unsigned 64-bit results in "dst".

__m256i _mm256_mul_epu32 (__m256i a, __m256i b)
VPMULUDQ ymm, ymm, ymm/m256

## mm256_mulhi_epi16

`mm256_mulhi_epi16`

Multiply the packed 16-bit integers in "a" and "b", producing intermediate 32-bit integers, and store the high 16 bits of the intermediate integers in "dst".

__m256i _mm256_mulhi_epi16 (__m256i a, __m256i b)
VPMULHW ymm, ymm, ymm/m256

## mm256_mulhi_epu16

`mm256_mulhi_epu16`

Multiply the packed unsigned 16-bit integers in "a" and "b", producing intermediate 32-bit integers, and store the high 16 bits of the intermediate integers in "dst".

__m256i _mm256_mulhi_epu16 (__m256i a, __m256i b)
VPMULHUW ymm, ymm, ymm/m256

## mm256_mulhrs_epi16

`mm256_mulhrs_epi16`

Multiply packed 16-bit integers in "a" and "b", producing intermediate signed 32-bit integers. Truncate each intermediate integer to the 18 most significant bits, round by adding 1, and store bits [16:1] to "dst".

__m256i _mm256_mulhrs_epi16 (__m256i a, __m256i b)
VPMULHRSW ymm, ymm, ymm/m256

## mm256_mullo_epi16

`mm256_mullo_epi16`

Multiply the packed 16-bit integers in "a" and "b", producing intermediate 32-bit integers, and store the low 16 bits of the intermediate integers in "dst".

__m256i _mm256_mullo_epi16 (__m256i a, __m256i b)
VPMULLW ymm, ymm, ymm/m256

## mm256_mullo_epi32

`mm256_mullo_epi32`

Multiply the packed 32-bit integers in "a" and "b", producing intermediate 64-bit integers, and store the low 32 bits of the intermediate integers in "dst".

__m256i _mm256_mullo_epi32 (__m256i a, __m256i b)
VPMULLD ymm, ymm, ymm/m256

## mm256_or_si256

`mm256_or_si256`

Compute the bitwise OR of 256 bits (representing integer data) in "a" and "b", and store the result in "dst".

__m256i _mm256_or_si256 (__m256i a, __m256i b)
VPOR ymm, ymm, ymm/m256

## mm256_packs_epi16

`mm256_packs_epi16`

Convert packed 16-bit integers from "a" and "b" to packed 8-bit integers using signed saturation, and store the results in "dst".

__m256i _mm256_packs_epi16 (__m256i a, __m256i b)
VPACKSSWB ymm, ymm, ymm/m256

## mm256_packs_epi32

`mm256_packs_epi32`

Convert packed 32-bit integers from "a" and "b" to packed 16-bit integers using signed saturation, and store the results in "dst".

__m256i _mm256_packs_epi32 (__m256i a, __m256i b)
VPACKSSDW ymm, ymm, ymm/m256

## mm256_packus_epi16

`mm256_packus_epi16`

Convert packed 16-bit integers from "a" and "b" to packed 8-bit integers using unsigned saturation, and store the results in "dst".

__m256i _mm256_packus_epi16 (__m256i a, __m256i b)
VPACKUSWB ymm, ymm, ymm/m256

## mm256_packus_epi32

`mm256_packus_epi32`

Convert packed 32-bit integers from "a" and "b" to packed 16-bit integers using unsigned saturation, and store the results in "dst".

__m256i _mm256_packus_epi32 (__m256i a, __m256i b)
VPACKUSDW ymm, ymm, ymm/m256

## mm256_permute2x128_si256

`mm256_permute2x128_si256`

Shuffle 128-bits (composed of integer data) selected by "imm8" from "a" and "b", and store the results in "dst".

__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
VPERM2I128 ymm, ymm, ymm/m256, imm8

## mm256_permute4x64_epi64

`mm256_permute4x64_epi64`

Shuffle 64-bit integers in "a" across lanes using the control in "imm8", and store the results in "dst".

__m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
VPERMQ ymm, ymm/m256, imm8

## mm256_permute4x64_pd

`mm256_permute4x64_pd`

Shuffle double-precision (64-bit) floating-point elements in "a" across lanes using the control in "imm8", and store the results in "dst".

__m256d _mm256_permute4x64_pd (__m256d a, const int imm8)
VPERMPD ymm, ymm/m256, imm8

## mm256_permutevar8x32_epi32

`mm256_permutevar8x32_epi32`

Shuffle 32-bit integers in "a" across lanes using the corresponding index in "idx", and store the results in "dst".

__m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
VPERMD ymm, ymm/m256, ymm

## mm256_permutevar8x32_ps

`mm256_permutevar8x32_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" across lanes using the corresponding index in "idx".

__m256 _mm256_permutevar8x32_ps (__m256 a, __m256i idx)
VPERMPS ymm, ymm/m256, ymm

## mm256_sad_epu8

`mm256_sad_epu8`

Compute the absolute differences of packed unsigned 8-bit integers in "a" and "b", then horizontally sum each consecutive 8 differences to produce four unsigned 16-bit integers, and pack these unsigned 16-bit integers in the low 16 bits of 64-bit elements in "dst".

__m256i _mm256_sad_epu8 (__m256i a, __m256i b)
VPSADBW ymm, ymm, ymm/m256

## mm256_shuffle_epi32

`mm256_shuffle_epi32`

Shuffle 32-bit integers in "a" within 128-bit lanes using the control in "imm8", and store the results in "dst".

__m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
VPSHUFD ymm, ymm/m256, imm8

## mm256_shuffle_epi8

`mm256_shuffle_epi8`

Shuffle 8-bit integers in "a" within 128-bit lanes according to shuffle control mask in the corresponding 8-bit element of "b", and store the results in "dst".

__m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
VPSHUFB ymm, ymm, ymm/m256

## mm256_shufflehi_epi16

`mm256_shufflehi_epi16`

Shuffle 16-bit integers in the high 64 bits of 128-bit lanes of "a" using the control in "imm8". Store the results in the high 64 bits of 128-bit lanes of "dst", with the low 64 bits of 128-bit lanes being copied from from "a" to "dst".

__m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
VPSHUFHW ymm, ymm/m256, imm8

## mm256_shufflelo_epi16

`mm256_shufflelo_epi16`

Shuffle 16-bit integers in the low 64 bits of 128-bit lanes of "a" using the control in "imm8". Store the results in the low 64 bits of 128-bit lanes of "dst", with the high 64 bits of 128-bit lanes being copied from from "a" to "dst".

__m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
VPSHUFLW ymm, ymm/m256, imm8

## mm256_sign_epi16

`mm256_sign_epi16`

Negate packed 16-bit integers in "a" when the corresponding signed 16-bit integer in "b" is negative, and store the results in "dst". Element in "dst" are zeroed out when the corresponding element in "b" is zero.

__m256i _mm256_sign_epi16 (__m256i a, __m256i b)
VPSIGNW ymm, ymm, ymm/m256

## mm256_sign_epi32

`mm256_sign_epi32`

Negate packed 32-bit integers in "a" when the corresponding signed 32-bit integer in "b" is negative, and store the results in "dst". Element in "dst" are zeroed out when the corresponding element in "b" is zero.

__m256i _mm256_sign_epi32 (__m256i a, __m256i b)
VPSIGND ymm, ymm, ymm/m256

## mm256_sign_epi8

`mm256_sign_epi8`

Negate packed 8-bit integers in "a" when the corresponding signed 8-bit integer in "b" is negative, and store the results in "dst". Element in "dst" are zeroed out when the corresponding element in "b" is zero.

__m256i _mm256_sign_epi8 (__m256i a, __m256i b)
VPSIGNB ymm, ymm, ymm/m256

## mm256_sll_epi16

`mm256_sll_epi16`

Shift packed 16-bit integers in "a" left by "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_sll_epi16 (__m256i a, __m128i count)
VPSLLW ymm, ymm, xmm/m128

## mm256_sll_epi32

`mm256_sll_epi32`

Shift packed 32-bit integers in "a" left by "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_sll_epi32 (__m256i a, __m128i count)
VPSLLD ymm, ymm, xmm/m128

## mm256_sll_epi64

`mm256_sll_epi64`

Shift packed 64-bit integers in "a" left by "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_sll_epi64 (__m256i a, __m128i count)
VPSLLQ ymm, ymm, xmm/m128

## mm256_slli_epi16

`mm256_slli_epi16`

Shift packed 16-bit integers in "a" left by "imm8" while shifting in zeros, and store the results in "dst".

__m256i _mm256_slli_epi16 (__m256i a, int imm8)
VPSLLW ymm, ymm, imm8

## mm256_slli_epi32

`mm256_slli_epi32`

Shift packed 32-bit integers in "a" left by "imm8" while shifting in zeros, and store the results in "dst".

__m256i _mm256_slli_epi32 (__m256i a, int imm8)
VPSLLD ymm, ymm, imm8

## mm256_slli_epi64

`mm256_slli_epi64`

Shift packed 64-bit integers in "a" left by "imm8" while shifting in zeros, and store the results in "dst".

__m256i _mm256_slli_epi64 (__m256i a, int imm8)
VPSLLQ ymm, ymm, imm8

## mm256_sllv_epi32

`mm256_sllv_epi32`

Shift packed 32-bit integers in "a" left by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
VPSLLVD ymm, ymm, ymm/m256

## mm256_sllv_epi64

`mm256_sllv_epi64`

Shift packed 64-bit integers in "a" left by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
VPSLLVQ ymm, ymm, ymm/m256

## mm256_srai_epi16

`mm256_srai_epi16`

Shift packed 16-bit integers in "a" right by "imm8" while shifting in sign bits, and store the results in "dst".

__m256i _mm256_srai_epi16 (__m256i a, int imm8)
VPSRAW ymm, ymm, imm8

## mm256_srai_epi32

`mm256_srai_epi32`

Shift packed 32-bit integers in "a" right by "imm8" while shifting in sign bits, and store the results in "dst".

__m256i _mm256_srai_epi32 (__m256i a, int imm8)
VPSRAD ymm, ymm, imm8

## mm256_srav_epi32

`mm256_srav_epi32`

Shift packed 32-bit integers in "a" right by the amount specified by the corresponding element in "count" while shifting in sign bits, and store the results in "dst".

__m256i _mm256_srav_epi32 (__m256i a, __m256i count)
VPSRAVD ymm, ymm, ymm/m256

## mm256_srl_epi16

`mm256_srl_epi16`

Shift packed 16-bit integers in "a" right by "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srl_epi16 (__m256i a, __m128i count)
VPSRLW ymm, ymm, xmm/m128

## mm256_srl_epi32

`mm256_srl_epi32`

Shift packed 32-bit integers in "a" right by "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srl_epi32 (__m256i a, __m128i count)
VPSRLD ymm, ymm, xmm/m128

## mm256_srl_epi64

`mm256_srl_epi64`

Shift packed 64-bit integers in "a" right by "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srl_epi64 (__m256i a, __m128i count)
VPSRLQ ymm, ymm, xmm/m128

## mm256_srli_epi16

`mm256_srli_epi16`

Shift packed 16-bit integers in "a" right by "imm8" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srli_epi16 (__m256i a, int imm8)
VPSRLW ymm, ymm, imm8

## mm256_srli_epi32

`mm256_srli_epi32`

Shift packed 32-bit integers in "a" right by "imm8" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srli_epi32 (__m256i a, int imm8)
VPSRLD ymm, ymm, imm8

## mm256_srli_epi64

`mm256_srli_epi64`

Shift packed 64-bit integers in "a" right by "imm8" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srli_epi64 (__m256i a, int imm8)
VPSRLQ ymm, ymm, imm8

## mm256_srlv_epi32

`mm256_srlv_epi32`

Shift packed 32-bit integers in "a" right by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srlv_epi32 (__m256i a, __m256i count)
VPSRLVD ymm, ymm, ymm/m256

## mm256_srlv_epi64

`mm256_srlv_epi64`

Shift packed 64-bit integers in "a" right by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m256i _mm256_srlv_epi64 (__m256i a, __m256i count)
VPSRLVQ ymm, ymm, ymm/m256

## mm256_stream_load_si256

`mm256_stream_load_si256`

Load 256-bits of integer data from memory into "dst" using a non-temporal memory hint.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
VMOVNTDQA ymm, m256

## mm256_sub_epi16

`mm256_sub_epi16`

Subtract packed 16-bit integers in "b" from packed 16-bit integers in "a", and store the results in "dst".

__m256i _mm256_sub_epi16 (__m256i a, __m256i b)
VPSUBW ymm, ymm, ymm/m256

## mm256_sub_epi32

`mm256_sub_epi32`

Subtract packed 32-bit integers in "b" from packed 32-bit integers in "a", and store the results in "dst".

__m256i _mm256_sub_epi32 (__m256i a, __m256i b)
VPSUBD ymm, ymm, ymm/m256

## mm256_sub_epi64

`mm256_sub_epi64`

Subtract packed 64-bit integers in "b" from packed 64-bit integers in "a", and store the results in "dst".

__m256i _mm256_sub_epi64 (__m256i a, __m256i b)
VPSUBQ ymm, ymm, ymm/m256

## mm256_sub_epi8

`mm256_sub_epi8`

Subtract packed 8-bit integers in "b" from packed 8-bit integers in "a", and store the results in "dst".

__m256i _mm256_sub_epi8 (__m256i a, __m256i b)
VPSUBB ymm, ymm, ymm/m256

## mm256_subs_epi16

`mm256_subs_epi16`

Subtract packed 16-bit integers in "b" from packed 16-bit integers in "a" using saturation, and store the results in "dst".

__m256i _mm256_subs_epi16 (__m256i a, __m256i b)
VPSUBSW ymm, ymm, ymm/m256

## mm256_subs_epi8

`mm256_subs_epi8`

Subtract packed 8-bit integers in "b" from packed 8-bit integers in "a" using saturation, and store the results in "dst".

__m256i _mm256_subs_epi8 (__m256i a, __m256i b)
VPSUBSB ymm, ymm, ymm/m256

## mm256_subs_epu16

`mm256_subs_epu16`

Subtract packed unsigned 16-bit integers in "b" from packed unsigned 16-bit integers in "a" using saturation, and store the results in "dst".

__m256i _mm256_subs_epu16 (__m256i a, __m256i b)
VPSUBUSW ymm, ymm, ymm/m256

## mm256_subs_epu8

`mm256_subs_epu8`

Subtract packed unsigned 8-bit integers in "b" from packed unsigned 8-bit integers in "a" using saturation, and store the results in "dst".

__m256i _mm256_subs_epu8 (__m256i a, __m256i b)
VPSUBUSB ymm, ymm, ymm/m256

## mm256_unpackhi_epi16

`mm256_unpackhi_epi16`

Unpack and interleave 16-bit integers from the high half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b)
VPUNPCKHWD ymm, ymm, ymm/m256

## mm256_unpackhi_epi32

`mm256_unpackhi_epi32`

Unpack and interleave 32-bit integers from the high half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b)
VPUNPCKHDQ ymm, ymm, ymm/m256

## mm256_unpackhi_epi64

`mm256_unpackhi_epi64`

Unpack and interleave 64-bit integers from the high half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b)
VPUNPCKHQDQ ymm, ymm, ymm/m256

## mm256_unpackhi_epi8

`mm256_unpackhi_epi8`

Unpack and interleave 8-bit integers from the high half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
VPUNPCKHBW ymm, ymm, ymm/m256

## mm256_unpacklo_epi16

`mm256_unpacklo_epi16`

Unpack and interleave 16-bit integers from the low half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
VPUNPCKLWD ymm, ymm, ymm/m256

## mm256_unpacklo_epi32

`mm256_unpacklo_epi32`

Unpack and interleave 32-bit integers from the low half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
VPUNPCKLDQ ymm, ymm, ymm/m256

## mm256_unpacklo_epi64

`mm256_unpacklo_epi64`

Unpack and interleave 64-bit integers from the low half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
VPUNPCKLQDQ ymm, ymm, ymm/m256

## mm256_unpacklo_epi8

`mm256_unpacklo_epi8`

Unpack and interleave 8-bit integers from the low half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
VPUNPCKLBW ymm, ymm, ymm/m256

## mm256_xor_si256

`mm256_xor_si256`

Compute the bitwise XOR of 256 bits (representing integer data) in "a" and "b", and store the result in "dst".

__m256i _mm256_xor_si256 (__m256i a, __m256i b)
VPXOR ymm, ymm, ymm/m256

## mm_blend_epi32

`mm_blend_epi32`

Blend packed 32-bit integers from "a" and "b" using control mask "imm8", and store the results in "dst".

__m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
VPBLENDD xmm, xmm, xmm/m128, imm8

## mm_broadcastb_epi8

`mm_broadcastb_epi8`

Broadcast the low packed 8-bit integer from "a" to all elements of "dst".

__m128i _mm_broadcastb_epi8 (__m128i a)
VPBROADCASTB xmm, m8

## mm_broadcastd_epi32

`mm_broadcastd_epi32`

Broadcast the low packed 32-bit integer from "a" to all elements of "dst".

__m128i _mm_broadcastd_epi32 (__m128i a)
VPBROADCASTD xmm, m32

## mm_broadcastq_epi64

`mm_broadcastq_epi64`

Broadcast the low packed 64-bit integer from "a" to all elements of "dst".

__m128i _mm_broadcastq_epi64 (__m128i a)
VPBROADCASTQ xmm, m64

## mm_broadcastsd_pd

`mm_broadcastsd_pd`

Broadcast the low double-precision (64-bit) floating-point element from "a" to all elements of "dst".

__m128d _mm_broadcastsd_pd (__m128d a)
VMOVDDUP xmm, xmm

## mm_broadcastss_ps

`mm_broadcastss_ps`

Broadcast the low single-precision (32-bit) floating-point element from "a" to all elements of "dst".

__m128 _mm_broadcastss_ps (__m128 a)
VBROADCASTSS xmm, xmm

## mm_broadcastw_epi16

`mm_broadcastw_epi16`

Broadcast the low packed 16-bit integer from "a" to all elements of "dst".

__m128i _mm_broadcastw_epi16 (__m128i a)
VPBROADCASTW xmm, m16

## mm_i32gather_epi32

`mm_i32gather_epi32`

Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128i _mm_i32gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
VPGATHERDD xmm, vm32x, xmm

## mm_i32gather_epi64

`mm_i32gather_epi64`

Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128i _mm_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
VPGATHERDQ xmm, vm32x, xmm

## mm_i32gather_pd

`mm_i32gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128d _mm_i32gather_pd (double const* base_addr, __m128i vindex, const int scale)
VGATHERDPD xmm, vm32x, xmm

## mm_i32gather_ps

`mm_i32gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128 _mm_i32gather_ps (float const* base_addr, __m128i vindex, const int scale)
VGATHERDPS xmm, vm32x, xmm

## mm_i64gather_epi32

`mm_i64gather_epi32`

Gather 32-bit integers from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128i _mm_i64gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
VPGATHERQD xmm, vm64x, xmm

## mm_i64gather_epi64

`mm_i64gather_epi64`

Gather 64-bit integers from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
VPGATHERQQ xmm, vm64x, xmm

## mm_i64gather_pd

`mm_i64gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128d _mm_i64gather_pd (double const* base_addr, __m128i vindex, const int scale)
VGATHERQPD xmm, vm64x, xmm

## mm_i64gather_ps

`mm_i64gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst". "scale" should be 1, 2, 4 or 8.

__m128 _mm_i64gather_ps (float const* base_addr, __m128i vindex, const int scale)
VGATHERQPS xmm, vm64x, xmm

## mm_mask_i32gather_epi32

`mm_mask_i32gather_epi32`

Gather 32-bit integers from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
VPGATHERDD xmm, vm32x, xmm

## mm_mask_i32gather_epi64

`mm_mask_i32gather_epi64`

Gather 64-bit integers from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128i _mm_mask_i32gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
VPGATHERDQ xmm, vm32x, xmm

## mm_mask_i32gather_pd

`mm_mask_i32gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128d _mm_mask_i32gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
VGATHERDPD xmm, vm32x, xmm

## mm_mask_i32gather_ps

`mm_mask_i32gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 32-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 32-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128 _mm_mask_i32gather_ps (__m128 src, float const* base_addr, __m128i vindex, __m128 mask, const int scale)
VGATHERDPS xmm, vm32x, xmm

## mm_mask_i64gather_epi32

`mm_mask_i64gather_epi32`

Gather 32-bit integers from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
VPGATHERQD xmm, vm64x, xmm

## mm_mask_i64gather_epi64

`mm_mask_i64gather_epi64`

Gather 64-bit integers from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128i _mm_mask_i64gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
VPGATHERQQ xmm, vm64x, xmm

## mm_mask_i64gather_pd

`mm_mask_i64gather_pd`

Gather double-precision (64-bit) floating-point elements from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128d _mm_mask_i64gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
VGATHERQPD xmm, vm64x, xmm

## mm_mask_i64gather_ps

`mm_mask_i64gather_ps`

Gather single-precision (32-bit) floating-point elements from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at "base_addr" and offset by each 64-bit element in "vindex" (each index is scaled by the factor in "scale"). Gathered elements are merged into "dst" using "mask" (elements are copied from "src" when the highest bit is not set in the corresponding element). "scale" should be 1, 2, 4 or 8.

__m128 _mm_mask_i64gather_ps (__m128 src, float const* base_addr, __m128i vindex, __m128 mask, const int scale)
VGATHERQPS xmm, vm64x, xmm

## mm_maskload_epi32

`mm_maskload_epi32`

Load packed 32-bit integers from memory into "dst" using "mask" (elements are zeroed out when the highest bit is not set in the corresponding element).

__m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask)
VPMASKMOVD xmm, xmm, m128

## mm_maskload_epi64

`mm_maskload_epi64`

Load packed 64-bit integers from memory into "dst" using "mask" (elements are zeroed out when the highest bit is not set in the corresponding element).

__m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask)
VPMASKMOVQ xmm, xmm, m128

## mm_maskstore_epi32

`mm_maskstore_epi32`

Store packed 32-bit integers from "a" into memory using "mask" (elements are not stored when the highest bit is not set in the corresponding element).

void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a)
VPMASKMOVD m128, xmm, xmm

## mm_maskstore_epi64

`mm_maskstore_epi64`

Store packed 64-bit integers from "a" into memory using "mask" (elements are not stored when the highest bit is not set in the corresponding element).

void _mm_maskstore_epi64 (__int64* mem_addr, __m128i mask, __m128i a)
VPMASKMOVQ m128, xmm, xmm

## mm_sllv_epi32

`mm_sllv_epi32`

Shift packed 32-bit integers in "a" left by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_sllv_epi32 (__m128i a, __m128i count)
VPSLLVD xmm, ymm, xmm/m128

## mm_sllv_epi64

`mm_sllv_epi64`

Shift packed 64-bit integers in "a" left by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_sllv_epi64 (__m128i a, __m128i count)
VPSLLVQ xmm, ymm, xmm/m128

## mm_srav_epi32

`mm_srav_epi32`

Shift packed 32-bit integers in "a" right by the amount specified by the corresponding element in "count" while shifting in sign bits, and store the results in "dst".

__m128i _mm_srav_epi32 (__m128i a, __m128i count)
VPSRAVD xmm, xmm, xmm/m128

## mm_srlv_epi32

`mm_srlv_epi32`

Shift packed 32-bit integers in "a" right by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_srlv_epi32 (__m128i a, __m128i count)
VPSRLVD xmm, xmm, xmm/m128

## mm_srlv_epi64

`mm_srlv_epi64`

Shift packed 64-bit integers in "a" right by the amount specified by the corresponding element in "count" while shifting in zeros, and store the results in "dst".

__m128i _mm_srlv_epi64 (__m128i a, __m128i count)
VPSRLVQ xmm, xmm, xmm/m128
