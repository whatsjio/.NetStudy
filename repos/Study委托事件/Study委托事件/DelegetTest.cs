using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study委托事件
{
    class DelegetTest
    {
        internal protected delegate void INMethodInvoker(int x);
        delegate double TwoLongsOp(long first, long second);
        delegate string GetAstring();
        delegate void twotwo(string gg);
    }
    
}
