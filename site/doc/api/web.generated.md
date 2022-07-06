---
title: Web Module
url: /doc/api/web/
---

Module that provides Web functions (e.g `url_encode`, `json`, `wget`...)

In order to use the functions provided by this module, you need to import this module:

```kalk
>>> import Web
```

## html_decode

`html_decode(text)`

Decodes a HTML input string (replacing `&amp;` by `&`)

- `text`: The input string

### Returns

The input string removed with any HTML entities.

### Example

```kalk
>>> "<p>This is a paragraph</p>" |> html_encode
# "<p>This is a paragraph</p>" |> html_encode
out = "&lt;p&gt;This is a paragraph&lt;/p&gt;"
>>> out |> html_decode
# out |> html_decode
out = "<p>This is a paragraph</p>"
```

## html_encode

`html_encode(text)`

Encodes a HTML input string (replacing `&` by `&amp;`)

- `text`: The input string

### Returns

The input string with HTML entities.

### Example

```kalk
>>> "<p>This is a paragraph</p>" |> html_encode
# "<p>This is a paragraph</p>" |> html_encode
out = "&lt;p&gt;This is a paragraph&lt;/p&gt;"
>>> out |> html_decode
# out |> html_decode
out = "<p>This is a paragraph</p>"
```

## html_strip

`html_strip(text)`

Removes any HTML tags from the input string

- `text`: The input string

### Returns

The input string removed with any HTML tags

### Example

```kalk
>>> "<p>This is a paragraph</p>" |> html_strip
# "<p>This is a paragraph</p>" |> html_strip
out = "This is a paragraph"
```

## json

`json(value)`

Converts to or from a JSON object depending on the value argument.

- `value`: A value argument:
    - If the value is a string, it is expecting this string to be a JSON string and will convert it to the appropriate object.
    - If the value is an array or object, it will convert it to a JSON string representation.

### Returns

A JSON string or an object/array depending on the argument.

### Example

```kalk
>>> json {a: 1, b: 2, c: [4,5], d: "Hello World"}
# json({a: 1, b: 2, c: [4,5], d: "Hello World"})
out = "{\"a\": 1, \"b\": 2, \"c\": [4, 5], \"d\": \"Hello World\"}"
>>> json out
# json(out)
out = {a: 1, b: 2, c: [4, 5], d: "Hello World"}
```

## url_decode

`url_decode(url)`

Converts a URL-encoded string into a decoded string.

- `url`: The URL to decode.

### Returns

The decoded URL

### Example

```kalk
>>> url_decode "this%3Cis%3Ean%3Aurl+and+another+part"
# url_decode("this%3Cis%3Ean%3Aurl+and+another+part")
out = "this<is>an:url and another part"
```

## url_encode

`url_encode(url)`

Converts a specified URL text into a URL-encoded.

 URL encoding converts characters that are not allowed in a URL into character-entity equivalents.
 For example, when the characters < and > are embedded in a block of text to be transmitted in a URL, they are encoded as %3c and %3e.

- `url`: The url text to encode as an URL.

### Returns

An encoded URL.

### Example

```kalk
 >>> url_encode "this<is>an:url and another part"
 # url_encode("this<is>an:url and another part")
 out = "this%3Cis%3Ean%3Aurl+and+another+part"
```

## url_escape

`url_escape(url)`

Identifies all characters in a string that are not allowed in URLS, and replaces the characters with their escaped variants.

- `url`: The input string.

### Returns

The input string url escaped

### Example

```kalk
>>> "<hello> & <scriban>" |> url_escape
# "<hello> & <scriban>" |> url_escape
out = "%3Chello%3E%20&%20%3Cscriban%3E"
```

## wget

`wget(url)`

Retrieves the content of the following URL by issuing a HTTP GET request.

- `url`: The URL to retrieve the content for.

### Returns

An object with the result of the request. This object contains the following members:
- `version`: the protocol of the version.
- `code`: the HTTP return code.
- `reason`: the HTTP reason phrase.
- `headers`: the HTTP returned headers.
- `content`: the HTTP content. Either a string if the mime type is `text/*` or an object if the mime type is `application/json` otherwise it will return a bytebuffer.

### Remarks

```
>>> wget "https://markdig.azurewebsites.net/"
# wget("https://markdig.azurewebsites.net/")
out = {version: "1.1", code: 200, reason: "OK", headers: {"Content-Type": "text/plain; charset=utf-8", "Content-Length": 0}, content: ""}
```
