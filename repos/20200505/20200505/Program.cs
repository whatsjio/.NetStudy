using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200505
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                unchecked
                {
                    long ad = 123123213123;
                    byte ac = (byte)ad;
                }
               

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }


        }
    }
}
