using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashStudy
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        //单纯逻辑判断相等，只需要重写Equals方法
        public override bool Equals(object obj)
        {
            return Name == (obj as Person).Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    /// <summary>
    /// 体育小组成员
    /// </summary>
    public class TeamMember {
        public Person Member { get; set; }
        public string Sport { get; set; } = "footabll";
    }
}
