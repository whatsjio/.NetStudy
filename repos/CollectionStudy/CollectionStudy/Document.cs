using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public byte Priority { get; private set; }
        public Document(string title,string content,byte priority)
        {
            Title = title;
            Content = content;
            Priority = priority;
        }
    }
}
