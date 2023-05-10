using System;

namespace AnimalPerspective
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = new Animal[10];
            Random rd = new Random();

            // Populate the animals array with random animals
            for (int i = 0; i < animals.Length; i++)
            {
                int animalType = rd.Next(4); // Generate a random number from 0 to 3
                switch (animalType)
                {
                    case 0:
                        animals[i] = new Dog();
                        break;
                    case 1:
                        animals[i] = new Cat();
                        break;
                    case 2:
                        animals[i] = new Bat();
                        break;
                    case 3:
                        animals[i] = new Bee();
                        break;
                }
            }

            // Print out the information for each animal
            for (int i = 0; i < animals.Length; i++)
            {
                Console.WriteLine("Animal: " + (i + 1) + " ---> " + animals[i].Sound());
                if (animals[i] is IMammal)
                {
                    IMammal mammal = (IMammal)animals[i];
                    Console.WriteLine("Number of nipples: " + mammal.NumberOfNipples);
                }
                if (animals[i] is ICanFly)
                {
                    ICanFly canFly = (ICanFly)animals[i];
                    Console.WriteLine("Number of wings: " + canFly.NumberOfWings);
                }
                Console.WriteLine();
            }
        }
    }

    public abstract class Animal
    {
        public abstract string Sound();
    }

    public class Dog : Animal, IMammal
    {
        public int NumberOfNipples { get { return 8; } }
        public override string Sound()
        {
            return "Woof!";
        }
    }

    public class Cat : Animal, IMammal
    {
        public int NumberOfNipples { get { return 6; } }
        public override string Sound()
        {
            return "Miau";
        }
    }

    public class Bat : Animal, IMammal, ICanFly
    {
        public int NumberOfNipples { get { return 4; } }
        public int NumberOfWings { get { return 2; } }
        public override string Sound()
        {
            return "VuVuVu";
        }
    }

    public class Bee : Animal, ICanFly
    {
        public int NumberOfWings { get { return 4; } }
        public override string Sound()
        {
            return "ZzzzzzzzzzzzzzzzZ";
        }
    }

    public interface IMammal
    {
        int NumberOfNipples { get; }
    }

    public interface ICanFly
    {
        int NumberOfWings { get; }
    }
}
