using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace 网络
{
    class Program
    {
        private const string NorthwindUrl = "http://service.data.org/Northwind/Nortthwind.svc/Regions";
        private const string IncorrectUrl = "http://service.data.org/Northwind1/Nortthwind.svc/Regions";
        static async Task Main(string[] args)
        {
            //await GetDataWithHeadersAsync();
            //await GetDataWithMessageHandlerAsync();
            //await OnSendRequest();
            //ReadKey();
            do
            {
                WriteLine("输入hostname");
                string hostname = ReadLine();
                if (hostname.ToUpper() == "BYE") {
                    WriteLine("Bye!");
                    return;
                }
                await OnLookupAsync(hostname);
                WriteLine();
            } while (true);


        }

        private async Task GetDataSimpleAsync() {
            using (var client=new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                if (response.IsSuccessStatusCode) {
                    WriteLine($"Response Status Code:{(int)response.StatusCode}{response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Recived payload of {responseBodyAsText.Length} charactes");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                

                }

            }
        
        }

        private async Task GetDataWithExceptionsAsync() {
            try
            {
                using (var clien=new HttpClient())
                {
                    HttpResponseMessage response = await clien.GetAsync(IncorrectUrl);
                    response.EnsureSuccessStatusCode();
                    WriteLine($"Response Status Code:{(int)response.StatusCode}{response.ReasonPhrase}");
                    string responseBodyAsText = await response.Content.ReadAsStringAsync();
                    WriteLine($"Recived payload of {responseBodyAsText.Length} charactes");
                    WriteLine();
                    WriteLine(responseBodyAsText);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.Message}");
            }
        
        }

        private static async Task GetDataWithHeadersAsync() {
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                    ShowHeaders("Request Heades:", client.DefaultRequestHeaders);
                    HttpResponseMessage response = await client.GetAsync(NorthwindUrl);
                    response.EnsureSuccessStatusCode();
                    ShowHeaders("Response Heades:", response.Headers);
                }
            }
            catch (Exception ex)
            {

                WriteLine($"{ex.Message}");
            }
             
        }

        public static void ShowHeaders(string title, HttpHeaders headers) {
            WriteLine(title);
            foreach (var header in headers)
            {
                string value = string.Join("", header.Value);
                WriteLine($"Header:{header.Key} Value:{value}");
            }
            WriteLine();
        
        }

        public static async Task GetDataWithMessageHandlerAsync() {
            var client = new HttpClient(new SampleMessageHandler("error"));
            var responses= await client.GetAsync(NorthwindUrl);


        }

        private async Task GetDataAdvancedAsync() {
            using (var client=new HttpClient())
            {
                var resquest = new HttpRequestMessage(HttpMethod.Get, NorthwindUrl);
                
                HttpResponseMessage respon = await client.SendAsync(resquest);
            }
        }

        private static async Task OnSendRequest() {
            try
            {
                using (var client=new HttpClient())
                {
                    var resuest = new HttpRequestMessage(HttpMethod.Get, "https://http2.akamai.com/demo");
                    HttpResponseMessage response = await client.SendAsync(resuest);
                    var Version = response.Version.ToString();
                    Console.WriteLine(Version);
                    response.EnsureSuccessStatusCode();
                    var result = await response.Content.ReadAsStringAsync();

                }
            }
            catch (Exception)
            {

                
            }
        
        
        }

        public static void IpaddressSamlpe(string ipaddressstring) {
            IPAddress address;
            if (!IPAddress.TryParse(ipaddressstring, out IPAddress address1)) {
                WriteLine($"不能转换ip地址{ipaddressstring}");
                return;
            }
            byte[] bytes = address1.GetAddressBytes();
            for (int i = 0; i < bytes.Length; i++)
            {
                WriteLine($"byte{i}:{bytes[i]:X}");
            }
            WriteLine($"family:{address1.AddressFamily},map to ipv6:{address1.MapToIPv6()},map to ipv4 {address1.MapToIPv4()}");
            
        }

        public static async Task OnLookupAsync(string hostname) {
            try
            {
                IPHostEntry ipHost = await Dns.GetHostEntryAsync(hostname);
                WriteLine($"Hostname:{ipHost.HostName}");
                foreach (var item in ipHost.AddressList)
                {
                    WriteLine($"Address Family:{item.AddressFamily}");
                    WriteLine($"Address:{item}");
                }
            }
            catch (Exception ex) 
            {
                WriteLine(ex.Message);
            }
        

        
        }



    }
}
