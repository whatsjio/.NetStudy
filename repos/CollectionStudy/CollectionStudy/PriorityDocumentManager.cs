using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    class PriorityDocumentManager
    {
        private readonly LinkedList<Document> _documentlist;
        private readonly List<LinkedListNode<Document>> _priorityNodes;
        public PriorityDocumentManager()
        {
            _documentlist = new LinkedList<Document>();
            _priorityNodes = new List<LinkedListNode<Document>>(10);
            for (int i = 0; i < 10; i++)
            {
                _priorityNodes.Add(new LinkedListNode<Document>(null));
            }
        }
        public void AddDocument(Document d) {
            if (d==null)
            {
                throw new ArgumentNullException("d");
            }
            
        }
    }
}
