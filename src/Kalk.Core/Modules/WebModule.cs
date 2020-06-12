using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Scriban.Functions;

namespace Kalk.Core.Modules
{
    public partial class WebModule : KalkModuleWithFunctions
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
        
        [KalkExport("html_strip", CategoryWeb)]
        public string HtmlStrip(string text) => HtmlFunctions.Strip(Engine, text);
        
        [KalkExport("wget", CategoryWeb)]
        public object WebGet(string url)
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
                        var mediaType = result.Content.Headers.ContentType.MediaType;
                        if (mediaType.StartsWith("text/"))
                        {
                            var readTask = Task.Run(async () => await result.Content.ReadAsStringAsync());
                            readTask.Wait();
                            return readTask.Result;
                        }
                        else
                        {
                            var readTask = Task.Run(async () => await result.Content.ReadAsByteArrayAsync());
                            readTask.Wait();
                            return readTask.Result;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message, nameof(url));
                }
            }
        }
    }
}