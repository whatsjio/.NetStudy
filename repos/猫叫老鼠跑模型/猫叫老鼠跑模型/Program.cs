using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 猫叫老鼠跑模型
{
    class Program
    {
        static void Main(string[] args)
        {
            cat ss = new cat();
            void sss(object se,string jio) {
                Console.WriteLine("猫叫了吼吼");
            };
            var handd = new EventHandler<string>(sss);
            ss.Catcall += handd;

        }
    }
}
