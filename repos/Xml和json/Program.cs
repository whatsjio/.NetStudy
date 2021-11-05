using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Console;

namespace Xml和json
{
    class Program
    {
        private const string BooksFileName = "book.xml";
        private const string NewBooksFileName = "newbooks.xml";
        private const string ReadTextOption = "-r";
        private const string ReadElementContentOption = "-c";
        private const string ReadElementContentOption2 = "-c2";
        private const string ReadDecimalOption = "-d";
        private const string ReadAttributesOption = "-a";
        private const string WriteOption = "-w";
     

        static void Main(string[] args)
        {
            //var paramstr = args[0];
            var paramstr = Console.ReadLine();
            switch (paramstr)
            {
                default:
                    break;
            }

        }

        public static void ReadTextNodes() {
            using (XmlReader reader=XmlReader.Create(BooksFileName))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Text) {
                        WriteLine(reader.Value);
                    }
                }
            }
        
        }

        public static void ReadElementContent() {
            using (XmlReader reader=XmlReader.Create(BooksFileName))
            {
                while (!reader.EOF)
                {
                    if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "title")
                    {
                        try
                        {
                            WriteLine(reader.ReadElementContentAsString());
                        }
                        catch (Exception)
                        {
                            reader.Read();
                        }
                    }
                    else {
                        reader.Read();
                    }
                }

            }
        
        }
    }
}
