using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 任务同步
{
    class SampleTask
    {
        private StateObject _s1;
        private StateObject _s2;
        public SampleTask(StateObject s1,StateObject s2)
        {
            _s1 = s1;
            _s2 = s2;
        }

        public void Deadlock1() {
            int i = 0;
            while (true)
            {
                lock (_s1)
                {
                    lock (_s2)
                    {
                        _s1.ChangeState(i);
                        _s2.ChangeState(i++);
                        Console.WriteLine($"still running,{i}");
                    }
                }
            }

        }

        public void Deadlock2() {
            int i = 0;
            while (true)
            {
                lock (_s1)
                {
                    lock (_s2)
                    {
                        _s1.ChangeState(i);
                        _s2.ChangeState(i++);
                        Console.WriteLine($"still running,{i}");
                    }
                }
            }
        }

        //public void RaceCondition(object o)
        //{
        //    Trace.Assert(o is StateObject, "o must be of type StateObject");
        //    StateObject state = o as StateObject;
        //    int i = 0;
        //    while (true)
        //    {
        //        state.ChangeState(i++);
        //    }
        //}
    }
}
