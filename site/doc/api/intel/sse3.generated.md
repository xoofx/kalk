---
title: Intel Sse3 Intrinsics
url: /doc/api/intel/sse3/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `Sse3` features.

{{end}}


## mm_addsub_pd

`mm_addsub_pd`

Alternatively add and subtract packed double-precision (64-bit) floating-point elements in "a" to/from packed elements in "b", and store the results in "dst".

__m128d _mm_addsub_pd (__m128d a, __m128d b)
ADDSUBPD xmm, xmm/m128

## mm_addsub_ps

`mm_addsub_ps`

Alternatively add and subtract packed single-precision (32-bit) floating-point elements in "a" to/from packed elements in "b", and store the results in "dst".

__m128 _mm_addsub_ps (__m128 a, __m128 b)
ADDSUBPS xmm, xmm/m128

## mm_hadd_pd

`mm_hadd_pd`

Horizontally add adjacent pairs of double-precision (64-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m128d _mm_hadd_pd (__m128d a, __m128d b)
HADDPD xmm, xmm/m128

## mm_hadd_ps

`mm_hadd_ps`

Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m128 _mm_hadd_ps (__m128 a, __m128 b)
HADDPS xmm, xmm/m128

## mm_hsub_pd

`mm_hsub_pd`

Horizontally subtract adjacent pairs of double-precision (64-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m128d _mm_hsub_pd (__m128d a, __m128d b)
HSUBPD xmm, xmm/m128

## mm_hsub_ps

`mm_hsub_ps`

Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in "a" and "b", and pack the results in "dst".

__m128 _mm_hsub_ps (__m128 a, __m128 b)
HSUBPS xmm, xmm/m128

## mm_lddqu_si128

`mm_lddqu_si128`

Load 128-bits of integer data from unaligned memory into "dst". This intrinsic may perform better than "_mm_loadu_si128" when the data crosses a cache line boundary.

__m128i _mm_lddqu_si128 (__m128i const* mem_addr)
LDDQU xmm, m128

## mm_loaddup_pd

`mm_loaddup_pd`

Load a double-precision (64-bit) floating-point element from memory into both elements of "dst".

__m128d _mm_loaddup_pd (double const* mem_addr)
MOVDDUP xmm, m64

## mm_movedup_pd

`mm_movedup_pd`

Duplicate the low double-precision (64-bit) floating-point element from "a", and store the results in "dst".

__m128d _mm_movedup_pd (__m128d a)
MOVDDUP xmm, xmm/m64

## mm_movehdup_ps

`mm_movehdup_ps`

Duplicate odd-indexed single-precision (32-bit) floating-point elements from "a", and store the results in "dst".

__m128 _mm_movehdup_ps (__m128 a)
MOVSHDUP xmm, xmm/m128

## mm_moveldup_ps

`mm_moveldup_ps`

Duplicate even-indexed single-precision (32-bit) floating-point elements from "a", and store the results in "dst".

__m128 _mm_moveldup_ps (__m128 a)
MOVSLDUP xmm, xmm/m128
