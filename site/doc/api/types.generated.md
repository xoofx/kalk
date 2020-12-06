---
title: Types Functions
url: /doc/api/types/
---

## bool

`bool(value?)`

Creates a boolean value (32-bit) value.

- `value`: The input value.

### Returns

A boolean (32-bit) value

### Example

```kalk
>>> bool 1
# bool(1)
out = true
>>> bool 0
# bool(0)
out = false
>>> bool true
# bool(true)
out = true
>>> bool false
# bool(false)
out = false
```

## bool16

`bool16(arguments)`

Creates a vector of 16 `bool` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: The vector is initialized with false values.
    - a single value: `bool16(true)` will initialize all elements with 123.
    - an array value: `bool16([true, false, ...])` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool4(bool2(true,false), bool2(false,true))` or `bool4(bool3(false,true,true), false)`)

### Returns

A bool16 vector initialized with the specified arguments

### Example

```kalk
>>> bool16(true)
# bool16(true)
out = bool16(true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true)
```

## bool2

`bool2(arguments)`

Creates a vector of 2 `bool` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: The vector is initialized with false values.
    - a single value: `bool2(true)` will initialize all elements with 123.
    - an array value: `bool2([true, false, ...])` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool4(bool2(true,false), bool2(false,true))` or `bool4(bool3(false,true,true), false)`)

### Returns

A bool2 vector initialized with the specified arguments

### Example

```kalk
>>> bool2(true)
# bool2(true)
out = bool2(true, true)
```

## bool2x2

`bool2x2(arguments)`

Creates a 2 (rows) x 2 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool2x2(123)` will initialize all elements with 123.
    - an array value: `bool2x2(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool2x2 matrix initialized with the specified arguments

## bool2x3

`bool2x3(arguments)`

Creates a 2 (rows) x 3 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool2x3(123)` will initialize all elements with 123.
    - an array value: `bool2x3(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool2x3 matrix initialized with the specified arguments

## bool2x4

`bool2x4(arguments)`

Creates a 2 (rows) x 4 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool2x4(123)` will initialize all elements with 123.
    - an array value: `bool2x4(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool2x4 matrix initialized with the specified arguments

## bool3

`bool3(arguments)`

Creates a vector of 3 `bool` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: The vector is initialized with false values.
    - a single value: `bool3(true)` will initialize all elements with 123.
    - an array value: `bool3([true, false, ...])` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool4(bool2(true,false), bool2(false,true))` or `bool4(bool3(false,true,true), false)`)

### Returns

A bool3 vector initialized with the specified arguments

### Example

```kalk
>>> bool3(true)
# bool3(true)
out = bool3(true, true, true)
```

## bool3x2

`bool3x2(arguments)`

Creates a 3 (rows) x 2 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool3x2(123)` will initialize all elements with 123.
    - an array value: `bool3x2(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool3x2 matrix initialized with the specified arguments

## bool3x3

`bool3x3(arguments)`

Creates a 3 (rows) x 3 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool3x3(123)` will initialize all elements with 123.
    - an array value: `bool3x3(1..9)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool3x3 matrix initialized with the specified arguments

## bool3x4

`bool3x4(arguments)`

Creates a 3 (rows) x 4 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool3x4(123)` will initialize all elements with 123.
    - an array value: `bool3x4(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool3x4 matrix initialized with the specified arguments

## bool4

`bool4(arguments)`

Creates a vector of 4 `bool` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: The vector is initialized with false values.
    - a single value: `bool4(true)` will initialize all elements with 123.
    - an array value: `bool4([true, false, ...])` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool4(bool2(true,false), bool2(false,true))` or `bool4(bool3(false,true,true), false)`)

### Returns

A bool4 vector initialized with the specified arguments

### Example

```kalk
>>> bool4(true)
# bool4(true)
out = bool4(true, true, true, true)
```

## bool4x2

`bool4x2(arguments)`

Creates a 4 (rows) x 2 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool4x2(123)` will initialize all elements with 123.
    - an array value: `bool4x2(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool4x2 matrix initialized with the specified arguments

## bool4x3

`bool4x3(arguments)`

Creates a 4 (rows) x 3 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool4x3(123)` will initialize all elements with 123.
    - an array value: `bool4x3(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool4x3 matrix initialized with the specified arguments

## bool4x4

`bool4x4(arguments)`

Creates a 4 (rows) x 4 (columns) matrix of bool.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `bool4x4(123)` will initialize all elements with 123.
    - an array value: `bool4x4(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool3x4(bool4(1), bool4(2), bool4(3))`.

### Returns

A bool4x4 matrix initialized with the specified arguments

## bool8

`bool8(arguments)`

Creates a vector of 8 `bool` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: The vector is initialized with false values.
    - a single value: `bool8(true)` will initialize all elements with 123.
    - an array value: `bool8([true, false, ...])` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `bool4(bool2(true,false), bool2(false,true))` or `bool4(bool3(false,true,true), false)`)

### Returns

A bool8 vector initialized with the specified arguments

### Example

```kalk
>>> bool8(true)
# bool8(true)
out = bool8(true, true, true, true, true, true, true, true)
```

## byte

`byte(value?)`

Creates an unsigned byte value.

- `value`: The input value.

### Returns

An unsigned byte value

### Example

```kalk
>>> byte
# byte
out = 0
>>> byte 0
# byte(0)
out = 0
>>> byte 255
# byte(255)
out = 255
```

## byte16

`byte16(arguments)`

Creates a vector of 16 `byte` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `byte16(123)` will initialize all elements with 123.
    - an array value: `byte16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `byte4(byte2(1,2), byte2(3,4))` or `byte4(byte3(1,2,3), 4)`.

### Returns

A byte16 vector initialized with the specified arguments

### Example

```kalk
>>> byte16
# byte16
out = byte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> byte16(1..16)
# byte16(1..16)
out = byte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> byte16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# byte16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = byte16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## byte32

`byte32(arguments)`

Creates a vector of 32 `byte` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `byte32(123)` will initialize all elements with 123.
    - an array value: `byte32(1..32)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `byte4(byte2(1,2), byte2(3,4))` or `byte4(byte3(1,2,3), 4)`.

### Returns

A byte32 vector initialized with the specified arguments

### Example

```kalk
>>> byte32
# byte32
out = byte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> byte32(1..32)
# byte32(1..32)
out = byte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32)
```

## byte64

`byte64(arguments)`

Creates a vector of 64 `byte` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `byte64(123)` will initialize all elements with 123.
    - an array value: `byte64(1..64)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `byte4(byte2(1,2), byte2(3,4))` or `byte4(byte3(1,2,3), 4)`.

### Returns

A byte64 vector initialized with the specified arguments

### Example

```kalk
>>> byte64
# byte64
out = byte64(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> byte64(1..64)
# byte64(1..64)
out = byte64(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64)
```

## double

`double(value?)`

Creates a double value (64-bit) value.

- `value`: The input value.

### Returns

A double (64-bit) value

### Example

```kalk
>>> double(1)
# double(1)
out = 1
>>> double(-1)
# double(-1)
out = -1
>>> double(100000000000)
# double(100000000000)
out = 100000000000
>>> double(1<<200)
# double(1 << 200)
out = 1.6069380442589903E+60
```

## double2

`double2(arguments)`

Creates a vector of 2 `double` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double2(123)` will initialize all elements with 123.
    - an array value: `double2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double4(double2(1,2), double2(3,4))` or `double4(double3(1,2,3), 4)`.

### Returns

A double2 vector initialized with the specified arguments

### Example

```kalk
>>> double2
# double2
out = double2(0, 0)
>>> double2(1..2)
# double2(1..2)
out = double2(1, 2)
>>> double2(10, 11)
# double2(10, 11)
out = double2(10, 11)
```

## double2x2

`double2x2(arguments)`

Creates a 2 (rows) x 2 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double2x2(123)` will initialize all elements with 123.
    - an array value: `double2x2(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double2x2 matrix initialized with the specified arguments

## double2x3

`double2x3(arguments)`

Creates a 2 (rows) x 3 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double2x3(123)` will initialize all elements with 123.
    - an array value: `double2x3(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double2x3 matrix initialized with the specified arguments

## double2x4

`double2x4(arguments)`

Creates a 2 (rows) x 4 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double2x4(123)` will initialize all elements with 123.
    - an array value: `double2x4(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double2x4 matrix initialized with the specified arguments

## double3

`double3(arguments)`

Creates a vector of 3 `double` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double3(123)` will initialize all elements with 123.
    - an array value: `double3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double4(double2(1,2), double2(3,4))` or `double4(double3(1,2,3), 4)`.

### Returns

A double3 vector initialized with the specified arguments

### Example

```kalk
>>> double3
# double3
out = double3(0, 0, 0)
>>> double3(1..3)
# double3(1..3)
out = double3(1, 2, 3)
>>> double3(10, 11, 12)
# double3(10, 11, 12)
out = double3(10, 11, 12)
```

## double3x2

`double3x2(arguments)`

Creates a 3 (rows) x 2 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double3x2(123)` will initialize all elements with 123.
    - an array value: `double3x2(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double3x2 matrix initialized with the specified arguments

## double3x3

`double3x3(arguments)`

Creates a 3 (rows) x 3 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double3x3(123)` will initialize all elements with 123.
    - an array value: `double3x3(1..9)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double3x3 matrix initialized with the specified arguments

## double3x4

`double3x4(arguments)`

Creates a 3 (rows) x 4 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double3x4(123)` will initialize all elements with 123.
    - an array value: `double3x4(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double3x4 matrix initialized with the specified arguments

## double4

`double4(arguments)`

Creates a vector of 4 `double` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double4(123)` will initialize all elements with 123.
    - an array value: `double4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double4(double2(1,2), double2(3,4))` or `double4(double3(1,2,3), 4)`.

### Returns

A double4 vector initialized with the specified arguments

### Example

```kalk
>>> double4
# double4
out = double4(0, 0, 0, 0)
>>> double4(1..4)
# double4(1..4)
out = double4(1, 2, 3, 4)
>>> double4(10, 11, 12, 13)
# double4(10, 11, 12, 13)
out = double4(10, 11, 12, 13)
```

## double4x2

`double4x2(arguments)`

Creates a 4 (rows) x 2 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double4x2(123)` will initialize all elements with 123.
    - an array value: `double4x2(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double4x2 matrix initialized with the specified arguments

## double4x3

`double4x3(arguments)`

Creates a 4 (rows) x 3 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double4x3(123)` will initialize all elements with 123.
    - an array value: `double4x3(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double4x3 matrix initialized with the specified arguments

## double4x4

`double4x4(arguments)`

Creates a 4 (rows) x 4 (columns) matrix of double.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double4x4(123)` will initialize all elements with 123.
    - an array value: `double4x4(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double3x4(double4(1), double4(2), double4(3))`.

### Returns

A double4x4 matrix initialized with the specified arguments

## double8

`double8(arguments)`

Creates a vector of 8 `double` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `double8(123)` will initialize all elements with 123.
    - an array value: `double8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `double4(double2(1,2), double2(3,4))` or `double4(double3(1,2,3), 4)`.

### Returns

A double8 vector initialized with the specified arguments

### Example

```kalk
>>> double8
# double8
out = double8(0, 0, 0, 0, 0, 0, 0, 0)
>>> double8(1..8)
# double8(1..8)
out = double8(1, 2, 3, 4, 5, 6, 7, 8)
>>> double8(10, 11, 12, 13, 14, 15, 16, 17)
# double8(10, 11, 12, 13, 14, 15, 16, 17)
out = double8(10, 11, 12, 13, 14, 15, 16, 17)
```

## float

`float(value?)`

Creates a float value (32-bit) value.

- `value`: The input value.

### Returns

A float (32-bit) value

### Example

```kalk
>>> float(1)
# float(1)
out = 1
>>> float(-1)
# float(-1)
out = -1
>>> float(100000000000)
# float(100000000000)
out = 1E+11
```

## float16

`float16(arguments)`

Creates a vector of 16 `float` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float16(123)` will initialize all elements with 123.
    - an array value: `float16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float4(float2(1,2), float2(3,4))` or `float4(float3(1,2,3), 4)`.

### Returns

A float16 vector initialized with the specified arguments

### Example

```kalk
>>> float16
# float16
out = float16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> float16(1..16)
# float16(1..16)
out = float16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> float16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# float16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = float16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## float2

`float2(arguments)`

Creates a vector of 2 `float` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float2(123)` will initialize all elements with 123.
    - an array value: `float2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float4(float2(1,2), float2(3,4))` or `float4(float3(1,2,3), 4)`.

### Returns

A float2 vector initialized with the specified arguments

### Example

```kalk
>>> float2
# float2
out = float2(0, 0)
>>> float2(1..2)
# float2(1..2)
out = float2(1, 2)
>>> float2(10, 11)
# float2(10, 11)
out = float2(10, 11)
```

## float2x2

`float2x2(arguments)`

Creates a 2 (rows) x 2 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float2x2(123)` will initialize all elements with 123.
    - an array value: `float2x2(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float2x2 matrix initialized with the specified arguments

## float2x3

`float2x3(arguments)`

Creates a 2 (rows) x 3 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float2x3(123)` will initialize all elements with 123.
    - an array value: `float2x3(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float2x3 matrix initialized with the specified arguments

## float2x4

`float2x4(arguments)`

Creates a 2 (rows) x 4 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float2x4(123)` will initialize all elements with 123.
    - an array value: `float2x4(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float2x4 matrix initialized with the specified arguments

## float3

`float3(arguments)`

Creates a vector of 3 `float` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float3(123)` will initialize all elements with 123.
    - an array value: `float3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float4(float2(1,2), float2(3,4))` or `float4(float3(1,2,3), 4)`.

### Returns

A float3 vector initialized with the specified arguments

### Example

```kalk
>>> float3
# float3
out = float3(0, 0, 0)
>>> float3(1..3)
# float3(1..3)
out = float3(1, 2, 3)
>>> float3(10, 11, 12)
# float3(10, 11, 12)
out = float3(10, 11, 12)
```

## float3x2

`float3x2(arguments)`

Creates a 3 (rows) x 2 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float3x2(123)` will initialize all elements with 123.
    - an array value: `float3x2(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float3x2 matrix initialized with the specified arguments

## float3x3

`float3x3(arguments)`

Creates a 3 (rows) x 3 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float3x3(123)` will initialize all elements with 123.
    - an array value: `float3x3(1..9)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float3x3 matrix initialized with the specified arguments

## float3x4

`float3x4(arguments)`

Creates a 3 (rows) x 4 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float3x4(123)` will initialize all elements with 123.
    - an array value: `float3x4(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float3x4 matrix initialized with the specified arguments

## float4

`float4(arguments)`

Creates a vector of 4 `float` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float4(123)` will initialize all elements with 123.
    - an array value: `float4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float4(float2(1,2), float2(3,4))` or `float4(float3(1,2,3), 4)`.

### Returns

A float4 vector initialized with the specified arguments

### Example

```kalk
>>> float4
# float4
out = float4(0, 0, 0, 0)
>>> float4(1..4)
# float4(1..4)
out = float4(1, 2, 3, 4)
>>> float4(10, 11, 12, 13)
# float4(10, 11, 12, 13)
out = float4(10, 11, 12, 13)
```

## float4x2

`float4x2(arguments)`

Creates a 4 (rows) x 2 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float4x2(123)` will initialize all elements with 123.
    - an array value: `float4x2(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float4x2 matrix initialized with the specified arguments

## float4x3

`float4x3(arguments)`

Creates a 4 (rows) x 3 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float4x3(123)` will initialize all elements with 123.
    - an array value: `float4x3(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float4x3 matrix initialized with the specified arguments

## float4x4

`float4x4(arguments)`

Creates a 4 (rows) x 4 (columns) matrix of float.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float4x4(123)` will initialize all elements with 123.
    - an array value: `float4x4(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float3x4(float4(1), float4(2), float4(3))`.

### Returns

A float4x4 matrix initialized with the specified arguments

## float8

`float8(arguments)`

Creates a vector of 8 `float` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `float8(123)` will initialize all elements with 123.
    - an array value: `float8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `float4(float2(1,2), float2(3,4))` or `float4(float3(1,2,3), 4)`.

### Returns

A float8 vector initialized with the specified arguments

### Example

```kalk
>>> float8
# float8
out = float8(0, 0, 0, 0, 0, 0, 0, 0)
>>> float8(1..8)
# float8(1..8)
out = float8(1, 2, 3, 4, 5, 6, 7, 8)
>>> float8(10, 11, 12, 13, 14, 15, 16, 17)
# float8(10, 11, 12, 13, 14, 15, 16, 17)
out = float8(10, 11, 12, 13, 14, 15, 16, 17)
```

## half

`half(value?)`

Creates a half float value (16-bit) value.

- `value`: The input value.

### Returns

A half float (16-bit) value

### Example

```kalk
>>> half(1)
# half(1)
out = 1
>>> half(-1)
# half(-1)
out = -1
>>> half(1000.5)
# half(1000.5)
out = 1000.5
>>> kind out
# kind(out)
out = "half"
```

## half16

`half16(arguments)`

Creates a vector of 16 `half` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half16(123)` will initialize all elements with 123.
    - an array value: `half16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half4(half2(1,2), half2(3,4))` or `half4(half3(1,2,3), 4)`.

### Returns

A half16 vector initialized with the specified arguments

### Example

```kalk
>>> half16
# half16
out = half16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> half16(1..16)
# half16(1..16)
out = half16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> half16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# half16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = half16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## half2

`half2(arguments)`

Creates a vector of 2 `half` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half2(123)` will initialize all elements with 123.
    - an array value: `half2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half4(half2(1,2), half2(3,4))` or `half4(half3(1,2,3), 4)`.

### Returns

A half2 vector initialized with the specified arguments

### Example

```kalk
>>> half2
# half2
out = half2(0, 0)
>>> half2(1..2)
# half2(1..2)
out = half2(1, 2)
>>> half2(10, 11)
# half2(10, 11)
out = half2(10, 11)
```

## half2x2

`half2x2(arguments)`

Creates a 2 (rows) x 2 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half2x2(123)` will initialize all elements with 123.
    - an array value: `half2x2(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half2x2 matrix initialized with the specified arguments

## half2x3

`half2x3(arguments)`

Creates a 2 (rows) x 3 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half2x3(123)` will initialize all elements with 123.
    - an array value: `half2x3(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half2x3 matrix initialized with the specified arguments

## half2x4

`half2x4(arguments)`

Creates a 2 (rows) x 4 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half2x4(123)` will initialize all elements with 123.
    - an array value: `half2x4(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half2x4 matrix initialized with the specified arguments

## half3

`half3(arguments)`

Creates a vector of 3 `half` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half3(123)` will initialize all elements with 123.
    - an array value: `half3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half4(half2(1,2), half2(3,4))` or `half4(half3(1,2,3), 4)`.

### Returns

A half3 vector initialized with the specified arguments

### Example

```kalk
>>> half3
# half3
out = half3(0, 0, 0)
>>> half3(1..3)
# half3(1..3)
out = half3(1, 2, 3)
>>> half3(10, 11, 12)
# half3(10, 11, 12)
out = half3(10, 11, 12)
```

## half32

`half32(arguments)`

Creates a vector of 32 `half` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half32(123)` will initialize all elements with 123.
    - an array value: `half32(1..32)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half4(half2(1,2), half2(3,4))` or `half4(half3(1,2,3), 4)`.

### Returns

A half32 vector initialized with the specified arguments

### Example

```kalk
>>> half32
# half32
out = half32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> half32(1..32)
# half32(1..32)
out = half32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32)
```

## half3x2

`half3x2(arguments)`

Creates a 3 (rows) x 2 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half3x2(123)` will initialize all elements with 123.
    - an array value: `half3x2(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half3x2 matrix initialized with the specified arguments

## half3x3

`half3x3(arguments)`

Creates a 3 (rows) x 3 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half3x3(123)` will initialize all elements with 123.
    - an array value: `half3x3(1..9)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half3x3 matrix initialized with the specified arguments

## half3x4

`half3x4(arguments)`

Creates a 3 (rows) x 4 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half3x4(123)` will initialize all elements with 123.
    - an array value: `half3x4(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half3x4 matrix initialized with the specified arguments

## half4

`half4(arguments)`

Creates a vector of 4 `half` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half4(123)` will initialize all elements with 123.
    - an array value: `half4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half4(half2(1,2), half2(3,4))` or `half4(half3(1,2,3), 4)`.

### Returns

A half4 vector initialized with the specified arguments

### Example

```kalk
>>> half4
# half4
out = half4(0, 0, 0, 0)
>>> half4(1..4)
# half4(1..4)
out = half4(1, 2, 3, 4)
>>> half4(10, 11, 12, 13)
# half4(10, 11, 12, 13)
out = half4(10, 11, 12, 13)
```

## half4x2

`half4x2(arguments)`

Creates a 4 (rows) x 2 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half4x2(123)` will initialize all elements with 123.
    - an array value: `half4x2(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half4x2 matrix initialized with the specified arguments

## half4x3

`half4x3(arguments)`

Creates a 4 (rows) x 3 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half4x3(123)` will initialize all elements with 123.
    - an array value: `half4x3(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half4x3 matrix initialized with the specified arguments

## half4x4

`half4x4(arguments)`

Creates a 4 (rows) x 4 (columns) matrix of half.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half4x4(123)` will initialize all elements with 123.
    - an array value: `half4x4(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half3x4(half4(1), half4(2), half4(3))`.

### Returns

A half4x4 matrix initialized with the specified arguments

## half8

`half8(arguments)`

Creates a vector of 8 `half` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `half8(123)` will initialize all elements with 123.
    - an array value: `half8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `half4(half2(1,2), half2(3,4))` or `half4(half3(1,2,3), 4)`.

### Returns

A half8 vector initialized with the specified arguments

### Example

```kalk
>>> half8
# half8
out = half8(0, 0, 0, 0, 0, 0, 0, 0)
>>> half8(1..8)
# half8(1..8)
out = half8(1, 2, 3, 4, 5, 6, 7, 8)
>>> half8(10, 11, 12, 13, 14, 15, 16, 17)
# half8(10, 11, 12, 13, 14, 15, 16, 17)
out = half8(10, 11, 12, 13, 14, 15, 16, 17)
```

## int

`int(value?)`

Creates a signed-int (32-bit) value.

- `value`: The input value.

### Returns

A signed-int (32-bit) value

### Example

```kalk
>>> int
# int
out = 0
>>> int 0
# int(0)
out = 0
>>> int(1 << 31 - 1)
# int(1 << 31 - 1)
out = 2147483647
>>> int(-(1<<31))
# int(-(1 << 31))
out = -2147483648
```

## int16

`int16(arguments)`

Creates a vector of 16 `int` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int16(123)` will initialize all elements with 123.
    - an array value: `int16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int4(int2(1,2), int2(3,4))` or `int4(int3(1,2,3), 4)`.

### Returns

A int16 vector initialized with the specified arguments

### Example

```kalk
>>> int16
# int16
out = int16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> int16(1..16)
# int16(1..16)
out = int16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> int16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# int16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = int16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## int2

`int2(arguments)`

Creates a vector of 2 `int` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int2(123)` will initialize all elements with 123.
    - an array value: `int2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int4(int2(1,2), int2(3,4))` or `int4(int3(1,2,3), 4)`.

### Returns

A int2 vector initialized with the specified arguments

### Example

```kalk
>>> int2
# int2
out = int2(0, 0)
>>> int2(1..2)
# int2(1..2)
out = int2(1, 2)
>>> int2(10, 11)
# int2(10, 11)
out = int2(10, 11)
```

## int2x2

`int2x2(arguments)`

Creates a 2 (rows) x 2 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int2x2(123)` will initialize all elements with 123.
    - an array value: `int2x2(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int2x2 matrix initialized with the specified arguments

## int2x3

`int2x3(arguments)`

Creates a 2 (rows) x 3 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int2x3(123)` will initialize all elements with 123.
    - an array value: `int2x3(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int2x3 matrix initialized with the specified arguments

## int2x4

`int2x4(arguments)`

Creates a 2 (rows) x 4 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int2x4(123)` will initialize all elements with 123.
    - an array value: `int2x4(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int2x4 matrix initialized with the specified arguments

## int3

`int3(arguments)`

Creates a vector of 3 `int` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int3(123)` will initialize all elements with 123.
    - an array value: `int3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int4(int2(1,2), int2(3,4))` or `int4(int3(1,2,3), 4)`.

### Returns

A int3 vector initialized with the specified arguments

### Example

```kalk
>>> int3
# int3
out = int3(0, 0, 0)
>>> int3(1..3)
# int3(1..3)
out = int3(1, 2, 3)
>>> int3(10, 11, 12)
# int3(10, 11, 12)
out = int3(10, 11, 12)
```

## int3x2

`int3x2(arguments)`

Creates a 3 (rows) x 2 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int3x2(123)` will initialize all elements with 123.
    - an array value: `int3x2(1..6)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int3x2 matrix initialized with the specified arguments

## int3x3

`int3x3(arguments)`

Creates a 3 (rows) x 3 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int3x3(123)` will initialize all elements with 123.
    - an array value: `int3x3(1..9)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int3x3 matrix initialized with the specified arguments

## int3x4

`int3x4(arguments)`

Creates a 3 (rows) x 4 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int3x4(123)` will initialize all elements with 123.
    - an array value: `int3x4(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int3x4 matrix initialized with the specified arguments

## int4

`int4(arguments)`

Creates a vector of 4 `int` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int4(123)` will initialize all elements with 123.
    - an array value: `int4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int4(int2(1,2), int2(3,4))` or `int4(int3(1,2,3), 4)`.

### Returns

A int4 vector initialized with the specified arguments

### Example

```kalk
>>> int4
# int4
out = int4(0, 0, 0, 0)
>>> int4(1..4)
# int4(1..4)
out = int4(1, 2, 3, 4)
>>> int4(10, 11, 12, 13)
# int4(10, 11, 12, 13)
out = int4(10, 11, 12, 13)
```

## int4x2

`int4x2(arguments)`

Creates a 4 (rows) x 2 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int4x2(123)` will initialize all elements with 123.
    - an array value: `int4x2(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int4x2 matrix initialized with the specified arguments

## int4x3

`int4x3(arguments)`

Creates a 4 (rows) x 3 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int4x3(123)` will initialize all elements with 123.
    - an array value: `int4x3(1..12)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int4x3 matrix initialized with the specified arguments

## int4x4

`int4x4(arguments)`

Creates a 4 (rows) x 4 (columns) matrix of int.

- `arguments`: The matrix item values. The total number of values must equal the total dimension of the matrix. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int4x4(123)` will initialize all elements with 123.
    - an array value: `int4x4(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int3x4(int4(1), int4(2), int4(3))`.

### Returns

A int4x4 matrix initialized with the specified arguments

## int8

`int8(arguments)`

Creates a vector of 8 `int` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `int8(123)` will initialize all elements with 123.
    - an array value: `int8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `int4(int2(1,2), int2(3,4))` or `int4(int3(1,2,3), 4)`.

### Returns

A int8 vector initialized with the specified arguments

### Example

```kalk
>>> int8
# int8
out = int8(0, 0, 0, 0, 0, 0, 0, 0)
>>> int8(1..8)
# int8(1..8)
out = int8(1, 2, 3, 4, 5, 6, 7, 8)
>>> int8(10, 11, 12, 13, 14, 15, 16, 17)
# int8(10, 11, 12, 13, 14, 15, 16, 17)
out = int8(10, 11, 12, 13, 14, 15, 16, 17)
```

## long

`long(value?)`

Creates a signed-long (64-bit) value.

- `value`: The input value.

### Returns

A signed-long (64-bit) value

### Example

```kalk
>>> long
# long
out = 0
>>> long 0
# long(0)
out = 0
>>> long(1 << 63 - 1)
# long(1 << 63 - 1)
out = 9223372036854775807
>>> long(-(1<<63))
# long(-(1 << 63))
out = -9223372036854775808
```

## long2

`long2(arguments)`

Creates a vector of 2 `long` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `long2(123)` will initialize all elements with 123.
    - an array value: `long2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `long4(long2(1,2), long2(3,4))` or `long4(long3(1,2,3), 4)`.

### Returns

A long2 vector initialized with the specified arguments

### Example

```kalk
>>> long2
# long2
out = long2(0, 0)
>>> long2(1..2)
# long2(1..2)
out = long2(1, 2)
>>> long2(10, 11)
# long2(10, 11)
out = long2(10, 11)
```

## long3

`long3(arguments)`

Creates a vector of 3 `long` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `long3(123)` will initialize all elements with 123.
    - an array value: `long3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `long4(long2(1,2), long2(3,4))` or `long4(long3(1,2,3), 4)`.

### Returns

A long3 vector initialized with the specified arguments

### Example

```kalk
>>> long3
# long3
out = long3(0, 0, 0)
>>> long3(1..3)
# long3(1..3)
out = long3(1, 2, 3)
>>> long3(10, 11, 12)
# long3(10, 11, 12)
out = long3(10, 11, 12)
```

## long4

`long4(arguments)`

Creates a vector of 4 `long` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `long4(123)` will initialize all elements with 123.
    - an array value: `long4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `long4(long2(1,2), long2(3,4))` or `long4(long3(1,2,3), 4)`.

### Returns

A long4 vector initialized with the specified arguments

### Example

```kalk
>>> long4
# long4
out = long4(0, 0, 0, 0)
>>> long4(1..4)
# long4(1..4)
out = long4(1, 2, 3, 4)
>>> long4(10, 11, 12, 13)
# long4(10, 11, 12, 13)
out = long4(10, 11, 12, 13)
```

## long8

`long8(arguments)`

Creates a vector of 8 `long` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `long8(123)` will initialize all elements with 123.
    - an array value: `long8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `long4(long2(1,2), long2(3,4))` or `long4(long3(1,2,3), 4)`.

### Returns

A long8 vector initialized with the specified arguments

### Example

```kalk
>>> long8
# long8
out = long8(0, 0, 0, 0, 0, 0, 0, 0)
>>> long8(1..8)
# long8(1..8)
out = long8(1, 2, 3, 4, 5, 6, 7, 8)
>>> long8(10, 11, 12, 13, 14, 15, 16, 17)
# long8(10, 11, 12, 13, 14, 15, 16, 17)
out = long8(10, 11, 12, 13, 14, 15, 16, 17)
```

## matrix

`matrix(name,row,column,arguments)`

Creates a matrix of the specified element type, number of rows and columns and optional values.

- `name`: The element type of the matrix (e.g float).
- `row`: The number of rows.
- `column`: The number of columns.
- `arguments`: The optional values (must have 1 or row x column elements).

### Returns

A matrix of the specified row x column.

### Example

```kalk
>>> matrix(float,4,3,1..12)
# matrix(float, 4, 3, 1..12)
out = float4x3(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)
      # col  0           1           2           / row
      float3(1         , 2         , 3         ) # 0
      float3(4         , 5         , 6         ) # 1
      float3(7         , 8         , 9         ) # 2
      float3(10        , 11        , 12        ) # 3
```

## rgb

`rgb(arguments)`

Creates an rgb vector type with the specified argument values.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector (3). The arguments can be:
    - No values: All items of the rgb vector are initialized with the value 0.
    - an integer value: `rgb(0xAABBCC)` will extract the RGB 8-bits component values (AA: R, BB: G, CC: B).
    - a string value: `rgb("#AABBCC")` or `rgb("AABBCC")` will extract the RGB 8-bits component values (AA: R, BB: G, CC: B).
    - an array value: `rgb([0xAA,0xBB,0xCC])` will initialize rgb elements with the array elements. The size of the array must match the size of the rgb vector (3).
    - A combination of vectors/single values (e.g `rgb(float3(0.1, 0.2, 0.3)`).

### Returns

A rgb vector initialized with the specified arguments

### Example

```kalk
>>> rgb(0xAABBCC)
# rgb(11189196)
out = rgb(170, 187, 204) ## AABBCC ##
>>> rgb("#AABBCC")
# rgb("#AABBCC")
out = rgb(170, 187, 204) ## AABBCC ##
>>> rgb("AABBCC")
# rgb("AABBCC")
out = rgb(170, 187, 204) ## AABBCC ##
>>> rgb([0xAA,0xBB,0xCC])
# rgb([170,187,204])
out = rgb(170, 187, 204) ## AABBCC ##
>>> out.xyz
# out.xyz
out = float3(0.6666667, 0.73333335, 0.8)
>>> rgb(out)
# rgb(out)
out = rgb(170, 187, 204) ## AABBCC ##
```

## rgba

`rgba(arguments)`

Creates an rgba vector type with the specified argument values.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector (4). The arguments can be:
    - No values: All items of the rgba vector are initialized with the value 0.
    - an integer value: `rgba(0xFFAABBCC)` will extract the RGB 8-bits component values (FF: A, AA: R, BB: G, CC: B).
    - a string value: `rgba("#FFAABBCC")` or `rgba("FFAABBCC")` will extract the RGB 8-bits component values (FF: A, AA: R, BB: G, CC: B).
    - an array value: `rgba([0xAA,0xBB,0xCC,0xFF])` will initialize rgba elements with the array elements. The size of the array must match the size of the rgb vector (3).
    - A combination of vectors/single values (e.g `rgba(float4(0.1, 0.2, 0.3, 1.0)`).

### Returns

A rgb vector initialized with the specified arguments

### Example

```kalk
>>> rgba(0xFFAABBCC)
# rgba(-5588020)
out = rgba(170, 187, 204, 255) ## AABBCCFF ##
>>> rgba("#FFAABBCC")
# rgba("#FFAABBCC")
out = rgba(170, 187, 204, 255) ## AABBCCFF ##
>>> rgba("FFAABBCC")
# rgba("FFAABBCC")
out = rgba(170, 187, 204, 255) ## AABBCCFF ##
>>> rgba([0xAA,0xBB,0xCC,0xFF])
# rgba([170,187,204,255])
out = rgba(170, 187, 204, 255) ## AABBCCFF ##
>>> out.xyzw
# out.xyzw
out = float4(0.6666667, 0.73333335, 0.8, 1)
>>> rgba(out)
# rgba(out)
out = rgba(170, 187, 204, 255) ## AABBCCFF ##
```

## sbyte

`sbyte(value?)`

Creates a signed-byte value.

- `value`: The input value.

### Returns

A signed-byte value

### Example

```kalk
>>> sbyte
# sbyte
out = 0
>>> sbyte 0
# sbyte(0)
out = 0
>>> sbyte 127
# sbyte(127)
out = 127
>>> sbyte(-128)
# sbyte(-128)
out = -128
```

## sbyte16

`sbyte16(arguments)`

Creates a vector of 16 `sbyte` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `sbyte16(123)` will initialize all elements with 123.
    - an array value: `sbyte16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `sbyte4(sbyte2(1,2), sbyte2(3,4))` or `sbyte4(sbyte3(1,2,3), 4)`.

### Returns

A sbyte16 vector initialized with the specified arguments

### Example

```kalk
>>> sbyte16
# sbyte16
out = sbyte16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> sbyte16(1..16)
# sbyte16(1..16)
out = sbyte16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> sbyte16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# sbyte16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = sbyte16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## sbyte32

`sbyte32(arguments)`

Creates a vector of 32 `sbyte` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `sbyte32(123)` will initialize all elements with 123.
    - an array value: `sbyte32(1..32)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `sbyte4(sbyte2(1,2), sbyte2(3,4))` or `sbyte4(sbyte3(1,2,3), 4)`.

### Returns

A sbyte32 vector initialized with the specified arguments

### Example

```kalk
>>> sbyte32
# sbyte32
out = sbyte32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> sbyte32(1..32)
# sbyte32(1..32)
out = sbyte32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32)
```

## sbyte64

`sbyte64(arguments)`

Creates a vector of 64 `sbyte` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `sbyte64(123)` will initialize all elements with 123.
    - an array value: `sbyte64(1..64)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `sbyte4(sbyte2(1,2), sbyte2(3,4))` or `sbyte4(sbyte3(1,2,3), 4)`.

### Returns

A sbyte64 vector initialized with the specified arguments

### Example

```kalk
>>> sbyte64
# sbyte64
out = sbyte64(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> sbyte64(1..64)
# sbyte64(1..64)
out = sbyte64(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64)
```

## short

`short(value?)`

Creates a signed-short (16-bit) value.

- `value`: The input value.

### Returns

A signed-short (16-bit) value

### Example

```kalk
>>> short
# short
out = 0
>>> short 0
# short(0)
out = 0
>>> short 32767
# short(32767)
out = 32767
>>> short(-32768)
# short(-32768)
out = -32768
>>> short 32768
Unable to convert type `int` to `short`
```

## short16

`short16(arguments)`

Creates a vector of 16 `short` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `short16(123)` will initialize all elements with 123.
    - an array value: `short16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `short4(short2(1,2), short2(3,4))` or `short4(short3(1,2,3), 4)`.

### Returns

A short16 vector initialized with the specified arguments

### Example

```kalk
>>> short16
# short16
out = short16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> short16(1..16)
# short16(1..16)
out = short16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> short16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# short16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = short16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## short2

`short2(arguments)`

Creates a vector of 2 `short` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `short2(123)` will initialize all elements with 123.
    - an array value: `short2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `short4(short2(1,2), short2(3,4))` or `short4(short3(1,2,3), 4)`.

### Returns

A short2 vector initialized with the specified arguments

### Example

```kalk
>>> short2
# short2
out = short2(0, 0)
>>> short2(1..2)
# short2(1..2)
out = short2(1, 2)
>>> short2(10, 11)
# short2(10, 11)
out = short2(10, 11)
```

## short32

`short32(arguments)`

Creates a vector of 32 `short` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `short32(123)` will initialize all elements with 123.
    - an array value: `short32(1..32)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `short4(short2(1,2), short2(3,4))` or `short4(short3(1,2,3), 4)`.

### Returns

A short32 vector initialized with the specified arguments

### Example

```kalk
>>> short32
# short32
out = short32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> short32(1..32)
# short32(1..32)
out = short32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32)
```

## short4

`short4(arguments)`

Creates a vector of 4 `short` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `short4(123)` will initialize all elements with 123.
    - an array value: `short4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `short4(short2(1,2), short2(3,4))` or `short4(short3(1,2,3), 4)`.

### Returns

A short4 vector initialized with the specified arguments

### Example

```kalk
>>> short4
# short4
out = short4(0, 0, 0, 0)
>>> short4(1..4)
# short4(1..4)
out = short4(1, 2, 3, 4)
>>> short4(10, 11, 12, 13)
# short4(10, 11, 12, 13)
out = short4(10, 11, 12, 13)
```

## short8

`short8(arguments)`

Creates a vector of 8 `short` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `short8(123)` will initialize all elements with 123.
    - an array value: `short8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `short4(short2(1,2), short2(3,4))` or `short4(short3(1,2,3), 4)`.

### Returns

A short8 vector initialized with the specified arguments

### Example

```kalk
>>> short8
# short8
out = short8(0, 0, 0, 0, 0, 0, 0, 0)
>>> short8(1..8)
# short8(1..8)
out = short8(1, 2, 3, 4, 5, 6, 7, 8)
>>> short8(10, 11, 12, 13, 14, 15, 16, 17)
# short8(10, 11, 12, 13, 14, 15, 16, 17)
out = short8(10, 11, 12, 13, 14, 15, 16, 17)
```

## uint

`uint(value?)`

Creates an unsigned int (32-bit) value.

- `value`: The input value.

### Returns

An unsigned int (32-bit) value

### Example

```kalk
>>> uint
# uint
out = 0
>>> uint 0
# uint(0)
out = 0
>>> uint(1<<32 - 1)
# uint(1 << 32 - 1)
out = 4294967295
```

## uint16

`uint16(arguments)`

Creates a vector of 16 `uint` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `uint16(123)` will initialize all elements with 123.
    - an array value: `uint16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `uint4(uint2(1,2), uint2(3,4))` or `uint4(uint3(1,2,3), 4)`.

### Returns

A uint16 vector initialized with the specified arguments

### Example

```kalk
>>> uint16
# uint16
out = uint16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> uint16(1..16)
# uint16(1..16)
out = uint16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> uint16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# uint16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = uint16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## uint2

`uint2(arguments)`

Creates a vector of 2 `uint` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `uint2(123)` will initialize all elements with 123.
    - an array value: `uint2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `uint4(uint2(1,2), uint2(3,4))` or `uint4(uint3(1,2,3), 4)`.

### Returns

A uint2 vector initialized with the specified arguments

### Example

```kalk
>>> uint2
# uint2
out = uint2(0, 0)
>>> uint2(1..2)
# uint2(1..2)
out = uint2(1, 2)
>>> uint2(10, 11)
# uint2(10, 11)
out = uint2(10, 11)
```

## uint3

`uint3(arguments)`

Creates a vector of 3 `uint` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `uint3(123)` will initialize all elements with 123.
    - an array value: `uint3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `uint4(uint2(1,2), uint2(3,4))` or `uint4(uint3(1,2,3), 4)`.

### Returns

A uint3 vector initialized with the specified arguments

### Example

```kalk
>>> uint3
# uint3
out = uint3(0, 0, 0)
>>> uint3(1..3)
# uint3(1..3)
out = uint3(1, 2, 3)
>>> uint3(10, 11, 12)
# uint3(10, 11, 12)
out = uint3(10, 11, 12)
```

## uint4

`uint4(arguments)`

Creates a vector of 4 `uint` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `uint4(123)` will initialize all elements with 123.
    - an array value: `uint4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `uint4(uint2(1,2), uint2(3,4))` or `uint4(uint3(1,2,3), 4)`.

### Returns

A uint4 vector initialized with the specified arguments

### Example

```kalk
>>> uint4
# uint4
out = uint4(0, 0, 0, 0)
>>> uint4(1..4)
# uint4(1..4)
out = uint4(1, 2, 3, 4)
>>> uint4(10, 11, 12, 13)
# uint4(10, 11, 12, 13)
out = uint4(10, 11, 12, 13)
```

## uint8

`uint8(arguments)`

Creates a vector of 8 `uint` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `uint8(123)` will initialize all elements with 123.
    - an array value: `uint8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `uint4(uint2(1,2), uint2(3,4))` or `uint4(uint3(1,2,3), 4)`.

### Returns

A uint8 vector initialized with the specified arguments

### Example

```kalk
>>> uint8
# uint8
out = uint8(0, 0, 0, 0, 0, 0, 0, 0)
>>> uint8(1..8)
# uint8(1..8)
out = uint8(1, 2, 3, 4, 5, 6, 7, 8)
>>> uint8(10, 11, 12, 13, 14, 15, 16, 17)
# uint8(10, 11, 12, 13, 14, 15, 16, 17)
out = uint8(10, 11, 12, 13, 14, 15, 16, 17)
```

## ulong

`ulong(value?)`

Creates an unsigned long (64-bit) value.

- `value`: The input value.

### Returns

An unsigned long (64-bit) value

### Example

```kalk
>>> ulong
# ulong
out = 0
>>> ulong 0
# ulong(0)
out = 0
>>> ulong(1 << 64 - 1)
# ulong(1 << 64 - 1)
out = 18446744073709551615
```

## ulong2

`ulong2(arguments)`

Creates a vector of 2 `ulong` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ulong2(123)` will initialize all elements with 123.
    - an array value: `ulong2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ulong4(ulong2(1,2), ulong2(3,4))` or `ulong4(ulong3(1,2,3), 4)`.

### Returns

A ulong2 vector initialized with the specified arguments

### Example

```kalk
>>> ulong2
# ulong2
out = ulong2(0, 0)
>>> ulong2(1..2)
# ulong2(1..2)
out = ulong2(1, 2)
>>> ulong2(10, 11)
# ulong2(10, 11)
out = ulong2(10, 11)
```

## ulong3

`ulong3(arguments)`

Creates a vector of 3 `ulong` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ulong3(123)` will initialize all elements with 123.
    - an array value: `ulong3(1..3)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ulong4(ulong2(1,2), ulong2(3,4))` or `ulong4(ulong3(1,2,3), 4)`.

### Returns

A ulong3 vector initialized with the specified arguments

### Example

```kalk
>>> ulong3
# ulong3
out = ulong3(0, 0, 0)
>>> ulong3(1..3)
# ulong3(1..3)
out = ulong3(1, 2, 3)
>>> ulong3(10, 11, 12)
# ulong3(10, 11, 12)
out = ulong3(10, 11, 12)
```

## ulong4

`ulong4(arguments)`

Creates a vector of 4 `ulong` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ulong4(123)` will initialize all elements with 123.
    - an array value: `ulong4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ulong4(ulong2(1,2), ulong2(3,4))` or `ulong4(ulong3(1,2,3), 4)`.

### Returns

A ulong4 vector initialized with the specified arguments

### Example

```kalk
>>> ulong4
# ulong4
out = ulong4(0, 0, 0, 0)
>>> ulong4(1..4)
# ulong4(1..4)
out = ulong4(1, 2, 3, 4)
>>> ulong4(10, 11, 12, 13)
# ulong4(10, 11, 12, 13)
out = ulong4(10, 11, 12, 13)
```

## ulong8

`ulong8(arguments)`

Creates a vector of 8 `ulong` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ulong8(123)` will initialize all elements with 123.
    - an array value: `ulong8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ulong4(ulong2(1,2), ulong2(3,4))` or `ulong4(ulong3(1,2,3), 4)`.

### Returns

A ulong8 vector initialized with the specified arguments

### Example

```kalk
>>> ulong8
# ulong8
out = ulong8(0, 0, 0, 0, 0, 0, 0, 0)
>>> ulong8(1..8)
# ulong8(1..8)
out = ulong8(1, 2, 3, 4, 5, 6, 7, 8)
>>> ulong8(10, 11, 12, 13, 14, 15, 16, 17)
# ulong8(10, 11, 12, 13, 14, 15, 16, 17)
out = ulong8(10, 11, 12, 13, 14, 15, 16, 17)
```

## ushort

`ushort(value?)`

Creates an unsigned short (16-bit) value.

- `value`: The input value.

### Returns

An unsigned short (16-bit) value

### Example

```kalk
>>> ushort
# ushort
out = 0
>>> ushort 0
# ushort(0)
out = 0
>>> ushort 65535
# ushort(65535)
out = 65535
```

## ushort16

`ushort16(arguments)`

Creates a vector of 16 `ushort` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ushort16(123)` will initialize all elements with 123.
    - an array value: `ushort16(1..16)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ushort4(ushort2(1,2), ushort2(3,4))` or `ushort4(ushort3(1,2,3), 4)`.

### Returns

A ushort16 vector initialized with the specified arguments

### Example

```kalk
>>> ushort16
# ushort16
out = ushort16(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> ushort16(1..16)
# ushort16(1..16)
out = ushort16(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
>>> ushort16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
# ushort16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
out = ushort16(10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25)
```

## ushort2

`ushort2(arguments)`

Creates a vector of 2 `ushort` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ushort2(123)` will initialize all elements with 123.
    - an array value: `ushort2(1..2)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ushort4(ushort2(1,2), ushort2(3,4))` or `ushort4(ushort3(1,2,3), 4)`.

### Returns

A ushort2 vector initialized with the specified arguments

### Example

```kalk
>>> ushort2
# ushort2
out = ushort2(0, 0)
>>> ushort2(1..2)
# ushort2(1..2)
out = ushort2(1, 2)
>>> ushort2(10, 11)
# ushort2(10, 11)
out = ushort2(10, 11)
```

## ushort32

`ushort32(arguments)`

Creates a vector of 32 `ushort` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ushort32(123)` will initialize all elements with 123.
    - an array value: `ushort32(1..32)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ushort4(ushort2(1,2), ushort2(3,4))` or `ushort4(ushort3(1,2,3), 4)`.

### Returns

A ushort32 vector initialized with the specified arguments

### Example

```kalk
>>> ushort32
# ushort32
out = ushort32(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
>>> ushort32(1..32)
# ushort32(1..32)
out = ushort32(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32)
```

## ushort4

`ushort4(arguments)`

Creates a vector of 4 `ushort` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ushort4(123)` will initialize all elements with 123.
    - an array value: `ushort4(1..4)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ushort4(ushort2(1,2), ushort2(3,4))` or `ushort4(ushort3(1,2,3), 4)`.

### Returns

A ushort4 vector initialized with the specified arguments

### Example

```kalk
>>> ushort4
# ushort4
out = ushort4(0, 0, 0, 0)
>>> ushort4(1..4)
# ushort4(1..4)
out = ushort4(1, 2, 3, 4)
>>> ushort4(10, 11, 12, 13)
# ushort4(10, 11, 12, 13)
out = ushort4(10, 11, 12, 13)
```

## ushort8

`ushort8(arguments)`

Creates a vector of 8 `ushort` items.

- `arguments`: The vector item values. The total number of values must equal the dimension of the vector. The arguments can be:
    - No values: All items of the vector are initialized with the value 0.
    - a single value: `ushort8(123)` will initialize all elements with 123.
    - an array value: `ushort8(1..8)` will initialize all elements with the array elements. The size of the array must match the size of the vector.
    - A combination of vectors/single values (e.g `ushort4(ushort2(1,2), ushort2(3,4))` or `ushort4(ushort3(1,2,3), 4)`.

### Returns

A ushort8 vector initialized with the specified arguments

### Example

```kalk
>>> ushort8
# ushort8
out = ushort8(0, 0, 0, 0, 0, 0, 0, 0)
>>> ushort8(1..8)
# ushort8(1..8)
out = ushort8(1, 2, 3, 4, 5, 6, 7, 8)
>>> ushort8(10, 11, 12, 13, 14, 15, 16, 17)
# ushort8(10, 11, 12, 13, 14, 15, 16, 17)
out = ushort8(10, 11, 12, 13, 14, 15, 16, 17)
```

## vector

`vector(name,dimension,arguments)`

Creates a vector of the specified element type, with the number of elements and optional values.

- `name`: The element type of the vector (e.g float).
- `dimension`: The dimension of the vector.
- `arguments`: The optional values (must have 1 or dimension elements).

### Returns

A matrix of the specified row x column.

### Example

```kalk
>>> vector(float, 4, 5..8)
# vector(float, 4, 5..8)
out = float4(5, 6, 7, 8)
```
