﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPAndUDPExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var readlines = Console.ReadLine();
            var getstr= await RequestHtmlAsync(readlines);
            Console.WriteLine(getstr);
            Console.ReadKey();

        }

        private const int ReadBufferSize = 1024;


        /// <summary>
        /// 模拟发送一个http get请求
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public static async Task<string> RequestHtmlAsync(string hostname) {
            try
            {
                using (var client=new TcpClient())
                {
                    await client.ConnectAsync(hostname, 80);
                    NetworkStream stream = client.GetStream();
                    string header = "GET / HTTP/1.1\r\n" + $"Host: {hostname} :80\r\n" + "Connection: close\r\n" + "\r\n";
                    byte[] buffer = Encoding.UTF8.GetBytes(header);
                    await stream.WriteAsync(buffer,0,buffer.Length);
                    await stream.FlushAsync();
                    //内存流
                    var ms = new MemoryStream();
                    buffer = new byte[ReadBufferSize];
                    int read = 0;
                    do
                    {
                        read = await stream.ReadAsync(buffer, 0, ReadBufferSize);
                        ms.Write(buffer, 0, read);
                        Array.Clear(buffer, 0, buffer.Length);
                    } while (read>0);
                    ms.Seek(0, SeekOrigin.Begin);
                    var reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
            catch (SocketException ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        
        }

    }
}
