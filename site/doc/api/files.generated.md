---
title: Files Module
url: /doc/api/files/
---

Modules providing file related functions.

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import Files
```

## cd

`cd(path?)`

Changes the current directory to the specified path.

- `path`: Path to the directory to change.

### Returns

The current directory or throws an exception if the directory does not exists

### Example

```kalk
>>> cd
# cd
out = "/code/kalk/tests"
>>> mkdir "testdir"
>>> cd "testdir"
# cd("testdir")
out = "/code/kalk/tests/testdir"
>>> cd ".."
# cd("..")
out = "/code/kalk/tests"
>>> rmdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = false
```

## dir

`dir(path?,recursive?)`

List files and directories from the specified path or the current directory.

- `path`: The specified directory or the current directory if not specified.
- `recursive`: A boolean to perform a recursive list. Default is `false`.

### Returns

An enumeration of the files and directories.

### Example

```kalk
>>> mkdir "testdir"
>>> cd "testdir"
# cd("testdir")
out = "/code/kalk/tests/testdir"
>>> mkdir "subdir"
>>> save_text("content", "file.txt")
>>> dir "."
# dir(".")
out = ["./file.txt", "./subdir"]
>>> save_text("content", "subdir/file2.txt")
>>> dir(".", true)
# dir(".", true)
out = ["./file.txt", "./subdir", "./subdir/file2.txt"]
>>> cd ".."
# cd("..")
out = "/code/kalk/tests"
>>> rmdir("testdir", true)
```

## dir_exists

`dir_exists(path)`

Checks if the specified directory path exists on the disk.

- `path`: Path to a directory.

### Returns

`true` if the specified directory path exists on the disk.

### Example

```kalk
>>> mkdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = true
>>> rmdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = false
```

## file_exists

`file_exists(path)`

Checks if the specified file path exists on the disk.

- `path`: Path to a file.

### Returns

`true` if the specified file path exists on the disk.

### Example

```kalk
>>> rm "test.txt"
>>> file_exists "test.txt"
# file_exists("test.txt")
out = false
>>> save_text("content", "test.txt")
>>> file_exists "test.txt"
# file_exists("test.txt")
out = true
```

## load_bytes

`load_bytes(path)`

Loads the specified file as binary.

- `path`: Path to a file to load as binary.

### Returns

The file loaded as a a byte buffer.

### Example

```kalk
>>> load_bytes "test.csv"
# load_bytes("test.csv")
out = bytebuffer([97, 44, 98, 44, 99, 10, 49, 44, 50, 44, 51, 10, 52, 44, 53, 44, 54])
>>> ascii out
# ascii(out)
out = "a,b,c\n1,2,3\n4,5,6"
```

## load_lines

`load_lines(path,encoding?)`

Load each lines from the specified file path.

- `path`: Path to a file to load lines from.
- `encoding`: The encoding of the file. Default is "utf-8"

### Returns

An enumeration on the lines.

### Example

```kalk
>>> load_lines "test.csv"
# load_lines("test.csv")
out = ["a,b,c", "1,2,3", "4,5,6"]
```

## load_text

`load_text(path,encoding?)`

Loads the specified file as text.

- `path`: Path to a file to load as text.
- `encoding`: The encoding of the file. Default is "utf-8"

### Returns

The file loaded as a string.

### Example

```kalk
>>> load_text "test.csv"
# load_text("test.csv")
out = "a,b,c\n1,2,3\n4,5,6"
```

## mkdir

`mkdir(path)`

Creates a directory at the specified path.

- `path`: Path of the directory to create.

### Example

```kalk
>>> mkdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = true
>>> rmdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = false
```

## pwd

`pwd`

Gets the current directory.

### Returns

The current directory.

### Example

```kalk
>>> pwd
# pwd
out = "/code/kalk/tests"
```

## rm

`rm(path)`

Deletes a file from the specified path.

- `path`: Path to the file to delete.

### Example

```kalk
>>> rm "test.txt"
>>> file_exists "test.txt"
# file_exists("test.txt")
out = false
>>> save_text("content", "test.txt")
>>> file_exists "test.txt"
# file_exists("test.txt")
out = true
```

## rmdir

`rmdir(path)`

Deletes the directory at the specified path.

- `path`: Path to the directory to delete.

### Example

```kalk
>>> mkdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = true
>>> rmdir "testdir"
>>> dir_exists "testdir"
# dir_exists("testdir")
out = false
```

## save_bytes

`save_bytes(data,path)`

Saves a byte buffer to the specified file path.

- `data`: The data to save.
- `path`: Path to the file to save the data to.

### Example

```kalk
>>> utf8("Hello World!")
# utf8("Hello World!")
out = bytebuffer([72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33])
>>> save_bytes(out, "test.bin")
>>> load_bytes("test.bin")
# load_bytes("test.bin")
out = bytebuffer([72, 101, 108, 108, 111, 32, 87, 111, 114, 108, 100, 33])
>>> utf8(out)
# utf8(out)
out = "Hello World!"
```

## save_lines

`save_lines(lines,path,encoding?)`

Saves an array of data as string to the specified files.

- `lines`: An array of data.
- `path`: Path to the file to save the lines to.
- `encoding`: The encoding of the file. Default is "utf-8"

### Example

```kalk
>>> save_lines(1..10, "lines.txt")
>>> load_lines("lines.txt")
# load_lines("lines.txt")
out = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"]
```

## save_text

`save_text(text,path,encoding?)`

Saves a text to the specified file path.

- `text`: The text to save.
- `path`: Path to the file to save the text to.
- `encoding`: The encoding of the file. Default is "utf-8"

### Example

```kalk
>>> save_text("Hello World!", "test.txt")
>>> load_text("test.txt")
# load_text("test.txt")
out = "Hello World!"
```
