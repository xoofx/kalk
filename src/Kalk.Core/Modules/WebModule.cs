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
    public sealed partial class WebModule : KalkModuleWithFunctions
    {
        public const string CategoryWeb = "Web & Html Functions";

        public WebModule() : base("Web")
        {
            RegisterFunctionsAuto();
        }

        [KalkExport("url_encode", CategoryWeb)]
        public string UrlEncode(string url) => WebUtility.UrlEncode(url);

        [KalkExport("url_decode", CategoryWeb)]
        public string UrlDecode(string url) => WebUtility.UrlDecode(url);

        [KalkExport("url_escape", CategoryWeb)]
        public string UrlEscape(string url) => HtmlFunctions.UrlEscape(url);

        [KalkExport("html_encode", CategoryWeb)]
        public string HtmlEncode(string text) => HtmlFunctions.Escape(text);

        [KalkExport("html_decode", CategoryWeb)]
        public string HtmlDecode(string text)
        {
            return string.IsNullOrEmpty(text) ? text : System.Net.WebUtility.HtmlDecode(text);
        }
        
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

        [KalkExport("html_strip", CategoryWeb)]
        public string HtmlStrip(string text) => HtmlFunctions.Strip(Engine, text);
        
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