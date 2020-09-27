using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using static System.Console;

namespace DynamicProgram
{
    class Program
    {
        private static StringBuilder OutputText = new StringBuilder();

        private const string CalculatorLibPath = @"C:\Users\MI\source\repos\DynamicProgram\DynamicProgram\bin\Debug\Calculator.dll";
        private const string CalculatorLibName = "Calculator";
        private const string CalculatorTypeName = "Calculator.Calculatorc";

        static void Main(string[] args)
        {
            //dynamic gh = GetCalculator();
            //var a=gh.Add(1, 2);
            //var staticPerson = new Person();
            dynamic dynamicperson = new Person();
            //staticPerson.GetFullName("sd", "sdsd");
            dynamicperson.GetFullName("sd", "dsd");

        }

        private static object GetCalculator() {
            Assembly assembly = Assembly.LoadFile(CalculatorLibPath);
            return assembly.CreateInstance(CalculatorTypeName);
        }
        static void AnalyzeType(Type t) {
            TypeInfo typeInfo = t.GetTypeInfo();
            AddtoOutput($"Type Name:{t.Name}");
            AddtoOutput($"Full Name:{t.FullName}");
            AddtoOutput($"Namespace:{t.Namespace}");
            Type tBase = t.BaseType;
            if (tBase!=null)
            {
                AddtoOutput($"Base Type:{tBase.Name}");
            }
            AddtoOutput("\npublic members:");
            foreach (MemberInfo nextMember in t.GetMembers())
            {
                AddtoOutput($"{nextMember.DeclaringType}||{nextMember.Name}");
              
            }
        }

        static void AddtoOutput(string Text) {
            OutputText.Append("\n" + Text);
        }
    }
    class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GetFullName() => $"{FirstName}{LastName}";

    }
}
