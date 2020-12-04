---
title: Language Syntax
---

## Overview

The language used by `kalk` is a **full featured language** with types, expressions, control flows, functions... with an easy and fluent syntax to work with.

In this document, you will find more details about its language features.

## Types

`kalk` supports different type of numbers and formats. All digits can be separated with the underscore `_` character.

### Integers

Integers: from a byte to large integers with any number of digits.

#### Simple Integers

From 8 bits to 64 bits integers:

```kalk
>>> 3
# 3
out = 3
>>> 14_768
# 14768
out = 14768
>>> display dev
# Display mode: dev (Developer)
>>> 3
# 3
out = 3
    # int - 32-bit
    = 0x_0000_0003
    = 0x____0____0____0____0____0____0____0____3
    = 0b_0000_0000_0000_0000_0000_0000_0000_0011
```

By default, an integer will be represented by an `int` (32 bits) or a `long` (64 bits) if the value is exceeding the range of an `int`.

But size of integers can be enforced by using specific type constructors: 

- 8 bits: `byte`, `sbyte`
- 16 bits: `ushort`, `short`
- 32 bits: `uint`, `int`
- 64 bits: `ulong`, `long` 

```kalk
>>> display dev
# Display mode: dev (Developer)
>>> int(5)
# int(5)
out = 5
    # int - 32-bit
    = 0x_0000_0005
    = 0x____0____0____0____0____0____0____0____5
    = 0b_0000_0000_0000_0000_0000_0000_0000_0101
>>> long(5)
# long(5)
out = 5
    # long - 64-bit
    = 0x_00000000_00000005
    = 0x____0____0____0____0____0____0____0____0____0____0____0____0____0____0____0____5
    = 0b_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0101
```

You can convert a `string` to a specific integer value:

```kalk
>>> int("5")
# int("5")
out = 5
```
[🢁 top](#overview)
#### Big Integers

With any number of digits:

```kalk
>>> 1e50
# 100000000000000000000000000000000000000000000000000
out = 100000000000000000000000000000000000000000000000000
```

[🢁 top](#overview)
#### Hexadecimal Integers

Hexadecimal integers are prefixed by `0x` followed by hexadecimal characters `[0-9A-Fa-f]` with an optional postfix specifier for unsigned (`u` or `U`):

```kalk
>>> 0xFC1234 # hexa
# 16519732 # hexa
out = 16519732
>>> hex out
# hex(out)
out = "34 12 FC 00"
>>> hex out
# hex(out)
out = 16519732  
>>> 0x80000001
# -2147483647
out = -2147483647
>>> 0x80000001u # force unsigned with `u` postfix
# 2147483649 # force unsigned with `u` postfix
out = 2147483649
>>> 0xFF_AB_12_E3
# -5565725
out = -5565725  
```

[🢁 top](#overview)
#### Binary Integers

Binary integers are prefixed by `0b` followed by binary characters `0` or `1` with an optional postfix specifier for unsigned (`u` or `U`):

```kalk
>>> 0b11111010 # binary
# 250 # binary
out = 250
>>> bin out
# bin(out)
out = "11111010"
>>> bin out
# bin(out)
out = 250
>>> 0b11110000_00000000_00000000_00000000
# -268435456
out = -268435456
>>> 0b11110000_00000000_00000000_00000000u
# 4026531840
out = 4026531840    
```

[🢁 top](#overview)
### Floats

`kalk` supports 4 kinds of float/decimal numbers:

- `half`: IEEE 754 16-bit half precision float
- `float`: IEEE 754 32-bit single precision float
- `double`: IEEE 754 64-bit double precision float
- `decimal`: 128-bit precision float

#### Half

Half IEEE 754 16-bit half precision float (4 digits precision). Use the constructor `half` to enforce a `half`.
```kalk
>>> half(1.5)
# half(1.5)
out = 1.5
>>> half(2.3e-3f)
# half(0.0023f)
out = 0.0023
>>> display dev
# Display mode: dev (Developer)
>>> half(1.5)
# half(1.5)
out = 1.5
    # IEEE 754 - half float - 16-bit
    #
    = 0x_3E00
    = 0x____3____E____0____0
    #    seee eeff ffff ffff
    = 0b_0011_1110_0000_0000
    #   15       8         0
    #
    #  sign     exponent    |-- fraction -|
    =   1 * 2 ^ (15 - 15) * 0b1.1000000000f
```

#### Float

Float IEEE 754 32-bit single precision float (6-9 digits precision). Use the postfix `f` to enforce a `float`.
```kalk
>>> 1.5f
# 1.5f
out = 1.5
>>> 2.3e-5f
# 2.3E-05f
out = 2.3E-05
>>> display dev
# Display mode: dev (Developer)
>>> 1.5f
# 1.5f
out = 1.5
    # IEEE 754 - float - 32-bit
    #
    = 0x_3FC0_0000
    = 0x____3____F____C____0____0____0____0____0
    #    seee eeee efff ffff ffff ffff ffff ffff
    = 0b_0011_1111_1100_0000_0000_0000_0000_0000
    #   31      24        16         8         0
    #
    #  sign   exponent            |------ fraction -----|
    =   1 * 2 ^ (127 - 127) * 0b1.10000000000000000000000f
```

[🢁 top](#overview)
#### Double

Double IEEE 754 64-bit double precision float (15-17 digits precision). This is the default when using a floating point number.

```kalk
>>> 1.5
# 1.5
out = 1.5
>>> 3.7e21
# 3.7E+21
out = 3.7E+21
>>> display dev
# Display mode: dev (Developer)
>>> 1.5
# 1.5
out = 1.5
    # IEEE 754 - double - 64-bit
    #
    = 0x_3FF80000_00000000
    = 0x____3____F____F____8____0____0____0____0____0____0____0____0____0____0____0____0
    #    seee eeee eeee ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff
    = 0b_0011_1111_1111_1000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000
    #   63                48                  32                  16                   0
    #
    # sign    exponent              |-------------------- fraction --------------------|
    =   1 * 2 ^ (1023 - 1023) * 0b1.1000000000000000000000000000000000000000000000000000
```

[🢁 top](#overview)
#### Decimal

Decimal 128-bit precision float (28-29 digits precision). Use the postfix `m` for enforcing a `decimal`.

```kalk
>>> 1.5m
# 1.5m
out = 1.5
>>> 1.56781920303940591068762166827m
# 1.5678192030394059106876216683m
out = 1.5678192030394059106876216683
>>> 1.56781920303940591068762166827m
# 1.5678192030394059106876216683m
out = 1.5678192030394059106876216683
    # Decimal 128-bit displayed as IEEE 754 - double - 64-bit
    #
    = 0x_3FF915C9_96B18541
    = 0x____3____F____F____9____1____5____C____9____9____6____B____1____8____5____4____1
    #    seee eeee eeee ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff ffff
    = 0b_0011_1111_1111_1001_0001_0101_1100_1001_1001_0110_1011_0001_1000_0101_0100_0001
    #   63                48                  32                  16                   0
    #
    # sign    exponent              |-------------------- fraction --------------------|
    =   1 * 2 ^ (1023 - 1023) * 0b1.1001000101011100100110010110101100011000010101000001
```

[🢁 top](#overview)
#### Binary as floats

By using the binary prefix `0b` associated with a dot `.` you can express a floating point number. The postfix `f` can be applied to enforce `float` precision. 

```kalk
>>> 0b1.101f
# 1.625f
out = 1.625
    # IEEE 754 - float - 32-bit
    #
    = 0x_3FD0_0000
    = 0x____3____F____D____0____0____0____0____0
    #    seee eeee efff ffff ffff ffff ffff ffff
    = 0b_0011_1111_1101_0000_0000_0000_0000_0000
    #   31      24        16         8         0
    #
    #  sign   exponent            |------ fraction -----|
    =   1 * 2 ^ (127 - 127) * 0b1.10100000000000000000000f
```

[🢁 top](#overview)
### Boolean

A boolean value is `true` or `false`.

```kalk
>>> true
# true
out = true
>>> false
# false
out = false
>>> bool(1)
# bool(1)
out = true
>>> bool(0)
# bool(0)
out = false
>>> bool("true")
# bool("true")
out = true
>>> bool("false")
# bool("false")
out = false
```

[🢁 top](#overview)
### Vectors

`kalk` supports multiple vector types:

```kalk
# Type Vector Constructors
    - bool16, bool2, bool3, bool4, bool8, byte16, byte32, byte64, double2,
      double3, double4, double8, float16, float2, float3, float4, float8,
      half16, half2, half3, half32, half4, half8, int16, int2, int3, int4,
      int8, long2, long3, long4, long8, rgb, rgba, sbyte16, sbyte32, sbyte64,
      short16, short2, short32, short4, short8, uint16, uint2, uint3, uint4,
      uint8, ulong2, ulong3, ulong4, ulong8, ushort16, ushort2, ushort32,
      ushort4, ushort8, vector
```

They can be initialized with:

- A single value
  ```kalk
  >>> float4(0.5)
  # float4(0.5)
  out = float4(0.5, 0.5, 0.5, 0.5)
  ```
- An array of values
  ```kalk
  >>> float4([1,3,5,7])
  # float4([1,3,5,7])
  out = float4(1, 3, 5, 7)
  ```
- Direct values
  ```kalk
  >>> float4(1,3,5,7)
  # float4(1, 3, 5, 7)
  out = float4(1, 3, 5, 7)
  ```
- Mixed vector values
  ```kalk
  >>> float4(1.xyz, 5)
  # float4(1.xyz, 5)
  out = float4(1, 1, 1, 5)  
  ```
They support swizzles `xyzw` and `rgba` operator:

```kalk
>>> float4(1..4)
# float4(1..4)
out = float4(1, 2, 3, 4)
>>> out.xy
# out.xy
out = float2(1, 2)
```

Components can be array indexed as well:

```kalk
>>> float4(5,6,7,8)
# float4(5, 6, 7, 8)
out = float4(5, 6, 7, 8)
>>> out[1]
# out[1]
out = 6
```

Arbitrary vector size can also be created:

```kalk
>>> vector(float, 11, [2..12] |> cos)
# vector(float, 11, [2..12] |> cos)
out = vector(float, 11, -0.41614684, -0.9899925, -0.6536436, 0.2836622, 0.96017027, 0.75390226, -0.14550003, -0.91113025, -0.8390715, 0.004425698, 0.84385395)
```

Many functions are able to be applied to vector types as a whole:

```kalk
>>> cos(float4(1..4))
# cos(float4(1..4))
out = float4(0.5403023, -0.41614684, -0.9899925, -0.6536436)
```

[🢁 top](#overview)
### Matrices

Similar to vector, matrices can be created with a single value:

```kalk
>>> float4x4(1)
# float4x4(1)
out = float4x4(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1)
      # col  0           1           2           3           / row
      float4(1         , 1         , 1         , 1         ) # 0
      float4(1         , 1         , 1         , 1         ) # 1
      float4(1         , 1         , 1         , 1         ) # 2
      float4(1         , 1         , 1         , 1         ) # 3
```

They can also be created with an array:

```kalk
>>> float3x3(1..9)
# float3x3(1..9)
out = float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9)
      # col  0           1           2           / row
      float3(1         , 2         , 3         ) # 0
      float3(4         , 5         , 6         ) # 1
      float3(7         , 8         , 9         ) # 2
```

They can be created by combining them with vectors:

```kalk
>>> float4x3(float3(1), float3(2), float3(3), float3(4))
# float4x3(float3(1), float3(2), float3(3), float3(4))
out = float4x3(1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4)
      # col  0           1           2           / row
      float3(1         , 1         , 1         ) # 0
      float3(2         , 2         , 2         ) # 1
      float3(3         , 3         , 3         ) # 2
      float3(4         , 4         , 4         ) # 3
```      

You can access the row of a matrix

```kalk
>>> float3x3(1..9)
# float3x3(1..9)
out = float3x3(1, 2, 3, 4, 5, 6, 7, 8, 9)
      # col  0           1           2           / row
      float3(1         , 2         , 3         ) # 0
      float3(4         , 5         , 6         ) # 1
      float3(7         , 8         , 9         ) # 2
>>> out[1]
# out[1]
out = float3(4, 5, 6)
```

Similar to vectors You can use functions to manipulate matrices:

```kalk
# cos(float3x3(1..9))
out = float3x3(0.5403023, -0.41614684, -0.9899925, -0.6536436, 0.2836622, 0.96017027, 0.75390226, -0.14550003, -0.91113025)
      # col   0            1            2           / row
      float3( 0.5403023 , -0.41614684, -0.9899925 ) # 0
      float3(-0.6536436 ,  0.2836622 ,  0.96017027) # 1
      float3( 0.75390226, -0.14550003, -0.91113025) # 2
```      

[🢁 top](#overview)
### Strings

You can create strings:

```kalk
>>> "This is a string"
# "This is a string"
out = "This is a string"
```

You can access a single character:

```kalk
>>> "abcd"[1]
# "abcd"[1]
out = "b"
```

You can get the size of a string:

```kalk
>>> "abcd".size
# "abcd".size
out = 4
```

Or by using the `size` function:

```kalk
>>> "abcd" |> size
# "abcd" |> size
out = 4
```

You can convert a string to an ascii buffer:

```kalk
>>> "Hello World!"
# "Hello World!"
out = "Hello World!"
>>> ascii out
# ascii(out)
out = bytebuffer([72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33])
```

[🢁 top](#overview)
### Arrays

You can create arrays by specifying its values:

```kalk
>>> [1, 3, 5, 7]
# [1, 3, 5, 7]
out = [1, 3, 5, 7]
```

You can access an element of the array:

```kalk
>>> arr = [1, 3, 5, 7]
# arr = [1, 3, 5, 7]
arr = [1, 3, 5, 7]
>>> arr[2]
# arr[2]
out = 5
```

You can get the size of an array:

```kalk
>>> [1, 3, 5, 7].size
# [1, 3, 5, 7].size
out = 4
```

Or by using the `size` function:

```kalk
>>> [1, 3, 5, 7] |> size
# [1, 3, 5, 7] |> size
out = 4
```

Some functions can be applied on each element of the array:

```kalk
>>> [1, 3, 5, 7, 10, 11] |> fib
# [1, 3, 5, 7, 10, 11] |> fib
out = [1, 2, 5, 13, 55, 89]
```

[🢁 top](#overview)
### Ranges

You can create an enumerator of values based on an inclusive range `from..to`

```kalk
>>> 1..10
# 1..10
out = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
```

An exclusive range is defined by `from..<to`

```kalk
>>> 1..<10
# 1..<10
out = [1, 2, 3, 4, 5, 6, 7, 8, 9]
```

A range can be created from variable or function results:

```kalk
>>> x = 1
# x = 1
x = 1
>>> y = 6
# y = 6
y = 6
>>> x..y
# x..y
out = [1, 2, 3, 4, 5, 6]
```

Ranges share similar behavior to arrays (size, indexing...).

[🢁 top](#overview)
### Objects

Objects with properties can be created:

```kalk
>>> {a: 1, b: 2, c: "yes", d: float4(1)}
# {a: 1, b: 2, c: "yes", d: float4(1)}
out = {a: 1, b: 2, c: "yes", d: float4(1, 1, 1, 1)}
```

Properties can be accessed by name or by dynamic indexer:

```kalk
>>> obj = {a: 1, b: 2, c: "yes", d: float4(1)}
# obj = {a: 1, b: 2, c: "yes", d: float4(1)}
obj = {a: 1, b: 2, c: "yes", d: float4(1, 1, 1, 1)}
>>> obj.b
# obj.b
out = 2
>>> obj.c
# obj.c
out = "yes"
>>> obj["d"]
# obj["d"]
out = float4(1, 1, 1, 1)
```

You can extract keys and values from an object:

```kalk
>>> obj = {a: 1, b: 2, c: "yes", d: float4(1)}
# obj = {a: 1, b: 2, c: "yes", d: float4(1)}
obj = {a: 1, b: 2, c: "yes", d: float4(1, 1, 1, 1)}
>>> obj |> keys
# obj |> keys
out = ["a", "b", "c", "d"]
>>> obj |> values
# obj |> values
out = [1, 2, "yes", float4(1, 1, 1, 1)]
```

You can convert an object to a json string back and forth:

```kalk
>>> import Web
# 8 functions successfully imported from module `Web`.
>>> {a: 1, b: "yes"} |> json
# {a: 1, b: "yes"} |> json
out = "{\"a\": 1, \"b\": \"yes\"}"
>>> json out
# json(out)
out = {a: 1, b: "yes"}
```

[🢁 top](#overview)
### ByteBuffers

Byte buffers are a special kind of array that can be used with CPU intrinsics and other memory functions:

```kalk
>>> buf = bytebuffer(1..10)
# buf = bytebuffer(1..10)
buf = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
>>> buf[0] = 255
>>> buf
# buf
out = bytebuffer([255, 2, 3, 4, 5, 6, 7, 8, 9, 10])
```

A bytebuffer can be allocated:

```kalk
>>> malloc(16)
# malloc(16)
out = bytebuffer([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0])
```

You can take a slice/view of a buffer, while it manipulates the original content:

```kalk
>>> buf = bytebuffer(1..10)
# buf = bytebuffer(1..10)
buf = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
>>> buf1 = slice(buf, 1, 5)
# buf1 = slice(buf, 1, 5)
buf1 = slice(bytebuffer([2, 3, 4, 5, 6]), 1, 5)
>>> buf1[0] = 255
>>> buf
# buf
out = bytebuffer([1, 2, 255, 4, 5, 6, 7, 8, 9, 10])
```

All types (except objects), can be converted to a bytebuffer representation via `asbytes`:

```kalk
>>> float4(1..4) |> asbytes
# float4(1..4) |> asbytes
out = bytebuffer([0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64])
```

A bytebuffer acts as a pointer for + operator with an integer:

```kalk
>>> bytebuffer(1..10)
# bytebuffer(1..10)
out = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10])
>>> out + 4
# out + 4
out = slice(bytebuffer([5, 6, 7, 8, 9, 10]), 4)
```
[🢁 top](#overview)
## Expressions

### Nested

An expression enclosed by `(` and `)` 

```kalk
>>> (2 - 5 * (1 + 3)) / 3
# (2 - 5 * (1 + 3)) / 3
out = -6
```

[🢁 top](#overview)
### With Numbers

The following binary operators are supported for **numbers**: 

|Operator            | Description
|--------------------|------------
| `<left> + <right>` | add left to right number 
| `<left> - <right>` | substract right number from left
| `<left> * <right>` | multiply left by right number
| `<left> / <right>` | divide left by right number
| `<left> // <right>`| divide left by right number and round to an integer
| `<left> % <right>` | calculates the modulus of left by right 
| `<left> ^ <right>` | calculates the exponent of left by right 

If left or right is a float and the other is an integer, the result of the operation will be a float.

```kalk
>>> 1 + 2
# 1 + 2
out = 3
>>> 3 - 1
# 3 - 1
out = 2
>>> 3 * 4
# 3 * 4
out = 12
>>> 5 / 2
# 5 / 2
out = 2.5
>>> 5 // 2
# 5 // 2
out = 2
>>> 5 % 2
# 5 % 2
out = 1
>>> 4 ^ 3
# 4 ^ 3
out = 64
```

[🢁 top](#overview)

### With Strings

The following binary operators are supported for **strings**: 

|Operator            | Description
|--------------------|------------
| `'left' + <right>` | concatenates left to right string: `"ab" + "c" -> "abc"`
| `'left' * <right>` | concatenates the left string `right` times: `'a' * 5  -> aaaaa`. left and right and be swapped as long as there is one string and one number.

As long as there is a string in a binary operation, the other part will be automatically converted to a string.

```kalk
>>> "abc" * 2
# "abc" * 2
out = "abcabc"
```

The following literals are converted to plain strings:

* `null -> ""`. e.g: `"aaaa" + null -> "aaaa"`
* `0 -> "0"`
* `1.0 -> "1.0"`
* `true -> "true"`
* `false -> "false"`


[🢁 top](#overview)

### With Arrays

The following binary operators are supported for **arrays**: 

```kalk
>>> [1, 2, 3] + [4, 5, 6]
# [1, 2, 3] + [4, 5, 6]
out = [1, 2, 3, 4, 5, 6]
```

Join array values with `|`:

```kalk
>>> [1, 2, 3] | [1, 2, 4]
# [1, 2, 3] | [1, 2, 4]
out = [1, 2, 3, 4]
```

Select values from both left and right `&`:

```kalk
>>> [1, 2, 3] & [1, 2, 4]
# [1, 2, 3] & [1, 2, 4]
out = [1, 2]
```

Multiply arrays with `*`:

```kalk
>>> [1,3,5] * 3
# [1,3,5] * 3
out = [1, 3, 5, 1, 3, 5, 1, 3, 5]
```

### Conditional

A boolean expression produces a boolean by comparing a left and right value.

|Operator            | Description
|--------------------|------------
| `<left> == <right>` | Is left equal to right? 
| `<left> != <right>` | Is left not equal to right?
| `<left> > <right>`  | Is left greater than right? 
| `<left> >= <right>` | Is left greater or equal to right?
| `<left> < <right>`  | Is left less than right?
| `<left> <= <right>` | Is left less or equal to right?

They work with both `numbers`, `strings` and datetimes.

You can combine conditional expressions with `&&` (and operator) and `||` (or operator).
Unlike in `javascript` it always returns `boolean` and never `<left>` or `<right>`.

|Operator            | Description
|--------------------|------------
| `<left> && <right>` | Is left true and right true?
| `<left> || <right>` | Is left true or right true?

The conditional expression `cond ? left : right` allow to return `left` if `cond` is `true` otherwise `right`.

The operators work with all types except objects (e.g basic, vector, matrices, arrays):

```kalk
>>> 1 == 2
# 1 == 2
out = false
>>> float4(1,2,3,4) == float4(1,0,3,0)
# float4(1, 2, 3, 4) == float4(1, 0, 3, 0)
out = bool4(true, false, true, false)
>>> [1, 2, 3] == [1, 0, 3]
# [1, 2, 3] == [1, 0, 3]
out = false
>>> [1, 2, 3] == [1, 2, 3]
# [1, 2, 3] == [1, 2, 3]
out = true
```

The operator `left ?? right` can be used to return the `right` value if `left` is null.

```kalk
>>> a = null
# a = null
a = null
>>> b = "yes"
# b = "yes"
b = "yes"
>>> a ?? b
# a ?? b
out = "yes"
```

[🢁 top](#overview)

## Control Flows

### Multiple statements

`kalk` supports multiple statements on the same line separated by `;`

```kalk
>>> x = 1; y = 2; x + y
# x = 1; y = 2; x + y
x = 1
y = 2
out = 3
```

[🢁 top](#overview)
### If statements

Supports for if, else, and else if statements: 

> `if <condition>; <statements>; else; <statements>; end;`

```kalk
>>> x = 1; if x < 1; y = 2; else; y = 3; end; x + y
# x = 1; if x < 1; y = 2; else; y = 3; end; x + y
x = 1
y = 3
out = 4
```

[🢁 top](#overview)
### Loop statements

Supports for the following `for` loop syntax: 

> `for <condition> in <expression>; <statements>; end;`

```kalk
>>> for x in 1..10; y = x; end
# for x in 1..10; y = x; end
y = 1
y = 2
y = 3
y = 4
y = 5
y = 6
y = 7
y = 8
y = 9
y = 10
```

Supports for `while` loop syntax: 

> `while <condition>; <statements>; end;`

```kalk
>>> x = 10; while x > 0; x = x - 1; end
# x = 10; while x > 0; x = x - 1; end
x = 10
x = 9
x = 8
x = 7
x = 6
x = 5
x = 4
x = 3
x = 2
x = 1
x = 0
```

[🢁 top](#overview)
#### Special loop variables

The following variables are accessible within a `for` block:

| Name                | Description
| ------------------- | -----------
| `for.index`     | The current `index` of the for loop
| `for.rindex`    | The current `index` of the for loop starting from the end of the list
| `for.first`     | A boolean indicating whether this is the first step in the loop
| `for.last`      | A boolean indicating whether this is the last step in the loop
| `for.even`      | A boolean indicating whether this is an even row in the loop
| `for.odd`       | A boolean indicating whether this is an odd row in the loop
| `for.changed`   | A boolean indicating whether a current value of this iteration changed from previous step

```kalk
>>> for x in 1..10; print(for.index + " first: " + for.first + " last: " + for.last); end;
0 first: true last: false
1 first: false last: false
2 first: false last: false
3 first: false last: false
4 first: false last: false
5 first: false last: false
6 first: false last: false
7 first: false last: false
8 first: false last: false
9 first: false last: true
```

Within a `while` statement, the following variables can be used:

| Name                | Description
| ------------------- | -----------
| `while.index`     | The current `index` of the while loop
| `while.first`     | A boolean indicating whether this is the first step in the loop
| `while.even`      | A boolean indicating whether this is an even row in the loop
| `while.odd`       | A boolean indicating whether this is an odd row in the loop

[🢁 top](#overview)

#### `break` and `continue`

You can use `break` and `continue` within loops as in standard languages.

```kalk
>>> for x in 1..10; if x > 5; break; end; x * 2; end
# for x in 1..10; if x > 5; break; end; x * 2; end
out = 2
out = 4
out = 6
out = 8
out = 10
```

[🢁 top](#overview)
## Functions

### Inline functions

A simple inline function can be declared with:

> `<function_name>(argName1, argName2, ...argNameN) = <expression>`

```kalk
>>> f(x, y, z) = x + 2y + 3z
# f(x, y, z) = x + 2 * y + 3 * z
f(x, y, z) = x + 2 y + 3 z
>>> f(1,2,3)
# f(1, 2, 3)
out = 14
```

[🢁 top](#overview)
### Multiline functions

> ` func <function_name>(argName1, argName2, ...argNameN); <statements>; end;`

```kalk
>>> func f(x,y); for v in x..y; 2v; end; end
# func f(x,y); for v in x..y; 2 * v; end; end
func f(x,y); for v in x .. y; 2 v; end; end
>>> f(1,10)
# f(1, 10)
out = 2
out = 4
out = 6
out = 8
out = 10
out = 12
out = 14
out = 16
out = 18
out = 20
```

[🢁 top](#overview)
### Anonymous functions

Anonymous functions are like simple functions but can be used in expressions (e.g as the last argument of function call)

```kalk
>>> f = do (x,y); ret x + y; end;
# f = do(x,y); ret x + y; end;
f = do(x,y); ret x + y; end;
>>> f(1,2)
# f(1, 2)
out = 3
```

[🢁 top](#overview)
### Function Pointers

A function can be passed to another function by using the operator `@` in front of the function to stop the evaluation and allow to pass the function as a "pointer".

```kalk
>>> f(x) = x + 1
# f(x) = x + 1
f(x) = x + 1
>>> g(y, z) = y(z)
# g(y, z) = y(z)
g(y, z) = y(z)
>>> g(@f, 5)
# g(@f, 5)
out = 6
```

[🢁 top](#overview)