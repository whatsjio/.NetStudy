using System;

namespace ClosureExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World!");
            var a = Show();
            a();
            a();
            Console.ReadKey();*/
            var a= SingletonTwo.Instance;
            a.Tesv = "sdsd";
            var b = SingletonTwo.Instance;
            var bs= b.Tesv;
            Console.ReadKey();
        }

        static Action Show()
        {
            int i = 0;
            void Closer()
            {
                i++;
                Console.WriteLine(i);
            }
            return Closer;
        }
    }
}
