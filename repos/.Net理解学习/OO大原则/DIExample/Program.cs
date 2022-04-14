using System;
using System.Threading;

namespace DIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    interface IRunnerProvider
    {
        void Run(Action action);
    }

    public class DefaultRunnerProvider : IRunnerProvider
    {
        public void Run(Action action)
        {
            var thread = new Thread(() => action());
            thread.Start();
        }
    }

    public class RunnerHost : IDisposable
    {
        private IRunnerProvider provider = null;

        public RunnerHost()
        {
            //伪代码，通过配置动态创建provider实例
            //provider=GetProvideConfig()
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
