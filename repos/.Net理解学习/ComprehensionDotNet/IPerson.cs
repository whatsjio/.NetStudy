using System;
using System.Collections.Generic;
using System.Text;

namespace ComprehensionDotNet
{
    interface IPerson
    {
        string Name { get; set; }

        int Age { get; set; }

        void DoWork();
    }

    class PersonAtHome: IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }

    class PersonAtSchool: IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }

    class PersonOnBus: IPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
