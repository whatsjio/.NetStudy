using Microsoft.Net.Http.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace WebListenerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //if (args.Length < 1)
            //{
            //    ShowUsage();
            //    return;
            //}
            var urlarry = new string[] { "http://+:8082/samples" };
            StartServerAsync(urlarry).Wait();
            ReadLine();
        }


        private static void ShowUsage()
        {
            WriteLine("Usage:HttpServer Prefix [Prefix2] ...");

        }

        public static async Task StartServerAsync(params string[] prefixes)
        {
            try
            {
                WriteLine($"server starting at");
                var listener = new WebListener();
                foreach (var prefixe in prefixes)
                {
                    listener.Settings.UrlPrefixes.Add(prefixe);
                    WriteLine($"\t{prefixe}");
                }
                listener.Start();
                do
                {
                    using (RequestContext context = await listener.AcceptAsync())
                    {
                        WriteLine($"收到请求:{context.Request.Method}");
                        context.Response.Headers.Add("content-type", new string[] { "text/html" });
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        byte[] buffer = GetHtmlContent(context.Request);
                        await context.Response.Body.WriteAsync(buffer, 0, buffer.Length);
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private static string htmlFormat = "<!DOCTYPE html><html><head><title>{0}</title></head>" + "<body>{1}</body></htm1>";

        private static byte[] GetHtmlContent(Request request) {
            string title = "简单的监听";
            var sb = new StringBuilder("<h1>来自监听服务</h1>");
            sb.Append("<h2>头部信息</h2>");
            sb.Append(string.Join(" ", GetHeaderInfo(request.Headers)));
            sb.Append("<h2>请求信息</h2>");
            sb.Append(string.Join(" ", GetResquestInfo(request)));
            string html = string.Format(htmlFormat, title, sb.ToString());
            return Encoding.UTF8.GetBytes(html);
        }

        private static IEnumerable<string> GetHeaderInfo(HeaderCollection headers) => headers.Keys.Select(key => $"<div>{key}:{string.Join(",", headers.GetValues(key))}</div>");



        private static IEnumerable<string> GetResquestInfo(Request request) => request.GetType().GetProperties().Select(t => $"<div>{t.Name}:{t.GetValue(request)}</div>");



    }
}
