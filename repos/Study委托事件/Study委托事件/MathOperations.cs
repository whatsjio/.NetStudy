using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Study委托事件
{
    class MathOperations
    {
        public static void MultiplyByTwo(double value) {
            double result = value * 2;
            WriteLine(result);
        }
        public static void Square(double value) {
            double result = value * value;
            WriteLine(result);
        }
    }
}
