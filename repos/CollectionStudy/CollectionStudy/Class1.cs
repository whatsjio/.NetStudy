using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    public class Class1
    {
        static void Main() {
            var a = new List<int>();
            a.TrimExcess();
            var stringList = new List<string>() { "asd", "sdsd" };
            var ataa = new datetimeindex();
            
            Random dd = new Random();
            //dd.Next(2, 7);
            int aa = 0;
            while (aa!=2)
            {
                aa= dd.Next(2, 7);
                Console.WriteLine(aa);
            }
            Console.ReadKey();
        }
    }
}
