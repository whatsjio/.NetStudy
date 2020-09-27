using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 任务同步
{
    class Calculator
    {
        private ManualResetEventSlim _mEvent;
        public int Result { get; private set; }
        public Calculator(ManualResetEventSlim ev)
        {
            _mEvent = ev;
        }

        public void Caculation(int x, int y) {
            Console.WriteLine($"线程ID:{Task.CurrentId} 开始计算");
            Task.Delay(new Random().Next(3000)).Wait();
            Result = x + y;
            Console.WriteLine($"线程:{Task.CurrentId} 准备好了");
            //将事件状态设置成有信号，从而允许一个或多个等待该事件的线程继续
            _mEvent.Set();
        }
    }
}
