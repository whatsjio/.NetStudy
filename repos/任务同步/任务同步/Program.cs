using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 任务同步
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo.TakesAWhileDelegate d1 = TaskAwhile;
            //var ar = d1.BeginInvoke(1, 3000, null, null);
            //var dg = ar.AsyncWaitHandle;

            //while (true)
            //{
            //    Console.WriteLine(".");
            //    if (ar.AsyncWaitHandle.WaitOne(3000))
            //    {
            //        Console.WriteLine("Can get the result now");
            //        break;
            //    }
            //    else {
            //        Console.WriteLine("等待中");
            //    }
            //}
            //int result = d1.EndInvoke(ar);
            //Console.WriteLine($"result:{result}");
            //var state = new StateObject();
            //for (int i = 0; i < 2; i++)
            //{
            //    Task.Run(() => new SampleTask().RaceCondition(state));
            //}
            //var state1 = new StateObject();
            //var state2 = new StateObject();
            //new Task(new SampleTask(state1, state2).Deadlock1).Start();
            //new Task(new SampleTask(state1, state2).Deadlock2).Start();
            //int numTasks = 20;
            //var state = new SharedState();
            //var tasks = new Task[numTasks];
            //for (int i = 0; i < numTasks; i++)
            //{
            //    tasks[i] = Task.Run(() => new Demo().DoThat());
            //}
            //Task.WaitAll(tasks);
            //Console.WriteLine($"summarized{state.State}");

            //bool createdNew;
            //var mutex = new Mutex(false, "ProSharpMutex", out createdNew);
            ////阻止当前线程
            //if (mutex.WaitOne())
            //{
            //    try
            //    {

            //    }
            //    finally
            //    {
            //        //释放信号量
            //        mutex.ReleaseMutex();
            //    }
            //}
            //else {
            //    //等待的时候做什么
            //}
            //int taskCount = 6;
            //int semaphoreCount = 3;
            //var semaphore = new SemaphoreSlim(semaphoreCount, semaphoreCount);
            //var tasks = new Task[taskCount];
            //for (int i = 0; i < taskCount; i++)
            //{
            //    tasks[i] = Task.Run(() => TaskMain(semaphore));
            //}
            //Task.WaitAll(tasks);
            const int taskCount = 4;

            var mEvents = new ManualResetEventSlim[taskCount];
            var waitHandles = new WaitHandle[taskCount];
            var calcs = new Calculator[taskCount];
            for (int i = 0; i < taskCount; i++)
            {
                int il = i;
                mEvents[i] = new ManualResetEventSlim(false);
                waitHandles[i] = mEvents[i].WaitHandle;
                calcs[i] = new Calculator(mEvents[i]);
                Task.Run(() => calcs[il].Caculation(il + 1, il + 3));
            }
            for (int i = 0; i < taskCount; i++)
            {
                int index = WaitHandle.WaitAny(waitHandles);
                if (index == WaitHandle.WaitTimeout)
                {
                    Console.WriteLine("已超时");
                }
                else {
                    mEvents[index].Reset();

                }
            }
            Console.ReadKey();
        }
        public static int TaskAwhile(int x, int ms) {
            Task.Delay(ms).Wait();
            return 42;
        }

        public static void TaskMain(SemaphoreSlim seamphore) {
            bool isCompleted = false;
            while (!isCompleted)
            {
                if (seamphore.Wait(600))
                {
                    try
                    {
                        Console.WriteLine($"线程ID{Task.CurrentId} 锁定");
                        Task.Delay(2000).Wait();
                    }
                    finally
                    {
                        Console.WriteLine($"线程ID{Task.CurrentId} 解除锁定");
                        seamphore.Release();
                        isCompleted = true;
                    }
                }
                else {
                    Console.WriteLine($"线程超时，再次等待线程：{Task.CurrentId}");
                }
            }
        }
      
    }
}
