using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    class Program
    {
        static void Main(string[] args)
        {
            //var names = new List<string> { "Nino", "Alberto", "Juan", "Mike", "Phil" };
            //var namesWithJ = from n in names where n.StartsWith("J") orderby n select n;
            //foreach (var item in namesWithJ)
            //{
            //    Console.WriteLine(item);
            //}
            var aa = (from jiojio in SampleData().AsParallel() where Math.Log(jiojio) < 4 select jiojio).Average();
            var bb = (from jiojio in Partitioner.Create(SampleData().ToList(),true).AsParallel() where Math.Log(jiojio) < 4 select jiojio).Average();
           
            Console.ReadLine();
        }
        static IEnumerable<int> SampleData() {
            const int arraySize = 50000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(n => r.Next(140)).ToList();
        }
    }
}
