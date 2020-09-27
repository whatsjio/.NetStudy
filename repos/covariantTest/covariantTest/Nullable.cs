using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covariantTest
{
    public struct Nullable<T> where T:struct
    {
        public Nullable(T value)
        {
            _value = value;
            _hasvalue = true;
        }
        private bool _hasvalue;
        public bool HasValue => _hasvalue;
        private T _value;
        public T Value {
            get {
                if (!_hasvalue) {
                    throw new InvalidOperationException("no value");
                }
                return _value;
            }

        }
        void Swap<T>(ref T x, ref T y) {
            T temple = default(T);
            temple = x;
            x = y;
            y = temple;
            List<string> a = new List<string>();
            a.Add("sd");
        }
        public static T2 Accmulate<T1, T2>(IEnumerable<T1> source, Func<T1, T2, T2> func) {
            T2 sum = default(T2);
            foreach (T1 item in source)
            {
                sum = func(item, sum);
            }
            return sum;
        }

    }
}
