---
title: Csv Functions
url: /doc/api/csv/
---

Module for loading/parsing CSV text/files.

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import Csv
```

## load_csv

`load_csv(path,headers?)`

Loads the specified file as a CSV, returning each CSV line in an array.

- `path`: The file path to load and parse as CSV.
- `headers`: true if the file to parse has CSV headers. Default is fault.

### Returns

An array of CSV columns values.

### Example

```kalk
>>> items = load_csv("test.csv")
# items = load_csv("test.csv")
items = [[1, 2, 3], [4, 5, 6]]
>>> items[0].a
# items[0].a
out = 1
>>> items[1].a
# items[1].a
out = 4
>>> items[1].c
# items[1].c
out = 6
```

## parse_csv

`parse_csv(text,headers?)`

Parse the specified text as a CSV, returning each CSV line in an array.

- `text`: The text to parse.
- `headers`: true if the text to parse has CSV headers. Default is fault.

### Returns

An array of CSV columns values.

### Example

```kalk
>>> items = parse_csv("a,b,c\n1,2,3\n4,5,6\n")
# items = parse_csv("a,b,c\n1,2,3\n4,5,6\n")
items = [[1, 2, 3], [4, 5, 6]]
>>> items[0].a
# items[0].a
out = 1
>>> items[0].b
# items[0].b
out = 2
>>> items[0].c
# items[0].c
out = 3
```
