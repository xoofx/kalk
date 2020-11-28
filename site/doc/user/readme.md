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

### Extras

Some functions like `ascii` can display a convenient ASCII table:

```kalk
>>> ascii
 ASCII controls                         ASCII printable characters     Extended ASCII Characters
  0 "\x00" (NUL / Null)                 32 " "   64 "@"   96 "`"       128 "€"  160 " "  192 "À"  224 "à"
  1 "\x01" (SOH / Start of Heading)     33 "!"   65 "A"   97 "a"       129 ""  161 "¡"  193 "Á"  225 "á"
  2 "\x02" (STX / Start of Text)        34 "\""  66 "B"   98 "b"       130 "‚"  162 "¢"  194 "Â"  226 "â"
  3 "\x03" (ETX / End of Text)          35 "#"   67 "C"   99 "c"       131 "ƒ"  163 "£"  195 "Ã"  227 "ã"
  4 "\x04" (EOT / End of Transmission)  36 "$"   68 "D"  100 "d"       132 "„"  164 "¤"  196 "Ä"  228 "ä"
  5 "\x05" (ENQ / Enquiry)              37 "%"   69 "E"  101 "e"       133 "…"  165 "¥"  197 "Å"  229 "å"
  6 "\x06" (ACK / Acknowledgment)       38 "&"   70 "F"  102 "f"       134 "†"  166 "¦"  198 "Æ"  230 "æ"
  7 "\a"   (BEL / Bell)                 39 "'"   71 "G"  103 "g"       135 "‡"  167 "§"  199 "Ç"  231 "ç"
  8 "\b"   (BS  / Backspace)            40 "("   72 "H"  104 "h"       136 "ˆ"  168 "¨"  200 "È"  232 "è"
  9 "\t"   (HT  / Horizontal Tab)       41 ")"   73 "I"  105 "i"       137 "‰"  169 "©"  201 "É"  233 "é"
 10 "\n"   (LF  / Line Feed)            42 "*"   74 "J"  106 "j"       138 "Š"  170 "ª"  202 "Ê"  234 "ê"
 11 "\v"   (VT  / Vertical Tab)         43 "+"   75 "K"  107 "k"       139 "‹"  171 "«"  203 "Ë"  235 "ë"
 12 "\f"   (FF  / Form Feed)            44 ","   76 "L"  108 "l"       140 ""  173 "­"  205 "Í"  237 "í"
 14 "\x0e" (SO  / Shift Out)            46 "."   78 "N"  110 "n"       142 "Ž"  174 "®"  206 "Î"  238 "î"
 15 "\x0f" (SI  / Shift In)             47 "/"   79 "O"  111 "o"       143 "¢  175 "¯"  207 "Ï"  239 "ï"
 16 "\x10" (DLE / Data Link Escape)     48 "0"   80 "P"  112 "p"       144 "  176 "°"  208 "Ð"  240 "ð"
 17 "\x11" (DC1 / Device Control 1)     49 "1"   81 "Q"  113 "q"       145 "‘"  177 "±"  209 "Ñ"  241 "ñ"
 18 "\x12" (DC2 / Device Control 2)     50 "2"   82 "R"  114 "r"       146 "’"  178 "²"  210 "Ò"  242 "ò"
 19 "\x13" (DC3 / Device Control 3)     51 "3"   83 "S"  115 "s"       147 "“"  179 "³"  211 "Ó"  243 "ó"
 20 "\x14" (DC4 / Device Control 4)     52 "4"   84 "T"  116 "t"       148 "”"  180 "´"  212 "Ô"  244 "ô"
 21 "\x15" (NAK / Negative Ack)         53 "5"   85 "U"  117 "u"       149 "•"  181 "µ"  213 "Õ"  245 "õ"
 22 "\x16" (SYN / Synchronous Idle)     54 "6"   86 "V"  118 "v"       150 "–"  182 "¶"  214 "Ö"  246 "ö"
 23 "\x17" (ETB / End of Trans Block)   55 "7"   87 "W"  119 "w"       151 "—"  183 "·"  215 "×"  247 "÷"
 24 "\x18" (CAN / Cancel)               56 "8"   88 "X"  120 "x"       152 "˜"  184 "¸"  216 "Ø"  248 "ø"
 25 "\x19" (EM  / End of Medium)        57 "9"   89 "Y"  121 "y"       153 "™"  185 "¹"  217 "Ù"  249 "ù"
 26 "\x1a" (SUB / Substitute)           58 ":"   90 "Z"  122 "z"       154 "š"  186 "º"  218 "Ú"  250 "ú"
 27 "\x1b" (ESC / Escape)               59 ";"   91 "["  123 "{"       155 "›"  187 "»"  219 "Û"  251 "û"
 28 "\x1c" (FS  / File Separator)       60 "<"   92 "\\" 124 "|"       156 "œ"  188 "¼"  220 "Ü"  252 "ü"
 29 "\x1d" (GS  / Group Separator)      61 "="   93 "]"  125 "}"       157 "  189 "½"  221 "Ý"  253 "ý"
 30 "\x1e" (RS  / Record Separator)     62 ">"   94 "^"  126 "~"       158 "ž"  190 "¾"  222 "Þ"  254 "þ"
 31 "\x1f" (US  / Unit Separator)       63 "?"   95 "_"  127 ""       159 "Ÿ"  191 "¿"  223 "ß"  255 "ÿ"
 ```

You can also try the `colors` function to see what it displays!

```kalk
>>> colors # watch out!
```

### Next

- Checkout [Language Syntax](syntax.md) for more details about `kalk` powerful language.
- Checkout [Advanced Topics](../advanced/readme.md) to use `kalk` in more advanced ways.
