using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
        }
        //1,1,2,3,5,8,13,21

        public int Foo(int i) {
            if (i <= 0)
            {
                return 0;
            }
            else if (i > 0 && i <= 2)
            {
                return 1;
            }
            else {
                return Foo(i - 1) + Foo(i - 2);
            }

        }

    }
}
