using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace FileAndIO
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new FileInfo(@"C:\Windows");
            Console.WriteLine(test.Exists);
            Console.ReadKey();
        }
        const string SamplelFileName = "Samplel.text";

        private static string GetDocumentsFolder()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static void CreateAfile()
        {
            string fileName = Path.Combine(GetDocumentsFolder(), SamplelFileName);
            File.WriteAllText(fileName, "Hello");
            var file = new FileInfo(@".\ReadMe.text");
            file.CopyTo(@"C:\Copies\ReadMe.txt");
            File.Copy(@".\ReadMe.text", @"C:\Copies\ReadMe.txt");
            var myFolder = new DirectoryInfo(@"C\Program Files");
            var test = new FileInfo(@"C:\Windows");
            Console.WriteLine(test.Exists);
        }

        private static void FileInformation(string fileName)
        {
            var file = new FileInfo(fileName);
            //file.Extension
            Console.WriteLine($"Name:{file.Name};{file.DirectoryName}");
        }

        public static void ReadingAFileLineByLine(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            int i = 1;
            foreach (var line in lines)
            {
                Console.WriteLine($"{i++}.{line}");
            }

            Console.WriteLine($"asdasd{true}");
        }
        public static void WritrAFile()
        {
            string fileName = Path.Combine(GetDocumentsFolder(), "movies.txt");
            string[] movies = {
                "123",
                "2323",
                "123123"
            };
            File.WriteAllLines(fileName, movies);
            //File.AppendAllLines()
            //Directory.GetDirectories()
        }

        private void ReadFileUsingFileStream(string fileName)
        {
            const int bufferSize = 4096;
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

            }
        }
        private void ShowStreamInfomation(Stream stream)
        {
            Console.WriteLine($"stream can read:{stream.CanRead},{stream.CanWrite},{stream.CanSeek},{stream.CanTimeout}");
            Console.WriteLine($"{stream.Length}{stream.Position}");
            if (stream.CanTimeout)
            {
                Console.WriteLine($"read timeout:{stream.ReadTimeout}{stream.WriteTimeout}");
            }
        }

        private static Encoding GetEncoding(Stream stream)
        {
            if (!stream.CanSeek) throw new ArgumentException("空查找");
            Encoding encoding = Encoding.ASCII;
            byte[] bom = new byte[5];
            int nRead = stream.Read(bom, 0, 5);
            if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0)
            {
                Console.WriteLine("UTF-32");
                stream.Seek(4, SeekOrigin.Begin);
                return Encoding.UTF32;
            }
            else if (bom[0] == 0xff && bom[1] == 0xfe)
            {
                WriteLine("UTF-16");
                stream.Seek(2, SeekOrigin.Begin);
                return Encoding.Unicode;
            }
            else if (bom[0] == 0xfe && bom[1] == 0xff)
            {
                WriteLine("UTF-16,big endian");
                stream.Seek(2, SeekOrigin.Begin);
                return Encoding.BigEndianUnicode;
            }
            else if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
            {
                WriteLine("UTF-8");
                stream.Seek(3, SeekOrigin.Begin);
                return Encoding.UTF8;
            }
            stream.Seek(0, SeekOrigin.Begin);
            return encoding;
        }

        public static void ReadFileUSFileStream(string fileName)
        {
            const int BUFFERSIZE = 256;
            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Encoding encoding = GetEncoding(stream);
                byte[] buffer = new byte[BUFFERSIZE];
                bool completed = false;
                do
                {
                    int nread = stream.Read(buffer, 0, BUFFERSIZE);
                    if (nread == 0) completed = true;
                    if (nread < BUFFERSIZE)
                    {
                        Array.Clear(buffer, nread, BUFFERSIZE - nread);
                    }
                    string s = encoding.GetString(buffer, 0, nread);
                    WriteLine($"read {nread} bytes");
                    WriteLine();
                } while (!completed);

            }
        }



    }
}
