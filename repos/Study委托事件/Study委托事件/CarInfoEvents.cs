using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Study委托事件
{
    public class CarInfoEvents:EventArgs
    {
        public CarInfoEvents(string car)
        {
            Car = car;
        }
        public string Car { get; }
    }

    public class CarDealer {
        public event EventHandler<CarInfoEvents> Newcarinfo;
        public void NewCar(string car) {
            System.Console.WriteLine($"{car}");
            Newcarinfo?.Invoke(this, new CarInfoEvents(car));
        }

    }

    public class Consumer {
        private string _name;
        public Consumer(string name)
        {
            _name = name;
        }
        public void NewCarIsHere(object sender, CarInfoEvents e) {
            Console.WriteLine($"{_name}:car {e.Car} is here");
        }

    }

    /// <summary>
    /// 猫叫的数据基类
    /// </summary>
    public class Eventdate:EventArgs {
        public Eventdate(string gg)
        {
            GG = gg;
        }
        public string GG { get; }
    }

    /// <summary>
    /// 猫叫的事件相当于事件发布者
    /// </summary>
    public class Cat {
        public event EventHandler<Eventdate> handlecatevents;

        private Eventdate _eve;

        public Cat(Eventdate eventdate)
        {
            _eve = eventdate;
        }
        /// <summary>
        /// 叫
        /// </summary>
        public void call() {
            Console.WriteLine("tom叫了");
            //我来传递个叫了之后的参数
            handlecatevents?.Invoke(this, _eve);
        }
    }
    /// <summary>
    /// 人怎么样 事件消费者
    /// </summary>
    public class People {
        /// <summary>
        /// 我看你传送的啥子，我醒了
        /// </summary>
        /// <param name="jiojio"></param>
        /// <param name="eventdate"></param>
        public void wakeup(object jiojio, Eventdate eventdate) {
            WriteLine($"我醒了，啥事，你说{eventdate.GG}哇？");
        }
    }
    /// <summary>
    /// 老鼠怎么样， 依然是事件消费者
    /// </summary>
    public class Mous {

        public event EventHandler<Eventdate> handlecatevents;
        private Eventdate _eve;
        public Mous(Eventdate eventdate)
        {
            _eve = eventdate;
        }
        /// <summary>
        /// 跑
        /// </summary>
        /// <param name="jiojio"></param>
        /// <param name="eventdate"></param>
        public void Run(object jiojio, Eventdate eventdate) {
            WriteLine($"我要跑了，GG{eventdate.GG}？");
            handlecatevents?.Invoke(this, _eve);
        }
    }
}
