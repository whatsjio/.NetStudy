using System;

namespace JITRunTime
{
    class Program
    {
        static void Main(string[] args)
        {
            Base three = new Three();
            three.M();
            three.N();
        }
    }

    public class Base
    {
        public void M()
        {
            Console.WriteLine("M in Base");
        }

        public virtual void N()
        {
            Console.WriteLine("N in Base");
        }
    }

    public class Three: Base
    {
        private static int ID { get; set; }
        public override void N()
        {
            Console.WriteLine("N in Three");
        }

        public void M()
        {
            Console.WriteLine("M in Three");
            M1();
        }

        public void M1()
        {
            Console.WriteLine("M1 in Three");
        }
    }

}
