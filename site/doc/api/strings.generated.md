---
title: Strings Module
url: /doc/api/strings/
---

Modules that provides string functions (e.g `upcase`, `downcase`, `regex_escape`...).

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import Strings
```

## capitalize

`capitalize(text)`

Converts the first character of the passed string to a upper case character.

- `text`: The input string

### Returns

The capitalized input string

### Example

```kalk
>>> "test" |> capitalize
# "test" |> capitalize
out = "Test"
```

## capitalize_words

`capitalize_words(text)`

Converts the first character of each word in the passed string to a upper case character.

- `text`: The input string

### Returns

The capitalized input string

### Example

```kalk
>>> "This is easy" |> capitalize_words
# "This is easy" |> capitalize_words
out = "This Is Easy"
```

## downcase

`downcase(text)`

Converts the string to lower case.

- `text`: The input string

### Returns

The input string lower case

### Example

```kalk
>>> "TeSt" |> downcase
# "TeSt" |> downcase
out = "test"
```

## endswith

`endswith(text,end)`

Returns a boolean indicating whether the input string ends with the specified string `value`.

- `text`: The input string
- `end`: The string to look for

### Returns

true if `text` ends with the specified string `value`

### Example

```kalk
>>> "This is easy" |> endswith "easy"
# "This is easy" |> endswith("easy")
out = true
>>> "This is easy" |> endswith "none"
# "This is easy" |> endswith("none")
out = false
```

## escape

`escape(text)`

Escapes a string with escape characters.

- `text`: The input string

### Returns

The two strings concatenated

### Example

```kalk
>>> "Hel\tlo\n\"W\\orld" |> escape
# "Hel\tlo\n\"W\\orld" |> escape
out = "Hel\\tlo\\n\\\"W\\\\orld"
```

## handleize

`handleize(text)`

Returns a url handle from the input string.

- `text`: The input string

### Returns

A url handle

### Example

```kalk
>>> '100% M @ Ms!!!' |> handleize
# '100% M @ Ms!!!' |> handleize
out = "100-m-ms"
```

## lstrip

`lstrip(text)`

Removes any whitespace characters on the **left** side of the input string.

- `text`: The input string

### Returns

The input string without any left whitespace characters

### Example

```kalk
>>> '   too many spaces' |> lstrip
# '   too many spaces' |> lstrip
out = "too many spaces"
```

## pad_left

`pad_left(text,width)`

Pads a string with leading spaces to a specified total length.

- `text`: The input string
- `width`: The number of characters in the resulting string

### Returns

The input string padded

### Example

```kalk
>>> "world" |> pad_left 10
# "world" |> pad_left(10)
out = "     world"
```

## pad_right

`pad_right(text,width)`

Pads a string with trailing spaces to a specified total length.

- `text`: The input string
- `width`: The number of characters in the resulting string

### Returns

The input string padded

### Example

```kalk
>>> "hello" |> pad_right 10
# "hello" |> pad_right(10)
out = "hello     "
```

## pluralize

`pluralize(number,singular,plural)`

Outputs the singular or plural version of a string based on the value of a number.

- `number`: The number to check
- `singular`: The singular string to return if number is == 1
- `plural`: The plural string to return if number is != 1

### Returns

The singular or plural string based on number

### Example

```kalk
>>> 3 |> pluralize('product', 'products')
# 3 |> pluralize('product', 'products')
out = "products"
```

## regex_escape

`regex_escape(text)`

Escapes a minimal set of characters (`\`, `*`, `+`, `?`, `|`, `{`, `[`, `(`,`)`, `^`, `$`,`.`, `#`, and white space)
by replacing them with their escape codes.
This instructs the regular expression engine to interpret these characters literally rather than as metacharacters.

- `text`: The input string that contains the text to convert.

### Returns

A string of characters with metacharacters converted to their escaped form.

### Example

```kalk
>>> "(abc.*)" |> regex_escape
# "(abc.*)" |> regex_escape
out = "\\(abc\\.\\*\\)"
```

## regex_match

`regex_match(text,pattern,options?)`

Searches an input string for a substring that matches a regular expression pattern and returns an array with the match occurences.

- `text`: The string to search for a match.
- `pattern`: The regular expression pattern to match.
- `options`: A string with regex options, that can contain the following option characters (default is `null`):
    - `i`: Specifies case-insensitive matching.
    - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
    - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
    - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.

### Returns

An array that contains all the match groups. The first group contains the entire match. The other elements contain regex matched groups `(..)`. An empty array returned means no match.

### Example

```kalk
>>> "this is a text123" |> regex_match `(\w+) a ([a-z]+\d+)`
# "this is a text123" |> regex_match(`(\w+) a ([a-z]+\d+)`)
out = ["is a text123", "is", "text123"]
```

## regex_matches

`regex_matches(text,pattern,options?)`

Searches an input string for multiple substrings that matches a regular expression pattern and returns an array with the match occurences.

- `text`: The string to search for a match.
- `pattern`: The regular expression pattern to match.
- `options`: A string with regex options, that can contain the following option characters (default is `null`):
    - `i`: Specifies case-insensitive matching.
    - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
    - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
    - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.

### Returns

An array of matches that contains all the match groups. The first group contains the entire match. The other elements contain regex matched groups `(..)`. An empty array returned means no match.

### Example

```kalk
>>> "this is a text123" |> regex_matches `(\w+)`
# "this is a text123" |> regex_matches(`(\w+)`)
out = [["this", "this"], ["is", "is"], ["a", "a"], ["text123", "text123"]]
```

## regex_replace

`regex_replace(text,pattern,replace,options?)`

In a specified input string, replaces strings that match a regular expression pattern with a specified replacement string.

- `text`: The string to search for a match.
- `pattern`: The regular expression pattern to match.
- `replace`: The replacement string.
- `options`: A string with regex options, that can contain the following option characters (default is `null`):
    - `i`: Specifies case-insensitive matching.
    - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
    - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
    - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.

### Returns

A new string that is identical to the input string, except that the replacement string takes the place of each matched string. If pattern is not matched in the current instance, the method returns the current instance unchanged.

### Example

```kalk
>>> "abbbbcccd" |> regex_replace("b+c+","-Yo-")
# "abbbbcccd" |> regex_replace("b+c+", "-Yo-")
out = "a-Yo-d"
```

## regex_split

`regex_split(text,pattern,options?)`

Splits an input string into an array of substrings at the positions defined by a regular expression match.

- `text`: The string to split.
- `pattern`: The regular expression pattern to match.
- `options`: A string with regex options, that can contain the following option characters (default is `null`):
    - `i`: Specifies case-insensitive matching.
    - `m`: Multiline mode. Changes the meaning of `^` and `$` so they match at the beginning and end, respectively, of any line, and not just the beginning and end of the entire string.
    - `s`: Specifies single-line mode. Changes the meaning of the dot `.` so it matches every character (instead of every character except `\n`).
    - `x`: Eliminates unescaped white space from the pattern and enables comments marked with `#`.

### Returns

A string array.

### Example

```kalk
>>> "a, b   , c,    d" |> regex_split `\s*,\s*`
# "a, b   , c,    d" |> regex_split(`\s*,\s*`)
out = ["a", "b", "c", "d"]
```

## regex_unescape

`regex_unescape(text)`

Converts any escaped characters in the input string.

- `text`: The input string containing the text to convert.

### Returns

A string of characters with any escaped characters converted to their unescaped form.

### Example

```kalk
>>> "\\(abc\\.\\*\\)" |> regex_unescape
# "\\(abc\\.\\*\\)" |> regex_unescape
out = "(abc.*)"
```

## rstrip

`rstrip(text)`

Removes any whitespace characters on the **right** side of the input string.

- `text`: The input string

### Returns

The input string without any left whitespace characters

### Example

```kalk
>>> '   too many spaces           ' |> rstrip
# '   too many spaces           ' |> rstrip
out = "   too many spaces"
```

## split

`split(text,match)`

The `split` function takes on a substring as a parameter.
The substring is used as a delimiter to divide a string into an array. You can output different parts of an array using `array` functions.

- `text`: The input string
- `match`: The string used to split the input `text` string

### Returns

An enumeration of the substrings

### Example

```kalk
>>> "Hi, how are you today?" |> split ' '
# "Hi, how are you today?" |> split(' ')
out = ["Hi,", "how", "are", "you", "today?"]
```

## startswith

`startswith(text,start)`

Returns a boolean indicating whether the input string starts with the specified string `value`.

- `text`: The input string
- `start`: The string to look for

### Returns

true if `text` starts with the specified string `value`

### Example

```kalk
>>> "This is easy" |> startswith "This"
# "This is easy" |> startswith("This")
out = true
>>> "This is easy" |> startswith "easy"
# "This is easy" |> startswith("easy")
out = false
```

## strip

`strip(text)`

Removes any whitespace characters on the **left** and **right** side of the input string.

- `text`: The input string

### Returns

The input string without any left and right whitespace characters

### Example

```kalk
>>> '   too many spaces           ' |> strip
# '   too many spaces           ' |> strip
out = "too many spaces"
```

## strip_newlines

`strip_newlines(text)`

Removes any line breaks/newlines from a string.

- `text`: The input string

### Returns

The input string without any breaks/newlines characters

### Example

```kalk
>>> "This is a string.\r\n With \nanother \rstring" |> strip_newlines
# "This is a string.\r\n With \nanother \rstring" |> strip_newlines
out = "This is a string. With another string"
```

## upcase

`upcase(text)`

Converts the string to uppercase

- `text`: The input string

### Returns

The input string upper case

### Example

```kalk
>>> "test" |> upcase
# "test" |> upcase
out = "TEST"
```
