using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review单链表
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new Node("a");
            //var b = new Node("b");
            //var c = new Node("c");
            //var d = new Node("d");
            //var list = new NodeList();
            //list.Add(a);
            //list.Add(b);
            //list.Add(c);
            //list.Add(d);
            //foreach (Node model in list)
            //{
            //    Console.WriteLine(model.Value);
            //}

            var List = new TList<int>();
            List.Add(1);
            List.Add(2);
            List.Add(3);
            List.Add(4);
            foreach (var item in List)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
