using System;

namespace ComprehensionDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPerson aPerson = new PersonAtHome();
            //aPerson.DoWork();
            //IPerson bPerson = new PersonAtSchool();
            //bPerson.DoWork();
            //Console.WriteLine("Hello World!");

            Bird bird = new Chicken();
            bird.ShowType();
            Chicken chicken = new Chicken();
            chicken.ShowType();
        }
    }
}
