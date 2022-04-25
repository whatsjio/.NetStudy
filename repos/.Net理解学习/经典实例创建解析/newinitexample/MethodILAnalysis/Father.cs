using System;
using System.Collections.Generic;
using System.Text;

namespace MethodILAnalysis
{
    public class Father
    {
        public void DoWork() {
            Console.WriteLine("Father.DoWork");
        }
        public virtual void DoVirtualWork() {
            Console.WriteLine("Father.DoVirtualWork");
        }

        public virtual void DoVirtualAll()
        {
            Console.WriteLine("Father.DoVirtualAll");
        }
    }

    public class Son : Father {
        public static void DoStaticWork() {
            Console.WriteLine("Son.DoStaticWork");
        }
        public new virtual void DoVirtualWork() {
            base.DoVirtualWork();
            Console.WriteLine("Son.DoVirtualWork()");
        }

        public override void DoVirtualAll()
        {
            Console.WriteLine("Son.DoVirtualAll()");
        }
    }

    public class Grandson : Son {
        public override void DoVirtualWork()
        {
            base.DoVirtualWork();
            Console.WriteLine("Grandson.DoVirtualWork");
        }
        public override void DoVirtualAll()
        {
            base.DoVirtualAll();
            Console.WriteLine("Grandson.DoVirtualAll");
        }
    }



}
