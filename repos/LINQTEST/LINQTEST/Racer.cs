using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    class Racer:IComparable<Racer>,IFormattable
    {
        public Racer(string firstName,string lastName,string country,int starts,int wins):this(firstName,lastName,country,starts,wins,null,null)
        {

        }
        public Racer(string firstName,string lastName,string country,int starts,int wins,IEnumerable<int> years,IEnumerable<string> cars)
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wins { get; set; }
        public string Country { get; set; }
        public int Stars { get; set; }
        public IEnumerable<string> Cars { get;}
        public IEnumerable<int> Years { get;}
        public override string ToString() => $"{FirstName}{LastName}";
        public int CompareTo(Racer other) => LastName.CompareTo(other?.LastName);
        public string ToString(string format) => ToString(format, null);
        public string ToString(string format, IFormatProvider formatProvider) {
            switch (format)
            {
                case null:
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "C":
                    return Country;
                case "S":
                    return Stars.ToString();
                case "W":
                    return Wins.ToString();
                case "A":
                    return $"{FirstName}{LastName},{Country};starts:{Stars},wins{Wins}";
                default:
                    throw new FormatException($"Format {format} not supported");
            }
        }
    }
}
