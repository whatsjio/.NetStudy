using System;
using System.Collections.Generic;
using System.Text;

namespace ComprehensionDotNet
{

    /// <summary>
    /// 接口例子
    /// </summary>
    class interfacesexample
    {
    }

    interface IDriveable
    {
        void Drive();
    }

    public class BusDriver : IDriveable
    {
        public void Drive()
        {
            Console.WriteLine("有经验的司机可以驾驶公共汽车");
        }
    }

    public class TractorDriver : IDriveable
    {
        public void Drive()
        {
            Console.WriteLine("拖拉机驾驶拖拉机");
        }
    }

    class dd: IDriveable
    {
        void IDriveable.Drive()
        {
            Console.WriteLine("测试重写信息");
        }
    }

    class interfacesexampleStart
    {
        public static void Start()
        {
            IList<IDriveable> drivers = new List<IDriveable>();
            drivers.Add(new BusDriver());
            drivers.Add(new TractorDriver());
            foreach (var drive in drivers)
            {
                drive.Drive();
            }
        }
    }


}
