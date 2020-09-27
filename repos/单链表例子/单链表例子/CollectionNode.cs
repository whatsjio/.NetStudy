using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace 单链表例子
{
    class CollectionNode<T>:IEnumerable<T>
    {
        public SingNode<T> Last { get; private set; }
        public SingNode<T> First { get; private set; }

        public CollectionNode()
        {

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public SingNode<T> Add(T value) {
            var date = new SingNode<T>(value);
            if (Last == null && First == null)
            {
                Last = date;
                First = date;
            }
            else {
                var zlast = Last;
                Last.Next = date;
                Last = date;
                Last.Pre = zlast;
            }
            return date;
        }
        public IEnumerator<T> GetEnumerator() {
            var first = First;
            while (first!=null)
            {
                yield return first.Value;
                first = first.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
