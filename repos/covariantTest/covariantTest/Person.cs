using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariantTest
{
    public class Person:IComparer<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() => $"{FirstName + LastName}";
        private PersonConpareType _personConpareType;
        public Person(PersonConpareType personConpareType)
        {
            _personConpareType = personConpareType;
        }
        public Person()
        {

        }
        public int Compare(Person x, Person y) {
            if (x==null&&y==null)
            {
                return 0;
            }
            if (x==null)
            {
                return 1;
            }
            if (y==null)
            {
                return -1;
            }
            switch (_personConpareType)
            {
                case PersonConpareType.FirstName:
                    return string.Compare(x.FirstName, y.FirstName);
                case PersonConpareType.LastName:
                    return string.Compare(x.LastName, y.LastName);
                default:
                    return string.Compare(x.FirstName, y.FirstName);
            }
            
        }
        static int SumOfSegments(ArraySegment<int>[] segment) {
            int sum = 0;
            foreach (var item in segment)
            {
                for (int i = item.Offset; i < item.Offset+ item.Count; i++)
                {
                    sum += item.Array[i];
                }
            }
            return sum;

        }
        //public int CompareTo(Person other) {
        //    if (other==null)
        //    {
        //        return 1;
        //    }
        //    int result = string.Compare(this.LastName, other.LastName);
        //    if (result==0)
        //    {
        //        result = string.Compare(this.FirstName, other.FirstName);
        //    }
        //    return result;
        //}


    }

    public enum PersonConpareType {
        FirstName,
        LastName
    }
}
