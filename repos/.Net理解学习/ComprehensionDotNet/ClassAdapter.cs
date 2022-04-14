using System;
using System.Collections.Generic;
using System.Text;

namespace ComprehensionDotNet
{
    /// <summary>
    /// 类Adapter(适配器)模式
    /// </summary>
    class ClassAdapter
    {

    }

    public interface ITweetable
    {
        void ToWeet();
    }

    public class EagleAdapter : Eagle, ITweetable
    {
        public void ToWeet()
        {
            throw new NotImplementedException();
        }
    }

    public class ChickenAdapter : Chicken, ITweetable
    {
        public void ToWeet()
        {
            throw new NotImplementedException();
        }
    }

}
