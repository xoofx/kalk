---
title: Intel Avx Intrinsics
url: /doc/api/intel/avx/
---

## mm256_add_pd

`mm256_add_pd`

Add packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256d _mm256_add_pd (__m256d a, __m256d b)
VADDPD ymm, ymm, ymm/m256

## mm256_add_ps

`mm256_add_ps`

Add packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256 _mm256_add_ps (__m256 a, __m256 b)
VADDPS ymm, ymm, ymm/m256

## mm256_addsub_pd

`mm256_addsub_pd`

Alternatively add and subtract packed double-precision (64-bit) floating-point elements in "a" to/from packed elements in "b", and store the results in "dst".

__m256d _mm256_addsub_pd (__m256d a, __m256d b)
VADDSUBPD ymm, ymm, ymm/m256

## mm256_addsub_ps

`mm256_addsub_ps`

Alternatively add and subtract packed single-precision (32-bit) floating-point elements in "a" to/from packed elements in "b", and store the results in "dst".

__m256 _mm256_addsub_ps (__m256 a, __m256 b)
VADDSUBPS ymm, ymm, ymm/m256

## mm256_and_pd

`mm256_and_pd`

Compute the bitwise AND of packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256d _mm256_and_pd (__m256d a, __m256d b)
VANDPD ymm, ymm, ymm/m256

## mm256_and_ps

`mm256_and_ps`

Compute the bitwise AND of packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256 _mm256_and_ps (__m256 a, __m256 b)
VANDPS ymm, ymm, ymm/m256

## mm256_andnot_pd

`mm256_andnot_pd`

Compute the bitwise NOT of packed double-precision (64-bit) floating-point elements in "a" and then AND with "b", and store the results in "dst".

__m256d _mm256_andnot_pd (__m256d a, __m256d b)
VANDNPD ymm, ymm, ymm/m256

## mm256_andnot_ps

`mm256_andnot_ps`

Compute the bitwise NOT of packed single-precision (32-bit) floating-point elements in "a" and then AND with "b", and store the results in "dst".

__m256 _mm256_andnot_ps (__m256 a, __m256 b)
VANDNPS ymm, ymm, ymm/m256

## mm256_blend_pd

`mm256_blend_pd`

Blend packed double-precision (64-bit) floating-point elements from "a" and "b" using control mask "imm8", and store the results in "dst".

__m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8)
VBLENDPD ymm, ymm, ymm/m256, imm8

## mm256_blend_ps

`mm256_blend_ps`

Blend packed single-precision (32-bit) floating-point elements from "a" and "b" using control mask "imm8", and store the results in "dst".

__m256 _mm256_blend_ps (__m256 a, __m256 b, const int imm8)
VBLENDPS ymm, ymm, ymm/m256, imm8

## mm256_blendv_pd

`mm256_blendv_pd`

Blend packed double-precision (64-bit) floating-point elements from "a" and "b" using "mask", and store the results in "dst".

__m256d _mm256_blendv_pd (__m256d a, __m256d b, __m256d mask)
VBLENDVPD ymm, ymm, ymm/m256, ymm

## mm256_blendv_ps

`mm256_blendv_ps`

Blend packed single-precision (32-bit) floating-point elements from "a" and "b" using "mask", and store the results in "dst".

__m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask)
VBLENDVPS ymm, ymm, ymm/m256, ymm

## mm256_broadcast_pd

`mm256_broadcast_pd`

Broadcast 128 bits from memory (composed of 2 packed double-precision (64-bit) floating-point elements) to all elements of "dst".

__m256d _mm256_broadcast_pd (__m128d const * mem_addr)
VBROADCASTF128, ymm, m128

## mm256_broadcast_ps

`mm256_broadcast_ps`

Broadcast 128 bits from memory (composed of 4 packed single-precision (32-bit) floating-point elements) to all elements of "dst".

__m256 _mm256_broadcast_ps (__m128 const * mem_addr)
VBROADCASTF128, ymm, m128

## mm256_broadcast_sd

`mm256_broadcast_sd`

Broadcast a double-precision (64-bit) floating-point element from memory to all elements of "dst".

__m256d _mm256_broadcast_sd (double const * mem_addr)
VBROADCASTSD ymm, m64

## mm256_broadcast_ss

`mm256_broadcast_ss`

Broadcast a single-precision (32-bit) floating-point element from memory to all elements of "dst".

__m256 _mm256_broadcast_ss (float const * mem_addr)
VBROADCASTSS ymm, m32

## mm256_ceil_pd

`mm256_ceil_pd`

Round the packed double-precision (64-bit) floating-point elements in "a" up to an integer value, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_ceil_pd (__m256d a)
VROUNDPD ymm, ymm/m256, imm8(10)

## mm256_ceil_ps

`mm256_ceil_ps`

Round the packed single-precision (32-bit) floating-point elements in "a" up to an integer value, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_ceil_ps (__m256 a)
VROUNDPS ymm, ymm/m256, imm8(10)

## mm256_cmp_pd

`mm256_cmp_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" based on the comparison operand specified by "imm8", and store the results in "dst".

__m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8)
VCMPPD ymm, ymm, ymm/m256, imm8

## mm256_cmp_ps

`mm256_cmp_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" based on the comparison operand specified by "imm8", and store the results in "dst".

__m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8)
VCMPPS ymm, ymm, ymm/m256, imm8

## mm256_cmpeq_pd

`mm256_cmpeq_pd`

__m256d _mm256_cmpeq_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(0)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpeq_ps

`mm256_cmpeq_ps`

__m256 _mm256_cmpeq_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(0)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpge_pd

`mm256_cmpge_pd`

__m256d _mm256_cmpge_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(13)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpge_ps

`mm256_cmpge_ps`

__m256 _mm256_cmpge_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(13)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpgt_pd

`mm256_cmpgt_pd`

__m256d _mm256_cmpgt_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(14)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpgt_ps

`mm256_cmpgt_ps`

__m256 _mm256_cmpgt_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(14)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmple_pd

`mm256_cmple_pd`

__m256d _mm256_cmple_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(2)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmple_ps

`mm256_cmple_ps`

__m256 _mm256_cmple_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(2)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmplt_pd

`mm256_cmplt_pd`

__m256d _mm256_cmplt_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(1)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmplt_ps

`mm256_cmplt_ps`

__m256 _mm256_cmplt_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(1)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpneq_pd

`mm256_cmpneq_pd`

__m256d _mm256_cmpneq_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(4)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpneq_ps

`mm256_cmpneq_ps`

__m256 _mm256_cmpneq_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(4)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpnge_pd

`mm256_cmpnge_pd`

__m256d _mm256_cmpnge_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(9)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpnge_ps

`mm256_cmpnge_ps`

__m256 _mm256_cmpnge_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(9)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpngt_pd

`mm256_cmpngt_pd`

__m256d _mm256_cmpngt_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(10)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpngt_ps

`mm256_cmpngt_ps`

__m256 _mm256_cmpngt_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(10)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpnle_pd

`mm256_cmpnle_pd`

__m256d _mm256_cmpnle_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(6)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpnle_ps

`mm256_cmpnle_ps`

__m256 _mm256_cmpnle_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(6)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpnlt_pd

`mm256_cmpnlt_pd`

__m256d _mm256_cmpnlt_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(5)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpnlt_ps

`mm256_cmpnlt_ps`

__m256 _mm256_cmpnlt_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(5)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpord_pd

`mm256_cmpord_pd`

__m256d _mm256_cmpord_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(7)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpord_ps

`mm256_cmpord_ps`

__m256 _mm256_cmpord_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(7)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpunord_pd

`mm256_cmpunord_pd`

__m256d _mm256_cmpunord_pd (__m256d a,  __m256d b) CMPPD ymm, ymm/m256, imm8(3)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cmpunord_ps

`mm256_cmpunord_ps`

__m256 _mm256_cmpunord_ps (__m256 a,  __m256 b) CMPPS ymm, ymm/m256, imm8(3)
The above native signature does not exist. We provide this additional overload for completeness.

## mm256_cvtepi32_pd

`mm256_cvtepi32_pd`

Convert packed 32-bit integers in "a" to packed double-precision (64-bit) floating-point elements, and store the results in "dst".

__m256d _mm256_cvtepi32_pd (__m128i a)
VCVTDQ2PD ymm, xmm/m128

## mm256_cvtepi32_ps

`mm256_cvtepi32_ps`

Convert packed 32-bit integers in "a" to packed single-precision (32-bit) floating-point elements, and store the results in "dst".

__m256 _mm256_cvtepi32_ps (__m256i a)
VCVTDQ2PS ymm, ymm/m256

## mm256_cvtpd_epi32

`mm256_cvtpd_epi32`

Convert packed double-precision (64-bit) floating-point elements in "a" to packed 32-bit integers, and store the results in "dst".

__m128i _mm256_cvtpd_epi32 (__m256d a)
VCVTPD2DQ xmm, ymm/m256

## mm256_cvtpd_ps

`mm256_cvtpd_ps`

Convert packed double-precision (64-bit) floating-point elements in "a" to packed single-precision (32-bit) floating-point elements, and store the results in "dst".

__m128 _mm256_cvtpd_ps (__m256d a)
VCVTPD2PS xmm, ymm/m256

## mm256_cvtps_epi32

`mm256_cvtps_epi32`

Convert packed single-precision (32-bit) floating-point elements in "a" to packed 32-bit integers, and store the results in "dst".

__m256i _mm256_cvtps_epi32 (__m256 a)
VCVTPS2DQ ymm, ymm/m256

## mm256_cvtps_pd

`mm256_cvtps_pd`

Convert packed single-precision (32-bit) floating-point elements in "a" to packed double-precision (64-bit) floating-point elements, and store the results in "dst".

__m256d _mm256_cvtps_pd (__m128 a)
VCVTPS2PD ymm, xmm/m128

## mm256_cvttpd_epi32

`mm256_cvttpd_epi32`

Convert packed double-precision (64-bit) floating-point elements in "a" to packed 32-bit integers with truncation, and store the results in "dst".

__m128i _mm256_cvttpd_epi32 (__m256d a)
VCVTTPD2DQ xmm, ymm/m256

## mm256_cvttps_epi32

`mm256_cvttps_epi32`

Convert packed single-precision (32-bit) floating-point elements in "a" to packed 32-bit integers with truncation, and store the results in "dst".

__m256i _mm256_cvttps_epi32 (__m256 a)
VCVTTPS2DQ ymm, ymm/m256

## mm256_div_pd

`mm256_div_pd`

Divide packed double-precision (64-bit) floating-point elements in "a" by packed elements in "b", and store the results in "dst".

__m256d _mm256_div_pd (__m256d a, __m256d b)
VDIVPD ymm, ymm, ymm/m256

## mm256_div_ps

`mm256_div_ps`

Divide packed single-precision (32-bit) floating-point elements in "a" by packed elements in "b", and store the results in "dst".

__m256 _mm256_div_ps (__m256 a, __m256 b)
VDIVPS ymm, ymm, ymm/m256

## mm256_dp_ps

`mm256_dp_ps`

Conditionally multiply the packed single-precision (32-bit) floating-point elements in "a" and "b" using the high 4 bits in "imm8", sum the four products, and conditionally store the sum in "dst" using the low 4 bits of "imm8".

__m256 _mm256_dp_ps (__m256 a, __m256 b, const int imm8)
VDPPS ymm, ymm, ymm/m256, imm8

## mm256_extractf128_pd

`mm256_extractf128_pd`

Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from "a", selected with "imm8", and store the result in "dst".

__m128d _mm256_extractf128_pd (__m256d a, const int imm8)
VEXTRACTF128 xmm/m128, ymm, imm8

## mm256_extractf128_ps

`mm256_extractf128_ps`

Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from "a", selected with "imm8", and store the result in "dst".

__m128 _mm256_extractf128_ps (__m256 a, const int imm8)
VEXTRACTF128 xmm/m128, ymm, imm8

## mm256_extractf128_si256

`mm256_extractf128_si256`

Extract 128 bits (composed of integer data) from "a", selected with "imm8", and store the result in "dst".

__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
VEXTRACTF128 xmm/m128, ymm, imm8

## mm256_floor_pd

`mm256_floor_pd`

Round the packed double-precision (64-bit) floating-point elements in "a" down to an integer value, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_floor_pd (__m256d a)
VROUNDPS ymm, ymm/m256, imm8(9)

## mm256_floor_ps

`mm256_floor_ps`

Round the packed single-precision (32-bit) floating-point elements in "a" down to an integer value, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_floor_ps (__m256 a)
VROUNDPS ymm, ymm/m256, imm8(9)

## mm256_hadd_pd

`mm256_hadd_pd`

Horizontally add adjacent pairs of double-precision (64-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m256d _mm256_hadd_pd (__m256d a, __m256d b)
VHADDPD ymm, ymm, ymm/m256

## mm256_hadd_ps

`mm256_hadd_ps`

Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m256 _mm256_hadd_ps (__m256 a, __m256 b)
VHADDPS ymm, ymm, ymm/m256

## mm256_hsub_pd

`mm256_hsub_pd`

Horizontally subtract adjacent pairs of double-precision (64-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m256d _mm256_hsub_pd (__m256d a, __m256d b)
VHSUBPD ymm, ymm, ymm/m256

## mm256_hsub_ps

`mm256_hsub_ps`

Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m256 _mm256_hsub_ps (__m256 a, __m256 b)
VHSUBPS ymm, ymm, ymm/m256

## mm256_insertf128_pd

`mm256_insertf128_pd`

Copy "a" to "dst", then insert 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from "b" into "dst" at the location specified by "imm8".

__m256d _mm256_insertf128_pd (__m256d a, __m128d b, int imm8)
VINSERTF128 ymm, ymm, xmm/m128, imm8

## mm256_insertf128_ps

`mm256_insertf128_ps`

Copy "a" to "dst", then insert 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from "b" into "dst" at the location specified by "imm8".

__m256 _mm256_insertf128_ps (__m256 a, __m128 b, int imm8)
VINSERTF128 ymm, ymm, xmm/m128, imm8

## mm256_insertf128_si256

`mm256_insertf128_si256`

Copy "a" to "dst", then insert 128 bits from "b" into "dst" at the location specified by "imm8".

__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
VINSERTF128 ymm, ymm, xmm/m128, imm8

## mm256_lddqu_si256

`mm256_lddqu_si256`

Load 256-bits of integer data from unaligned memory into "dst". This intrinsic may perform better than "_mm256_loadu_si256" when the data crosses a cache line boundary.

__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
VLDDQU ymm, m256

## mm256_load_pd

`mm256_load_pd`

Load 256-bits (composed of 4 packed double-precision (64-bit) floating-point elements) from memory into "dst".
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

__m256d _mm256_load_pd (double const * mem_addr)
VMOVAPD ymm, ymm/m256

## mm256_load_ps

`mm256_load_ps`

Load 256-bits (composed of 8 packed single-precision (32-bit) floating-point elements) from memory into "dst".
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

__m256 _mm256_load_ps (float const * mem_addr)
VMOVAPS ymm, ymm/m256

## mm256_load_si256

`mm256_load_si256`

Load 256-bits of integer data from memory into "dst".
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

__m256i _mm256_load_si256 (__m256i const * mem_addr)
VMOVDQA ymm, m256

## mm256_loadu_pd

`mm256_loadu_pd`

Load 256-bits (composed of 4 packed double-precision (64-bit) floating-point elements) from memory into "dst".
	"mem_addr" does not need to be aligned on any particular boundary.

__m256d _mm256_loadu_pd (double const * mem_addr)
VMOVUPD ymm, ymm/m256

## mm256_loadu_ps

`mm256_loadu_ps`

Load 256-bits (composed of 8 packed single-precision (32-bit) floating-point elements) from memory into "dst".
	"mem_addr" does not need to be aligned on any particular boundary.

__m256 _mm256_loadu_ps (float const * mem_addr)
VMOVUPS ymm, ymm/m256

## mm256_loadu_si256

`mm256_loadu_si256`

Load 256-bits of integer data from memory into "dst".
	"mem_addr" does not need to be aligned on any particular boundary.

__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
VMOVDQU ymm, m256

## mm256_maskload_pd

`mm256_maskload_pd`

Load packed double-precision (64-bit) floating-point elements from memory into "dst" using "mask" (elements are zeroed out when the high bit of the corresponding element is not set).

__m256d _mm256_maskload_pd (double const * mem_addr, __m256i mask)
VMASKMOVPD ymm, ymm, m256

## mm256_maskload_ps

`mm256_maskload_ps`

Load packed single-precision (32-bit) floating-point elements from memory into "dst" using "mask" (elements are zeroed out when the high bit of the corresponding element is not set).

__m256 _mm256_maskload_ps (float const * mem_addr, __m256i mask)
VMASKMOVPS ymm, ymm, m256

## mm256_maskstore_pd

`mm256_maskstore_pd`

Store packed double-precision (64-bit) floating-point elements from "a" into memory using "mask".

void _mm256_maskstore_pd (double * mem_addr, __m256i mask, __m256d a)
VMASKMOVPD m256, ymm, ymm

## mm256_maskstore_ps

`mm256_maskstore_ps`

Store packed single-precision (32-bit) floating-point elements from "a" into memory using "mask".

void _mm256_maskstore_ps (float * mem_addr, __m256i mask, __m256 a)
VMASKMOVPS m256, ymm, ymm

## mm256_max_pd

`mm256_max_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b", and store packed maximum values in "dst".

__m256d _mm256_max_pd (__m256d a, __m256d b)
VMAXPD ymm, ymm, ymm/m256

## mm256_max_ps

`mm256_max_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b", and store packed maximum values in "dst".

__m256 _mm256_max_ps (__m256 a, __m256 b)
VMAXPS ymm, ymm, ymm/m256

## mm256_min_pd

`mm256_min_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b", and store packed minimum values in "dst".

__m256d _mm256_min_pd (__m256d a, __m256d b)
VMINPD ymm, ymm, ymm/m256

## mm256_min_ps

`mm256_min_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b", and store packed minimum values in "dst".

__m256 _mm256_min_ps (__m256 a, __m256 b)
VMINPS ymm, ymm, ymm/m256

## mm256_movedup_pd

`mm256_movedup_pd`

Duplicate even-indexed double-precision (64-bit) floating-point elements from "a", and store the results in "dst".

__m256d _mm256_movedup_pd (__m256d a)
VMOVDDUP ymm, ymm/m256

## mm256_movehdup_ps

`mm256_movehdup_ps`

Duplicate odd-indexed single-precision (32-bit) floating-point elements from "a", and store the results in "dst".

__m256 _mm256_movehdup_ps (__m256 a)
VMOVSHDUP ymm, ymm/m256

## mm256_moveldup_ps

`mm256_moveldup_ps`

Duplicate even-indexed single-precision (32-bit) floating-point elements from "a", and store the results in "dst".

__m256 _mm256_moveldup_ps (__m256 a)
VMOVSLDUP ymm, ymm/m256

## mm256_movemask_pd

`mm256_movemask_pd`

Set each bit of mask "dst" based on the most significant bit of the corresponding packed double-precision (64-bit) floating-point element in "a".

int _mm256_movemask_pd (__m256d a)
VMOVMSKPD reg, ymm

## mm256_movemask_ps

`mm256_movemask_ps`

Set each bit of mask "dst" based on the most significant bit of the corresponding packed single-precision (32-bit) floating-point element in "a".

int _mm256_movemask_ps (__m256 a)
VMOVMSKPS reg, ymm

## mm256_mul_pd

`mm256_mul_pd`

Multiply packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256d _mm256_mul_pd (__m256d a, __m256d b)
VMULPD ymm, ymm, ymm/m256

## mm256_mul_ps

`mm256_mul_ps`

Multiply packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256 _mm256_mul_ps (__m256 a, __m256 b)
VMULPS ymm, ymm, ymm/m256

## mm256_or_pd

`mm256_or_pd`

Compute the bitwise OR of packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256d _mm256_or_pd (__m256d a, __m256d b)
VORPD ymm, ymm, ymm/m256

## mm256_or_ps

`mm256_or_ps`

Compute the bitwise OR of packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256 _mm256_or_ps (__m256 a, __m256 b)
VORPS ymm, ymm, ymm/m256

## mm256_permute2f128_pd

`mm256_permute2f128_pd`

Shuffle 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) selected by "imm8" from "a" and "b", and store the results in "dst".

__m256d _mm256_permute2f128_pd (__m256d a, __m256d b, int imm8)
VPERM2F128 ymm, ymm, ymm/m256, imm8

## mm256_permute2f128_ps

`mm256_permute2f128_ps`

Shuffle 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) selected by "imm8" from "a" and "b", and store the results in "dst".

__m256 _mm256_permute2f128_ps (__m256 a, __m256 b, int imm8)
VPERM2F128 ymm, ymm, ymm/m256, imm8

## mm256_permute2f128_si256

`mm256_permute2f128_si256`

Shuffle 128-bits (composed of integer data) selected by "imm8" from "a" and "b", and store the results in "dst".

__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
VPERM2F128 ymm, ymm, ymm/m256, imm8

## mm256_permute_pd

`mm256_permute_pd`

Shuffle double-precision (64-bit) floating-point elements in "a" within 128-bit lanes using the control in "imm8", and store the results in "dst".

__m256d _mm256_permute_pd (__m256d a, int imm8)
VPERMILPD ymm, ymm, imm8

## mm256_permute_ps

`mm256_permute_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" within 128-bit lanes using the control in "imm8", and store the results in "dst".

__m256 _mm256_permute_ps (__m256 a, int imm8)
VPERMILPS ymm, ymm, imm8

## mm256_permutevar_pd

`mm256_permutevar_pd`

Shuffle double-precision (64-bit) floating-point elements in "a" within 128-bit lanes using the control in "b", and store the results in "dst".

__m256d _mm256_permutevar_pd (__m256d a, __m256i b)
VPERMILPD ymm, ymm, ymm/m256

## mm256_permutevar_ps

`mm256_permutevar_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" within 128-bit lanes using the control in "b", and store the results in "dst".

__m256 _mm256_permutevar_ps (__m256 a, __m256i b)
VPERMILPS ymm, ymm, ymm/m256

## mm256_rcp_ps

`mm256_rcp_ps`

Compute the approximate reciprocal of packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m256 _mm256_rcp_ps (__m256 a)
VRCPPS ymm, ymm/m256

## mm256_round_pd1

`mm256_round_pd1`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_round_pd (__m256d a, _MM_FROUND_CUR_DIRECTION)
VROUNDPD ymm, ymm/m256, imm8(4)

## mm256_round_pd1_to_nearest_integer

`mm256_round_pd1_to_nearest_integer`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC)
VROUNDPD ymm, ymm/m256, imm8(8)

## mm256_round_pd1_to_negative_infinity

`mm256_round_pd1_to_negative_infinity`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_NEG_INF | _MM_FROUND_NO_EXC)
VROUNDPD ymm, ymm/m256, imm8(9)

## mm256_round_pd1_to_positive_infinity

`mm256_round_pd1_to_positive_infinity`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_POS_INF | _MM_FROUND_NO_EXC)
VROUNDPD ymm, ymm/m256, imm8(10)

## mm256_round_pd1_to_zero

`mm256_round_pd1_to_zero`

Round the packed double-precision (64-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed double-precision floating-point elements in "dst".

__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)
VROUNDPD ymm, ymm/m256, imm8(11)

## mm256_round_ps

`mm256_round_ps`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_round_ps (__m256 a, _MM_FROUND_CUR_DIRECTION)
VROUNDPS ymm, ymm/m256, imm8(4)

## mm256_round_ps_to_nearest_integer

`mm256_round_ps_to_nearest_integer`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC)
VROUNDPS ymm, ymm/m256, imm8(8)

## mm256_round_ps_to_negative_infinity

`mm256_round_ps_to_negative_infinity`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_NEG_INF | _MM_FROUND_NO_EXC)
VROUNDPS ymm, ymm/m256, imm8(9)

## mm256_round_ps_to_positive_infinity

`mm256_round_ps_to_positive_infinity`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_POS_INF | _MM_FROUND_NO_EXC)
VROUNDPS ymm, ymm/m256, imm8(10)

## mm256_round_ps_to_zero

`mm256_round_ps_to_zero`

Round the packed single-precision (32-bit) floating-point elements in "a" using the "rounding" parameter, and store the results as packed single-precision floating-point elements in "dst".

__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)
VROUNDPS ymm, ymm/m256, imm8(11)

## mm256_rsqrt_ps

`mm256_rsqrt_ps`

Compute the approximate reciprocal square root of packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst". The maximum relative error for this approximation is less than 1.5*2^-12.

__m256 _mm256_rsqrt_ps (__m256 a)
VRSQRTPS ymm, ymm/m256

## mm256_shuffle_pd

`mm256_shuffle_pd`

Shuffle double-precision (64-bit) floating-point elements within 128-bit lanes using the control in "imm8", and store the results in "dst".

__m256d _mm256_shuffle_pd (__m256d a, __m256d b, const int imm8)
VSHUFPD ymm, ymm, ymm/m256, imm8

## mm256_shuffle_ps

`mm256_shuffle_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" within 128-bit lanes using the control in "imm8", and store the results in "dst".

__m256 _mm256_shuffle_ps (__m256 a, __m256 b, const int imm8)
VSHUFPS ymm, ymm, ymm/m256, imm8

## mm256_sqrt_pd

`mm256_sqrt_pd`

Compute the square root of packed double-precision (64-bit) floating-point elements in "a", and store the results in "dst".

__m256d _mm256_sqrt_pd (__m256d a)
VSQRTPD ymm, ymm/m256

## mm256_sqrt_ps

`mm256_sqrt_ps`

Compute the square root of packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst".

__m256 _mm256_sqrt_ps (__m256 a)
VSQRTPS ymm, ymm/m256

## mm256_store_pd

`mm256_store_pd`

Store 256-bits (composed of 4 packed double-precision (64-bit) floating-point elements) from "a" into memory.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

void _mm256_store_pd (double * mem_addr, __m256d a)
VMOVAPD m256, ymm

## mm256_store_ps

`mm256_store_ps`

Store 256-bits (composed of 8 packed single-precision (32-bit) floating-point elements) from "a" into memory.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

void _mm256_store_ps (float * mem_addr, __m256 a)
VMOVAPS m256, ymm

## mm256_store_si256

`mm256_store_si256`

Store 256-bits of integer data from "a" into memory.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
MOVDQA m256, ymm

## mm256_storeu_pd

`mm256_storeu_pd`

Store 256-bits (composed of 4 packed double-precision (64-bit) floating-point elements) from "a" into memory.
	"mem_addr" does not need to be aligned on any particular boundary.

void _mm256_storeu_pd (double * mem_addr, __m256d a)
MOVUPD m256, ymm

## mm256_storeu_ps

`mm256_storeu_ps`

Store 256-bits (composed of 8 packed single-precision (32-bit) floating-point elements) from "a" into memory.
	"mem_addr" does not need to be aligned on any particular boundary.

void _mm256_storeu_ps (float * mem_addr, __m256 a)
MOVUPS m256, ymm

## mm256_storeu_si256

`mm256_storeu_si256`

Store 256-bits of integer data from "a" into memory.
	"mem_addr" does not need to be aligned on any particular boundary.

void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
MOVDQU m256, ymm

## mm256_stream_pd

`mm256_stream_pd`

Store 256-bits (composed of 4 packed double-precision (64-bit) floating-point elements) from "a" into memory using a non-temporal memory hint.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

void _mm256_stream_pd (double * mem_addr, __m256d a)
MOVNTPD m256, ymm

## mm256_stream_ps

`mm256_stream_ps`

Store 256-bits (composed of 8 packed single-precision (32-bit) floating-point elements) from "a" into memory using a non-temporal memory hint.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

void _mm256_stream_ps (float * mem_addr, __m256 a)
MOVNTPS m256, ymm

## mm256_stream_si256

`mm256_stream_si256`

Store 256-bits of integer data from "a" into memory using a non-temporal memory hint.
	"mem_addr" must be aligned on a 32-byte boundary or a general-protection exception may be generated.

void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
VMOVNTDQ m256, ymm

## mm256_sub_pd

`mm256_sub_pd`

Subtract packed double-precision (64-bit) floating-point elements in "b" from packed double-precision (64-bit) floating-point elements in "a", and store the results in "dst".

__m256d _mm256_sub_pd (__m256d a, __m256d b)
VSUBPD ymm, ymm, ymm/m256

## mm256_sub_ps

`mm256_sub_ps`

Subtract packed single-precision (32-bit) floating-point elements in "b" from packed single-precision (32-bit) floating-point elements in "a", and store the results in "dst".

__m256 _mm256_sub_ps (__m256 a, __m256 b)
VSUBPS ymm, ymm, ymm/m256

## mm256_testc_pd

`mm256_testc_pd`

Compute the bitwise AND of 256 bits (representing double-precision (64-bit) floating-point elements) in "a" and "b", producing an intermediate 256-bit value, and set "ZF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "CF" value.

int _mm256_testc_pd (__m256d a, __m256d b)
VTESTPS ymm, ymm/m256

## mm256_testc_ps

`mm256_testc_ps`

Compute the bitwise AND of 256 bits (representing single-precision (32-bit) floating-point elements) in "a" and "b", producing an intermediate 256-bit value, and set "ZF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "CF" value.

int _mm256_testc_ps (__m256 a, __m256 b)
VTESTPS ymm, ymm/m256

## mm256_testc_si256

`mm256_testc_si256`

Compute the bitwise AND of 256 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return the "CF" value.

int _mm256_testc_si256 (__m256i a, __m256i b)
VPTEST ymm, ymm/m256

## mm256_testnzc_pd

`mm256_testnzc_pd`

Compute the bitwise AND of 256 bits (representing double-precision (64-bit) floating-point elements) in "a" and "b", producing an intermediate 256-bit value, and set "ZF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return 1 if both the "ZF" and "CF" values are zero, otherwise return 0.

int _mm256_testnzc_pd (__m256d a, __m256d b)
VTESTPD ymm, ymm/m256

## mm256_testnzc_ps

`mm256_testnzc_ps`

Compute the bitwise AND of 256 bits (representing single-precision (32-bit) floating-point elements) in "a" and "b", producing an intermediate 256-bit value, and set "ZF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return 1 if both the "ZF" and "CF" values are zero, otherwise return 0.

int _mm256_testnzc_ps (__m256 a, __m256 b)
VTESTPS ymm, ymm/m256

## mm256_testnzc_si256

`mm256_testnzc_si256`

Compute the bitwise AND of 256 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return 1 if both the "ZF" and "CF" values are zero, otherwise return 0.

int _mm256_testnzc_si256 (__m256i a, __m256i b)
VPTEST ymm, ymm/m256

## mm256_testz_pd

`mm256_testz_pd`

Compute the bitwise AND of 256 bits (representing double-precision (64-bit) floating-point elements) in "a" and "b", producing an intermediate 256-bit value, and set "ZF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "ZF" value.

int _mm256_testz_pd (__m256d a, __m256d b)
VTESTPD ymm, ymm/m256

## mm256_testz_ps

`mm256_testz_ps`

Compute the bitwise AND of 256 bits (representing single-precision (32-bit) floating-point elements) in "a" and "b", producing an intermediate 256-bit value, and set "ZF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "ZF" value.

int _mm256_testz_ps (__m256 a, __m256 b)
VTESTPS ymm, ymm/m256

## mm256_testz_si256

`mm256_testz_si256`

Compute the bitwise AND of 256 bits (representing integer data) in "a" and "b", and set "ZF" to 1 if the result is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", and set "CF" to 1 if the result is zero, otherwise set "CF" to 0. Return the "ZF" value.

int _mm256_testz_si256 (__m256i a, __m256i b)
VPTEST ymm, ymm/m256

## mm256_unpackhi_pd

`mm256_unpackhi_pd`

Unpack and interleave double-precision (64-bit) floating-point elements from the high half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256d _mm256_unpackhi_pd (__m256d a, __m256d b)
VUNPCKHPD ymm, ymm, ymm/m256

## mm256_unpackhi_ps

`mm256_unpackhi_ps`

Unpack and interleave single-precision (32-bit) floating-point elements from the high half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256 _mm256_unpackhi_ps (__m256 a, __m256 b)
VUNPCKHPS ymm, ymm, ymm/m256

## mm256_unpacklo_pd

`mm256_unpacklo_pd`

Unpack and interleave double-precision (64-bit) floating-point elements from the low half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256d _mm256_unpacklo_pd (__m256d a, __m256d b)
VUNPCKLPD ymm, ymm, ymm/m256

## mm256_unpacklo_ps

`mm256_unpacklo_ps`

Unpack and interleave single-precision (32-bit) floating-point elements from the low half of each 128-bit lane in "a" and "b", and store the results in "dst".

__m256 _mm256_unpacklo_ps (__m256 a, __m256 b)
VUNPCKLPS ymm, ymm, ymm/m256

## mm256_xor_pd

`mm256_xor_pd`

Compute the bitwise XOR of packed double-precision (64-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256d _mm256_xor_pd (__m256d a, __m256d b)
VXORPS ymm, ymm, ymm/m256

## mm256_xor_ps

`mm256_xor_ps`

Compute the bitwise XOR of packed single-precision (32-bit) floating-point elements in "a" and "b", and store the results in "dst".

__m256 _mm256_xor_ps (__m256 a, __m256 b)
VXORPS ymm, ymm, ymm/m256

## mm_broadcast_ss

`mm_broadcast_ss`

Broadcast a single-precision (32-bit) floating-point element from memory to all elements of "dst".

__m128 _mm_broadcast_ss (float const * mem_addr)
VBROADCASTSS xmm, m32

## mm_cmp_pd

`mm_cmp_pd`

Compare packed double-precision (64-bit) floating-point elements in "a" and "b" based on the comparison operand specified by "imm8", and store the results in "dst".

__m128d _mm_cmp_pd (__m128d a, __m128d b, const int imm8)
VCMPPD xmm, xmm, xmm/m128, imm8

## mm_cmp_ps

`mm_cmp_ps`

Compare packed single-precision (32-bit) floating-point elements in "a" and "b" based on the comparison operand specified by "imm8", and store the results in "dst".

__m128 _mm_cmp_ps (__m128 a, __m128 b, const int imm8)
VCMPPS xmm, xmm, xmm/m128, imm8

## mm_cmp_sd

`mm_cmp_sd`

Compare the lower double-precision (64-bit) floating-point element in "a" and "b" based on the comparison operand specified by "imm8", store the result in the lower element of "dst", and copy the upper element from "a" to the upper element of "dst".

__m128d _mm_cmp_sd (__m128d a, __m128d b, const int imm8)
VCMPSS xmm, xmm, xmm/m32, imm8

## mm_cmp_ss

`mm_cmp_ss`

Compare the lower single-precision (32-bit) floating-point element in "a" and "b" based on the comparison operand specified by "imm8", store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cmp_ss (__m128 a, __m128 b, const int imm8)
VCMPSD xmm, xmm, xmm/m64, imm8

## mm_maskload_pd

`mm_maskload_pd`

Load packed double-precision (64-bit) floating-point elements from memory into "dst" using "mask" (elements are zeroed out when the high bit of the corresponding element is not set).

__m128d _mm_maskload_pd (double const * mem_addr, __m128i mask)
VMASKMOVPD xmm, xmm, m128

## mm_maskload_ps

`mm_maskload_ps`

Load packed single-precision (32-bit) floating-point elements from memory into "dst" using "mask" (elements are zeroed out when the high bit of the corresponding element is not set).

__m128 _mm_maskload_ps (float const * mem_addr, __m128i mask)
VMASKMOVPS xmm, xmm, m128

## mm_maskstore_pd

`mm_maskstore_pd`

Store packed double-precision (64-bit) floating-point elements from "a" into memory using "mask".

void _mm_maskstore_pd (double * mem_addr, __m128i mask, __m128d a)
VMASKMOVPD m128, xmm, xmm

## mm_maskstore_ps

`mm_maskstore_ps`

Store packed single-precision (32-bit) floating-point elements from "a" into memory using "mask".

void _mm_maskstore_ps (float * mem_addr, __m128i mask, __m128 a)
VMASKMOVPS m128, xmm, xmm

## mm_permute_pd

`mm_permute_pd`

Shuffle double-precision (64-bit) floating-point elements in "a" using the control in "imm8", and store the results in "dst".

__m128d _mm_permute_pd (__m128d a, int imm8)
VPERMILPD xmm, xmm, imm8

## mm_permute_ps

`mm_permute_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" using the control in "imm8", and store the results in "dst".

__m128 _mm_permute_ps (__m128 a, int imm8)
VPERMILPS xmm, xmm, imm8

## mm_permutevar_pd

`mm_permutevar_pd`

Shuffle double-precision (64-bit) floating-point elements in "a" using the control in "b", and store the results in "dst".

__m128d _mm_permutevar_pd (__m128d a, __m128i b)
VPERMILPD xmm, xmm, xmm/m128

## mm_permutevar_ps

`mm_permutevar_ps`

Shuffle single-precision (32-bit) floating-point elements in "a" using the control in "b", and store the results in "dst".

__m128 _mm_permutevar_ps (__m128 a, __m128i b)
VPERMILPS xmm, xmm, xmm/m128

## mm_testc_pd

`mm_testc_pd`

Compute the bitwise AND of 128 bits (representing double-precision (64-bit) floating-point elements) in "a" and "b", producing an intermediate 128-bit value, and set "ZF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "CF" value.

int _mm_testc_pd (__m128d a, __m128d b)
VTESTPD xmm, xmm/m128

## mm_testc_ps

`mm_testc_ps`

Compute the bitwise AND of 128 bits (representing single-precision (32-bit) floating-point elements) in "a" and "b", producing an intermediate 128-bit value, and set "ZF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "CF" value.

int _mm_testc_ps (__m128 a, __m128 b)
VTESTPS xmm, xmm/m128

## mm_testnzc_pd

`mm_testnzc_pd`

Compute the bitwise AND of 128 bits (representing double-precision (64-bit) floating-point elements) in "a" and "b", producing an intermediate 128-bit value, and set "ZF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return 1 if both the "ZF" and "CF" values are zero, otherwise return 0.

int _mm_testnzc_pd (__m128d a, __m128d b)
VTESTPD xmm, xmm/m128

## mm_testnzc_ps

`mm_testnzc_ps`

Compute the bitwise AND of 128 bits (representing single-precision (32-bit) floating-point elements) in "a" and "b", producing an intermediate 128-bit value, and set "ZF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return 1 if both the "ZF" and "CF" values are zero, otherwise return 0.

int _mm_testnzc_ps (__m128 a, __m128 b)
VTESTPS xmm, xmm/m128

## mm_testz_pd

`mm_testz_pd`

Compute the bitwise AND of 128 bits (representing double-precision (64-bit) floating-point elements) in "a" and "b", producing an intermediate 128-bit value, and set "ZF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "ZF" value.

int _mm_testz_pd (__m128d a, __m128d b)
VTESTPD xmm, xmm/m128

## mm_testz_ps

`mm_testz_ps`

Compute the bitwise AND of 128 bits (representing single-precision (32-bit) floating-point elements) in "a" and "b", producing an intermediate 128-bit value, and set "ZF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "ZF" to 0. Compute the bitwise NOT of "a" and then AND with "b", producing an intermediate value, and set "CF" to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set "CF" to 0. Return the "ZF" value.

int _mm_testz_ps (__m128 a, __m128 b)
VTESTPS xmm, xmm/m128
