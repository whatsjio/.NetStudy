using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DynamicProgram;
[assembly: SupportsWhatsNewAttribute]
namespace DynamicProgram
{
    [LastModified("5 jun 2017", "jiojiopi", Issues = "sdsd")]
    [LastModified("5 jun 2015","jiojiopi",Issues ="sdsd")]
    public class Vector : IFormattable, IEnumerable<string>
    {
        public Vector(double x, double y, double z)
        {
            //Type t = typeof(double);
            //t.GetMethods()
            
        }
        public Vector(Vector vector) : this(vector.X, vector.Y, vector.Z)
        {

        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public IEnumerator<string> GetEnumerator() {
            yield return "1";
            yield return "2";
            yield return "3";
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string ToString(string format, IFormatProvider formatProvider) {
            return "qw3";
        }
    }
}
