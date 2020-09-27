using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Runtime.CompilerServices;
namespace ErroAndExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    try
            //    {
            //        string userInput;
            //        WriteLine("输入一个0到5的数，否则将退出");
            //        userInput = ReadLine();
            //        if (string.IsNullOrEmpty(userInput))
            //        {
            //            break;
            //        }
            //        int index = Convert.ToInt32(userInput);
            //        if (index < 0 || index > 5)
            //        {
            //            throw new IndexOutOfRangeException($"你输入的是{userInput}");
            //        }
            //        WriteLine($"你输入的是{userInput}");

            //    }
            //    catch (IndexOutOfRangeException ex)
            //    {
            //        WriteLine("Expertion:" + ex.Message);
            //    }
            //    catch (Exception e)
            //    {
            //        WriteLine($"An exception was thrown :{e.Message}");
            //    }
            //    finally {
            //        WriteLine("谢谢");
            //    }
            //}
            //try
            //{
            //    ThrowWidthErrorCode(405);
            //}
            //catch (MyExpression ex) when (ex.Errorcode == 402)
            //{

            //    WriteLine("自定义异常生效了");
            //}
            //catch (Exception ec) {
            //    WriteLine("我来处理非402异常");
            //}
            var p = new Program();
            p.Log();
            ReadKey();
        }

        public void Log([CallerLineNumber] int line = -1, [CallerFilePath] string path = null, [CallerMemberName] string name = null) {
            WriteLine(line < 0 ? "no line" : "Line:" + line);
            WriteLine(path ==null  ? "no patch" : "patch:" + path);
            WriteLine(name == null ? "no name" : "name:" + name);
        }

        public static void ThrowWidthErrorCode(int code) {
            throw new MyExpression(code);
        }

    }
}
