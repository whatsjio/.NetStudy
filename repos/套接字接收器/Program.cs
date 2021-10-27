using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace 套接字接收器
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("输入host");
            var hoststr = ReadLine();
            WriteLine("输入监听端口");
            var portstr = ReadLine();
            int.TryParse(portstr, out int port);
            WriteLine("按下回车键开始");
            ReadLine();

        }



    }
}
