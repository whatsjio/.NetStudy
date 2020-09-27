using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErroAndExpression
{
    sealed class MyExpression:Exception
    {
        public int Errorcode { get; }
        public MyExpression(int code):base()
        {
            Errorcode = code;
        }
    }
}
