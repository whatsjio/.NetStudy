using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document("F:/Visual2019/ConsoleApp2/bin/Debug/股权收益转让合同（取值版）.docx");
            doc.Range.Replace("ContractCode", "测试ContractCode");
            doc.Save("股权收益转让合同（取值替换版）.docx");

        }
    }
}
