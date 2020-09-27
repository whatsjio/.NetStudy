using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review单链表
{
    class Node
    {
        public Node(object value)
        {
            Value = value;
        }
        public object Value { get; }

        public Node Previou { get; set; }

        public Node Next { get; set; }
    }
}
