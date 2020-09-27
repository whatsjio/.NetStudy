using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Start255
{
    public class PersonCollection
    {
        private Person[] _people;
        public PersonCollection(params Person[] people)
        {
            _people = people;
        }
        public Person this[int index] {
            get { return _people[index]; }
            set { _people[index] = value; }
        }
        public IEnumerable<Person> this[DateTime dateTime]=> _people.Where(t => t.Birthday == dateTime);
    }
}
