using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace UdpReserver
{
    class Program
    {
        static void Main(string[] args)
        {
            string groupaddress = "";
            int port = 0;
            do
            {
                WriteLine("输入地址：");
                groupaddress= ReadLine();
            } while (string.IsNullOrEmpty(groupaddress));
            do
            {
                WriteLine("输入端口号：");
                var portstr = ReadLine();
                int.TryParse(portstr, out port);
            } while (port==0);
            ReaderAsync(groupaddress, port).Wait();
            ReadKey();
        }

        private static async Task ReaderAsync(string groupaddress, int port) {
            using (var client=new UdpClient(port))
            {
                var readip = IPAddress.Parse(groupaddress);
                client.JoinMulticastGroup(readip);
                WriteLine($"加入MulticastGroup {readip}");
                bool completed = false;
                do
                {
                    WriteLine("开始接收");
                    UdpReceiveResult result = await client.ReceiveAsync();
                    byte[] datagram = result.Buffer;
                    string received = Encoding.UTF8.GetString(datagram);
                    WriteLine($"收到：{received}");
                    if (received.ToLower() == "bye") {
                        completed = true;
                    }
                } while (!completed);
                WriteLine("接收关闭");
                client.DropMulticastGroup(readip);
            }
        
        
        }
    }
}
