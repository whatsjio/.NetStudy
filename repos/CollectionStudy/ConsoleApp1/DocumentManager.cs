using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DocumentManager
    {
        private readonly Queue<Document> _documentsQueue = new Queue<Document>();
        public void AddDocument(Document doc) {
            lock (this)
            {
                _documentsQueue.Enqueue(doc);
            }
        }
        public Document GetDocument() {
            Document doc = null;
            lock (this)
            {
                doc = _documentsQueue.Dequeue();
            }
            return doc;
        }
        public bool IsDocumentAvailable => _documentsQueue.Count > 0;
    }
}
