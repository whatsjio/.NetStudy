using System;
using System.Collections.Generic;
using System.Text;

namespace ComprehensionDotNet
{
    /// <summary>
    /// 实例Adapter模式
    /// 相当于少了一个继承和接口实现
    /// </summary>
    class InstanceAdapter
    {
    }

    public class BirdAdatper : ITweetable
    {
        private readonly Bird _brid;
        public BirdAdatper(Bird brids)
        {
            _brid = brids;
        }

        public void ShowType()
        {
            _brid.ShowType();
        }


        /// <summary>
        /// 内聚
        /// </summary>
        public void ToWeet()
        {

            if (_brid is Chicken)
            {

            }
            else
            {
                
            }
        }
    }

    public class Test
    {
        public void TestAdapter()
        {
            var ad = new BirdAdatper(new Chicken());
            ad.ToWeet();
        }
    }

}
