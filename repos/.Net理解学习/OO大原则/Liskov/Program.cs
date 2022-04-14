using System;

namespace Liskov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    class FatherClass
    {
        //父类行为
        public virtual void Method()
        {

        }
    }

    class SonClass: FatherClass
    {
        //重写父类行为
        public override void Method()
        {
            base.Method();
        }
    }

}
