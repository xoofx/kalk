---
title: Intel Hardware Intrinsics
---

Module with Intel CPU Hardware intrinsics.

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import HardwareIntrinsics
```

{{NOTE do}}
Depending on the characteristics of your CPU (e.g `AVX2`, `SSE3`...), this module will import only the intrinsic functions supported by your CPU.
{{end}}

## Usage

Let's take the example of the instruction [`mm_or_ps`](/doc/api/intel/sse/#mm_or_ps) which allows to perform a OR of 4 x int32:

```kalk
# mm_or_ps
#
#   Compute the bitwise OR of packed single-precision (32-bit) floating-point 
#   elements in "a" and "b", and store the results in "dst".
#
#   __m128 _mm_or_ps (__m128 a,  __m128 b)
#   ORPS xmm, xmm/m128
```

The arguments `__m128` in the Intel documentation show that the function is expecting a 128-bit vector.

In `kalk`, a 128-bit vector is represented by e.g `bool4`, or `int4` or `float4` or `byte16` (and more). You can pass these vectors directly to `mm_or_ps`:

```kalk
>>> mm_or_ps(int4(1,2,3,4), int4(5,6,7,8))
# mm_or_ps(int4(1, 2, 3, 4), int4(5, 6, 7, 8))
out = float4(7E-45, 8E-45, 1E-44, 1.7E-44)
```

Note that the result is returned using `float4`. This is because `m128` types is by default converted to a `float4` in `kalk`.
But you can easily bitcast it to int4:

```kalk
>>> bitcast(int4, out)
# bitcast(int4, out)
out = int4(5, 6, 7, 12)
```

Let's use a similar example with [`mm_blend_ps`](/doc/api/intel/sse41/#mm_blend_ps):

```kalk
>>> bitcast(int4, mm_blend_ps(int4(1,2,3,4), int4(5,6,7,8), 0b1010))
# bitcast(int4, mm_blend_ps(int4(1, 2, 3, 4), int4(5, 6, 7, 8), 10))
out = int4(1, 6, 3, 8)
```

Or for example using [`mm_extract_epi8`](/doc/api/intel/sse41/#mm_extract_epi8):

```kalk
>>> mm_extract_epi8(int4(1,2,3,4), 0)
# mm_extract_epi8(int4(1, 2, 3, 4), 0)
out = 1
>>> mm_extract_epi8(int4(1,2,3,4), 4)
# mm_extract_epi8(int4(1, 2, 3, 4), 4)
out = 2
```