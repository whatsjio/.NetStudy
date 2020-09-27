using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单链表例子
{
    class SingNode<T>
    {
        /// <summary>
        /// 上一个
        /// </summary>
        public SingNode<T> Pre { get; internal set; }
        /// <summary>
        /// 下一个
        /// </summary>
        public SingNode<T> Next { get; internal set; }
        public SingNode(T value)
        {
            Value = value;
        }
        public T Value { get; private set; }
    }
}
