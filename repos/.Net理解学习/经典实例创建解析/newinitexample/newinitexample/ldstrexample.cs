using System;
using System.Collections.Generic;
using System.Text;

namespace newinitexample
{
    class ldstrexample
    {
        public static void start()
        {
            var firstName = "Wang";
            var secondName = new string('T', 5);
            Console.WriteLine(firstName+secondName);
            Console.Read();
        }
    }

    class  CreateInstance
    {
        public static void Main1()
        {
            char[] arrChars = new char[5];
            for (int i = 0; i < 5; i++)
            {
                arrChars[i] = 'a';
            }
            Console.WriteLine(arrChars[0]);
        }
    }
}
