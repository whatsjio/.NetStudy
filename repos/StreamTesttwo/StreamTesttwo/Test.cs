using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StreamTesttwo
{
    class Test
    {
        //public void ReadFileUsingFileStream(string fileName) {
        //    const int bufferSize = 4096;
        //    using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read,FileShare.Read))
        //    {
        //        Encoding encoding = GetEncoding(asd);
        //    }
        //    using (FileStream stream=File.OpenRead())
        //    {

        //    }
        //}

        public static void t1s(object a,string b) {
          
             

        }
        public static void ReadFileUsingFileStream(string fileName) {
            const int buffersize = 256;
            using (var stream=new FileStream(fileName,FileMode.Open,FileAccess.Read,FileShare.Read))
            {
                byte[] buffer = new byte[buffersize];
                bool completed = false;
                do
                {
                    int nread = stream.Read(buffer, 0, buffersize);
                    if (nread == 0) completed = true;
                    if (nread<buffersize)
                    {
                        Array.Clear(buffer, nread, buffersize - nread);
                    }
                    var decodermodel = Encoding.UTF8.GetDecoder();
                    var charlength = decodermodel.GetCharCount(buffer, 0, buffer.Length);
                    char[] yes = new char[charlength];
                    var s = decodermodel.GetChars(buffer, 0, buffer.Length, yes, 0);
                    Console.WriteLine(new string(yes));
                } while (!completed);
            }
            
        }

        /// <summary>
        /// 写入流
        /// </summary>
        public static void WriteTextFile()
        {
            string tempTextFileName = Path.ChangeExtension(Path.GetTempFileName(), "txt");
            using (FileStream stream=File.OpenWrite(tempTextFileName))
            {
                //获取所用编码的字节序列
                byte[] preamble = Encoding.UTF8.GetPreamble();
                stream.Write(preamble, 0, preamble.Length);
                string hello = "Hello World ✌很ok";
                byte[] buffer = Encoding.UTF8.GetBytes(hello);
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine($"文件{stream.Name} 写入完成");
            }
        }

        public static void CopyUsingStream(string inputFile, string outputFile)
        {
            const int BUFFERSIZE = 4096;
            using (var inputstream = File.OpenRead(inputFile))
            using (var outputStream = File.OpenWrite(outputFile))
            {
                byte[] buffer = new byte[BUFFERSIZE];
                bool completed = false;
                do
                {
                    int nRead = inputstream.Read(buffer, 0, BUFFERSIZE);
                    if (nRead == 0) completed = true;
                    outputStream.Write(buffer, 0, nRead);
                } while (completed);
            }

        }

        public static void CopyUsingStream2(string inputfile, string outputFile) {
            using (var inputStream = File.OpenRead(inputfile))
            using (var outputStream=File.OpenWrite(outputFile))
            {
                inputStream.CopyTo(outputStream);
            }
        }

        const string SampleFilePath = "./sample.data";
        public static async Task CreateSampleFile(int nrecords) {
            FileStream stream = File.Create(SampleFilePath);
            using (var write=new StreamWriter(stream))
            {
                var r = new Random();
                var records = Enumerable.Range(0, nrecords).Select(x => new
                {
                    Number = x,
                    Text = $"Sample text {r.Next(200)}",
                    Date = new DateTime(Math.Abs((long)(r.NextDouble() * 2 - 1) * DateTime.MaxValue.Ticks))
                });
                foreach (var rec in records)
                {
                    string date = rec.Date.ToString("d", CultureInfo.InvariantCulture);
                    string s = $"#{rec.Number,8};{rec.Text,-20};{date}#{Environment.NewLine}";
                    await write.WriteAsync(s).ConfigureAwait(false);
                }
            }
        }

        public static void RandAccessSample() {
            try
            {
                using (FileStream stream=File.OpenRead(SampleFilePath))
                {
                    byte[] buffer = new byte[4098];
                    do
                    {
                        try
                        {
                            Console.Write("recoder number(or 'byte' to end):");
                            string line = ReadLine();
                            if (line.ToUpper().CompareTo("BYTE") == 0) break;
                            int record;
                            if (int.TryParse(line,out record))
                            {
                                stream.Seek((record - 1) * 4098, SeekOrigin.Begin);
                                stream.Read(buffer, 0, 4098);
                                string s = Encoding.UTF8.GetString(buffer);
                                WriteLine($"record:{s}");
                            }

                        }
                        catch (Exception ex)
                        {

                            WriteLine(ex.Message);
                        }

                    } while (true);
                }
            }
            catch (FileNotFoundException)
            {
                WriteLine("请先创建文件来读取");
            }
        }

        public static void ReadFileUsingReader(string filename) {
            var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            using (var reader=new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    WriteLine(line);
                }
            }
            //var reader = new StreamReader(stream, detectEncodingFromByteOrderMarks: true);
            //var reader = new StreamReader(stream, Encoding.Unicode);

        }

        public static void WriteFIleUsingWriter(string fileName, string lines) {
            var outputStream = File.OpenWrite(fileName);
            using (var writer=new StreamWriter(outputStream))
            {
                byte[] preamble = Encoding.UTF8.GetPreamble();
                outputStream.Write(preamble, 0, preamble.Length);
                writer.Write(lines);
            }
        }

        /// <summary>
        /// 写入二进制流
        /// </summary>
        /// <param name="binFile"></param>
        public static void WriteFileUsingBinaryWriter(string binFile) {
            var outputStream = File.Create(binFile);
            using (var writer=new BinaryWriter(outputStream))
            {
                double d = 47.47;
                int i = 42;
                long l = 987654321;
                string s = "sample";
                writer.Write(d);
                writer.Write(i);
                writer.Write(l);
                writer.Write(s);
            }
        }

        /// <summary>
        /// 读取二进制流
        /// </summary>
        /// <param name="binFile"></param>
        public static void ReadFileUsingBinaryReader(string binFile) {
            var inputStream = File.Open(binFile, FileMode.Open);
            using (var reader=new BinaryReader(inputStream))
            {
                double d = reader.ReadDouble();
                int i = reader.ReadInt32();
                long l = reader.ReadInt64();
                string s = reader.ReadString();
                WriteLine($"d:{d},i:{i},l:{l},s:{s}");
            }
        }

        /// <summary>
        /// 压缩流
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="compressedFileName"></param>
        public static void CompressFile(string fileName, string compressedFileName) {
            using (FileStream inputStream=File.OpenRead(fileName))
            {
                FileStream outputStream = File.OpenWrite(compressedFileName);
                using (var compressStream=new DeflateStream(outputStream,CompressionMode.Compress))
                {
                    inputStream.CopyTo(compressStream);
                }
            }
        }

        /// <summary>
        /// 解压流
        /// </summary>
        /// <param name="fileName"></param>
        public static void DecompressFile(string fileName) {
            FileStream inputStream = File.OpenRead(fileName);
            using (MemoryStream outputStream = new MemoryStream())
            using (var compressStream=new DeflateStream(inputStream,CompressionMode.Decompress))
            {
                compressStream.CopyTo(outputStream);
                outputStream.Seek(0, SeekOrigin.Begin);
                using (var reader=new StreamReader(outputStream,Encoding.UTF8,detectEncodingFromByteOrderMarks:true,bufferSize:4096,leaveOpen:true))
                {
                    string result = reader.ReadToEnd();
                    WriteLine(result);
                }
            }
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="zipFile"></param>
        public static void CreateZIpFile(string directory, string zipFile) {
            FileStream zipStream = File.OpenWrite(zipFile);
            using (var archive=new ZipArchive(zipStream,ZipArchiveMode.Create))
            {
                IEnumerable<string> files = Directory.EnumerateFiles(directory, "*", SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    if (file.Equals(zipFile)) continue;
                    ZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(file));
                    using (FileStream inputstream = File.OpenRead(file))
                    using (Stream outputStream=entry.Open())
                    {
                        inputstream.CopyTo(outputStream);
                    }
                }
            }
        }
        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="zipFile"></param>
        /// <param name="florepath"></param>
        public static void DepressFile(string zipFile,string florepath) {
            DirectoryInfo directoryInfo = new DirectoryInfo(florepath);
            if (!directoryInfo.Exists) directoryInfo.Create();

            FileStream zipStream = File.OpenRead(zipFile);
            using (ZipArchive archive= new ZipArchive(zipStream,ZipArchiveMode.Read))
            {
                foreach (var entry in archive.Entries)
                {
                    var filepath = florepath + @"\" + entry.Name;
                    entry.ExtractToFile(filepath);
                }
                var tenet = "asdasd";



            }
        }

        /// <summary>
        /// 观察文件的更改
        /// </summary>
        /// <param name="path"></param>
        /// <param name="filter"></param>
        public static void WatchFiles(string path, string filter) {
            var watcher = new FileSystemWatcher(path, filter)
            {
                IncludeSubdirectories=true
            };
            watcher.Created += OnFileChanged;
            watcher.Changed += OnFileChanged;
            watcher.Deleted += OnFileChanged;
            watcher.Renamed += OnFileChanged;
            watcher.EnableRaisingEvents = true;
            WriteLine("正在监听文件的改动....");
        }

        private static void OnFileChanged(object sender, FileSystemEventArgs e) {
            WriteLine($"file:{e.Name}{e.ChangeType}");
        }

        private static void OnFileRenamed(object sender, RenamedEventArgs e) {
            WriteLine($"file{e.OldName}{e.ChangeType}to {e.Name}");
        }

    }
}
