using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace TaskTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Task(consoles);
            //a.Start();
            //a.Wait();
            //WriteLine("主线程执行完毕");
            //var b= Task.Factory.StartNew(ttr).ConfigureAwait(true);
            consoles();
            WriteLine("eqwe");
            //ReadKey();
        }

        static string ttr() {
            return "sdasd";
        }
         
        static async void consoles() {
            await Task.Delay(1000);
            WriteLine("分支");
            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Delay(1000);
            //    Task.Yield();
            //    Console.WriteLine($"正在执行{i}");
                
            //}
            
        }
    }
}
