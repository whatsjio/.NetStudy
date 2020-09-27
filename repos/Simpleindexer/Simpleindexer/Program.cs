using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Simpleindexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var q = 0;
            var o = 0;
            for (int i = 0; i < 6; i++)
            {
                var s = 1;
                q= q++;
                var a = 1;
                o= ++o;
                WriteLine(string.Format("q是{0},o是{1}", q,o));
            }
           
            ReadLine();
        }
    }
}
