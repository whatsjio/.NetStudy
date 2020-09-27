using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace HashStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            //var Beckham = new Person { Name = "beckham", Age = 21 };
            //var Kobe = new Person { Name = "Kobe", Age = 21 };
            //var footabllTeam = new List<TeamMember>
            //{
            //    new TeamMember{ Member=new Person{Name="nash",Age=21 } },
            //    new TeamMember{Member=Beckham}
            //};
            //var basketballTeam = new List<TeamMember> {
            //     new TeamMember{ Member=new Person{Name="nash",Age=21 } },
            //    new TeamMember{Member=Kobe}
            //};
            //Console.WriteLine($"足球队第一个和篮球队第一个是不同的引用对象所以==比较为{footabllTeam[0] == basketballTeam[0]}");
            //Console.WriteLine($"足球队第一个和篮球队第一个是不同的逻辑上是同一个人，也就是姓名相同所以结果为：{footabllTeam[0].Member.Equals(basketballTeam[0].Member)}");
            ////统计两个球队中的所有成员
            //var members = footabllTeam.Select(t => t.Member).Union(basketballTeam.Select(t => t.Member));

            //thash s = new thash();
            //thash b = new thash();

            //var c = s.Equals(b);
            //var d = s.GetHashCode();
            //var e = b.GetHashCode();
            //var j = s;
            //var g= j.Equals(s);
            //Console.WriteLine($"成员有{members.Count()}个");
            string a = "23";
            string b = "23";
            string c = a;
            string d = "sdsd";
            WriteLine($"a:{a.GetHashCode()}||b:{b.GetHashCode()}||c:{c.GetHashCode()}||d:{d.GetHashCode()}");
            Console.ReadLine();
        }
    }
}
