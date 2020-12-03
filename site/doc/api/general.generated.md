---
title: General Functions
url: /doc/api/general/
---

## action

`action(action)`

Creates an action for the command line editor experience related to
 cursor/text manipulation. This action can then be used by the `shortcut` command.

- `action`: The name of the action to create. This name must be
    
     {.table}
     | Action                | Description               |
     |-----------------------|---------------------------|
     | `cursor_left`         | Move the cursor to the left
     | `cursor_right`        | Move the cursor to the right
     | `history_previous`    | Bring the previous command from the history
     | `history_next`        | Bring the next command from the history
     | `copy`                | Copy the selection to the clipboard 
     | `cut`                 | Cut the selection to the clipboard 
     | `paste`               | Paste the content of the clipboard at the position of the cursor
     | `cursor_word_left`    | Move the cursor to the left by one word boundary
     | `cursor_word_right`   | Move the cursor to the right by one word boundary
     | `cursor_line_start`   | Move the cursor to the beginning of the line
     | `cursor_line_end`     | Move the cursor to the end of the line
     | `completion`          | Trigger a completion at the cursor's position
     | `delete_left`         | Delete the character to the left of the cursor
     | `delete_right`        | Delete the character to the right of the cursor
     | `delete_word_left`    | Delete a word to the left of the cursor
     | `delete_word_right`   | Delete a word to the right of the cursor
     | `validate_line`       | Validate the current line
     | `force_validate_line` | Validate the current line and force a new line even in case of a syntax error
     | `exit`                | Exit the program
     | `copy_or_exit`        | Copy the content of the selection to the clipboard or if there is no selection, exit the program

### Returns

An action object.

### Remarks

This function is not meant to be used directly but in conjunction with the `shortcut` command.

### Example

```kalk
 >>> shortcut(cursor_left, "left, ctrl+b", action("cursor_left"))
```

## alias

`alias(name,aliases)`

Creates an alias between variable names.

- `name`: Name of the original alias name.
- `aliases`: Variable names that are all equivalent to the alias name.

### Remarks

See the command `aliases` to list the aliases currently defined. Several aliases are defined by default for common mathematical symbols (e.g `alias(pi, Π, π)`).

### Example

```kalk
>>> alias(var1, var2, var3)
>>> var1 = 2
# var1 = 2
var1 = 2
>>> var2
# var2
out = 2
>>> var3
# var3
out = 2
>>> list
# Variables
var1 = 2
>>> var2 = 1
# var2 = 1
var2 = 1
>>> list
# Variables
var1 = 1
```

## aliases

`aliases`

Displays all built-in and user-defined aliases.

### Remarks

Aliases are usually used to define equivalent variable names for equivalent mathematical symbols. To create an alias, see the command `alias`.

### Example

```kalk
>>> aliases
# Builtin Aliases
alias(alpha, Α, α)
alias(beta, Β, β)
alias(chi, Χ, χ)
alias(delta, Δ, δ)
alias(epsilon, Ε, ε)
alias(eta, Η, η)
alias(gamma, Γ, γ)
alias(iota, Ι, ι)
alias(kappa, Κ, κ)
alias(lambda, Λ, λ)
alias(mu, Μ, μ)
alias(nu, Ν, ν)
alias(omega, Ω, ω)
alias(omicron, Ο, ο)
alias(phi, Φ, φ, ϕ)
alias(pi, Π, π)
alias(psi, Ψ, ψ)
alias(rho, Ρ, ρ)
alias(sigma, Σ, σ)
alias(tau, Τ, τ)
alias(theta, Θ, θ, ϑ)
alias(upsilon, Υ, υ)
alias(xi, Ξ, ξ)
alias(zeta, Ζ, ζ)
```

## clear

`clear(what?)`

Clears the screen (by default) or the history (e.g clear history).

- `what`: An optional argument specifying what to clear. Can be of the following value:
    * screen: to clear the screen (default if not passed)
    * history: to clear the history
    * shortcuts: to clear all shortcuts defined. WARNING, clearing shortcuts is removing all common shortcuts, including basic navigation and edition mode!

### Example

```kalk
>>> 1 + 2
# 1 + 2
out = 3
>>> history
0: 1 + 2
>>> clear history
>>> history
# History empty
```

## clipboard

`clipboard(value?)`

Gets or sets the current content of the clipboard.

- `value`: Value to set the clipboard to. If not set, this function returns the current content of the clipboard.

### Returns

Returns the content of the clipboard.

### Remarks

On Unix platform, if you are running from WSL or from raw console, the clipboard is not supported.

### Example

```kalk
>>> clipboard "text"
# clipboard("text")
out = "text"
>>> clipboard
# clipboard
out = "text"
```

## cls

`cls`

Clears the screen.

### Example

```kalk
>>> cls
```

## config

`config`

Gets the config object.

### Example

```kalk
>>> config
# config
out = {help_max_column: 100, limit_to_string: "auto"}
```

## del

`del(variable)`

Deletes a user defined variable or function.

- `variable`: Name of the variable or function to delete.

### Example

```kalk
>>> x = 5; y = 2
# x = 5; y = 2
x = 5
y = 2
>>> del x
# Variable `x == 5` deleted.
>>> list
# Variables
y = 2
>>> del y
# Variable `y == 2` deleted.
>>> f(x) = x + 5
# f(x) = x + 5
f(x) = x + 5
>>> list
# Functions
f(x) = x + 5
>>> del f
# Function `f(x) = x + 5` deleted.
>>> list
# No variables
```

## display

`display(name?)`

Gets or sets the display mode.

 - `std` for standard mode
 - `dev` for developer mode to display advanced details about integers, vectors and floating point values.
 - `eng` for engineering mode to display floating point values using 3 digits for the exponent.

- `name`: An optional parameter to set the display mode. Default is `std`. If this parameter is not set, this function will display the display mode currently used.

### Example

```kalk
 >>> display
 # Display mode: std (Standard)
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
 >>> display invalid
 Invalid display name `invalid`. Expecting `std`, `dev` or `eng`. (Parameter 'name')
```

## echo

`echo(value?)`

Gets or sets the current echo mode.

- `value`: An optional `true`/`on` or `false`/`off` value to enable or disable the echo. A value of `false` will disable any output generated by a command except for the print commands. If this parameter is not set, this function will display the current display mode.

### Example

```kalk
>>> echo
# Echo is on.
>>> 1 + 2
# 1 + 2
out = 3
>>> echo off
>>> 1 + 2
>>> echo
>>> echo on
# Echo is on.
>>> 1 + 2
# 1 + 2
out = 3
```

## eval

`eval(text,output?)`

Evaluates dynamically the input string as an expression.

- `text`: The text of the expression to evaluate.
- `output`: An optional parameter to output intermediate results of nested expressions. Default is `false`.

### Returns

The result of the evaluation.

### Example

```kalk
>>> eval "1+5"
# eval("1+5")
out = 6
>>> eval "eval '1+5'"
# eval("eval '1+5'")
out = 6
```

## exit

`exit`

Exits kalk.

### Example

```kalk
>>> exit
```

## help

`help(expression?)`

Displays the documentation of the specified topic or function name.

- `expression`: An optional topic or function name. If this parameter is not set, it will display all available topics and functions.

### Example

```kalk
>>> help cls
# cls
#
#   Clears the screen.
#
# Example
.   >>> cls
```

## history

`history(line?)`

Displays the command history.

- `line`: An optional parameter that indicates:
    
     - if it is >= 0, the index of the history command to re-run. (e.g `history 1` to re-run the command 1 in the history)
     - if it is < 0, how many recent lines to display. (e.g `history -3` would display the last 3 lines in the history)

### Example

```kalk
 >>> 1 + 5
 # 1 + 5
 out = 6
 >>> abs(out)
 # abs(out)
 out = 6
 >>> history
 0: 1 + 5
 1: abs(out)
```

## kind

`kind(value)`

Gets the kind of a value.

- `value`: A value to inspect the kind

### Example

```kalk
>>> kind 1
# kind(1)
out = "int"
>>> kind "a"
# kind("a")
out = "string"
>>> kind byte (1)
# kind(byte(1))
out = "byte"
>>> kind []
# kind([])
out = "array"
>>> kind {}
# kind({})
out = "object"
```

## license

`license`

Displays the license

## list

`list`

Lists all user-defined variables and functions.

### Example

```kalk
>>> x = 5; y = 2; f(x) = x + 5
# x = 5; y = 2; f(x) = x + 5
x = 5
y = 2
 f(x) = x + 5
>>> list
# Variables
x = 5
y = 2
# Functions
 f(x) = x + 5
```

## load

`load(path,output?)`

Loads and evaluates the specified script from a file location on a disk.

- `path`: The file location of the script to load and evaluate.
- `output`: An optional parameter to output intermediate results of nested expressions. Default is `false`.

### Returns

The result of the evaluation.

### Example

```kalk
>>> import Files
# 14 functions successfully imported from module `Files`.
>>> save_text("x = 1\ny = 2\nx + y", "test.kalk")
>>> load "test.kalk"
# load("test.kalk")
x = 1
y = 2
out = 3
```

## out

`out`

Returns the last evaluated result.

### Returns

The last evaluated result as an object.

### Example

```kalk
>>> 1 + 2
# 1 + 2
out = 3
>>> out + 1
# out + 1
out = 4
```

## out2clipboard

`out2clipboard`

Copies the last evaluated content to the clipboard.

 This is equivalent to `out |> clipboard`.

### Example

```kalk
 >>> 1 + 2
 # 1 + 2
 out = 3
 >>> out2clipboard
 >>> clipboard
 # clipboard
 out = "3"
```

## print

`print(value)`

Prints the specified value to the output.

- `value`: A value to print to the output.

### Remarks

When the `echo` is off, this method will still output.

### Example

```kalk
>>> print "kalk"
kalk
>>> echo off
>>> print "kalk2"
kalk2
```

## printf

`printf(value)`

Prints a formatted string where values to format are embraced by `{{` and `}}`.

- `value`: A template string to the output. Values to format must be embraced by `{{` and `}}`.

### Remarks

When the `echo` is off, this method will still output.

### Example

```kalk
>>> x = 1; y = "yes"
# x = 1; y = "yes"
x = 1
y = "yes"
>>> printf "Hello {{x}} World and {{y}}"
Hello 1 World and yes
```

## printh

`printh(value)`

Prints the specified value to the output formatted with kalk syntax highlighting.

- `value`: A value to print to the output.

### Remarks

When the `echo` is off, this method will still output.

### Example

```kalk
>>> printh "# This is a kalk comment"
# This is a kalk comment
```

## reset

`reset`

Removes all user-defined variables and functions.

### Example

```kalk
>>> x = 5; y = 2
# x = 5; y = 2
x = 5
y = 2
>>> list
# Variables
x = 5
y = 2
>>> reset
>>> list
# No variables
```

## shortcut

`shortcut(name,shortcuts)`

Creates a keyboard shortcut associated with an expression or remove a keyboard shortcut.

- `name`: Name of the shortcut
- `shortcuts`: A collection of pair of shortcut description (e.g `ctrl+a`) and associated shortcut expression (e.g `1 + 2`).

### Remarks

See the command `shortcuts` to list the shortcuts currently defined. By default several shortcuts for common mathematical symbols are defined (e.g for the symbol pi: `shortcut(pi, "ctrl+g p", "Π", "ctrl+g p", "π")`).

 If no shortcuts are associated to the name, the existing shortcuts for this name will be removed.

### Example

```kalk
 >>> # Creates a shortcut that will print 3 when pressing ctrl+R.
 >>> shortcut(myshortcut, "ctrl+g", 1 + 2)
 >>> # Overrides the previous shortcut that will print the text
 >>> # `kalk` when pressing ctrl+g.
 >>> shortcut(myshortcut, "ctrl+g", "kalk")
 >>> # Overrides the previous shortcut that will print the text
 >>> # `kalk` when pressing ctrl+g or the text `kalk2` when pressing
 >>> # ctrl+e and r key.
 >>> shortcut(myshortcut, "ctrl+g", "kalk", "ctrl+e r", "kalk2")
 >>> # Remove the previous defined shortcuts
 >>> shortcut(myshortcut)
```

## shortcuts

`shortcuts`

Displays all built-in and user-defined keyboard shortcuts.

### Remarks

To create an keyboard shortcut, see the command `shortcut`.

### Example

```kalk
>>> clear shortcuts
>>> shortcut(tester, "ctrl+d", '"' + date + '"')
>>> shortcuts
# User-defined Shortcuts
shortcut(tester, "ctrl+d", '"' + date + '"')                 # ctrl+d => '"' + date + '"'
```

## sprintf

`sprintf(value)`

Formats a formatted string where values to format are embraced by `{{` and `}}`.

- `value`: A template string to the output. Values to format must be embraced by `{{` and `}}`.

### Returns

A string formatted with the specified embedded values.

### Example

```kalk
>>> x = 1; y = "yes"
# x = 1; y = "yes"
x = 1
y = "yes"
>>> sprintf "Hello {{x}} World and {{y}}"
# sprintf("Hello {{x}} World and {{y}}")
out = "Hello 1 World and yes"
```

## to

`to(src,dst)`

Converts from one value unit to a destination unit.

 The pipe operator |> can be used between the src and destination unit to make it
 more readable. Example: `105 g |> to kg`

- `src`: The source value with units.
- `dst`: The destination unit.

### Returns

The result of the calculation.

### Example

```kalk
 >>> import StandardUnits
 # 1294 units successfully imported from module `StandardUnits`.
 >>> 10 kg/s |> to kg/h
 # ((10 * kg) / s) |> to(kg / h)
 out = 36000 * kg / h
 >>> 50 kg/m |> to g/km
 # ((50 * kg) / m) |> to(g / km)
 out = 50000000 * g / km
```

## unit

`unit(name,description?,symbol?,value?,plural?,prefix?)`

Defines a unit with the specified name and characteristics.

- `name`: Long name of the unit.
- `description`: A description of the unit. This value is optional.
- `symbol`: Short name (symbol) of the unit. This value is optional.
- `value`: The expression value of this unit. This value is optional.
- `plural`: The plural name of this unit. This value is optional.
- `prefix`: A comma list separated of prefix kinds:
    - "decimal": Defines the twenty prefixes for the International System of Units (SI). Example: Yotta/Y, kilo/k, milli/m...
    - "binary": Defines the binary prefixes. See https://en.wikipedia.org/wiki/Binary_prefix. Example: kibbi/Ki, mebi/Mi...
    - Individual prefixes:
      Decimal prefixes:
      - `Y` - `Yotta` (10^24)
      - `Z` - `Zetta` (10^21)
      - `E` - `Exa` (10^18)
      - `P` - `Peta` (10^15)
      - `T` - `Tera` (10^12)
      - `G` - `Giga` (10^9)
      - `M` - `Mega` (10^6)
      - `k` - `kilo` (10^3)
      - `h` - `hecto` (10^2)
      - `da` - `deca` (10^1)
      - `d` - `deci` (10^)-1
      - `c` - `centi` (10^)-2
      - `m` - `milli` (10^)-3
      - `µ` - `micro` (10^-6)
      - `n` - `nano` (10^)-9
      - `p` - `pico` (10^)-12
      - `f` - `femto` (10^)-15
      - `a` - `atto` (10^)-18
      - `z` - `zepto` (10^)-21
      - `y` - `yocto` (10^)-24
      
      Binary prefixes:
      - `Ki` - `Kibi` (2^10)
      - `Mi` - `Mibi` (2^20)
      - `Gi` - `Gibi` (2^30)
      - `Ti` - `Tibi` (2^40)
      - `Pi` - `Pibi` (2^50)
      - `Ei` - `Eibi` (2^60)
      - `Zi` - `Zibi` (2^70)
      - `Yi` - `Yibi` (2^80)

### Returns

The associated unit object.

### Example

```kalk
>>> unit(tomato, "A tomato unit", prefix: "decimal")
# unit(tomato, "A tomato unit", prefix: "decimal")
out = tomato
>>> unit(ketchup, "A ketchup unit", kup, 5 tomato, prefix: "decimal")
# unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
out = kup
>>> 4 kup
# 4 * kup
out = 20 * tomato
>>> tomato
unit(tomato, "A tomato unit", tomato, prefix: "decimal")
  - yottatomato/Ytomato, zettatomato/Ztomato, exatomato/Etomato, petatomato/Ptomato, 
    teratomato/Ttomato, gigatomato/Gtomato, megatomato/Mtomato, kilotomato/ktomato, 
    hectotomato/htomato, decatomato/datomato, decitomato/dtomato, centitomato/ctomato, 
    millitomato/mtomato, microtomato/µtomato, nanotomato/ntomato, picotomato/ptomato, 
    femtotomato/ftomato, attotomato/atomato, zeptotomato/ztomato, yoctotomato/ytomato
>>> ketchup
unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
  - yottaketchup/Ykup, zettaketchup/Zkup, exaketchup/Ekup, petaketchup/Pkup, teraketchup/Tkup, 
    gigaketchup/Gkup, megaketchup/Mkup, kiloketchup/kkup, hectoketchup/hkup, decaketchup/dakup, 
    deciketchup/dkup, centiketchup/ckup, milliketchup/mkup, microketchup/µkup, nanoketchup/nkup, 
    picoketchup/pkup, femtoketchup/fkup, attoketchup/akup, zeptoketchup/zkup, yoctoketchup/ykup
```

## units

`units`

If used in an expression, returns an object containing all units defined.
Otherwise it will display units in a friendly format.
By default, no units are defined. You can define units by using the `unit` function
and you can also import predefined units or currencies via `import StandardUnits` or
`import Currencies`.

### Example

```kalk
>>> unit(tomato, "A tomato unit", prefix: "decimal")
# unit(tomato, "A tomato unit", prefix: "decimal")
out = tomato
>>> unit(ketchup, "A ketchup unit", kup, 5 tomato, prefix: "decimal")
# unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
out = kup
>>> units
# User Defined Units
unit(ketchup, "A ketchup unit", kup, 5 * tomato, prefix: "decimal")
  - yottaketchup/Ykup, zettaketchup/Zkup, exaketchup/Ekup, petaketchup/Pkup, teraketchup/Tkup,
    gigaketchup/Gkup, megaketchup/Mkup, kiloketchup/kkup, hectoketchup/hkup, decaketchup/dakup,
    deciketchup/dkup, centiketchup/ckup, milliketchup/mkup, microketchup/µkup, nanoketchup/nkup,
    picoketchup/pkup, femtoketchup/fkup, attoketchup/akup, zeptoketchup/zkup, yoctoketchup/ykup

unit(tomato, "A tomato unit", tomato, prefix: "decimal")
  - yottatomato/Ytomato, zettatomato/Ztomato, exatomato/Etomato, petatomato/Ptomato,
    teratomato/Ttomato, gigatomato/Gtomato, megatomato/Mtomato, kilotomato/ktomato,
    hectotomato/htomato, decatomato/datomato, decitomato/dtomato, centitomato/ctomato,
    millitomato/mtomato, microtomato/µtomato, nanotomato/ntomato, picotomato/ptomato,
    femtotomato/ftomato, attotomato/atomato, zeptotomato/ztomato, yoctotomato/ytomato
```

## version

`version`

Prints the version of kalk.

### Example

```kalk
>>> version
kalk 1.0.0 - Copyright (c) 2020 Alexandre Mutel
```
