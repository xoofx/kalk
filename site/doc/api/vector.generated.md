---
title: Vector Functions
url: /doc/api/vector/
---

## col

`col(x,index)`

Extract a column from the specified matrix.

- `x`: The matrix to extract a column from.
- `index`: The index of the column (zero based).

### Returns

A vector extracted from the matrix.

### Example

```kalk
>>> col(float4x4(1..16), 2)
# col(float4x4(1..16), 2)
out = float4(3, 7, 11, 15)
```

## cross

`cross(x,y)`

Returns the cross product of two floating-point, 3D vectors.

- `x`: The first floating-point, 3D vector.
- `y`: The second floating-point, 3D vector.

### Returns

The cross product of the x parameter and the y parameter.

### Example

```kalk
>>> cross(float3(1,2,3), float3(4,5,6))
# cross(float3(1, 2, 3), float3(4, 5, 6))
out = float3(-3, 6, -3)
>>> cross(float3(1,0,0), float3(0,1,0))
# cross(float3(1, 0, 0), float3(0, 1, 0))
out = float3(0, 0, 1)
>>> cross(float3(0,0,1), float3(0,1,0))
# cross(float3(0, 0, 1), float3(0, 1, 0))
out = float3(-1, 0, 0)
```

## determinant

`determinant(m)`

Calculates the determinant of the specified matrix.

- `m`: The matrix to calculate the determinant for.

### Returns

A scalar representing the determinant of the matrix.

### Example

```kalk
>>> float4x4(4,3,2,2,0,1,-3,3,0,-1,3,3,0,3,1,1)
# float4x4(4, 3, 2, 2, 0, 1, -3, 3, 0, -1, 3, 3, 0, 3, 1, 1)
out = float4x4(4, 3, 2, 2, 0, 1, -3, 3, 0, -1, 3, 3, 0, 3, 1, 1)
      # col  0            1           2          3           / row
      float4(4         ,  3        ,  2        , 2         ) # 0
      float4(0         ,  1        , -3        , 3         ) # 1
      float4(0         , -1        ,  3        , 3         ) # 2
      float4(0         ,  3        ,  1        , 1         ) # 3
>>> determinant out
# determinant(out)
out = -240
```

## diag

`diag(x)`

Returns the diagonal vector of a squared matrix or a diagonal matrix from the specified vector.

- `x`: A vector or matrix to return the associated diagonal for.

### Returns

A diagonal vector of a matrix or a diagonal matrix of a vector.

### Example

```kalk
 >>> diag(float4x4(1..16))
 # diag(float4x4(1..16))
 out = float4(1, 6, 11, 16)
 >>> diag(float4(1,2,3,4))
 # diag(float4(1, 2, 3, 4))
 out = float4x4(1, 0, 0, 0, 0, 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 4)
       # col  0           1           2           3           / row
       float4(1         , 0         , 0         , 0         ) # 0
       float4(0         , 2         , 0         , 0         ) # 1
       float4(0         , 0         , 3         , 0         ) # 2
       float4(0         , 0         , 0         , 4         ) # 3
```

## dot

`dot(x,y)`

Returns the dot product of two vectors.

- `x`: The first vector.
- `y`: The second vector.

### Returns

The dot product of the x parameter and the y parameter.

### Example

```kalk
>>> dot(float3(1,2,3), float3(4,5,6))
# dot(float3(1, 2, 3), float3(4, 5, 6))
out = 32
>>> dot(float3(1,2,3), 4)
# dot(float3(1, 2, 3), 4)
out = 24
>>> dot(4, float3(1,2,3))
# dot(4, float3(1, 2, 3))
out = 24
>>> dot(5,6)
# dot(5, 6)
out = 30
```

## identity

`identity(m)`

Creates an identity of a squared matrix.

- `m`: The type of the squared matrix.

### Returns

The identity matrix of the squared matrix type.

### Example

```kalk
>>> identity(float4x4)
# identity(float4x4)
out = float4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1)
      # col  0           1           2           3           / row
      float4(1         , 0         , 0         , 0         ) # 0
      float4(0         , 1         , 0         , 0         ) # 1
      float4(0         , 0         , 1         , 0         ) # 2
      float4(0         , 0         , 0         , 1         ) # 3
```

## inverse

`inverse(m)`

Calculates the inverse of the specified matrix.

- `m`: The matrix to calculate the inverse for.

### Returns

The inverse matrix of the specified matrix.

### Example

```kalk
>>> inverse(float3x3(10,20,10,4,5,6,2,3,5))
# inverse(float3x3(10, 20, 10, 4, 5, 6, 2, 3, 5))
out = float3x3(-0.1, 1, -1, 0.11428571, -0.42857143, 0.28571427, -0.028571427, -0.14285715, 0.42857143)
      # col   0             1            2           / row
      float3(-0.1        ,  1         , -1         ) # 0
      float3( 0.11428571 , -0.42857143,  0.28571427) # 1
      float3(-0.028571427, -0.14285715,  0.42857143) # 2
```

## length

`length(x)`

Returns the length of the specified floating-point vector.

- `x`: The specified floating-point vector.

### Returns

A floating-point scalar that represents the length of the x parameter.

### Example

```kalk
>>> length float2(1, 2)
# length(float2(1, 2))
out = 2.23606797749979
>>> length -5
# length(-5)
out = 5
```

## mul

`mul(x,y)`

Multiplies a vector x vector (dot product), or a vector x matrix, or a matrix x vector or a matrix x matrix.

- `x`: A left vector or a matrix.
- `y`: A right vector or matrix.

### Returns

The result of the multiplication.

### Example

```kalk
>>> mul(float4(1,2,3,4), float4(5,6,7,8))
# mul(float4(1, 2, 3, 4), float4(5, 6, 7, 8))
out = 70
>>> mul(float3(3,7,5), float3x3(2,3,-4,11,8,7,2,5,3))
# mul(float3(3, 7, 5), float3x3(2, 3, -4, 11, 8, 7, 2, 5, 3))
out = float3(7, 124, 56)
>>> mul(float3x3(2,3,-4,11,8,7,2,5,3), float3(3,7,5))
# mul(float3x3(2, 3, -4, 11, 8, 7, 2, 5, 3), float3(3, 7, 5))
out = float3(93, 90, 52)
>>> mul(float3x3(2,7,4,3,2,1,9,-1,2), float3x3(1,4,6,-1,-2,5,8,7,6))
# mul(float3x3(2, 7, 4, 3, 2, 1, 9, -1, 2), float3x3(1, 4, 6, -1, -2, 5, 8, 7, 6))
out = float3x3(68, 9, 20, 37, -16, 4, 91, 64, 51)
      # col  0            1          2           / row
      float3(68        ,  9        , 20        ) # 0
      float3(37        , -16       , 4         ) # 1
      float3(91        ,  64       , 51        ) # 2
```

## normalize

`normalize(x)`

Normalizes the specified floating-point vector according to x / length(x).

- `x`: he specified floating-point vector.

### Returns

The normalized x parameter. If the length of the x parameter is 0, the result is indefinite.

### Example

```kalk
>>> normalize float2(1,2)
# normalize(float2(1, 2))
out = float2(0.4472136, 0.8944272)
```

## row

`row(x,index)`

Extract a row from the specified matrix.

- `x`: The matrix to extract a row from.
- `index`: The index of the row (zero based).

### Returns

A vector extracted from the matrix.

### Example

```kalk
>>> row(float4x4(1..16), 2)
# row(float4x4(1..16), 2)
out = float4(9, 10, 11, 12)
```

## transpose

`transpose(m)`

Transposes the specified matrix.

- `m`: The matrix to transpose.

### Returns

The transposed matrix.

### Example

```kalk
>>> transpose float3x4(1..12)
# transpose(float3x4(1..12))
out = float4x3(1, 5, 9, 2, 6, 10, 3, 7, 11, 4, 8, 12)
      # col  0           1           2           / row
      float3(1         , 5         , 9         ) # 0
      float3(2         , 6         , 10        ) # 1
      float3(3         , 7         , 11        ) # 2
      float3(4         , 8         , 12        ) # 3
>>> transpose(out)
# transpose(out)
out = float3x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12)
      # col  0           1           2           3           / row
      float4(1         , 2         , 3         , 4         ) # 0
      float4(5         , 6         , 7         , 8         ) # 1
      float4(9         , 10        , 11        , 12        ) # 2
```
