using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AWait
{
    class Program
    {
        static CancellationTokenSource _cans = new CancellationTokenSource();
        static void Main(string[] args)
        {
            
        }

        private static async void HandleOneError() {
            Task taskresult = null;
            try
            {
                Task t1= ThrowAfter(2000, "first");
                Task t2= ThrowAfter(2000, "first");
                taskresult = Task.WhenAll(t1, t2);
                await taskresult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"handled{ex.Message}");
            }
            foreach (var expmodel in taskresult.Exception.InnerExceptions)
            {

            }
            Action sdd = () => { };

             await Task.Run(sdd, _cans.Token); 
           
                
        }

        private static async Task<int> ssss (){

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"开始任务{i}");
                await Task.Delay(3000);
                Console.WriteLine($"任务{i} 延迟了2秒执行");
            }
            return 5;

        }
        private static void CallerWithContinuationTask() {
            Task<string> t1 = GreetingAsync("Stephanie");
            t1.ContinueWith(t =>
            {
                string result = t.Result;
                Console.WriteLine(result);
            });
        }

        static Task<string> GreetingAsync(string name) {
            return Task.Run<string>(() =>
            {
                return Greeting(name);
            });
        }

        static string Greeting(string name) {
            Task.Delay(3000).Wait();
            return $"Hello,{name}";
        }
        private async static void MultipleAsyncMethods() {
            Task<string> t1 = GreetingAsync("aa");
            Task<string> t2 = GreetingAsync("aa");
            var resultarry= await Task.WhenAll(t1, t2);
        }

        private static Func<string, string> greetinginvoker = Greeting;
        private static IAsyncResult BeginGreeting(string name, AsyncCallback callback, object state) {
            return greetinginvoker.BeginInvoke(name, callback, state);
        }

        private static string EndGreeting(IAsyncResult result) {
            return greetinginvoker.EndInvoke(result);
        }

        private static async void ConvertingAsyncPattern() {
            string s = await Task<string>.Factory.FromAsync(BeginGreeting, EndGreeting, "asg", null);
        }
        private async static  void qq() {
            Action<string> ssss = (dg) =>
            {
                Thread.Sleep(3000);
                Console.WriteLine(dg);
            };
            var aac = new AsyncCallback(callback);
            var result= ssss.BeginInvoke("ssddd", aac,null);
            void rerer(IAsyncResult resultsss){
                ssss.EndInvoke(resultsss);
            }
           await Task.Factory.FromAsync(result, rerer);


            //var gg = result.AsyncWaitHandle;
            //阻塞
            //g.WaitOne();

            //阻塞
            //ssss.EndInvoke(result);
            Console.WriteLine("完成所有");
        }
        public static void callback(IAsyncResult ass) {
            var b = ass.AsyncState;
            var a = ass.IsCompleted;
            Console.WriteLine("完成后回调");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ms"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        static async Task ThrowAfter(int ms,string message)
        {
            await Task.Delay(ms);
            throw new Exception(message);
        }


    }
}
