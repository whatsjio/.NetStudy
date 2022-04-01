using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientSimple
{
    public class HttpHelper
    {

        /// <summary>
        /// 日志接口
        /// </summary>
        private readonly ILogWrite _logWrite;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="iloogger"></param>
        public HttpHelper(ILogWrite iloogger)
        {
            _logWrite = iloogger;
        }

        #region 异步post jsion版调用 
        /// <summary>
        /// 异步post jsion版调用 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData">json字符串</param>
        /// <param name="name">调用者名称(可选)</param>
        /// <returns></returns>
        public  async Task<HttpPostresultDTO> MaindataAsyPost(string url, string postData, [CallerMemberName] string name = null)
        {
            var resultmodel = new HttpPostresultDTO(false, "");

            //LogHelper.FileInfoLog($"异步post请求:{name}|post请求详情:url:{url}|参数:{postData}");
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                httpContent.Headers.ContentType.CharSet = "utf-8";
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, httpContent).ConfigureAwait(false);
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        resultmodel.Success = true;
                        resultmodel.Result = result;
                        _logWrite.Log($"异步post请求:{name}响应:{result}");
                    }
                    else
                    {
                        var erroresponCode = $"Http响应{response.StatusCode}失败";
                        resultmodel.Result = erroresponCode;
                        _logWrite.Log($"{erroresponCode}:{name}响应:{result}");
                    }
                }
            }
            catch (Exception e)
            {
                _logWrite.Log("AsyPost请求异常", e);
                resultmodel.Result = "请求异常，详情查看日志";
            }
            return resultmodel;
        }
        #endregion


        #region 异步application/json请求
        /// <summary>
        /// 异步application/json请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData">json字符串</param>
        /// <param name="name">调用者名称(可选)</param>
        /// <returns></returns>
        public async Task<HttpPostresultDTO> AsyncPost(string url, string postData, [CallerMemberName] string name = null)
        {
            var resultmodel = new HttpPostresultDTO(false, "");
            try
            {
                if (url.StartsWith("https"))
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                }
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json")
                {
                    CharSet = "utf-8"
                };
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.PostAsync(url, httpContent).ConfigureAwait(false);
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        resultmodel.Success = true;
                        resultmodel.Result = result;
                    }
                    else
                    {
                        var erroresponCode = $"Http响应{response.StatusCode}失败";
                        resultmodel.Result = erroresponCode;
                    }
                }
            }
            catch (Exception e)
            {
                resultmodel.Result = $"http请求异常:{e.Message}";
                _logWrite.Log("http请求异常",e);
            }
            return resultmodel;
        }
        #endregion


        #region http请求

        /// <summary>
        /// http请求
        /// </summary>
        /// <typeparam name="T">请求处理类型</typeparam>
        /// <param name="url">请求地址</param>
        /// <param name="anyMessageHander">定制处理</param>
        /// <param name="writeresponse">是否开启日志写入返回结果 默认开启</param>
        /// <param name="name">调用者名称</param>
        /// <returns></returns>
        public  async Task<HttpPostresultDTO> AsyncSend<T>(string url, T anyMessageHander, bool writeresponse = true,
            [CallerMemberName] string name = null) where T : AnyMessageHander
        {
            var resultmodel = new HttpPostresultDTO(false, "");
            if (anyMessageHander == null) return new HttpPostresultDTO(false, "缺失处理方法");
            var verifyheadstr = anyMessageHander.HeaderDictionary != null ? JsonConvert.SerializeObject(anyMessageHander.HeaderDictionary) : "";
            var methodname = anyMessageHander.SendMethod.Method;
            var asyncguid = Guid.NewGuid().ToString();
            var errorlog = $"{asyncguid}|异步{methodname}请求:{name}|请求详情:url:{url}|头部参数:{verifyheadstr}|提交参数{anyMessageHander.Postdata}";
            _logWrite.Log($"{asyncguid}|异步{methodname}请求:{name}|请求详情:url:{url}|头部参数:{verifyheadstr}");
            try
            {
                if (url.StartsWith("https"))
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                }
                using (HttpClient httpClient = new HttpClient(anyMessageHander))
                {
                    //提交方法以管道处理为准
                    var requerthttp = new HttpRequestMessage(HttpMethod.Post, url);
                    HttpResponseMessage response = await httpClient.SendAsync(requerthttp).ConfigureAwait(false);
                    var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (response.IsSuccessStatusCode)
                    {
                        resultmodel.Success = true;
                        resultmodel.Result = result;
                        _logWrite.Log($"{asyncguid}|异步{methodname}请求:{name}响应成功|响应信息:{(writeresponse ? result : "未开启写入详情")}");
                    }
                    else
                    {
                        var erroresponCode = $"{methodname}响应{response.StatusCode}失败";
                        resultmodel.Result = erroresponCode;
                        _logWrite.Log($"{errorlog}|响应代码:{erroresponCode}|响应信息:{result}");
                    }
                }
            }
            catch (Exception e)
            {
                resultmodel.Result = $"{methodname}请求异常:{e.Message}";
                _logWrite.Log($"{errorlog}|{methodname}请求异常", e);
            }
            return resultmodel;
        }
        #endregion


        #region 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="url">文件uri</param>
        /// <returns></returns>
        public  HttpPostresultDTO WebClientDownLoadFile(string path, string url)
        {
            var resultmodel = new HttpPostresultDTO(false, "");
            try
            {
                WebClient client = new WebClient();
                client.DownloadFile(url, path);
                resultmodel.Success = true;
                resultmodel.Result = "下载成功";
            }
            catch (Exception e)
            {
                _logWrite.Log("WebClient文件下载请求异常", e);
                resultmodel.Result = $"请求异常:{e.Message}";
            }
            return resultmodel;
        }
        #endregion


        #region 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<HttpPostresultDTO> DownLoadFile(string path, string url)
        {
            var resultmodel = new HttpPostresultDTO(false, "");
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    if (url.StartsWith("https"))
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                    }
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                    httpRequestMessage.Method = new HttpMethod("GET");
                    httpRequestMessage.Headers.Add("context-type", "application/pdf");
                    httpRequestMessage.RequestUri = new Uri(url);
                    httpClient.DefaultRequestHeaders.UserAgent.Clear();
                    httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Chrome/22.0.1229.94");

                    /*httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.87 Safari/537.36");*/
                    var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        Stream stream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);
                        using (FileStream fs = new FileStream(path, FileMode.CreateNew))
                        {
                            byte[] buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, buffer.Length);
                            fs.Write(buffer, 0, buffer.Length);
                        }
                        resultmodel.Success = true;
                        resultmodel.Result = "下载成功";
                    }
                    else
                    {
                        var erroresponCode = $"Http响应{httpResponseMessage.StatusCode}失败";
                        _logWrite.Log($"下载文件响应失败:{erroresponCode}");
                        resultmodel.Result = erroresponCode;
                    }
                }
            }
            catch (Exception e)
            {
                _logWrite.Log("http请求异常",e);
                resultmodel.Result = $"http请求异常:{e.Message}";
            }
            return resultmodel;
        }
        #endregion

        #region 下载文件
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public  HttpPostresultDTO DownloadFiles(string url, string filename)
        {
            var resultmodel = new HttpPostresultDTO(false, "");
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.ProtocolVersion = HttpVersion.Version11;
                HttpWebResponse myrp = (HttpWebResponse)webRequest.GetResponse();
                using (Stream responseStream = myrp.GetResponseStream())
                using (Stream so = new FileStream(filename, FileMode.Create))
                {
                    byte[] bytes = new byte[1024];
                    if (responseStream != null)
                    {
                        int osize = responseStream.Read(bytes, 0, bytes.Length);
                        while (osize > 0)
                        {
                            so.Write(bytes, 0, osize);
                            osize = responseStream.Read(bytes, 0, bytes.Length);
                        }
                    }
                }
                myrp.Close();
                webRequest.Abort();
                resultmodel.Success = true;
                resultmodel.Result = "下载成功";
            }
            catch (Exception e)
            {
                _logWrite.Log("DownloadFiles请求异常", e);
                resultmodel.Result = $"DownloadFiles请求异常:{e.Message}";
            }
            return resultmodel;
        }
        #endregion
    }
}
