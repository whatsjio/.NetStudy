using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgram
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field| AttributeTargets.Class, AllowMultiple =false,Inherited =false)]
    class Myattrbute:Attribute
    {
        public string Comment { get; set; }
        private string _fileName;
        public Myattrbute(string fileName)
        {
            _fileName = fileName;
        }
    }
}
