using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace SpecialCollection
{
    class Program
    {
        private static readonly object ImmutableArray;

        static void Main(string[] args)
        {
            //var bitsl = new BitArray(8);

            //bitsl.SetAll(true);
            //bitsl.Set(1, false);
            //bitsl[5] = false;
            //var bits2 = new BitArray(8);
            //bits2.SetAll(true);
            //bits2.Set(3, false);
            //bits2.Set(4, false);
            //bits2.Set(0, false);
            //bitsl.Xor(bits2);
            //bitsl.Length = 10;
            //BitVector32 aa=new BitVector32();
            //var b= aa.ToString();
            //var bitsl = new BitVector32();
            //var bits11= BitVector32.CreateMask();
            //var bits22= BitVector32.CreateMask(bits11);
            //bitsl[bits11] = true;
            //bitsl[bits22] = true;
            //var aa = bitsl.ToString();
           
        }
        public static void DisplayBits(BitArray bits) {
            foreach (bool item in bits)
            {
                WriteLine(item ? 1 : 0);
            }

        }
    }
}
