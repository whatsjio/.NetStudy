using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 任务同步
{
    public class Demo
    {
        private object _syncRoot = new object();
        public delegate int TakesAWhileDelegate(int x, int ms);
        public void DoThis() {
            lock (_syncRoot)
            {

            }
        }
        public void DoThat() {
            bool a = false;
            Monitor.TryEnter(_syncRoot, 500, ref a);
            SpinLock spinLock;
            //spinLock.IsHeld;
            //spinLock.IsHeldByCurrentThread
        }
    }
}
