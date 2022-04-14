using System;

namespace CreateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            var dog= FactoryBuilder.Build("Dog");



        }
    }

    public abstract class Animal
    {
        public abstract void Show();
    }

    public class Dog : Animal
    {
        public override void Show()
        {
            Console.WriteLine("This is Dog");
        }
    }

    public class Cat : Animal
    {
        public override void Show()
        {
            Console.WriteLine("This is Cat");
        }
    }

    public class NormalCreation
    {
        public static void Main2()
        {
            Animal animal = new Dog();
        }
    }

    public interface IAnimalFactory<TAnimal>
    {
        TAnimal Create();
    }



    public class AnimalFactory<TAnimalBase, TAnimal> : IAnimalFactory<TAnimal> where TAnimal : TAnimalBase, new()
    {
        public TAnimal Create()
        {
            return new TAnimal();
        }
    }

    public class FactoryBuilder
    {
        public static IAnimalFactory<Animal> Build(string type)
        {
            if (type=="Dog")
            {
                return new AnimalFactory<Animal, Dog>() as IAnimalFactory<Animal>;
            }
            else if(type=="Cat")
            {
                return new AnimalFactory<Animal, Cat>() as IAnimalFactory<Animal>;
            }

            return null;
        }
    }

}
