using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStudy
{
    class datetimeindex
    {
        public IEnumerable<string> this[DateTime dateTime] {
            get {
                return new List<string>();
            }
        }

    }
}
