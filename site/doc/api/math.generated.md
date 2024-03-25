---
title: Math Functions
url: /doc/api/math/
---

## abs

`abs(x)`

Returns the absolute value of the specified value.

- `x`: The specified value.

### Returns

The absolute value of the x parameter.

### Example

```kalk
>>> abs(-1)
# abs(-1)
out = 1
>>> abs(float4(-1, 1, -2, -3))
# abs(float4(-1, 1, -2, -3))
out = float4(1, 1, 2, 3)
```

## acos

`acos(x)`

Returns the arccosine of the specified value.

- `x`: The specified value. Each component should be a floating-point value within the range of -1 to 1.

### Returns

The arccosine of the x parameter.

### Example

```kalk
>>> acos(-1)
# acos(-1)
out = 3.141592653589793
>>> acos(0)
# acos(0)
out = 1.5707963267948966
>>> acos(1)
# acos(1)
out = 0
>>> acos(float4(-1,0,1,0.5))
# acos(float4(-1, 0, 1, 0.5))
out = float4(3.1415927, 1.5707964, 0, 1.0471976)
```

## acosh

`acosh(x)`

Returns the inverse hyperbolic cosine of a number. The number must be greater than or equal to 1.

- `x`: Any real number equal to or greater than 1.

### Returns

The inverse hyperbolic cosine of the x parameter

### Example

```kalk
>>> acosh(1)
# acosh(1)
out = 0
>>> acosh(10)
# acosh(10)
out = 2.993222846126381
>>> acosh(float4(1,2,4,10))
# acosh(float4(1, 2, 4, 10))
out = float4(0, 1.316958, 2.063437, 2.993223)
```

## all

`all(x)`

Determines if all components of the specified value are non-zero.

- `x`: The specified value.

### Returns

true if all components of the x parameter are non-zero; otherwise, false.

### Remarks

This function is similar to the `any` function.
The `any` function determines if any components of the specified value are non-zero, while the `all` function determines if all components of the specified value are non-zero.

### Example

```kalk
>>> all(bool4(true, false, true, false))
# all(bool4(true, false, true, false))
out = false
>>> all(bool4(true, true, true, true))
# all(bool4(true, true, true, true))
out = true
>>> all([0,1,0,2])
# all([0,1,0,2])
out = false
>>> all([1,1,1,1])
# all([1,1,1,1])
out = true
```

## any

`any(x)`

Determines if any components of the specified value are non-zero.

- `x`: The specified value.

### Returns

true if any components of the x parameter are non-zero; otherwise, false.

### Remarks

This function is similar to the `all` intrinsic function.
The `any` function determines if any components of the specified value are non-zero,
while the `all` function determines if all components of the specified value are non-zero.

### Example

```kalk
>>> any(bool4(true, false, true, false))
# any(bool4(true, false, true, false))
out = true
>>> any(bool4(false, false, false, false))
# any(bool4(false, false, false, false))
out = false
>>> any([0,1,0,2])
# any([0,1,0,2])
out = true
>>> any([0,0,0,0])
# any([0,0,0,0])
out = false
```

## asin

`asin(x)`

Returns the arcsine of the specified value.

- `x`: The specified value. Each component of the x parameter should be within the range of -π/2 to π/2.

### Returns

The arcsine of the x parameter.

### Example

```kalk
>>> asin 0.5
# asin(0.5)
out = 0.5235987755982989
>>> asin float4(-1, 0, 1, 0.5)
# asin(float4(-1, 0, 1, 0.5))
out = float4(-1.5707964, 0, 1.5707964, 0.5235988)
```

## asinh

`asinh(x)`

Returns the inverse hyperbolic sine of a number.

- `x`: The specified value.

### Returns

The inverse hyperbolic sine of the x parameter.

### Example

```kalk
>>> asinh(-1.1752011936438014)
# asinh(-1.1752011936438014)
out = -1
>>> asinh(0)
# asinh(0)
out = 0
>>> asinh(1.1752011936438014)
# asinh(1.1752011936438014)
out = 1
>>> asinh(float4(-1.1752011936438014, 0, 1.1752011936438014, 2))
# asinh(float4(-1.1752011936438014, 0, 1.1752011936438014, 2))
out = float4(-1, 0, 1, 1.4436355)
```

## atan

`atan(x)`

Returns the arctangent of the specified value.

- `x`: The specified value.

### Returns

The arctangent of the x parameter. This value is within the range of -π/2 to π/2.

### Example

```kalk
>>> atan(0.5)
# atan(0.5)
out = 0.4636476090008061
>>> atan(1)
# atan(1)
out = 0.7853981633974483
>>> atan(0)
# atan(0)
out = 0
>>> atan(float4(0,1,2,3))
# atan(float4(0, 1, 2, 3))
out = float4(0, 0.7853982, 1.1071488, 1.2490457)
```

## atan2

`atan2(y,x)`

Returns the arctangent of two values (x,y).

- `y`: The y value.
- `x`: The x value.

### Returns

The arctangent of (y,x).

### Remarks

The signs of the x and y parameters are used to determine the quadrant of the return values within the range of -π to π. The `atan2` function is well-defined for every point other than the origin, even if y equals 0 and x does not equal 0.

### Example

```kalk
>>> atan2(1,1)
# atan2(1, 1)
out = 0.7853981633974483
>>> atan2(1,0)
# atan2(1, 0)
out = 1.5707963267948966
>>> atan2(0,1)
# atan2(0, 1)
out = 0
>>> atan2(float4(1), float4(0,1,-1,2))
# atan2(float4(1), float4(0, 1, -1, 2))
out = float4(1.5707964, 0.7853982, 2.3561945, 0.4636476)
```

## atanh

`atanh(x)`

Returns the inverse hyperbolic tangent of a number.

- `x`: The specified value. Number must be between -1 and 1 (excluding -1 and 1).

### Returns

The inverse hyperbolic tangent of the x parameter

### Example

```kalk
>>> atanh(0)
# atanh(0)
out = 0
>>> atanh(0.5)
# atanh(0.5)
out = 0.5493061443340549
>>> atanh(float4(-0.5, 0, 0.5, 0.8))
# atanh(float4(-0.5, 0, 0.5, 0.8))
out = float4(-0.54930615, 0, 0.54930615, 1.0986123)
```

## ceil

`ceil(x)`

Returns the smallest integer value that is greater than or equal to the specified value.

- `x`: The specified input.

### Returns

The smallest integer value (returned as a floating-point type) that is greater than or equal to the x parameter.

### Example

```kalk
>>> ceil(0.2); ceil(1.5); ceil(10.7)
# ceil(0.2); ceil(1.5); ceil(10.7)
out = 1
out = 2
out = 11
>>> ceil(-0.2); ceil(-1.5); ceil(-10.7)
# ceil(-0.2); ceil(-1.5); ceil(-10.7)
out = -0
out = -1
out = -10
```

## clamp

`clamp(x,min,max)`

Clamps the specified value to the specified minimum and maximum range.

- `x`: A value to clamp.
- `min`: The specified minimum range.
- `max`: The specified maximum range.

### Returns

The clamped value for the x parameter.

### Remarks

For values of -inf or inf, clamp will behave as expected. However for values of `nan`, the results are undefined.

### Example

```kalk
>>> clamp(-1, 0, 1)
# clamp(-1, 0, 1)
out = 0
>>> clamp(2, 0, 1)
# clamp(2, 0, 1)
out = 1
>>> clamp(0.5, 0, 1)
# clamp(0.5, 0, 1)
out = 0.5
>>> clamp(float4(0, 1, -2, 3), float4(0, -1, 3, 4), float4(1, 2, 5, 6))
# clamp(float4(0, 1, -2, 3), float4(0, -1, 3, 4), float4(1, 2, 5, 6))
out = float4(0, 1, 3, 4)
```

## cos

`cos(x)`

Returns the cosine of the specified value.

- `x`: The specified value, in radians.

### Returns

The cosine of the x parameter.

### Example

```kalk
>>> cos 0.5
# cos(0.5)
out = 0.8775825618903728
>>> cos float4(pi, pi/2, 0, 0.5)
# cos(float4(pi, pi / 2, 0, 0.5))
out = float4(-1, -4.371139E-08, 1, 0.87758255)
```

## cosh

`cosh(x)`

Returns the hyperbolic cosine of the specified value.

- `x`: The specified value, in radians.

### Returns

The hyperbolic cosine of the x parameter.

### Example

```kalk
>>> cosh(-1)
# cosh(-1)
out = 1.5430806348152437
>>> cosh(1)
# cosh(1)
out = 1.5430806348152437
>>> cosh(0)
# cosh(0)
out = 1
>>> cosh(float4(-1, 1, 0, 2))
# cosh(float4(-1, 1, 0, 2))
out = float4(1.5430807, 1.5430807, 1, 3.7621956)
```

## degrees

`degrees`

Converts the specified value from radians to degrees.

### Returns

The x parameter converted from radians to degrees.

### Example

```kalk
>>> degrees(pi/2)
# degrees(pi / 2)
out = 90
>>> degrees(pi)
# degrees(pi)
out = 180
```

## e

`e`

Defines the natural logarithmic base. e = 2.71828182845905

### Example

```kalk
>>> e
# e
out = 2.718281828459045
```

## exp

`exp(x)`

Returns the base-e exponential, or e^x, of the specified value.

- `x`: The specified value.

### Returns

The base-e exponential of the x parameter.

### Example

```kalk
>>> exp(0)
# exp(0)
out = 1
>>> exp(1)
# exp(1)
out = 2.718281828459045
>>> exp(float4(0,1,2,3))
# exp(float4(0, 1, 2, 3))
out = float4(1, 2.7182817, 7.389056, 20.085537)
```

## exp2

`exp2(x)`

Returns the base 2 exponential, or 2^x, of the specified value.

- `x`: The specified value.

### Returns

The base-2 exponential of the x parameter.

### Example

```kalk
>>> exp2(0)
# exp2(0)
out = 1
>>> exp2(1)
# exp2(1)
out = 2
>>> exp2(4)
# exp2(4)
out = 16
>>> exp2(float4(0,1,2,3))
# exp2(float4(0, 1, 2, 3))
out = float4(1, 2, 4, 8)
```

## fib

`fib(x)`

Calculates the fibonacci number for the specified input.

- `x`: The input number.

### Returns

The fibonacci number.

### Example

```kalk
>>> fib 50
# fib(50)
out = 12_586_269_025
```

## floor

`floor(x)`

Returns the largest integer that is less than or equal to the specified value.

- `x`: The specified value.

### Returns

The largest integer value (returned as a floating-point type) that is less than or equal to the x parameter.

### Example

```kalk
>>> floor(0.2); floor(1.5); floor(10.7)
# floor(0.2); floor(1.5); floor(10.7)
out = 0
out = 1
out = 10
>>> floor(-0.2); floor(-1.5); floor(-10.7)
# floor(-0.2); floor(-1.5); floor(-10.7)
out = -1
out = -2
out = -11
```

## fmod

`fmod(x,y)`

Returns the floating-point remainder of x/y.

- `x`: The floating-point dividend.
- `y`: The floating-point divisor.

### Returns

The floating-point remainder of the x parameter divided by the y parameter.

### Remarks

The floating-point remainder is calculated such that x = i * y + f, where i is an integer, f has the same sign as x, and the absolute value of f is less than the absolute value of y.

### Example

```kalk
>>> fmod(2.5, 2)
# fmod(2.5, 2)
out = 0.5
>>> fmod(2.5, 3)
# fmod(2.5, 3)
out = 2.5
>>> fmod(-1.5, 1)
# fmod(-1.5, 1)
out = -0.5
>>> fmod(float4(1.5, 1.2, -2.3, -4.6), 0.2)
# fmod(float4(1.5, 1.2, -2.3, -4.6), 0.2)
out = float4(0.09999998, 2.9802322E-08, -0.09999992, -0.19999984)
```

## frac

`frac(x)`

Returns the fractional (or decimal) part of x; which is greater than or equal to 0 and less than 1.

- `x`: The specified value.

### Returns

The fractional part of the x parameter.

### Example

```kalk
>>> frac(1.25)
# frac(1.25)
out = 0.25
>>> frac(10.5)
# frac(10.5)
out = 0.5
>>> frac(-1.75)
# frac(-1.75)
out = 0.25
>>> frac(-10.25)
# frac(-10.25)
out = 0.75
>>> frac(float4(1.25, 10.5, -1.75, -10.25))
# frac(float4(1.25, 10.5, -1.75, -10.25))
out = float4(0.25, 0.5, 0.25, 0.75)
```

## i

`i`

Defines the imaginary part of a complex number.

### Returns

A complex number.

### Example

```kalk
>>> 1 + 2i
# 1 + 2 * i
out = 1 + 2i
>>> i ^ 3
# i ^ 3
out = i
```

## imag

`imag(x)`

Returns the imaginary part of the complex number.

- `x`: A complex number.

### Returns

The imaginary part of the parameter x complex number.

### Example

```kalk
>>> imag(1.5 + 2.5i)
# imag(1.5 + 2.5 * i)
out = 2.5
```

## inf

`inf`

Defines the infinity constant for a double.

### Example

```kalk
>>> inf
# inf
out = inf
```

## isfinite

`isfinite(x)`

Determines if the specified floating-point value is finite.

- `x`: The specified value.

### Returns

Returns a value of the same size as the input, with a value set to `true` if the x parameter is finite; otherwise `false`.

### Example

```kalk
>>> isfinite(1)
# isfinite(1)
out = true
>>> isfinite(nan)
# isfinite(nan)
out = false
>>> isfinite(inf)
# isfinite(inf)
out = false
>>> isfinite(float4(1, -10.5, inf, nan))
# isfinite(float4(1, -10.5, inf, nan))
out = bool4(true, true, false, false)
```

## isinf

`isinf(x)`

Determines if the specified value is infinite.

- `x`: The specified value.

### Returns

Returns a value of the same size as the input, with a value set to `true` if the x parameter is +inf or -inf. Otherwise, `false`.

### Example

```kalk
>>> isinf(1)
# isinf(1)
out = false
>>> isinf(inf)
# isinf(inf)
out = true
>>> isinf(float4(1, -10.5, inf, nan))
# isinf(float4(1, -10.5, inf, nan))
out = bool4(false, false, true, false)
```

## isnan

`isnan(x)`

Determines if the specified value is `nan`.

- `x`: The specified value.

### Returns

Returns a value of the same size as the input, with a value set to `true` if the x parameter is `nan`. Otherwise, `false`.

### Example

```kalk
>>> isnan(1)
# isnan(1)
out = false
>>> isnan(inf)
# isnan(inf)
out = false
>>> isnan(nan)
# isnan(nan)
out = true
>>> isnan(float4(1, -10.5, inf, nan))
# isnan(float4(1, -10.5, inf, nan))
out = bool4(false, false, false, true)
```

## lerp

`lerp(x,y,s)`

Performs a linear interpolation.

- `x`: The first-floating point value.
- `y`: The second-floating point value.
- `s`: A value that linearly interpolates between the x parameter and the y parameter.

### Returns

The result of the linear interpolation.

### Example

```kalk
>>> lerp(0, 10, 0.5)
# lerp(0, 10, 0.5)
out = 5
>>> lerp(rgb("AliceBlue").xyz, rgb("Green").xyz, 0.5)
# lerp(rgb("AliceBlue").xyz, rgb("Green").xyz, 0.5)
out = float3(0.47058824, 0.7372549, 0.5)
```

## log

`log(x)`

Returns the base-e logarithm of the specified value.

- `x`: The specified value.

### Returns

The base-e logarithm of the x parameter. If the x parameter is negative, this function returns indefinite. If the x parameter is 0, this function returns `-inf`.

### Example

```kalk
>>> log 1
# log(1)
out = 0
>>> log 2
# log(2)
out = 0.6931471805599453
>>> log 0
# log(0)
out = -inf
>>> log float4(0,1,2,3)
# log(float4(0, 1, 2, 3))
out = float4(-inf, 0, 0.6931472, 1.0986123)
```

## log10

`log10(x)`

Returns the base-10 logarithm of the specified value.

- `x`: The specified value.

### Returns

The base-10 logarithm of the x parameter. If the x parameter is negative, this function returns indefinite. If the x is 0, this function returns -inf.

### Example

```kalk
>>> log10 0
# log10(0)
out = -inf
>>> log10 10
# log10(10)
out = 1
>>> log10 100
# log10(100)
out = 2
>>> log10 1001
# log10(1001)
out = 3.000434077479319
>>> log10(float4(0,10,100,1001))
# log10(float4(0, 10, 100, 1001))
out = float4(-inf, 1, 2, 3.0004342)
```

## log2

`log2(x)`

Returns the base-2 logarithm of the specified value.

- `x`: The specified value.

### Returns

The base-2 logarithm of the x parameter. If the x parameter is negative, this function returns indefinite. If the x parameter is 0, this function returns -inf.

### Example

```kalk
>>> log2 0
# log2(0)
out = -inf
>>> log2 8
# log2(8)
out = 3
>>> log2 129
# log2(129)
out = 7.011227255423254
>>> log2 float4(0, 2, 16, 257)
# log2(float4(0, 2, 16, 257))
out = float4(-inf, 1, 4, 8.005625)
```

## max

`max(x,y)`

Selects the greater of x and y.

- `x`: The x input value.
- `y`: The y input value.

### Returns

The x or y parameter, whichever is the largest value.

### Example

```kalk
>>> max(-5, 6)
# max(-5, 6)
out = 6
>>> max(1, 0)
# max(1, 0)
out = 1
>>> max(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
# max(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
out = float4(1, 1, 3, 3)
```

## min

`min(x,y)`

Selects the lesser of x and y.

- `x`: The x input value.
- `y`: The y input value.

### Returns

The x or y parameter, whichever is the smallest value.

### Example

```kalk
>>> min(-5, 6)
# min(-5, 6)
out = -5
>>> min(1, 0)
# min(1, 0)
out = 0
>>> min(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
# min(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
out = float4(0, 0, 2, 2)
```

## modf

`modf(x)`

Splits the value x into fractional and integer parts, each of which has the same sign as x.

- `x`: The input value.

### Returns

The signed-fractional portion of x.

### Example

```kalk
>>> modf(1.5)
# modf(1.5)
out = [1, 0.5]
>>> modf(float2(-1.2, 3.4))
# modf(float2(-1.2, 3.4))
out = [float2(-1, 3), float2(-0.20000005, 0.4000001)]
```

## nan

`nan`

Defines the "Not a Number" constant for a double.

### Example

```kalk
>>> nan
# nan
out = nan
```

## phase

`phase(x)`

Returns the phase of the complex number.

- `x`: A complex number.

### Returns

The phase of the parameter x complex number.

### Example

```kalk
>>> phase(1.5 + 2.5i)
# phase(1.5 + 2.5 * i)
out = 1.0303768265243125
```

## pi

`pi`

Defines the PI constant. pi = 3.14159265358979

### Example

```kalk
>>> pi
# pi
out = 3.141592653589793
```

## pow

`pow(x,y)`

Returns the specified value raised to the specified power.

- `x`: The specified value.
- `y`: The specified power.

### Returns

The x parameter raised to the power of the y parameter.

### Example

```kalk
>>> pow(1.5, 3.5)
# pow(1.5, 3.5)
out = 4.133513940946613
>>> pow(2, 4)
# pow(2, 4)
out = 16
>>> pow(float4(1,2,3,4), 4)
# pow(float4(1, 2, 3, 4), 4)
out = float4(1, 16, 81, 256)
>>> pow(float4(1..4), float4(5..8))
# pow(float4(1..4), float4(5..8))
out = float4(1, 64, 2187, 65536)
```

## radians

`radians(x)`

Converts the specified value from degrees to radians.

- `x`: The specified value in degrees.

### Returns

The x parameter converted from degrees to radians.

### Example

```kalk
>>> radians(90)
# radians(90)
out = 1.5707963267948966
>>> radians(180)
# radians(180)
out = 3.141592653589793
```

## real

`real(x)`

Returns the real part of the complex number.

- `x`: A complex number.

### Returns

The real part of the parameter x complex number.

### Example

```kalk
>>> real(1.5 + 2.5i)
# real(1.5 + 2.5 * i)
out = 1.5
```

## rnd

`rnd(x?)`

Returns a random value.

- `x`: A value to create random values for.

### Returns

A random value or a random value of the x parameter.

### Example

```kalk
>>> seed(0); rnd
# seed(0); rnd
out = 0.7262432699679598
>>> rnd
# rnd
out = 0.8173253595909687
>>> rnd(float4)
# rnd(float4)
out = float4(0.7680227, 0.5581612, 0.20603316, 0.5588848)
```

## round

`round(x)`

Rounds the specified value to the nearest integer.

- `x`: The specified value.

### Returns

The x parameter, rounded to the nearest integer within a floating-point type.

### Example

```kalk
>>> round(0.2); round(1.5); round(10.7)
# round(0.2); round(1.5); round(10.7)
out = 0
out = 2
out = 11
>>> round(-0.2); round(-1.5); round(-10.7)
# round(-0.2); round(-1.5); round(-10.7)
out = -0
out = -2
out = -11
```

## rsqrt

`rsqrt(x)`

Returns the reciprocal of the square root of the specified value.

- `x`: The specified value.

### Returns

The reciprocal of the square root of the x parameter.

### Remarks

This function uses the following formula: 1 / sqrt(x).

### Example

```kalk
>>> rsqrt(1)
# rsqrt(1)
out = 1
>>> rsqrt(2)
# rsqrt(2)
out = 0.7071067811865475
>>> rsqrt(float4(1,2,3,4))
# rsqrt(float4(1, 2, 3, 4))
out = float4(1, 0.70710677, 0.57735026, 0.5)
```

## saturate

`saturate(x)`

Clamps the specified value within the range of 0 to 1.

- `x`: The specified value.

### Returns

The x parameter, clamped within the range of 0 to 1.

### Example

```kalk
>>> saturate(10)
# saturate(10)
out = 1
>>> saturate(-10)
# saturate(-10)
out = 0
>>> saturate(float4(-1, 0.5, 1, 2))
# saturate(float4(-1, 0.5, 1, 2))
out = float4(0, 0.5, 1, 1)
```

## seed

`seed(x?)`

Setup the seed function for rnd. The default seed is random.

- `x`: An original seed value for the `rnd` function.

### Remarks

The x is not specified, it will generate a random seed automatically.

### Example

```kalk
>>> seed(0); rnd
# seed(0); rnd
out = 0.7262432699679598
>>> seed(1); rnd
# seed(1); rnd
out = 0.24866858415709278
```

## sign

`sign(x)`

Returns an integer that indicates the sign of a number.

- `x`: A signed number.

### Returns

A number that indicates the sign of x:
 - -1 if x is less than zero
 - 0 if x is equal to zero
 - 1 if x is greater than zero.

### Example

```kalk
>>> sign(-5); sign(0); sign(2.3)
# sign(-5); sign(0); sign(2.3)
out = -1
out = 0
out = 1
>>> sign float4(-1, 2, 0, 1.5)
# sign(float4(-1, 2, 0, 1.5))
out = float4(-1, 1, 0, 1)
```

## sin

`sin(x)`

Returns the sine of the specified value.

- `x`: The specified value, in radians.

### Returns

The sine of the x parameter.

### Example

```kalk
>>> sin 0.5
# sin(0.5)
out = 0.479425538604203
>>> sin float4(pi, pi/2, 0, 0.5)
# sin(float4(pi, pi / 2, 0, 0.5))
out = float4(-8.742278E-08, 1, 0, 0.47942555)
```

## sinh

`sinh(x)`

Returns the hyperbolic sine of the specified value.

- `x`: The specified value, in radians.

### Returns

The hyperbolic sine of the x parameter.

### Example

```kalk
>>> sinh(-1)
# sinh(-1)
out = -1.1752011936438014
>>> sinh(0)
# sinh(0)
out = 0
>>> sinh(1)
# sinh(1)
out = 1.1752011936438014
>>> sinh(float4(-1, 1, 0, 2))
# sinh(float4(-1, 1, 0, 2))
out = float4(-1.1752012, 1.1752012, 0, 3.6268604)
```

## smoothstep

`smoothstep(min,max,x)`

Returns a smooth Hermite interpolation between 0 and 1, if x is in the range [min, max].

- `min`: The minimum range of the x parameter.
- `max`: The maximum range of the x parameter.
- `x`: The specified value to be interpolated.

### Returns

Returns 0 if x is less than min; 1 if x is greater than max; otherwise, a value between 0 and 1 if x is in the range [min, max].

### Remarks

Use the smoothstep function to create a smooth transition between two values. For example, you can use this function to blend two colors smoothly.

### Example

```kalk
>>> smoothstep(float4(0), float4(1), float4(-0.5))
# smoothstep(float4(0), float4(1), float4(-0.5))
out = float4(0, 0, 0, 0)
>>> smoothstep(float4(0), float4(1), float4(1.5))
# smoothstep(float4(0), float4(1), float4(1.5))
out = float4(1, 1, 1, 1)
>>> smoothstep(float4(0), float4(1), float4(0.5))
# smoothstep(float4(0), float4(1), float4(0.5))
out = float4(0.5, 0.5, 0.5, 0.5)
>>> smoothstep(float4(0), float4(1), float4(0.9))
# smoothstep(float4(0), float4(1), float4(0.9))
out = float4(0.972, 0.972, 0.972, 0.972)
```

## sqrt

`sqrt(x)`

Returns the square root of the specified floating-point value, per component.

- `x`: The specified floating-point value.

### Returns

The square root of the x parameter, per component.

### Example

```kalk
>>> sqrt(1)
# sqrt(1)
out = 1
>>> sqrt(2)
# sqrt(2)
out = 1.4142135623730951
>>> sqrt(float4(1,2,3,4))
# sqrt(float4(1, 2, 3, 4))
out = float4(1, 1.4142135, 1.7320508, 2)
```

## step

`step(y,x)`

Compares two values, returning 0 or 1 based on which value is greater.

- `y`: The first floating-point value to compare.
- `x`: The second floating-point value to compare.

### Returns

1 if the x parameter is greater than or equal to the y parameter; otherwise, 0.

### Remarks

This function uses the following formula: (x >= y) ? 1 : 0. The function returns either 0 or 1 depending on whether the x parameter is greater than the y parameter. To compute a smooth interpolation between 0 and 1, use the `smoothstep` function.

### Example

```kalk
>>> step(1, 5)
# step(1, 5)
out = 1
>>> step(5, 1)
# step(5, 1)
out = 0
>>> step(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
# step(float4(0, 1, 2, 3), float4(1, 0, 3, 2))
out = float4(1, 0, 1, 0)
>>> step(-10, 5)
# step(-10, 5)
out = 1
>>> step(5.5, -10.5)
# step(5.5, -10.5)
out = 0
```

## sum

`sum(value,values)`

Performs the summation of the specified value.

- `value`: The specified value.
- `values`: Additional values.

### Returns

The summation of the values.

### Example

```kalk
>>> sum(1,2,3,4)
# sum(1, 2, 3, 4)
out = 10
>>> sum(float4(1..4))
# sum(float4(1..4))
out = 10
>>> sum(float4(1..4), float4(5..8))
# sum(float4(1..4), float4(5..8))
out = float4(15, 16, 17, 18)
>>> sum("a", "b", "c")
# sum("a", "b", "c")
out = "abc"
>>> sum(["a", "b", "c"])
# sum(["a", "b", "c"])
out = "abc"
```

## tan

`tan(x)`

Returns the tangent of the specified value.

- `x`: The specified value, in radians.

### Returns

The tangent of the x parameter.

### Example

```kalk
>>> tan(0.5)
# tan(0.5)
out = 0.5463024898437905
>>> tan(1)
# tan(1)
out = 1.5574077246549023
>>> tan float4(1, 2, 3, 4)
# tan(float4(1, 2, 3, 4))
out = float4(1.5574077, -2.1850398, -0.14254655, 1.1578213)
```

## tanh

`tanh(x)`

Returns the hyperbolic tangent of the specified value.

- `x`: The specified value, in radians.

### Returns

The hyperbolic tangent of the x parameter.

### Example

```kalk
>>> tanh(0)
# tanh(0)
out = 0
>>> tanh(1)
# tanh(1)
out = 0.7615941559557649
>>> tanh(2)
# tanh(2)
out = 0.9640275800758169
>>> tanh(float4(0, 1, 2, 3))
# tanh(float4(0, 1, 2, 3))
out = float4(0, 0.7615942, 0.9640276, 0.9950548)
```

## trunc

`trunc(x)`

Truncates a floating-point value to the integer component.

- `x`: The specified input.

### Returns

The input value truncated to an integer component.

### Remarks

This function truncates a floating-point value to the integer component. Given a floating-point value of 1.6, the trunc function would return 1.0, where as the round function would return 2.0.

### Example

```kalk
>>> trunc(0.2); trunc(1.5); trunc(10.7)
# trunc(0.2); trunc(1.5); trunc(10.7)
out = 0
out = 1
out = 10
>>> trunc(-0.2); trunc(-1.5); trunc(-10.7)
# trunc(-0.2); trunc(-1.5); trunc(-10.7)
out = -0
out = -1
out = -10
```
