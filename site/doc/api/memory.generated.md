---
title: Memory Functions
url: /doc/api/memory/
---

## asbytes

`asbytes(value)`

Binary cast the specified value to a bytebuffer.

- `value`: An input value.

### Returns

A binary bytebuffer representing the value in binary form. The size of the buffer equals the binary size in memory of the input value.

### Example

```kalk
>>> asbytes(float4(1..4))
# asbytes(float4(1..4))
out = bytebuffer([0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64])
>>> asbytes(int(0x01020304))
# asbytes(int(16909060))
out = bytebuffer([4, 3, 2, 1])
>>> asbytes(1.5)
# asbytes(1.5)
out = bytebuffer([0, 0, 0, 0, 0, 0, 248, 63])
>>> asbytes(2.5f)
# asbytes(2.5f)
out = bytebuffer([0, 0, 32, 64])
```

## asdouble

`asdouble(x)`

Reinterprets a 64-bit value into a double.

- `x`: The input value.

### Returns

The input recast as a double.

### Example

```kalk
>>> asdouble(1.5)
# asdouble(1.5)
out = 1.5
>>> aslong(1.5)
# aslong(1.5)
out = 4_609_434_218_613_702_656
>>> asdouble(out)
# asdouble(out)
out = 1.5
```

## asfloat

`asfloat(x)`

Reinterprets a 32-bit value into a float.

- `x`: The input value.

### Returns

The input recast as a float.

### Example

```kalk
>>> asfloat(1.5f)
# asfloat(1.5f)
out = 1.5
>>> asint(1.5f)
# asint(1.5f)
out = 1_069_547_520
>>> asfloat(out)
# asfloat(out)
out = 1.5
```

## asint

`asint(x)`

Reinterprets an input value into a 32-bit int.

- `x`: The input value.

### Returns

The input recast as a 32-bit int.

### Example

```kalk
>>> asint(1.5f)
# asint(1.5f)
out = 1_069_547_520
>>> asfloat(out)
# asfloat(out)
out = 1.5
```

## aslong

`aslong(x)`

Reinterprets an input value to a 64-bit long.

- `x`: The input value.

### Returns

The input recast as a 64-bit long.

### Example

```kalk
>>> aslong(1.5)
# aslong(1.5)
out = 4_609_434_218_613_702_656
>>> asdouble(out)
# asdouble(out)
out = 1.5
```

## asuint

`asuint(x)`

Reinterprets an input value into a 32-bit uint.

- `x`: The input value.

### Returns

The input recast as a 32-bit uint.

### Example

```kalk
>>> asuint(-1.5f)
# asuint(-1.5f)
out = 3_217_031_168
>>> asfloat(out)
# asfloat(out)
out = -1.5
```

## asulong

`asulong(x)`

Reinterprets an input value to a 64-bit ulong.

- `x`: The input value.

### Returns

The input recast as a 64-bit ulong.

### Example

```kalk
>>> asulong(-1.5)
# asulong(-1.5)
out = 13_832_806_255_468_478_464
>>> asdouble(out)
# asdouble(out)
out = -1.5
```

## bitcast

`bitcast(type,value)`

Binary cast of a value to a target type.

- `type`: The type to cast to.
- `value`: The value to cast.

### Returns

The binary cast of the input value.

### Remarks

The supported types are `byte`, `sbyte`, `short`, `ushort`, `int`, `uint`, `long`, `ulong`, `float`, `double`, `rgb`, `rgba` and all vector and matrix types.

### Example

```kalk
>>> bitcast(int, 1.5f)
# bitcast(int, 1.5f)
out = 1_069_547_520
>>> bitcast(float, out)
# bitcast(float, out)
out = 1.5
>>> bitcast(long, 2.5)
# bitcast(long, 2.5)
out = 4_612_811_918_334_230_528
>>> bitcast(double, out)
# bitcast(double, out)
out = 2.5
>>> asbytes(float4(1..4))
# asbytes(float4(1..4))
out = bytebuffer([0, 0, 128, 63, 0, 0, 0, 64, 0, 0, 64, 64, 0, 0, 128, 64])
>>> bitcast(float4, out)
# bitcast(float4, out)
out = float4(1, 2, 3, 4)
```

## bytebuffer

`bytebuffer(values)`

Creates a bytebuffer from the specified input.

- `values`: The input values.

### Returns

A bytebuffer from the specified input.

### Example

```kalk
>>> bytebuffer
# bytebuffer
out = bytebuffer([])
>>> bytebuffer(0,1,2,3,4)
# bytebuffer(0, 1, 2, 3, 4)
out = bytebuffer([0, 1, 2, 3, 4])
>>> bytebuffer(float4(1))
# bytebuffer(float4(1))
out = bytebuffer([0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63, 0, 0, 128, 63])
>>> bytebuffer([1,2,3,4])
# bytebuffer([1,2,3,4])
out = bytebuffer([1, 2, 3, 4])
```

## countbits

`countbits(value)`

Counts the number of bits (per component) of the input value.

- `value`: The input value.

### Returns

The number of bits (per component if the input is an int vector).

### Example

```kalk
>>> for val in 0..7; countbits(val); end;
# for val in 0..7; countbits(val); end;
out = 0
out = 1
out = 1
out = 2
out = 1
out = 2
out = 2
out = 3
>>> countbits(int4(1,2,3,4))
# countbits(int4(1, 2, 3, 4))
out = int4(1, 1, 2, 1)
>>> countbits(bytebuffer(1..16))
# countbits(bytebuffer(1..16))
out = 33
```

## firstbithigh

`firstbithigh(value)`

Gets the location of the first set bit starting from the highest order bit and working downward, per component.

- `value`: The input value.

### Returns

The location of the first set bit.

### Remarks

If no bits are sets, this function will return -1.

### Example

```kalk
>>> firstbithigh 128
# firstbithigh(128)
out = 24
>>> firstbithigh byte(128)
# firstbithigh(byte(128))
out = 0
>>> firstbithigh 0
# firstbithigh(0)
out = -1
>>> firstbithigh(int4(1, -1, 65536, 1 << 20))
# firstbithigh(int4(1, -1, 65536, 1 << 20))
out = int4(31, 0, 15, 11)
```

## firstbitlow

`firstbitlow(value)`

Returns the location of the first set bit starting from the lowest order bit and working upward, per component.

- `value`: The input value.

### Returns

The location of the first set bit.

### Remarks

If no bits are sets, this function will return -1.

### Example

```kalk
>>> firstbitlow 128
# firstbitlow(128)
out = 7
>>> firstbitlow byte(128)
# firstbitlow(byte(128))
out = 7
>>> firstbitlow 0
# firstbitlow(0)
out = -1
>>> firstbitlow(int4(1, -1, 65536, 1 << 20))
# firstbitlow(int4(1, -1, 65536, 1 << 20))
out = int4(0, 0, 16, 20)
```

## malloc

`malloc(size)`

Allocates a `bytebuffer` of the specified size.

- `size`: Size of the bytebuffer.

### Returns

A bytebuffer of the specified size.

### Example

```kalk
>>> buffer = malloc(16)
# buffer = malloc(16)
buffer = bytebuffer([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0])
>>> buffer[0] = 5
>>> buffer
# buffer
out = bytebuffer([5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0])
```

## reversebits

`reversebits(value)`

Reverses the order of the bits, per component

- `value`: The input value.

### Returns

The input value, with the bit order reversed

### Example

```kalk
>>> reversebits 128
# reversebits(128)
out = 16_777_216
>>> reversebits out
# reversebits(out)
out = 128
>>> reversebits byte(128)
# reversebits(byte(128))
out = 1
>>> reversebits(out)
# reversebits(out)
out = 128
>>> reversebits(int4(1,2,3,4))
# reversebits(int4(1, 2, 3, 4))
out = int4(-2_147_483_648, 1_073_741_824, -1_073_741_824, 536_870_912)
>>> reversebits out
# reversebits(out)
out = int4(1, 2, 3, 4)
```
