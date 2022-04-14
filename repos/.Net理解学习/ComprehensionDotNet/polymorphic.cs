using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ComprehensionDotNet
{
    /// <summary>
    /// 多态例子
    /// </summary>
    class polymorphic
    {
    }

    enum FileType
    {
        doc,
        pdf,
        txt,
        ppt,
        jpg,
        gif,
        mp3,
        avi
    }

    class Files
    {
        private FileType fileType;

        public FileType FileType
        {
            get { return fileType; }
        }
    }

    class FileManager
    {
        public void OpenDocFIle()
        {
            Console.WriteLine("Alibaba Open File World");
        }

        public void OpenPdfFile()
        {
            Console.WriteLine("Alibaba Open File Pdf");
        }

        public void OpenJpgFile()
        {
            Console.WriteLine("Alibaba Open File JpgFile");
        }

        public void OpenMp3File()
        {
            Console.WriteLine("Alibaba Open File Mp3File");
        }
    }

    class polymorphicclient
    {
        void start()
        {
            FileManager fileManager = new FileManager();
            IList<Files> files = new List<Files>();
            foreach (var filetypemodel in files)
            {
                switch (filetypemodel.FileType)
                {
                    case FileType.doc:
                        fileManager.OpenDocFIle();
                        break;
                    case FileType.pdf:
                        fileManager.OpenPdfFile();
                        break;
                    case FileType.jpg:
                        fileManager.OpenJpgFile();
                        break;
                }
            }

        }
    }



    interface IFileOpen
    {
        void Open();
    }

    abstract class CommonFiles : IFileOpen
    {
        private FileType fileType;

        public FileType FileType
        {

            get { return fileType; }
        }
        public abstract void Open();
    }


    /// <summary>
    /// Doc类文档
    /// </summary>
    abstract class DocFile : CommonFiles
    {
        public int GetPageCount()
        {
            throw new NotImplementedException();
        }
    }

    abstract class ImageFile : CommonFiles
    {
        public void ZoomIn()
        {
            //放大比例
        }

        public void ZoomOut()
        {
            //缩小比例
        }
    }

    class WORDFIle:DocFile
    {
        public override void Open()
        {
            Console.WriteLine("Open the WORD file");
        }
    }

    abstract class MediaFile:CommonFiles
    {
        
    }

    class MPEGFIle : MediaFile
    {
        public override void Open()
        {
            Console.WriteLine("Open the MPEG file.");
        }
    }

    class LoadManager
    {
        private IList<CommonFiles> files = new List<CommonFiles>();

        public IList<CommonFiles> Files => files;

        /// <summary>
        /// 加入文件
        /// </summary>
        /// <param name="file"></param>
        public void LoadFiles(CommonFiles file)
        {
            files.Add(file);
        }

        /// <summary>
        /// 打开全部
        /// </summary>
        public void OpenAllFiles()
        {
            foreach (IFileOpen file in files)
            {
                file.Open();
            }
        }

        public void OpenFIle(IFileOpen file)
        {
            file.Open();
        }

        public FileType GetFileType(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            return (FileType)Enum.Parse(typeof(FileType), fi.Extension);
        }

    }

    class FileClient
    {
        public static void StartMain()
        {
            CommonFiles ad = new WORDFIle();

            LoadManager lm = new LoadManager();
            //添加处理文件
            lm.LoadFiles(new WORDFIle());
            lm.LoadFiles(new MPEGFIle());
            foreach (var file in lm.Files)
            {
                file.Open();
            }

        }

    }



}
