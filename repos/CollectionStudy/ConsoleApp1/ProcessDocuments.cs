using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ProcessDocuments
    {
        public static void Start(DocumentManager dm) {
            Task.Run(new ProcessDocuments(dm).Run);
        }
        public ProcessDocuments(DocumentManager dm)
        {
            if (dm == null)
            {
                throw new ArgumentNullException(nameof(dm));
            }
            else {
                _documentManager = dm;
            }
        }
        private DocumentManager _documentManager;
        protected async Task Run() {
            while (true)
            {
                if (_documentManager.IsDocumentAvailable)
                {
                    Document doc = _documentManager.GetDocument();
                    Console.WriteLine("Processing document{0}", doc.Title);
                }
                await Task.Delay(new Random().Next(20));
            }

        }
    }
}
