using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Application
{
    internal class AnimalLibrary
    {
        static List<Dog> dogs = new List<Dog>();
        static List<Bird> birds = new List<Bird>();
        static List<Monkey> monkeys = new List<Monkey>();
        private static Animal Getanimal { get; set; }

        //ANIMAL ADD METHOD
        public static void AnimalAdd(Animal _getanimal)
        {

            Getanimal = _getanimal;
            if (Getanimal is Dog dog)
            {
                dogs.Add(dog);
                Console.WriteLine("\nDog was added to Doglist");
            }
            else if (Getanimal is Bird bird)
            {
                birds.Add(bird);
                Console.WriteLine("\nBird was added to Birdlist");
            }
            else if (Getanimal is Monkey monkey)
            {
                monkeys.Add(monkey);
                Console.WriteLine("\nMonkey was added to Monkeylist");
            }
        }
        //ANIMAL DELETE METHOD
        public static void AnimalDelete(int _animalnumber, string _whichanimal)
        {
            if (dogs.Count == 0 && birds.Count == 0 && monkeys.Count == 0)
            {
                Console.WriteLine("There are no animals in the zoo");
            }
            else
            {
                if (_whichanimal.ToLower() == "dog")
                {
                    if (_animalnumber <= dogs.Count)
                    {
                        dogs.RemoveAt(_animalnumber - 1);
                        Console.WriteLine("\nDog was deleted from dogs list");
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: Index number exceeded");
                    }

                }

                if (_whichanimal.ToLower() == "bird")
                {
                    if (_animalnumber <= birds.Count)
                    {
                        birds.RemoveAt(_animalnumber - 1);
                        Console.WriteLine("\nBird was deleted from birds list");
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: Index number exceeded");
                    }

                }

                if (_whichanimal.ToLower() == "monkey")
                {
                    if (_animalnumber <= monkeys.Count)
                    {
                        monkeys.RemoveAt(_animalnumber - 1);
                        Console.WriteLine("\nMonkey was deleted from monkeys list");
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: Index number exceeded");
                    }
                }

            }
        }


        //ANIMAL VIEW METHOD
        public static void AnimalView()
        {
            if (dogs.Count == 0 && birds.Count == 0 && monkeys.Count == 0)
            {
                Console.WriteLine("\nWARNING: There are no animals in the zoo!!!");
            }
            else
            {
                Console.WriteLine("\nDogs in the zoo:");
                if (dogs.Count > 0)
                {
                    for (int i = 0; i < dogs.Count; i++)
                    {
                        Dog dog = dogs[i];
                        Console.WriteLine($"{i + 1}. Dog's Name: {dog.Name}, Age: {dog.Age}, Color: {dog.Dogcolor}");
                    }
                }

                Console.WriteLine("\nbirds in the zoo:");
                if (birds.Count > 0)
                {
                    for (int i = 0; i < birds.Count; i++)
                    {
                        Bird bird = birds[i];
                        Console.WriteLine($"{i + 1}. Bird's Name: {bird.Name}, Age: {bird.Age}, Color: {bird.Birdcolor}");
                    }
                }

                Console.WriteLine("\nMonkeys in the zoo: ");
                if (monkeys.Count > 0)
                {
                    for (int i = 0; i < monkeys.Count; i++)
                    {
                        Monkey monkey = monkeys[i];
                        Console.WriteLine($"{i + 1}. Monkey's Name: {monkey.Name}, Age: {monkey.Age}, Color: {monkey.Monkeycolor}");
                    }
                }

            }
        }
        //ANIMAL SOUND METHOD
        public static void AnimalSound(string _soundname)
        {
            if (_soundname.ToLower() == "dog")
            {
                if (dogs.Count == 0)
                {
                    Console.WriteLine("\nThere is no a dog in the zoo");
                }
                else
                {
                    Dog.MakeSound();
                }
            }
            if (_soundname.ToLower() == "bird")
            {
                if (birds.Count == 0)
                {
                    Console.WriteLine("\nThere is no bird in the zoo");
                }
                else
                {
                    Bird.MakeSound();
                }
            }
            if (_soundname.ToLower() == "monkey")
            {
                if (monkeys.Count == 0)
                {
                    Console.WriteLine("\nThere is no monkey in the zoo");
                }
                else
                {
                    Monkey.MakeSound();
                }
            }
        }


    }
}
