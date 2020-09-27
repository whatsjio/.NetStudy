using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 猫叫老鼠跑模型
{
    public delegate void ddd();
    
    class cat
    {
        public event ddd dsdsd;
        //EventHandler固定的委托类型
        //接收订阅
        public event EventHandler<string> Catcall;
        public void Oncall(object e,string s) {
            Console.WriteLine("猫叫了");
            Catcall?.Invoke(e, s);
        }
    }

    class Mouse {

        public event EventHandler<string> Run;
        public void Onrun(object e, string s) {
            Console.WriteLine("老鼠跑了");
            Run?.Invoke(e, s);
        }

    }
}
