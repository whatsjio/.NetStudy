using System;
using System.Collections.Generic;
using System.Text;

namespace ClosureExample
{
    public sealed class SingletonOne
    {
        SingletonOne()
        {

        }

        public static SingletonOne Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonOne();
                }

                return instance;
            }
        }
        private static SingletonOne instance = null;
    }

    public sealed class SingletonTwo
    {
        SingletonTwo()
        {
        }

        public string Tesv { get; set; }

        public static SingletonTwo Instance => instance;

        private static readonly SingletonTwo instance = new SingletonTwo();
    }
}
