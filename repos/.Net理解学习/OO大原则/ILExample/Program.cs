using System;

namespace ILExample
{
    class Program
    {

        /// <summary>
        /// 主方法测试
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            /*int id = 1;
            var one = new One();
            one.ID = id;
            var two = new Two();
            Console.WriteLine(two.SayHello());*/

            Console.WriteLine(typeof(One).MetadataToken);
            Console.ReadKey();
        }
    }


}
