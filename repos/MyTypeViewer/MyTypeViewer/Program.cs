using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm;
            asm = Assembly.Load("345");
        }

        /// <summary>
        /// 反射方法
        /// </summary>
        /// <param name="t"></param>
        static void ListMethods(Type t) {
            Console.WriteLine("*****");
            var mi = t.GetMethods();
            foreach (var item in mi)
            {
                Console.WriteLine("->{0}",item.Name);
            }
            Console.ReadLine();
        }

        static void CreateUsingLateBinding(Assembly asm) {
            try
            {
                Type miniVan = asm.GetType("1234");
                object obj = Activator.CreateInstance(miniVan);
            }
            catch (Exception)
            {

                throw;
            }


        }


        /// <summary>
        /// 反射属性
        /// </summary>
        /// <param name="t"></param>
        static void ListProps(Type t)
        {
            Console.WriteLine("*****");

            var porpNames = from p in t.GetProperties() select p.Name;
            //var mi = t.GetMethods();
            foreach (var item in porpNames)
            {
                Console.WriteLine("->{0}", item);
            }
            Console.ReadLine();
        }

        static void DisplayTypesInAsm(Assembly asm) {
            Type[] types = asm.GetTypes();
            foreach (var item in types)
            {

            }

        }


        /// <summary>
        /// 反射接口
        /// </summary>
        /// <param name="t"></param>
        //static void ListInterfaces(Type t) {
        //    Console.WriteLine("*****");
        //    var ifaces = from i in t.GetInterface() select i;



        //}

    }
}
