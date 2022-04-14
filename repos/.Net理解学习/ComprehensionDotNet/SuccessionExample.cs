using System;
using System.Collections.Generic;
using System.Text;

namespace ComprehensionDotNet
{
    class SuccessionExample
    {
    }

    /// <summary>
    /// 动物基类
    /// </summary>
    public abstract class Animal
    {
        /// <summary>
        /// 抽象类型
        /// </summary>
        public abstract void ShowType();

        /// <summary>
        /// 基类实现方法
        /// </summary>
        public void Eat()
        {
            Console.WriteLine("Animal always eat.");
        }
    }

    /// <summary>
    /// 鸟类
    /// </summary>
    public class Bird : Animal
    {
        private string type = "Bird";
        public  override void ShowType()
        {
            Console.WriteLine("Type is {0}",type);
        }

        public void fly()
        {

        }

        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

    }

    public class Eagle : Bird
    {

    }

    public class Chicken : Bird
    {
        private string type = "Chicken";
        public override void ShowType()
        {
            Console.WriteLine("Type is {0}", type);
        }

        public new void fly()
        {

        }

        public void ShowColor()
        {
            Console.WriteLine("Color is {0}", Color);
        }
    }
}
