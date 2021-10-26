using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace UDPtest
{
    class Program
    {
        static void Main(string[] args)
        {
            int port=0;
            string hostname="";
            string groupaddress="";
            WriteLine("输入地址：");
            groupaddress = ReadLine();
            WriteLine("输入端口：");
            var portstr = ReadLine();
            int.TryParse(portstr, out port);

            WriteLine("输入hostname：");
            hostname = ReadLine();


            IPEndPoint endpoint = 
                GetIPEndPoint(port, hostname, false, groupaddress, false).Result;
            Sender(endpoint, false, groupaddress).Wait();
            ReadKey();

        }


        private static async Task Sender(IPEndPoint endPoint, bool broadcast, string groupAddress) {
            try
            {
                string localhost = Dns.GetHostName();
                using (var client=new UdpClient())
                {
                    var sendip = IPAddress.Parse(groupAddress);
                    client.EnableBroadcast = broadcast;
                    if (groupAddress != null) {
                        client.JoinMulticastGroup(sendip);
                    
                    }
                    bool completed = false;
                    do
                    {
                        WriteLine("输入一个消息，或者退出");
                        string input = ReadLine();
                        WriteLine();
                        completed = input.ToLower() == "bye";
                        byte[] datagram = Encoding.UTF8.GetBytes($"{input}  from {localhost}");
                        int sent = await client.SendAsync(datagram, datagram.Length, endPoint);
                    } while (!completed);
                    client.DropMulticastGroup(sendip);
                }
            }
            catch (SocketException ex)
            {
                WriteLine(ex.Message);
            }
        
        
        }

        /// <summary>
        /// 获取ip终结点
        /// </summary>
        /// <param name="port"></param>
        /// <param name="hostname"></param>
        /// <param name="broadcast"></param>
        /// <param name="groupaddress"></param>
        /// <param name="ipv6"></param>
        /// <returns></returns>
        public static async Task<IPEndPoint> GetIPEndPoint(int port, string hostname, bool broadcast, string groupaddress, bool ipv6) {
            IPEndPoint endPoint = null;
            try
            {
                if (broadcast)
                {
                    endPoint = new IPEndPoint(IPAddress.Broadcast, port);
                }
                else if (!string.IsNullOrEmpty(hostname))
                {
                    IPHostEntry hostEntry = await Dns.GetHostEntryAsync(hostname);
                    IPAddress address = null;
                    if (ipv6)
                    {
                        address = hostEntry.AddressList.Where(t => t.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6).FirstOrDefault();
                    }
                    else
                    {
                        address = hostEntry.AddressList.Where(t => t.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault();
                    }
                    endPoint = new IPEndPoint(address, port);
                }
                else if (groupaddress != null)
                {
                    endPoint = new IPEndPoint(IPAddress.Parse(groupaddress), port);
                }
                else {
                    throw new InvalidOperationException("参数不正确");
                
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return endPoint;
        
        }
    }
}
