using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariantTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //GGSMD();
            //GGSMD("dsd", "sdsd");
            //var a = new string[] { "sd", "df" };
            //GGSMD(a);
            //int[] myArry = new int[3];
            //int[] myarry = { 1, 2, 3, 4 };
            //Person[] people = new Person[2];
            //people[0] = new Person()
            //{
            //    FirstName = "weq",
            //    LastName = "we"
            //};
            //people[1] = new Person()
            //{
            //    FirstName = "a",
            //    LastName = "b"
            //};
            //int[,] twodim = new int[3, 3];
            //twodim[0, 0] = 1;
            //twodim[0, 1] = 2;
            //twodim[0, 2] = 3;
            //twodim[1, 0] = 4;
            //int[,] p = {
            //    { 1, 2, 3 },
            //    { 4, 5, 6 },
            //    { 7, 8, 9 }
            //};
            //int[,] twoarrary = p;
            //int[][] jagged = new int[3][];
            //jagged[0] = new int[2] { 1, 2 };
            //jagged[1] = new int[6] { 1, 2,3,4,5,6 };
            //jagged[2] = new int[3] { 9, 10,11 };
            //for (int i = 0; i < jagged.Length; i++)
            //{
            //    for (int j = 0; j < jagged[i].Length; j++)
            //    {

            //    }
            //}
            //Array intarrary1 = Array.CreateInstance(typeof(int), 5);
            //for (int i = 0; i < intarrary1.Length; i++)
            //{
            //    intarrary1.SetValue(33, i);
            //}
            //for (int i = 0; i < intarrary1.Length; i++)
            //{
            //    intarrary1.GetValue(i);
            //}
            //int[] jiojio = { 3, 4, 5 };
            //Person[] persons = {
            //    new Person{ FirstName="a",LastName="b" },
            //    new Person{ FirstName="c",LastName="d" },
            //    null,
            //    new Person{ FirstName="g",LastName="h" },
            //    new Person{ FirstName="i",LastName="j" },
            //};
            //Array.Sort(persons,new Person(PersonConpareType.FirstName));
            int[] arr1 = { 1, 4, 5, 22, 67, 89 };
            int[] arr2 = { 3, 4, 5, 8, 21 };
            var segment = new ArraySegment<int>(arr1, 0, 3);
            var segments = new ArraySegment<int>(arr1, 3, 3);
            var a= segments.Array;
        }
        public static void Foo<T>(T obj) {
            Console.WriteLine($"Foo<T> type:{obj.GetType().Name}");
        }
        public static void Foo(int x) {
            Console.WriteLine($"Foo(int x)");
        }
        public static void Foo<T1,T2>(T1 x,T2 y)
        {
            Console.WriteLine($"Foo<T1,T2>(T1 x,T2 y) type: x:{x.GetType().Name} y:{y.GetType().Name}");
        }
        public static void Foo<T2>(int x, T2 y)
        {
            Console.WriteLine($"Foo<T1,T2>(T1 x,T2 y) type: x:{x.GetType().Name} ");
        }
        public static void GGSMD(params string[] dsd) {
            var a = dsd.Length;
            if (dsd==null)
            {

            }
        }

    }
}
