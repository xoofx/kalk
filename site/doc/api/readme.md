---
title: API Reference
---

This is the API



```kalk
>>> help
# help [name]
#
# General
    - alias, aliases, clear, clipboard, cls, config, del, display, echo, eval, exit,
      help, history, list, load, out, out2clipboard, print, printh, reset, shortcut,
      shortcuts, version

# Math Functions
    - abs, acos, acosh, all, any, asin, asinh, atan, atan2, atanh, ceil, clamp, cos,
      cosh, degrees, e, exp, exp2, fib, floor, fmod, frac, i, imag, inf, isfinite,
      isinf, isnan, lerp, log, log10, log2, max, min, modf, nan, phase, pi, pow,
      radians, real, rnd, round, rsqrt, saturate, seed, sign, sin, sinh, smoothstep,
      sqrt, step, sum, tan, tanh, trunc

# Math Vector/Matrix Functions
    - col, cross, determinant, diag, dot, identity, inverse, length, mul, normalize,
      row, transpose

# Misc Functions
    - ascii, bin, colors, contains, date, guid, hex, insert_at, keys, lines,
      remove_at, replace, size, slice, utf16, utf32, utf8, values

# Misc Memory Functions
    - asbytes, asdouble, asfloat, asint, aslong, asuint, asulong, bitcast,
      bytebuffer, countbits, firstbithigh, firstbitlow, malloc, reversebits

# Modules (e.g `import Files`)
    - All, Csv, Currencies, Files, HardwareIntrinsics, StandardUnits, Strings, Web

# Type Constructors
    - bool, byte, double, float, int, long, sbyte, short, uint, ulong, ushort

# Type Matrix Constructors
    - bool2x2, bool2x3, bool2x4, bool3x2, bool3x3, bool3x4, bool4x2, bool4x3,
      bool4x4, double2x2, double2x3, double2x4, double3x2, double3x3, double3x4,
      double4x2, double4x3, double4x4, float2x2, float2x3, float2x4, float3x2,
      float3x3, float3x4, float4x2, float4x3, float4x4, int2x2, int2x3, int2x4,
      int3x2, int3x3, int3x4, int4x2, int4x3, int4x4, matrix

# Type Vector Constructors
    - bool16, bool2, bool3, bool4, bool8, byte16, byte32, byte64, double2, double3,
      double4, double8, float16, float2, float3, float4, float8, int16, int2, int3,
      int4, int8, long2, long3, long4, long8, rgb, rgba, sbyte16, sbyte32, sbyte64,
      short16, short2, short32, short4, short8, uint16, uint2, uint3, uint4, uint8,
      ulong2, ulong3, ulong4, ulong8, ushort16, ushort2, ushort32, ushort4, ushort8,
      vector

# Unit Functions
    - to, unit, units

>>> for x in 1..10; 1 + cos 2x; end
# for x in 1..10; 1 + cos(2 * x); end
out = 0.5838531634528576
out = 0.34635637913638806
out = 1.9601702866503659
out = 0.8544999661913865
out = 0.16092847092354756
out = 1.8438539587324922
out = 1.1367372182078337
out = 0.04234051967661534
out = 1.6603167082440802
out = 1.408082061813392

null, true, false

​​This is an error

```
