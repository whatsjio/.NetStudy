using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Study委托事件
{
    delegate double DoubleOp(double x);
    class Program
    {
        private delegate string GetAstring();
        static Func<string> ssss;
        static void Main(string[] args)
        {
            //int x = 40;
            //GetAstring bs = Currency.GetCurrencyUnit;
            //var a = bs();
            //GetAstring getAstring = new GetAstring(x.ToString);
            //GetAstring get = x.ToString;
            //getAstring();
            //getAstring.Invoke();
            //Action<string, string, int, int> asdd = (string a, string b, int c, int d) =>
            //{

            //};
            //Action asd = () =>
            //{

            //};
            //Func<double,double>[] operations = {
            //    MathOperations.MultiplyByTwo,
            //    MathOperations.Square
            //};
            //DoubleOp[] operations = {
            //    MathOperations.MultiplyByTwo,
            //    MathOperations.Square
            //};
            //for (int i = 0; i < operations.Length; i++)
            //{
            //    ProcessAndDisplay(operations[i], 2.0);
            //}
            //Action<double> operations1 = MathOperations.MultiplyByTwo;
            //operations1 += MathOperations.Square;
            //ProcessAndDisplay(operations1, 3.0d);
            //ReadKey();
            //Action<double> operations = operations1 + operations2;
            //GetAstring sdsd = null;
            //ssss = null;

            //Action dl = One;
            //dl += Two;
            //var delegates= dl.GetInvocationList();
            //foreach (Action item in delegates)
            //{
            //    try
            //    {
            //        item();
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }

            //}
            //int someVal = 5;
            //Func<int, int> f = x => someVal=6;
            //var a = f(2);
            //someVal = 4;
            //var b= f(2);
            //var dealer = new CarDealer();
            //var daniel = new Consumer("asdasd");
            //dealer.Newcarinfo += daniel.NewCarIsHere;
            //dealer.NewCar("123");
            var ev = new Eventdate("猫叫事件开始吧");
            var cat = new Cat(ev);

            var mousdata = new Eventdate("收到猫的信号");
            var mouse = new Mous(mousdata);
            cat.handlecatevents += mouse.Run;
            //老鼠跑触发人的事件
            var people = new People();
            mouse.handlecatevents += people.wakeup;

            cat.call();
            ReadLine();
        }
        static void ProcessAndDisplay(Action<double> action, double value) {
            action(value);
        }
        static void One() {
            WriteLine("One");
            throw new Exception("hhh");
        }
        static void Two() {
            WriteLine("Two");
        }
        Func<double, double> square = x =>
        {
            return x * x;
        };
        static Tuple<string, int, float> sdsds() {
            var sss=new Tuple<string, int, float>("sd", 12, 12.3f);
            return Tuple.Create<string, int, float>("sd", 12, 12.3f);
        }
    }
}
