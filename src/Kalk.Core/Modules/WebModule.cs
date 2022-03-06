using System;
using System.Collections;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Scriban.Functions;
using Scriban.Helpers;
using Scriban.Runtime;

namespace Kalk.Core.Modules
{
    /// <summary>
    /// Module that provides Web functions (e.g `url_encode`, `json`, `wget`...)
    /// </summary>
    [KalkExportModule(ModuleName)]
    public sealed partial class WebModule : KalkModuleWithFunctions
    {
        private const string ModuleName = "Web";
        public const string CategoryWeb = "Web & Html Functions";

        public WebModule() : base(ModuleName)
        {
            RegisterFunctionsAuto();
        }

        /// <summary>
        /// Converts a specified URL text into a URL-encoded.
        ///
        /// URL encoding converts characters that are not allowed in a URL into character-entity equivalents.
        /// For example, when the characters &lt; and &gt; are embedded in a block of text to be transmitted in a URL, they are encoded as %3c and %3e.
        /// </summary>
        /// <param name="url">The url text to encode as an URL.</param>
        /// <returns>An encoded URL.</returns>
        /// <example>
        /// ```kalk
        /// >>> url_encode "this&lt;is&gt;an:url and another part"
        /// # url_encode("this&lt;is&gt;an:url and another part")
        /// out = "this%3Cis%3Ean%3Aurl+and+another+part"
        /// ```
        /// </example>
        [KalkExport("url_encode", CategoryWeb)]
        public string UrlEncode(string url) => WebUtility.UrlEncode(url);

        /// <summary>
        /// Converts a URL-encoded string into a decoded string.
        /// </summary>
        /// <param name="url">The URL to decode.</param>
        /// <returns>The decoded URL</returns>
        /// <example>
        /// ```kalk
        /// >>> url_decode "this%3Cis%3Ean%3Aurl+and+another+part"
        /// # url_decode("this%3Cis%3Ean%3Aurl+and+another+part")
        /// out = "this&lt;is&gt;an:url and another part"
        /// ```
        /// </example>
        [KalkExport("url_decode", CategoryWeb)]
        public string UrlDecode(string url) => WebUtility.UrlDecode(url);

        /// <summary>
        /// Identifies all characters in a string that are not allowed in URLS, and replaces the characters with their escaped variants.
        /// </summary>
        /// <param name="url">The input string.</param>
        /// <returns>The input string url escaped</returns>
        /// <example>
        /// ```kalk
        /// >>> "&lt;hello&gt; &amp; &lt;scriban&gt;" |> url_escape
        /// # "&lt;hello&gt; &amp; &lt;scriban&gt;" |> url_escape
        /// out = "%3Chello%3E%20&amp;%20%3Cscriban%3E"
        /// ```
        /// </example>
        [KalkExport("url_escape", CategoryWeb)]
        public string UrlEscape(string url) => HtmlFunctions.UrlEscape(url);

        /// <summary>
        /// Encodes a HTML input string (replacing `&amp;` by `&amp;amp;`)
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string with HTML entities.</returns>
        /// <example>
        /// ```kalk
        /// >>> "&lt;p&gt;This is a paragraph&lt;/p&gt;" |> html_encode
        /// # "&lt;p&gt;This is a paragraph&lt;/p&gt;" |> html_encode
        /// out = "&amp;lt;p&amp;gt;This is a paragraph&amp;lt;/p&amp;gt;"
        /// >>> out |> html_decode
        /// # out |> html_decode
        /// out = "&lt;p&gt;This is a paragraph&lt;/p&gt;"
        /// ```
        /// </example>
        [KalkExport("html_encode", CategoryWeb)]
        public string HtmlEncode(string text) => HtmlFunctions.Escape(text);

        /// <summary>
        /// Decodes a HTML input string (replacing `&amp;amp;` by `&amp;`)
        /// </summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string removed with any HTML entities.</returns>
        /// <example>
        /// ```kalk
        /// >>> "&lt;p&gt;This is a paragraph&lt;/p&gt;" |> html_encode
        /// # "&lt;p&gt;This is a paragraph&lt;/p&gt;" |> html_encode
        /// out = "&amp;lt;p&amp;gt;This is a paragraph&amp;lt;/p&amp;gt;"
        /// >>> out |> html_decode
        /// # out |> html_decode
        /// out = "&lt;p&gt;This is a paragraph&lt;/p&gt;"
        /// ```
        /// </example>
        [KalkExport("html_decode", CategoryWeb)]
        public string HtmlDecode(string text)
        {
            return string.IsNullOrEmpty(text) ? text : System.Net.WebUtility.HtmlDecode(text);
        }
        
        /// <summary>
        /// Converts to or from a JSON object depending on the value argument.
        /// </summary>
        /// <param name="value">A value argument:
        /// - If the value is a string, it is expecting this string to be a JSON string and will convert it to the appropriate object.
        /// - If the value is an array or object, it will convert it to a JSON string representation.
        /// </param>
        /// <returns>A JSON string or an object/array depending on the argument.</returns>
        /// <example>
        /// ```kalk
        /// >>> json {a: 1, b: 2, c: [4,5], d: "Hello World"}
        /// # json({a: 1, b: 2, c: [4,5], d: "Hello World"})
        /// out = "{\"a\": 1, \"b\": 2, \"c\": [4, 5], \"d\": \"Hello World\"}"
        /// >>> json out
        /// # json(out)
        /// out = {a: 1, b: 2, c: [4, 5], d: "Hello World"}
        /// ```
        /// </example>
        [KalkExport("json", CategoryWeb)]
        public object Json(object value)
        {
            switch (value)
            {
                case string text:
                    try
                    {
                        var jsonDoc = JsonDocument.Parse(text);
                        return ConvertFromJson(jsonDoc.RootElement);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException($"Unable to parse input text. Reason: {ex.Message}", nameof(value));
                    }

                default:
                {
                    var previousLimit = Engine.LimitToString;
                    try
                    {
                        Engine.LimitToString = 0;
                        var builder = new StringBuilder();
                        ConvertToJson(value, builder);
                        return builder.ToString();
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException($"Unable to convert script object input to json text. Reason: {ex.Message}", nameof(value));
                    }
                    finally
                    {
                        Engine.LimitToString = previousLimit;
                    }
                }
            }
        }

        /// <summary>Removes any HTML tags from the input string</summary>
        /// <param name="text">The input string</param>
        /// <returns>The input string removed with any HTML tags</returns>
        /// <example>
        /// ```kalk
        /// >>> "&lt;p&gt;This is a paragraph&lt;/p&gt;" |> html_strip
        /// # "&lt;p&gt;This is a paragraph&lt;/p&gt;" |> html_strip
        /// out = "This is a paragraph"
        /// ```
        /// </example>
        [KalkExport("html_strip", CategoryWeb)]
        public string HtmlStrip(string text) => HtmlFunctions.Strip(Engine, text);

        /// <summary>
        /// Retrieves the content of the following URL by issuing a HTTP GET request.
        /// </summary>
        /// <param name="url">The URL to retrieve the content for.</param>
        /// <returns>An object with the result of the request. This object contains the following members:
        /// - `version`: the protocol of the version.
        /// - `code`: the HTTP return code.
        /// - `reason`: the HTTP reason phrase.
        /// - `headers`: the HTTP returned headers.
        /// - `content`: the HTTP content. Either a string if the mime type is `text/*` or an object if the mime type is `application/json` otherwise it will return a bytebuffer.
        /// </returns>
        /// <example>
        /// ```kalk
        /// >>> wget "https://markdig.azurewebsites.net/"
        /// # wget("https://markdig.azurewebsites.net/")
        /// out = {version: "1.1", code: 200, reason: "OK", headers: {"Content-Type": "text/plain; charset=utf-8", "Content-Length": 0}, content: ""}
        /// ```
        /// </example>
        [KalkExport("wget", CategoryWeb)]
        public ScriptObject WebGet(string url)
        {
            if (url == null) throw new ArgumentNullException(nameof(url));
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage result;
                try
                {
                    var task = Task.Run(async () => await httpClient.GetAsync(url));
                    task.Wait();
                    result = task.Result;

                    if (!result.IsSuccessStatusCode)
                    {
                        throw new ArgumentException($"HTTP/{result.Version} {(int)result.StatusCode} {result.ReasonPhrase}", nameof(url));
                    }
                    else
                    {
                        var headers = new ScriptObject();
                        foreach (var headerItem in result.Content.Headers)
                        {
                            var items = new ScriptArray(headerItem.Value);
                            object itemValue = items;
                            if (items.Count == 1)
                            {
                                var str = (string) items[0];
                                itemValue = str;
                                if (str == "true")
                                {
                                    itemValue = (KalkBool)true;
                                }
                                else if (str == "false")
                                {
                                    itemValue = (KalkBool)false;
                                }
                                else if (long.TryParse(str, out var longValue))
                                {
                                    if (longValue >= int.MinValue && longValue <= int.MaxValue)
                                    {
                                        itemValue = (int) longValue;
                                    }
                                    else
                                    {
                                        itemValue = longValue;
                                    }
                                }
                                else if (DateTime.TryParse(str, out var time))
                                {
                                    itemValue = time;
                                }
                            }
                            headers[headerItem.Key] = itemValue;
                        }

                        var mediaType = result.Content.Headers.ContentType.MediaType;
                        var resultObj = new ScriptObject()
                        {
                            {"version", result.Version.ToString()},
                            {"code", (int) result.StatusCode},
                            {"reason", result.ReasonPhrase},
                            {"headers", headers}
                        };

                        if (mediaType.StartsWith("text/") || mediaType == "application/json")
                        {
                            var readTask = Task.Run(async () => await result.Content.ReadAsStringAsync());
                            readTask.Wait();
                            var text = readTask.Result;
                            if (mediaType == "application/json" && TryParseJson(text, out var jsonObject))
                            {
                                resultObj["content"] = jsonObject;
                            }
                            else
                            {
                                resultObj["content"] = readTask.Result;
                            }
                        }
                        else
                        {
                            var readTask = Task.Run(async () => await result.Content.ReadAsByteArrayAsync());
                            readTask.Wait();
                            resultObj["content"] = new KalkNativeBuffer(readTask.Result);
                        }

                        return resultObj;
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message, nameof(url));
                }
            }
        }

        private static bool TryParseJson(string text, out ScriptObject scriptObj)
        {
            scriptObj = null;
            try
            {
                // Make sure that we can parse the input JSON
                var jsonDoc = JsonDocument.Parse(text);
                var result = ConvertFromJson(jsonDoc.RootElement);
                scriptObj = result as ScriptObject;
                return scriptObj != null;
            }
            catch
            {
                // ignore
                return false;
            }
        }

        private void ConvertToJson(object element, StringBuilder builder)
        {
            if (element == null)
            {
                builder.Append("null");
            }
            else if (element is ScriptObject scriptObject)
            {
                builder.Append("{");
                bool isFirst = true;
                foreach (var item in scriptObject)
                {
                    if (!isFirst)
                    {
                        builder.Append(", ");
                    }
                    builder.Append('\"');
                    builder.Append(StringFunctions.Escape(item.Key));
                    builder.Append('\"');
                    builder.Append(": ");
                    ConvertToJson(item.Value, builder);
                    isFirst = false;
                }
                builder.Append("}");
            }
            else if (element is string text)
            {
                builder.Append('\"');
                builder.Append(StringFunctions.Escape(text));
                builder.Append('\"');
            }
            else if (element.GetType().IsNumber())
            {
                builder.Append(Engine.ObjectToString(element));
            }
            else if (element is bool rb)
            {
                builder.Append(rb ? "true" : "false");
            }
            else if (element is KalkBool b)
            {
                builder.Append(b ? "true" : "false");
            }
            else if (element is IEnumerable it)
            {
                builder.Append('[');
                bool isFirst = true;
                foreach (var item in it)
                {
                    if (!isFirst)
                    {
                        builder.Append(", ");
                    }
                    ConvertToJson(item, builder);
                    isFirst = false;
                }
                builder.Append(']');
            }
            else
            {
                builder.Append('\"');
                builder.Append(StringFunctions.Escape(Engine.ObjectToString(element)));
                builder.Append('\"');
            }
        }

        private static object ConvertFromJson(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Object:
                    var obj = new ScriptObject();
                    foreach (var prop in element.EnumerateObject())
                    {
                        obj[prop.Name] = ConvertFromJson(prop.Value);
                    }

                    return obj;
                case JsonValueKind.Array:
                    var array = new ScriptArray();
                    foreach (var nestedElement in element.EnumerateArray())
                    {
                        array.Add(ConvertFromJson(nestedElement));
                    }
                    return array;
                case JsonValueKind.String:
                    return element.GetString();
                case JsonValueKind.Number:
                    if (element.TryGetInt32(out var intValue))
                    {
                        return intValue;
                    }
                    else if (element.TryGetInt64(out var longValue))
                    {
                        return longValue;
                    }
                    else if (element.TryGetUInt32(out var uintValue))
                    {
                        return uintValue;
                    }
                    else if (element.TryGetUInt64(out var ulongValue))
                    {
                        return ulongValue;
                    }
                    else if (element.TryGetDecimal(out var decimalValue))
                    {
                        return decimalValue;
                    }
                    else if (element.TryGetDouble(out var doubleValue))
                    {
                        return doubleValue;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Unable to convert number {element}");
                    }
                case JsonValueKind.True:
                    return (KalkBool)true;
                case JsonValueKind.False:
                    return (KalkBool)false;
                default:
                    return null;
            }
        }
    }
}