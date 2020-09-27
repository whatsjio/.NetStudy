using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileNames = new BlockingCollection<string>();
            var lines = new BlockingCollection<string>();
            var words = new ConcurrentDictionary<string, int>();
            var items = new BlockingCollection<Info>();
            var coloredItems = new BlockingCollection<Info>();
        }

        private static async void StartPipeline() {
           
        }
    }
}
