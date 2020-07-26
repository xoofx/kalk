---
title: Language Syntax
---

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

#### Big Integers

With any number of digits:

```kalk
>>> 1e50
# 100000000000000000000000000000000000000000000000000
out = 100000000000000000000000000000000000000000000000000
```

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

### Floats

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

### Vectors


### Matrices


### Strings

### Arrays

### Ranges

### Objects

### ByteBuffers


## Expressions



## Control Flows








