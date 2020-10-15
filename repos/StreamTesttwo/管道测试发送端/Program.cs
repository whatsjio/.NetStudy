using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO.Pipes;
using System.IO;

namespace 管道测试发送端
{
    class Program
    {
        static void Main(string[] args)
        {
            PipesWriter("yohayou");
            ReadKey();
        }

        public static void PipesWriter(string pipeName) {
            var pipWriter = new NamedPipeClientStream("localhost", pipeName, PipeDirection.Out);
            using (var writer=new StreamWriter(pipWriter))
            {
                pipWriter.Connect();
                WriteLine("writer connected");
                bool completed = false;
                while (!completed)
                {
                    string input = ReadLine();
                    if (input == "bye") completed = true;
                    writer.WriteLine(input);
                    writer.Flush();
                }
            }
            WriteLine("完成输入");
        }
    }
}
