using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }
        public Document(string title,string content)
        {
            Title = title;
            Content = content;
        }

    }
}
