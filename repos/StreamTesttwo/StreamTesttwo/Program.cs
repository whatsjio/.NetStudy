using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Threading;
using static System.Console;

namespace StreamTesttwo
{
    class Program
    {
        private static ManualResetEventSlim _mapCreated = new ManualResetEventSlim(initialState: false);
        private static ManualResetEventSlim _dataWrittrnEvent = new ManualResetEventSlim(initialState: false);
        private const string MAPNAME = "SampleMap";

        static void Main(string[] args)
        {
            //Test.ReadFileUsingFileStream(@"D:\小石头.txt");
            //Test.WriteTextFile();
            //Test.CopyUsingStream2(@"D:\小石头.txt", @"D:\复制的小石头.txt");
            //Task.Run(async () => { await Test.CreateSampleFile(100000); }).Wait();
            //var a = new string[] { "新增字符" };
            //Test.WriteFIleUsingWriter(@"D:\小石头新写入.txt", "新增字符");
            //Test.WriteFileUsingBinaryWriter(@"D:\二进制小石头新写入.bin");
            //Test.CompressFile(@"D:\小石头.txt", @"D:\压缩写入.txt");
            //Test.DecompressFile(@"D:\压缩写入.txt");
            //Test.CreateZIpFile(@"D:\APTest", @"D:\APTest\qw.Zip");
            //Test.WatchFiles(@"D:\APTest", @"*.txt");

            //Console.ReadKey();
            Task.Run(() => WriterAsync());
            Task.Run(() => Reader());
            Console.WriteLine("tasks started");
            Console.ReadLine();
        }

        private static async Task WriterAsync() {
            try
            {
                using (MemoryMappedFile mappedFile=MemoryMappedFile.CreateOrOpen(MAPNAME,10000))
                {
                    _mapCreated.Set();
                    WriteLine("共享内存已创建和发送信号");
                    using (MemoryMappedViewAccessor accessor= mappedFile.CreateViewAccessor(0,10000,MemoryMappedFileAccess.Write))
                    {
                        for (int i = 0,pos=0; i < 100; i++,pos+=4)
                        {
                            accessor.Write(pos, i);
                            WriteLine($"written{i} at position{pos}");
                            await Task.Delay(10);
                        }
                        _dataWrittrnEvent.Set();
                    }
                }
            }
            catch (Exception ex)
            {

                WriteLine($"writer{ex.Message}");
            }
        }

        private static void Reader() {
            try
            {
                WriteLine("reader");
                _mapCreated.Wait();
                WriteLine("reader starting");
                using (MemoryMappedFile mappedFile =MemoryMappedFile.OpenExisting(MAPNAME,MemoryMappedFileRights.Read))
                {
                    using (MemoryMappedViewAccessor accessor=mappedFile.CreateViewAccessor(0,10000,MemoryMappedFileAccess.Read))
                    {
                        _dataWrittrnEvent.Wait();
                        WriteLine("reading can start now");
                        for (int i = 0; i < 400; i+=4)
                        {
                            int result = accessor.ReadInt32(i);
                            WriteLine($"reading {result} from position{i}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                WriteLine($"reader {ex.Message}");
            }

        }

        private async Task WriterUsingStreams() {
            try
            {
                using (MemoryMappedFile mappedFile=MemoryMappedFile.CreateOrOpen(MAPNAME,10000,MemoryMappedFileAccess.ReadWrite))
                {
                    _mapCreated.Set();
                    WriteLine("shared memory segment created");
                    MemoryMappedViewStream stream = mappedFile.CreateViewStream(0, 10000, MemoryMappedFileAccess.Write);
                    using (var writer=new StreamWriter(stream))
                    {
                        writer.AutoFlush = true;
                        for (int i = 0; i < 100; i++)
                        {
                            string s = $"some data{i}";
                            WriteLine($"writing{s} at {stream.Position}");
                            await writer.WriteLineAsync(s);
                        }
                    }
                    _dataWrittrnEvent.Set();
                    WriteLine("data written");
                }
            }
            catch (Exception ex)
            {

                WriteLine($"writer {ex.Message}");
            }
        }

        private async Task ReaderUsingStreams() {
            try
            {
                WriteLine("reader");
                _mapCreated.Wait();
                WriteLine("reader starting");
                using (MemoryMappedFile mappedFile =MemoryMappedFile.OpenExisting(MAPNAME,MemoryMappedFileRights.Read))
                {
                    MemoryMappedViewStream stream = mappedFile.CreateViewStream(0, 10000, MemoryMappedFileAccess.Read);
                    using (var reader=new StreamReader(stream))
                    {
                        _dataWrittrnEvent.Wait();
                        WriteLine($"reading can start now");
                        for (int i = 0; i < 100; i++)
                        {
                            long pos = stream.Position;
                            string s = await reader.ReadLineAsync();
                            WriteLine($"read{s} from {pos}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                WriteLine($"reader {ex.Message}");
            }

        }
    }
}
