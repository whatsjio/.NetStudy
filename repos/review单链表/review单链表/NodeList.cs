using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace review单链表
{
    class NodeList:IEnumerable
    {
        public Node Last { private set; get; }
        public Node First { private set; get; }

        public Node Add(object t) {
            var addmodel = new Node(t);
            if (First == null&&Last==null)
            {
                First = addmodel;
                Last = addmodel;
            }
            else {
                var tem = Last;
                Last = addmodel;
                tem.Next = addmodel;
                addmodel.Previou = tem;
            }
            return addmodel;
        }
        public IEnumerator GetEnumerator() {
            var firetmodel = First;
            while (firetmodel!=null)
            {
                yield return firetmodel.Value;
                firetmodel = firetmodel.Next;
            }
        }

        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        //public IEnumerator GetEnumerator()

    }
}
