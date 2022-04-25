using System;

namespace MethodILAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Father son = new Son();
            son.DoWork();
            son.DoVirtualWork();
            Son.DoStaticWork();
            Father aGrandSon = new Grandson();
            aGrandSon.DoWork();
            aGrandSon.DoVirtualWork();
            aGrandSon.DoVirtualAll();
            Console.Read();
        }
    }
}
