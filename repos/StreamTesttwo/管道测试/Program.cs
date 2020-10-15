using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
using System.IO.Pipes;
using System.Threading;


namespace 管道测试
{
    class Program
    {
        static void Main(string[] args)
        {
            PipesReader("yohayou");
            ReadKey();
        }

        private static void PipesReader(string pipeName) {
            try
            {
                using (var pipReader=new NamedPipeServerStream(pipeName,PipeDirection.In))
                {
                    pipReader.WaitForConnection();
                    WriteLine("reader connected");
                    const int BUFFERSIZE = 256;
                    bool completed = false;
                    while (!completed)
                    {
                        byte[] buffer = new byte[BUFFERSIZE];
                        int nRead = pipReader.Read(buffer, 0, BUFFERSIZE);
                        string line = Encoding.UTF8.GetString(buffer, 0, nRead);
                        WriteLine(line);
                        if (line == "bye") completed = true;
                    }
                }
                WriteLine("completed reading");
                ReadLine();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }

        }
    }
}
