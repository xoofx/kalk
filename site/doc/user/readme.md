---
title: User Guide
---

## Getting Started

`kalk` is a simple command line calculator. Run it from a shell terminal:

```shell-session
$ kalk
```

### Expressions

Then you can start to type mathematical expressions and get their results:

```kalk
>>> 1+2
# 1 + 2
out = 3
```

You can use many of the built-in functions:

```kalk
>>> cos 3π/5 + 1
# cos((3 * π) / 5) + 1
out = 0.6909830056250527
```

> When functions are taking only one argument, you can omit the parenthesis.
>
> `kalk` conveniently write your expression with parenthesis in the output to make sure that what you wrote is what you expect to be evaluated.

### Variables

You can reuse the result of a previous calculation by using the special variable `out`:

```kalk
>>> log(125)
# log(125)
out = 4.8283137373023015
>>> out * 7
# out * 7
out = 33.79819616111611
```

You can store intermediate results in a variable:

```kalk
>>> x = 1
# x = 1
x = 1
>>> y = 2
# y = 2
y = 2
>>> x + y
# x + y
out = 3
```

You can list your declared variables:

```kalk
>>> list
# Variables
x = 1
y = 2
```

### Functions

You can create you own custom function:

```kalk
>>> f(x) = x^2 + 2x + 1
# f(x) = (x ^ 2) + 2 * x + 1
f(x) = x ^ 2+ 2 x + 1
>>> f(1)
# f(1)
out = 4
>>> f(3)
# f(3)
out = 16
```

You can also list your declared functions:

```kalk
>>> list
# Functions
f(x) = x ^ 2+ 2 x + 1
```

### Pipe Expressions

You can use the operator `|>` to chain multiple functions input/output:

```kalk
>>> 1 |> cos |> log
# 1 |> cos |> log
out = -0.6156264703860141
```

### Modules

You can use modules (e.g `Strings`, `Files`) to extend the functions accessible:

```kalk
>>> import Strings
# 22 functions successfully imported from module `Strings`.
```

You can then use the functions provided by this module:

```kalk
>>> "this is a string, with some ^character" |> handleize
# "this is a string, with some ^character" |> handleize
out = "this-is-a-string-with-some-character"
```

### Units and Currencies

You can use standard units with `import StandardUnits`:

```kalk
>>> import StandardUnits
# 1294 units successfully imported from module `StandardUnits`.
>>> 15 kg/m
# (15 * kg) / m
out = 15000 * g / m
>>> (15 kg/m) * 7cm
# (((15 * kg) / m)) * 7 * cm
out = 1050 * g
```

Or you you can play easily with foreign exchange rates with `import Currencies`:

```kalk
>>> import Currencies
# 2 functions successfully imported from module `Currencies`.
# Downloading rates from https://api.exchangeratesapi.io/latest
# 32 rates successfully updated.
# Using rates defined as of 2020-11-27.
>>> 25 EUR |> to USD
# 25 * EUR |> to(USD)
out = 29.805 * USD
```

### Array types

You can use arrays:

```kalk
>>> 1..9
# 1..9
out = [1, 2, 3, 4, 5, 6, 7, 8, 9]
```

And perform calculations on them:

```kalk
>>> 1..9 |> cos
# 1..9 |> cos
out = [0.5403023058681398, -0.4161468365471424, -0.9899924966004454, -0.6536436208636119, 0.28366218546322625, 0.960170286650366, 0.7539022543433046, -0.14550003380861354, -0.9111302618846769]
```

### Vector and Matrix types

You can use vector and matrix types:

```kalk
>>> x = float4(1,2,3,4)
# x = float4(1, 2, 3, 4)
x = float4(1, 2, 3, 4)
>>> mat = float4x4(1..16)
# mat = float4x4(1..16)
mat = float4x4(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16)
      # col  0           1           2           3           / row
      float4(1         , 2         , 3         , 4         ) # 0
      float4(5         , 6         , 7         , 8         ) # 1
      float4(9         , 10        , 11        , 12        ) # 2
      float4(13        , 14        , 15        , 16        ) # 3
>>> mul(mat, x)
# mul(mat, x)
out = float4(90, 100, 110, 120)
```

### Next

- Checkout [Language Syntax](syntax.md) for more details about `kalk` powerful language.
- Checkout [Advanced Topics](../advanced/readme.md) to use `kalk` in more advanced ways.







