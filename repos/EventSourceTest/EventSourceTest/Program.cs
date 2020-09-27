using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Tracing;
using static System.Console;
using System.Threading;
using System.Threading.Tasks.Dataflow;
using System.IO;

namespace EventSourceTest
{
    class Program
    {
        private static EventSource sampleEventSource = new EventSource("Wrox-EventSourceSample");
        private static BufferBlock<string> s_buffer = new BufferBlock<string>();

        public static void Producer() {
            bool exit = false;
            while (!exit)
            {
                string input = ReadLine();
                if (string.Compare(input, "ex", ignoreCase: true) == 0)
                {
                    exit = true;
                }
                else {
                    s_buffer.Post(input);
                }
            }
        }

        public static async Task ConsumerAsync() {
            while (true)
            {
                string data = await s_buffer.ReceiveAsync();
                WriteLine($"user input:{data}");
            }
        }

        static void Main(string[] args)
        {
            //WriteLine($"Log Guid:{sampleEventSource.Guid}");
            //WriteLine($"Name{sampleEventSource.Name}");
            //sampleEventSource.Write("开始", new { Info = "startapp" });
            //ParallelFor();
            //StopParallelForEarly();
            //ParallelForWithInt();
            //ParallelForeach();
            //ParallelInvoke();
            //RunSynchronousTask();
            //LongRunningTask();
            //TaskWithResultDemo();
            //ParentAndChild();
            //var a= TaskMethodAsync();
            //a.Wait();
            //var b= a.Result;
            //ProceTest();
            //Task.Delay(5000).Wait();
            //CancelParallelFor();
            //CancelTask();

            //ActionBlock


            //ReadLine();

            Task t1 = Task.Run(() => Producer());
            Task t2 = Task.Run(async () => await ConsumerAsync());
            Task.WaitAll(t1, t2);
        }

        public static void Log(string prefix) {
            WriteLine($"{prefix},task:{Task.CurrentId},thread:{Thread.CurrentThread.ManagedThreadId}");
        }

        public static void ParallelFor() {
            ParallelLoopResult result = Parallel.For(0, 10,async i =>
            {
                Log($"S{i}");
                await Task.Delay(10);
                Log($"E{i}");
            });
            WriteLine($"完成状态:{result.IsCompleted}");
        }

        public static void StopParallelForEarly() {
            ParallelLoopResult result = Parallel.For(10, 40, (int
                     i, ParallelLoopState pls) =>
                {
                    Log($"S{i}");
                    if (i>12)
                    {
                        pls.Break();
                        Log($"break now{i}");
                    }
                    Task.Delay(10).Wait();
                    Log($"E{i}");
                });
            WriteLine($"完成状态:{result.IsCompleted}");
            WriteLine($"中断结果:{result.LowestBreakIteration}");
        }
        public static void ParallelForWithInt() {
            Parallel.For<string>(0, 10, () =>
            {
                Log($"初始化");
                return $"当前线程id:{Thread.CurrentThread.ManagedThreadId}";
            }, (i, pls, strl) =>
            {
                Log($"循环线程{i} str{strl}");
                Task.Delay(10).Wait();
                return $"i{i}";
            }, (str) =>
            {
                Log($"最后线程结束{str}");
            });
        }

        public static void ParallelForeach() {
            string[] data = { "zero", "one", "two", "three", "four", "fice", "six" };
            Parallel.ForEach<string>(data, (ss,pls,l) =>
            {
                
                WriteLine(ss);
            });
            
        }
        public static void ParallelInvoke() {
            Parallel.Invoke(Foo, Bar);
        }
        public static void Foo() {
            WriteLine("foo");
        }
        public static void Bar() {
            WriteLine("bar");
        }
        private static object s_logLock = new object();
        public static void TaskMethod(object o) {
            Logs(o?.ToString());
        }

        public static void Logs(string title) {
            lock (s_logLock)
            {
                WriteLine(title);
                WriteLine($"任务 id:{Task.CurrentId?.ToString() ?? "no task"}||是否是线程池的线程:{Thread.CurrentThread.IsThreadPoolThread}");


            }
        }

        public void TasksUsingThreadPool() {
            var tf = new TaskFactory();
            Task t1 = tf.StartNew(TaskMethod, "eqwe");
            Task t2 = Task.Factory.StartNew(TaskMethod, "ds");
            var t3 = new Task(TaskMethod, "22");
            t3.Start();
            Task t4 = Task.Run(() => TaskMethod("sdsd"));
        }

        private static void RunSynchronousTask() {
            TaskMethod("eqwe");
            var t1 = new Task(TaskMethod, "run sss");
            t1.RunSynchronously();
            
        }

        private static void LongRunningTask() {
            var t1 = new Task(TaskMethod, "long", TaskCreationOptions.LongRunning);
            t1.Start();
        }

        public static Tuple<int, int> TaskWithResult(object division) {
            Tuple<int, int> div = (Tuple<int, int>)division;
            int result = div.Item1 / div.Item2;
            int reminder = div.Item1 % div.Item2;
            WriteLine("task creates a reault...");
            return Tuple.Create(result, reminder);
        }
        public static void TaskWithResultDemo() {
            var t1 = new Task<Tuple<int, int>>(TaskWithResult, Tuple.Create(8, 13));
            t1.Start();
            WriteLine(t1.Result.Item1);
            t1.Wait();
            WriteLine($"result from task:i1 {t1.Result.Item1}i2 {t1.Result.Item2}");
        }

        private static void DoOnFirst() {
            WriteLine($"doing some task{Task.CurrentId}");
            Task.Delay(3000).Wait();
        }
        private static void DoOneSecond(Task t) {
            WriteLine($"task{t.Id} finished");
            WriteLine($"task id:{Task.CurrentId}");
            WriteLine("do some cleanup");
            Task.Delay(3000).Wait();
        }

        public static void ContinuationTasks() {
            Task t1 = new Task(DoOnFirst);
            Task t2 = t1.ContinueWith(DoOneSecond);
            Task t3= t2.ContinueWith(DoOneSecond);
            Task t4 = t3.ContinueWith(DoOneSecond);
            t1.Start();
        }

        public static void ParentAndChild() {
            var parent = new Task(ParentTask);
            parent.Start();
            Task.Delay(2000).Wait();
            WriteLine(parent.Status);
            Task.Delay(4000).Wait();
            WriteLine(parent.Status);
        }

        private static void ParentTask() {
            WriteLine($"task id {Task.CurrentId}");
            var child = new Task(ChildTask);
            child.Start();
            Task.Delay(1000).Wait();
            WriteLine("parent started child");
        }
        private static void ChildTask() {
            WriteLine("child");
            Task.Delay(5000).Wait();
            WriteLine("child finished");
        }

        public static Task<IEnumerable<string>> TaskMethodAsync() {
            return Task.FromResult<IEnumerable<string>>(new List<string>() { "one,two" });
            Task.WhenAll();
            Task.WaitAll();
            Task.WhenAny();
            Task.WaitAny();
            Task.Yield();
        }

        static async Task ProceTest() {
            await Task.Yield();
            var tcs = new TaskCompletionSource<bool>();
             await Task.Run( async() =>
             {
                 Task.Delay(2000);
                 WriteLine("ewe");
                 tcs.SetResult(true);
             });
            tcs.Task.Wait();
            CancellationToken ss;
        }

        public static void CancelParallelFor() {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() =>
            {
                WriteLine("取消回调执行");
            });
            cts.CancelAfter(500);
            try
            {
                ParallelLoopResult result = Parallel.For(0, 100, new ParallelOptions
                {
                    CancellationToken = cts.Token,
                }, x =>
                {
                    WriteLine($"loop {x} started");
                    int sum = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        Task.Delay(2).Wait();
                        sum += i;
                    }
                    WriteLine($"loop {x} finished");
                });
            }
            catch (OperationCanceledException ex)
            {
                WriteLine(ex.Message);
            }
            
        }
        public static void CancelTask() {
            var cts = new CancellationTokenSource();
            cts.Token.Register(() =>
            {
                WriteLine("任务取消");
            });
            cts.CancelAfter(500);
            Task t1 = Task.Run(() =>
            {
                WriteLine("in task");
                for (int i = 0; i < 20; i++)
                {
                    Task.Delay(100).Wait();
                    CancellationToken token = cts.Token;
                    if (token.IsCancellationRequested)
                    {
                        WriteLine($"已被标记为取消状态");
                        token.ThrowIfCancellationRequested();
                        break;
                    }
                    WriteLine("in loop");
                }
                WriteLine($"task finished ");
            }, cts.Token);

            try
            {
                t1.Wait();
            }
            catch (AggregateException ex)
            {
                WriteLine($"exception:{ex.GetType().Name},{ex.Message}");
                foreach (var innerexception in ex.InnerExceptions)
                {
                    WriteLine($"innerexception:{ex.InnerException.GetType()}:{ex.InnerException.Message}");
                }
                throw;
            }
        }

        //获取文件列表
        public static IEnumerable<string> GetFileNames(string path) {
            foreach (var filename in Directory.EnumerateFiles(path,"*.cs"))
            {
                yield return filename;
            }
        }

        //得到文件的每一行
        public static IEnumerable<string> LoadLines(IEnumerable<string> fileNames) {
            foreach (var fileName in fileNames)
            {
                using (FileStream stream=File.OpenRead(fileName))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while ((line=reader.ReadLine())!=null)
                    {
                        yield return line;
                    }
                }
            }
        }

        public static IEnumerable<string> GetWords(IEnumerable<string> lines) {
            foreach (var line in lines)
            {
                string[] words = line.Split(' ', ',');
                foreach (var word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        yield return word;
                    }
                }
            }
        }
        public static ITargetBlock<string> SetupPipeline() {
            var fileNamesForPath = new TransformBlock<string, IEnumerable<string>>(path =>
            {
                return GetFileNames(path);
            });
            var lines = new TransformBlock<IEnumerable<string>, IEnumerable<string>>(filenames =>
            {
                return LoadLines(filenames);
            });
            var words = new TransformBlock<IEnumerable<string>, IEnumerable<string>>(lines2 =>
            {
                return GetWords(lines2);
            });
            var display = new ActionBlock<IEnumerable<string>>(coll =>
            {
                foreach (var s in coll)
                {
                    WriteLine(s);
                }
            });
            fileNamesForPath.LinkTo(lines);
            lines.LinkTo(words);
            words.LinkTo(display);
            return fileNamesForPath;

        }


    }
}
