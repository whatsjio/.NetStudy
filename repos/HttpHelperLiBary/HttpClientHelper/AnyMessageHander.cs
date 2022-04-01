﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HttpClientSimple
{
    public class AnyMessageHander: HttpClientHandler
    {
        /// <summary>
        /// 日志接口
        /// </summary>
        private readonly ILogWrite _logWrite;

        /// <summary>
        /// 定制请求头
        /// </summary>
        public Dictionary<string, string> HeaderDictionary { get; set; }

        /// <summary>
        /// 提交数据
        /// </summary>
        public string Postdata { get; set; }

        /// <summary>
        /// 请求主体
        /// </summary>
        public HttpContent PosthttpContent { get; set; }

        /// <summary>
        /// Http请求方法
        /// </summary>
        public HttpMethod SendMethod { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httptype">Http请求类型</param>
        public AnyMessageHander(EHttpType httptype, ILogWrite iLogWrite)
        {
            _logWrite = iLogWrite;
            SendMethod = HttpMethod.Get;
            switch (httptype)
            {
                case EHttpType.GET:
                    SendMethod = HttpMethod.Get;
                    break;
                case EHttpType.POST:
                    SendMethod = HttpMethod.Post;
                    break;
                case EHttpType.DELETE:
                    SendMethod = HttpMethod.Delete;
                    break;
                case EHttpType.PUT:
                    SendMethod = HttpMethod.Put;
                    break;
            }
        }

        #region 设置httpcontentForm提交方式
        /// <summary>
        /// 设置httpcontentForm提交方式
        /// </summary>
        /// <param name="valuecollection"></param>
        /// <param name="contentType">提交类型</param>
        public virtual void SetFormContent(Dictionary<string, string> valuecollection, string contentType)
        {
            Postdata = JsonConvert.SerializeObject(valuecollection);
            PosthttpContent = new FormUrlEncodedContent(valuecollection);
            PosthttpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType)
            {
                CharSet = "utf-8"
            };
        }
        #endregion

        #region 设置httpcontent字符串请求体
        /// <summary>
        /// 设置httpcontent字符串请求体
        /// </summary>
        public virtual void SetContent(string postdata, string contentType)
        {
            Postdata = postdata;
            PosthttpContent = new StringContent(postdata ?? "");
            PosthttpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType)
            {
                CharSet = "utf-8"
            };
        }
        #endregion


        /// <summary>
        /// 提交请求
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                request.Method = SendMethod;
                if (request.Method != HttpMethod.Get)
                {
                    if (PosthttpContent == null)
                    {
                        _logWrite?.Log($"{SendMethod.Method}请求异常：未设置Content主体");
                        var repsonse = new HttpResponseMessage(HttpStatusCode.BadRequest);
                        return Task.FromResult(repsonse);
                    }
                    request.Content = PosthttpContent;
                }
                if (HeaderDictionary != null && HeaderDictionary.Any())
                {
                    foreach (var keyValuePair in HeaderDictionary)
                    {
                        request.Headers.Add(keyValuePair.Key, keyValuePair.Value);
                    }
                }
            }
            catch (Exception e)
            {
                _logWrite?.Log($"{SendMethod.Method}请求异常:{JsonConvert.SerializeObject(e)}");
                var repsonse = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return Task.FromResult(repsonse);
            }
            return base.SendAsync(request, cancellationToken);
        }


    }
}
