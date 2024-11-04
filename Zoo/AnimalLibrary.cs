using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hayvanatbahcesi
{
    internal class AnimalLibrary
    {
        static List<Dog> dogs = new List<Dog>();
        static List<Bird> birds = new List<Bird>();
        static List<Monkey> monkeys = new List<Monkey>();
        public Animal getanimal { get; set; }

        public void Getanimal(Animal a)
        {
            getanimal = a;
        }
        public void AnimalAdd()
        {
            if (getanimal is Dog dog)
            {
                dogs.Add(dog);
                Console.WriteLine("*****New dog of dog list  is added*****");
            }
            else if (getanimal is Bird bird)
            {
                birds.Add(bird);
                Console.WriteLine("*****New bird of bird list is added*****");
            }
            else if (getanimal is Monkey monkey)
            {
                monkeys.Add(monkey);
                Console.WriteLine("*****New monkey of monkey list is added*****");
            }
        }
        public static void AllAnimalShow()
        {
            if (dogs.Count == 0 && birds.Count == 0 && monkeys.Count == 0)
            {
                Console.WriteLine("WARNING: No animals in the list.");
            }
            else
            {
                Console.WriteLine("\n************ ALL ANIMALS IN THE ZOO ************");
                if(dogs != null)
                {
                    Console.WriteLine("Dogs in the zoo: ");
                    foreach (Dog dog in dogs)
                    {
                        Console.WriteLine("Dog Name: {0}, Age: {1}, Legs: {2}, Color: {3}", dog.Name, dog.Age, dog.Legs, dog.Dogcolor);
                    }
                }
                if(birds != null)
                {
                    Console.WriteLine("\nBirds in the zoo: ");
                    foreach (Bird bird in birds)
                    {
                        Console.WriteLine("Bird Name: {0}, Age: {1}, Legs: {2}, Color: {3}", bird.Name, bird.Age, bird.Legs, bird.Birdcolor);
                    }
                }
                if(monkeys != null)
                {
                    Console.WriteLine("\nMonkeys in the zoo: ");
                    foreach (Monkey monkey in monkeys)
                    {
                        Console.WriteLine("Monkey Name: {0}, Age: {1}, Legs: {2}, Color: {3}, Taillegth: {4}cm", monkey.Name, monkey.Age, monkey.Legs, monkey.Monkeycolor, monkey.Taillength);
                    }
                }
            }
            
        }
        public void Doglibraryshow()
        {
            foreach (Dog dog in dogs)
            {
                Console.WriteLine("Dog Name: {0}, Age: {1}, Legs: {2}, Color: {3}", dog.Name, dog.Age, dog.Legs, dog.Dogcolor);
            }
        }

    }
}
