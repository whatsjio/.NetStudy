using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace 网络
{
    public class SampleMessageHandler:HttpClientHandler
    {
        private string _message;
        public SampleMessageHandler(string message)
        {
            _message = message;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            WriteLine($"传递消息是{_message}");
            if (_message == "error") {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return Task.FromResult(response);
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
