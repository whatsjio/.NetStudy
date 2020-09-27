using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace 任务同步
{
    class StateObject
    {
        private int _state = 5;
        private object sync = new object();
        public void ChangeState(int loop)  {
            lock (sync)
            {
                if (_state == 5)
                {
                    _state++;
                    Trace.Assert(_state == 6, $"Race condition occurred after{loop} loops");
                }
                _state = 5;
            }
          
        }

     
    }
}
