using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace StreamTest
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public static void WriteTextFile() {
            string tempTextFileName = Path.ChangeExtension(Path.GetTempFileName(), "txt");
            using (FileStream stream=File.OpenWrite(tempTextFileName))
            {

            }
        }
         
    }
}
