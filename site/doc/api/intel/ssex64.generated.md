---
title: Intel SseX64 Intrinsics
url: /doc/api/intel/ssex64/
---

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
These intrinsic functions are only available if your CPU supports `SseX64` features.

{{end}}


## mm_cvtsi64_ss

`mm_cvtsi64_ss`

Convert the 64-bit integer "b" to a single-precision (32-bit) floating-point element, store the result in the lower element of "dst", and copy the upper 3 packed elements from "a" to the upper elements of "dst".

__m128 _mm_cvtsi64_ss (__m128 a, __int64 b)
CVTSI2SS xmm, reg/m64

## mm_cvtss_si64

`mm_cvtss_si64`

Convert the lower single-precision (32-bit) floating-point element in "a" to a 64-bit integer, and store the result in "dst".

__int64 _mm_cvtss_si64 (__m128 a)
CVTSS2SI r64, xmm/m32

## mm_cvttss_si64

`mm_cvttss_si64`

Convert the lower single-precision (32-bit) floating-point element in "a" to a 64-bit integer with truncation, and store the result in "dst".

__int64 _mm_cvttss_si64 (__m128 a)
CVTTSS2SI r64, xmm/m32
