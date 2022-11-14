---
title: Misc Functions
url: /doc/api/misc/
---

## ascii

`ascii(obj?)`

Prints the ascii table or convert an input string to an ascii array, or an ascii array to a string.

- `obj`: An optional input (string or array of numbers or directly an integer).

### Returns

Depending on the input:
- If no input, it will display the ascii table
- If the input is an integer, it will convert it to the equivalent ascii char.
- If the input is a string, it will convert the string to a byte buffer containing the corresponding ascii bytes.
- If the input is an array of integer, it will convert each element to the equivalent ascii char.

### Example

```kalk
>>> ascii 65
# ascii(65)
out = "A"
>>> ascii 97
# ascii(97)
out = "a"
>>> ascii "A"
# ascii("A")
out = 65
>>> ascii "kalk"
# ascii("kalk")
out = bytebuffer([107, 97, 108, 107])
>>> ascii out
# ascii(out)
out = "kalk"
```

## bin

`bin(value,prefix?,separator?)`

Converts an integral/bytebuffer input to a binary representation or convert a binary input string
to an integral/bytebuffer representation.

- `value`: The input value.
- `prefix`: Output the prefix `0x` in front of each binary bytes when converting
        from integral to binary.
- `separator`: The character used to separate binary bytes when converting
        from integral to binary.

### Returns

The binary representation of the input or convert the binary input string
to an integral representation.

### Remarks

When converting from a binary string to an integral representation, this method
will skip any white-space characters, comma `,`, colon `:`, semi-colon `;`, underscore `_` and
dash `-`.
When the binary input string can be converted to an integral less than or equal 8 bytes (64 bits)
it will convert it to a single integral result, otherwise it will convert to a bytebuffer.
See the following examples.

### Example

```kalk
>>> bin 13
# bin(13)
out = "00001101 00000000 00000000 00000000"
>>> bin out
# bin(out)
out = 13
>>> bin "111111111011"
# bin("111111111011")
out = 4_091
>>> bin 0xff030201
# bin(-16580095)
out = "00000001 00000010 00000011 11111111"
>>> bin out
# bin(out)
out = 4_278_387_201
>>> bin "11111111000000110000001000000001"
# bin("11111111000000110000001000000001")
out = 4_278_387_201
>>> bin(byte(5))
# bin(byte(5))
out = "00000101"
>>> bin(long(6))
# bin(long(6))
out = "00000110 00000000 00000000 00000000 00000000 00000000 00000000 00000000"
>>> bin(out)
# bin(out)
out = 6
>>> kind(out)
# kind(out)
out = "long"
```

## colors

`colors`

Display or returns the known CSS colors.

### Returns

Prints known CSS colors or return a list if this function is used in an expression.

### Example

```kalk
>>> colors[0]
# colors[0]
out = rgb(240, 248, 255) ## F0F8FF AliceBlue ##
>>> mycolor = colors["AliceBlue"]; mycolor.name
# mycolor = colors["AliceBlue"]; mycolor.name
mycolor = rgb(240, 248, 255) ## F0F8FF AliceBlue ##
out = "AliceBlue"
```

## contains

`contains(list,value)`

Checks if an object (string, list, vector types, bytebuffer...) is containing the specified value.

- `list`: The list to search into.
- `value`: The value to search into the list.

### Returns

true if value was found in the list input; otherwise false.

### Example

```kalk
>>> contains("kalk", "l")
# contains("kalk", "l")
out = true
>>> contains("kalk", "e")
# contains("kalk", "e")
out = false
>>> contains([1,2,3,4,5], 3)
# contains([1,2,3,4,5], 3)
out = true
>>> contains([1,2,3,4,5], 6)
# contains([1,2,3,4,5], 6)
out = false
>>> contains(float4(1,2,3,4), 3)
# contains(float4(1, 2, 3, 4), 3)
out = true
>>> contains(float4(1,2,3,4), 6)
# contains(float4(1, 2, 3, 4), 6)
out = false
```

## date

`date`

Gets the current date, parse the input date or return the date object, depending on use cases.
 - If this function doesn't have any parameter and is not used to index a member, it returns the current date. It is equivalent of `date.now`

   The return date object has the following properties:

   | Name             | Description
   |--------------    |-----------------
   | `.year`          | Gets the year of a date object
   | `.month`         | Gets the month of a date object
   | `.day`           | Gets the day in the month of a date object
   | `.day_of_year`   | Gets the day within the year
   | `.hour`          | Gets the hour of the date object
   | `.minute`        | Gets the minute of the date object
   | `.second`        | Gets the second of the date object
   | `.millisecond`   | Gets the millisecond of the date object
 
 - If this function has a string parameter, it will try to parse the string as a date
 - Otherwise, if this function provides the following sub functions and members:
   - `date.add_days`: Example `'2016/01/05' |> date |> date.add_days 1`
   - `date.add_months`: Example `'2016/01/05' |> date |> date.add_months 1`
   - `date.add_years`: Example `'2016/01/05' |> date |> date.add_years 1`
   - `date.add_hours`
   - `date.add_minutes`
   - `date.add_seconds`
   - `date.add_milliseconds`
   - `date.to_string`: Converts a datetime object to a textual representation using the specified format string.
 
      By default, if you are using a date, it will use the format specified by `date.format` which defaults to `date.default_format` (readonly) which default to `%d %b %Y`
      
      You can override the format used for formatting all dates by assigning the a new format: `date.format = '%a %b %e %T %Y';`
      
      You can recover the default format by using `date.format = date.default_format;`
      
      By default, the to_string format is using the **current culture**, but you can switch to an invariant culture by using the modifier `%g`
      
      For example, using `%g %d %b %Y` will output the date using an invariant culture.
      
      If you are using `%g` alone, it will output the date with `date.format` using an invariant culture.
      
      Suppose that `date.now` would return the date `2013-09-12 22:49:27 +0530`, the following table explains the format modifiers:
      
      | Format | Result            | Description
      |--------|-------------------|--------------------------------------------
      | `"%a"` |  `"Thu"`          | Name of week day in short form of the
      | `"%A"` |  `"Thursday"`     | Week day in full form of the time
      | `"%b"` |  `"Sep"`          | Month in short form of the time
      | `"%B"` |  `"September"`    | Month in full form of the time
      | `"%c"` |                   | Date and time (%a %b %e %T %Y)
      | `"%C"` |  `"20"`           | Century of the time
      | `"%d"` |  `"12"`           | Day of the month of the time
      | `"%D"` |  `"09/12/13"`     | Date (%m/%d/%y)
      | `"%e"` |  `"12"`           | Day of the month, blank-padded ( 1..31)
      | `"%F"` |  `"2013-09-12"`   | ISO 8601 date (%Y-%m-%d)
      | `"%h"` |  `"Sep"`          | Alias for %b
      | `"%H"` |  `"22"`           | Hour of the time in 24 hour clock format
      | `"%I"` |  `"10"`           | Hour of the time in 12 hour clock format
      | `"%j"` |  `"255"`          | Day of the year (001..366) (3 digits, left padded with zero)
      | `"%k"` |  `"22"`           | Hour of the time in 24 hour clock format, blank-padded ( 0..23)
      | `"%l"` |  `"10"`           | Hour of the time in 12 hour clock format, blank-padded ( 0..12)
      | `"%L"` |  `"000"`          | Millisecond of the time (3 digits, left padded with zero)
      | `"%m"` |  `"09"`           | Month of the time
      | `"%M"` |  `"49"`           | Minutes of the time (2 digits, left padded with zero e.g 01 02)
      | `"%n"` |                   | Newline character (\n)
      | `"%N"` |  `"000000000"`    | Nanoseconds of the time (9 digits, left padded with zero)
      | `"%p"` |  `"PM"`           | Gives AM / PM of the time
      | `"%P"` |  `"pm"`           | Gives am / pm of the time
      | `"%r"` |  `"10:49:27 PM"`  | Long time in 12 hour clock format (%I:%M:%S %p)
      | `"%R"` |  `"22:49"`        | Short time in 24 hour clock format (%H:%M)
      | `"%s"` |                   | Number of seconds since 1970-01-01 00:00:00 +0000
      | `"%S"` |  `"27"`           | Seconds of the time
      | `"%t"` |                   | Tab character (\t)
      | `"%T"` |  `"22:49:27"`     | Long time in 24 hour clock format (%H:%M:%S)
      | `"%u"` |  `"4"`            | Day of week of the time (from 1 for Monday to 7 for Sunday)
      | `"%U"` |  `"36"`           | Week number of the current year, starting with the first Sunday as the first day of the first week (00..53)
      | `"%v"` |  `"12-SEP-2013"`  | VMS date (%e-%b-%Y) (culture invariant)
      | `"%V"` |  `"37"`           | Week number of the current year according to ISO 8601 (01..53)
      | `"%W"` |  `"36"`           | Week number of the current year, starting with the first Monday as the first day of the first week (00..53)
      | `"%w"` |  `"4"`            | Day of week of the time (from 0 for Sunday to 6 for Saturday)
      | `"%x"` |                   | Preferred representation for the date alone, no time
      | `"%X"` |                   | Preferred representation for the time alone, no date
      | `"%y"` |  `"13"`           | Gives year without century of the time
      | `"%Y"` |  `"2013"`         | Year of the time
      | `"%Z"` |  `"IST"`          | Gives Time Zone of the time
      | `"%%"` |  `"%"`            | Output the character `%`
      
      Note that the format is using a good part of the ruby format ([source](http://apidock.com/ruby/DateTime/strftime))

### Returns

The current date, parse the input date or return the date object, depending on use cases.

### Example

```kalk
 >>> today = date
 # today = date
 today = 11/22/20 10:13:00
 >>> today.year
 # today.year
 out = 2_020
 >>> today.month
 # today.month
 out = 11
 >>> "30 Nov 2020" |> date
 # "30 Nov 2020" |> date
 out = 11/30/20 00:00:00
 >>> out |> date.add_days 4
 # out |> date.add_days(4)
 out = 12/04/20 00:00:00
 >>> date.format = "%F"
 >>> date
 # date
 out = 2020-11-22
```

## guid

`guid`

Returns a new GUID as a string.

### Returns

A new GUID as a string.

### Example

```kalk
>>> guid
# guid
out = "0deafe30-de4d-47c3-9631-2d3292afbb8e"
```

## hex

`hex(value,separator?,prefix?)`

Converts an integral/bytebuffer input to an hexadecimal representation or convert an hexadecimal input string
to an integral/bytebuffer representation.

- `value`: The input value.
- `separator`: The character used to separate hexadecimal bytes when converting
    from integral to hexadecimal.
- `prefix`: Output the prefix `0x` in front of each hexadecimal bytes when converting
    from integral to hexadecimal.

### Returns

The hexadecimal representation of the input or convert the hexadecimal input string
to an integral representation.

### Remarks

When converting from a hexadecimal string to an integral representation, this method
will skip any white-space characters, comma `,`, colon `:`, semi-colon `;`, underscore `_` and
dash `-`.
When the hexadecimal input string can be converted to an integral less than or equal 8 bytes (64 bits)
it will convert it to a single integral result, otherwise it will convert to a bytebuffer.
See the following examples.

### Example

```kalk
>>> hex 10
# hex(10)
out = "0A"
>>> hex "12c"
# hex("12c")
out = 300
>>> hex "0a"
# hex("0a")
out = 10
>>> hex "0xff030201"
# hex("0xff030201")
out = 4_278_387_201
>>> hex out
# hex(out)
out = "01 02 03 FF"
>>> hex "01:02:03:04:05:06:07:08:09:0A:0B:0C:0D:0E:0F"
# hex("01:02:03:04:05:06:07:08:09:0A:0B:0C:0D:0E:0F")
out = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])
>>> hex(out, true, ",")
# hex(out, true, ",")
out = "0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09,0x0A,0x0B,0x0C,0x0D,0x0E,0x0F"
>>> hex out
# hex(out)
out = bytebuffer([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15])
>>> hex("1a,2b;3c 4d-5e_6f")
# hex("1a,2b;3c 4d-5e_6f")
out = 103_832_130_169_626
>>> hex out
# hex(out)
out = "1A 2B 3C 4D 6F 5E 00 00"
>>> hex float4(1,2,3,4)
# hex(float4(1, 2, 3, 4))
out = "00 00 80 3F 00 00 00 40 00 00 40 40 00 00 80 40"
```

## insert_at

`insert_at(list,index,item)`

Inserts an item into a string or list at the specified index.

- `list`: A string or list to insert an item into.
- `index`: The index at which to insert the item.
- `item`: The item to insert.

### Returns

A new string with the item inserted, or a new list with the item inserted at the specified index.

### Remarks

The index is adjusted at the modulo of the length of the input value.
If the index is < 0, then the index starts from the end of the string/list length + 1. A value of -1 for the index would insert the item at the end, after the last element of the string or list.

### Example

```kalk
>>> insert_at("kalk", 0, "YES")
# insert_at("kalk", 0, "YES")
out = "YESkalk"
>>> insert_at("kalk", -1, "YES")
# insert_at("kalk", -1, "YES")
out = "kalkYES"
>>> insert_at(0..10, 1, 50)
# insert_at(0..10, 1, 50)
out = [0, 50, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
>>> insert_at(0..9, 21, 50) # final index is 21 % 10 = 1
# insert_at(0..9, 21, 50) # final index is 21 % 10 = 1
out = [0, 50, 1, 2, 3, 4, 5, 6, 7, 8, 9]
>>> insert_at([], 3, 1)
# insert_at([], 3, 1)
out = [1]
```

## keys

`keys(obj)`

Returns the keys of the specified object.

- `obj`: An object to get the keys from.

### Returns

The keys of the parameter obj.

### Example

```kalk
>>> obj = {m: 1, n: 2}; keys obj
# obj = {m: 1, n: 2}; keys(obj)
obj = {m: 1, n: 2}
out = ["m", "n"]
```

## lines

`lines(text)`

Extract lines from the specified string.

- `text`: A string to extract lines from.

### Returns

Lines extracted from the input string.

### Example

```kalk
>>> lines("k\na\nl\nk")
# lines("k\na\nl\nk")
out = ["k", "a", "l", "k"]
```

## remove_at

`remove_at(list,index)`

Removes an item from a string or list at the specified index.

- `list`: A string or list to remove an item from.
- `index`: The index at which to remove the item.

### Returns

A new string/list with the item at the specified index removed.

### Remarks

The index is adjusted at the modulo of the length of the input value.
If the index is < 0, then the index starts from the end of the string/list length. A value of -1 for the index would remove the last element.

### Example

```kalk
>>> remove_at("kalk", 0)
# remove_at("kalk", 0)
out = "alk"
>>> remove_at("kalk", -1)
# remove_at("kalk", -1)
out = "kal"
>>> remove_at(0..9, 5)
# remove_at(0..9, 5)
out = [0, 1, 2, 3, 4, 6, 7, 8, 9]
>>> remove_at(0..9, -1)
# remove_at(0..9, -1)
out = [0, 1, 2, 3, 4, 5, 6, 7, 8]
>>> remove_at(asbytes(0x04030201), 1)
# remove_at(asbytes(67305985), 1)
out = bytebuffer([1, 3, 4])
```

## replace

`replace(list,value,by)`

Replaces in an object (string, list, vector types, bytebuffer...) an item of the specified value by another value.

- `list`: The list to search into to replace an element.
- `value`: The item to replace.
- `by`: The value to replace with.

### Returns

The modified object.

### Example

```kalk
>>> replace("kalk", "k", "woo")
# replace("kalk", "k", "woo")
out = "wooalwoo"
>>> replace([1,2,3,4], 3, 5)
# replace([1,2,3,4], 3, 5)
out = [1, 2, 5, 4]
>>> replace(float4(1,2,3,4), 3, 5)
# replace(float4(1, 2, 3, 4), 3, 5)
out = float4(1, 2, 5, 4)
```

## reverse

`reverse(list)`

Reverse a list of values.

- `list`: The list to reverse.

### Returns

The list of values reversed.

### Example

```kalk
>>> reverse([1,2,3,4,5])
# reverse([1,2,3,4,5])
out = [5, 4, 3, 2, 1]
>>> reverse("abc")
# reverse("abc")
out = "cba"
>>> reverse(asbytes(0x04030201))
# reverse(asbytes(67305985))
out = bytebuffer([4, 3, 2, 1])
```

## size

`size(obj)`

Returns the size of the specified object.

- `obj`: The object value.

### Returns

The size of the object.

### Example

```kalk
>>> size 1
# size(1)
out = 0
>>> size "kalk"
# size("kalk")
out = 4
>>> size float4(1,2,3,4)
# size(float4(1, 2, 3, 4))
out = 4
>>> size [1, 2, 3]
# size([1, 2, 3])
out = 3
```

## slice

`slice(list,index,length?)`

Creates a slice of an object (string, list, vector types, bytebuffer...) starting at the specified index and with the specified length;

- `list`: The object to create a slice from.
- `index`: The index into the object.
- `length`: The optional length of the slice. If the length is not defined, the length will start from index with the remaining elements.

### Returns

A slice of the input object.

### Remarks

The index is adjusted at the modulo of the specified length of the input object.
If the index is < 0, then the index starts from the end of the input object length. A value of -1 for the index would take a slice with the only the last element.

### Example

```kalk
>>> slice("kalk", 1)
# slice("kalk", 1)
out = "alk"
>>> slice("kalk", -2)
# slice("kalk", -2)
out = "lk"
>>> slice("kalk", 1, 2)
# slice("kalk", 1, 2)
out = "al"
>>> slice([1,2,3,4], 1)
# slice([1,2,3,4], 1)
out = [2, 3, 4]
>>> slice([1,2,3,4], -1)
# slice([1,2,3,4], -1)
out = [4]
>>> slice([1,2,3,4], -1, 3) # length is bigger than expected, no errors
# slice([1,2,3,4], -1, 3) # length is bigger than expected, no errors
out = [4]
>>> slice(asbytes(0x04030201), 1, 2)
# slice(asbytes(67305985), 1, 2)
out = slice(bytebuffer([2, 3]), 1, 2)
```

## utf16

`utf16(value)`

Converts a string to an UTF16 bytebuffer or convert a bytebuffer of UTF16 bytes to a string.

- `value`: The specified input.

### Returns

The UTF16 bytebuffer representation of the input string or the string representation of the input UTF16 bytebuffer.

### Example

```kalk
>>> utf16 "kalk"
# utf16("kalk")
out = bytebuffer([107, 0, 97, 0, 108, 0, 107, 0])
>>> utf16 out
# utf16(out)
out = "kalk"
```

## utf32

`utf32(value)`

Converts a string to an UTF32 bytebuffer or convert a bytebuffer of UTF32 bytes to a string.

- `value`: The specified input.

### Returns

The UTF32 bytebuffer representation of the input string or the string representation of the input UTF32 bytebuffer.

### Example

```kalk
>>> utf32 "kalk"
# utf32("kalk")
out = bytebuffer([107, 0, 0, 0, 97, 0, 0, 0, 108, 0, 0, 0, 107, 0, 0, 0])
>>> utf32 out
# utf32(out)
out = "kalk"
```

## utf8

`utf8(value)`

Converts a string to an UTF8 bytebuffer or convert a bytebuffer of UTF8 bytes to a string.

- `value`: The specified input.

### Returns

The UTF8 bytebuffer representation of the input string or the string representation of the input UTF8 bytebuffer.

### Example

```kalk
>>> utf8 "kalk"
# utf8("kalk")
out = bytebuffer([107, 97, 108, 107])
>>> utf8 out
# utf8(out)
out = "kalk"
```

## values

`values(obj)`

Returns the values of the specified object.

- `obj`: An object to get the values from.

### Returns

The values of the parameter obj.

### Example

```kalk
>>> obj = {m: 1, n: 2}; values obj
# obj = {m: 1, n: 2}; values(obj)
obj = {m: 1, n: 2}
out = [1, 2]
```
