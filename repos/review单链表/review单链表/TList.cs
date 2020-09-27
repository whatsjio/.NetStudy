using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace review单链表
{
    class TList<T>:IEnumerable<T>
    {
        /// <summary>
        /// 第一个
        /// </summary>
        public TNode<T> First { get; private set; }
        /// <summary>
        /// 最后一个
        /// </summary>
        public TNode<T> Last { get; private set; }

        public TNode<T> Add(T model) {
            var nextlast = new TNode<T>(model);
            if (First == null && Last == null)
            {
                First = nextlast;
                Last = nextlast;
            }
            else {
                var temp = Last;
                temp.Netxt = nextlast;
                Last = nextlast;
                nextlast.Pre = temp;
            }
            return nextlast;
        }

        public IEnumerator<T> GetEnumerator() {
            var returnmodel = First;
            while (returnmodel!=null)
            {
                yield return returnmodel.Value;
                returnmodel = returnmodel.Netxt;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();



    }
}
