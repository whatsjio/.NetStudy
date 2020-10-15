using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace 匿名管道
{
    class Program
    {
        private string _pipHandle;
        private ManualResetEventSlim _pipHandleSet;

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
            ReadLine();
        }

        public void Run()
        {
            _pipHandleSet = new ManualResetEventSlim(initialState: false);
            //任务之间互相通信
            Task.Run(() => Reader());
            Task.Run(() => Writer());
            ReadLine();
        }


        private void Reader()
        {
            try
            {
                var pipReader = new AnonymousPipeServerStream(PipeDirection.In, System.IO.HandleInheritability.None);
                using (var reader = new StreamReader(pipReader))
                {
                    _pipHandle = pipReader.GetClientHandleAsString();
                    WriteLine($"pipe handle:{_pipHandle}");
                    _pipHandleSet.Set();
                    bool end = false;
                    while (!end)
                    {
                        string line = reader.ReadLine();
                        WriteLine(line);
                        if (line == "end") end = true;
                    }
                    WriteLine("finished reading");
                }
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private void Writer() {
            WriteLine("anonymous pipe wroter");
            _pipHandleSet.Wait();
            var pipWriter = new AnonymousPipeClientStream(PipeDirection.Out, _pipHandle);
            using (var writer=new StreamWriter(pipWriter))
            {
                writer.AutoFlush = true;
                WriteLine("starting writer");
                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine($"Message {i}");
                    Task.Delay(500).Wait();
                }
                writer.WriteLine("end");
            }
        }

    }
}
