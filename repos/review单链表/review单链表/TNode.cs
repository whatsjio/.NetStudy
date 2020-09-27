using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace review单链表
{
    class TNode<T>
    {
        public TNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// 值
        /// </summary>
        public T Value { get; private set; }
        /// <summary>
        /// 上一个
        /// </summary>
        public TNode<T> Pre { get; set; }
        /// <summary>
        /// 下一个
        /// </summary>
        public TNode<T> Netxt { get; set; }
    }
}
