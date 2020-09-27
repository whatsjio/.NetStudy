using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace operatorstudy
{
    class Program
    {
        private static string JIojio;
        static void Main(string[] args)
        {
            //byte b = 255;
            //unchecked
            //{
            //    b++;
            //}
            //WriteLine(b);
            //var a = nameof(hh);
            int[] arr = null;
            int x1 = arr?[0] ?? 0;
            byte a = 3;
            byte b = 5;
            byte c =checked((byte)(a + b));
        }
        public static void hh() {

        }
    }
}
