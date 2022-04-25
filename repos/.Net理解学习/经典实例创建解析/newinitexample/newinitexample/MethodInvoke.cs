using System;
using System.Collections.Generic;
using System.Text;

namespace newinitexample
{
    public class MethodInvoke
    {
        public static void StaticMethod()
        {

        }

        public void InstanceMethod()
        {

        }
    }

    class IL_Method_TEst
    {
        public static void Main2()
        {
            //调用静态方法
            MethodInvoke.StaticMethod();
            MethodInvoke mi = new MethodInvoke();
            mi.InstanceMethod();
        }
    }
}
