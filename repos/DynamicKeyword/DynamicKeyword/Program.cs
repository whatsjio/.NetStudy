using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //var s1 = "Greetings";
            //object s2 = "Form";
            //dynamic s3 = "Minneapolis";
            
            //Console.WriteLine("123rtt{0}", s3.GetType());
            //Console.ReadLine();

            dynamic t = "Hello";
            Console.WriteLine("str{0}",t.GetType());
            t = false;

            Console.WriteLine("bool{0}", t.GetType());

            t = 123;
            Console.WriteLine("int{0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("list int{0}", t.GetType());


            t = new object[] { "123", "456", 2334 };
            Console.WriteLine("object arrary{0}", t.GetType());


            Console.ReadLine();
        }
    }
}
