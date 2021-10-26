using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace 套接字
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("输入监听端口");
            var portstr = ReadLine();
            int.TryParse(portstr, out int port);
            Listener(port);

        }

        public static void Listener(int port) {
            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.ReceiveTimeout = 5000;
            listener.SendTimeout = 5000;
            listener.Bind(new IPEndPoint(IPAddress.Any, port));
            listener.Listen(backlog: 15);
            WriteLine($"开始监听在端口{port}上");

            var cts = new CancellationTokenSource();
            var tf = new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None);
            tf.StartNew(() =>
            {
                WriteLine("监听程序开始");
                while (true)
                {
                    if (cts.Token.IsCancellationRequested) {
                        cts.Token.ThrowIfCancellationRequested();
                        break;
                    }
                    WriteLine("等待接收");
                    //阻塞方法
                    Socket client = listener.Accept();
                    if (!client.Connected) {
                        WriteLine("没有连接接入");
                        continue;
                    }
                    WriteLine($"客户端连接ip{((IPEndPoint)client.LocalEndPoint).Address} 端口 {((IPEndPoint)client.LocalEndPoint).Port} 远程ip{((IPEndPoint)client.RemoteEndPoint).Address} 远程端口 {((IPEndPoint)client.RemoteEndPoint).Port}");
                    Task t = CommunicateWithClientUsingSocketAsync(client);
                }
                listener.Dispose();
                WriteLine("连接任务关闭");

            }, cts.Token);
            WriteLine("按任意键退出");
            ReadLine();
            cts.Cancel();
        }


        private static Task CommunicateWithClientUsingSocketAsync(Socket socket) {
            return Task.Run(() =>
            {
                try
                {
                    using (socket)
                    {
                        bool completed = false;
                        do
                        {
                            byte[] readBuffer = new byte[1024];
                            int read = socket.Receive(readBuffer, 0, 1024, SocketFlags.None);
                            string formClient = Encoding.UTF8.GetString(readBuffer, 0, read);
                            WriteLine($"读取{read}流{formClient}");
                            if (string.Compare(formClient, "bye", ignoreCase: true) == 0) {
                                completed = true;
                            }
                            byte[] writeBuffer = Encoding.UTF8.GetBytes($"收到 {formClient}");
                            int send = socket.Send(writeBuffer);
                            WriteLine($"已发送 {send} 比特");
                        } while (!completed);
                    }
                    WriteLine("关闭流和客户端连接");
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }

            });
        
        
        }
    }
}
