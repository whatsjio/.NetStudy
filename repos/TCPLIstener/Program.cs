using System;
using System.Collections;
using System.Collections.Concurrent;

using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;
using static TCPLIstener.CustomeProtocol;

namespace TCPLIstener
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public void Run() {
            //代码示例不完整
            //using (var timer=new Timer(timees))
            //{

            //}
        
        }

        private async Task RunServerAsync() {
            try
            {
                var listener = new TcpListener(IPAddress.Any, 1036);
                WriteLine($"开始监听在端口 {1036}");
                listener.Start();
                while (true)
                {
                    WriteLine($"等待客户端连接");
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Task t = RunClientRequestAsync(client);
                }
            }
            catch (Exception ex)
            {
                WriteLine($"异常类型{ex.GetType().Name},Message{ex.Message}");
            }
        
        }

        private Task RunClientRequestAsync(TcpClient client) {
            return Task.Run(async () =>
            {
                try
                {
                    using (client)
                    {
                        WriteLine("客户端已连接");
                        using (NetworkStream stream=client.GetStream())
                        {
                            bool completed = false;
                            do
                            {
                                byte[] readBuffer = new byte[1024];
                                int read = await stream.ReadAsync(readBuffer, 0, readBuffer.Length);
                                string request = Encoding.ASCII.GetString(readBuffer, 0, read);
                                WriteLine($"收到:{request}");
                                string sessionId;
                                string result;
                                byte[] writeBuffer = null;
                                string response = string.Empty;
                                //ParseResponse

                            } while (true);
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }

            });
        }



    }
}
