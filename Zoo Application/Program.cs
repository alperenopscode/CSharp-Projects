using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool control = true;
            while (control)
            {
                var choiceResult = choice();

                switch (choiceResult)
                {
                    case "1":
                        MainAnimalAdd();
                        break;
                    case "2":
                        AnimalLibrary.AnimalView();
                        break;
                    case "3":
                        MainAnimalDelete();
                        break;
                    case "4":
                        MainAnimalSound();
                        break;
                    case "5":
                        Console.WriteLine("Please click ENTER button");
                        control = false;
                        break;
                    default:
                        Console.WriteLine("WARNING: Please use selection numbers");
                        break;
                }
            }

            Console.ReadLine();
        }

        private static string choice()
        {
            Console.WriteLine("\nWelcome to Zoo, Please enter the your choice");
            Console.WriteLine("1- Animal Add");
            Console.WriteLine("2- Animals view in the zoo");
            Console.WriteLine("3- Animal delete");
            Console.WriteLine("4- Animals sound");
            Console.WriteLine("5- Quit");

            Console.Write("\nYour Choice: ");
            string _Mchoice = Console.ReadLine();
            return _Mchoice;
        }
        //MAIN ANIMAL ADD METHOD
        private static void MainAnimalAdd()
        {
            Console.Write("Which animal do you want to enter: ");
            string animalName = Console.ReadLine();

            if (animalName.ToLower() == "dog")
            {
                Console.Write("What is the dog's name: ");
                string dogName = Console.ReadLine();
                Console.Write("How old is the dog: ");
                int dogAge = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is the dog's color: ");
                string dogColor = Console.ReadLine();

                var newdog = new Dog(dogName, dogAge, dogColor);
                AnimalLibrary.AnimalAdd(newdog);
            }
            else if (animalName.ToLower() == "bird")
            {
                Console.Write("What is the bird's name: ");
                string birdName = Console.ReadLine();
                Console.Write("How old is the bird: ");
                int birdAge = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is the bird's color: ");
                string birdColor = Console.ReadLine();

                var newbird = new Bird(birdName, birdAge, birdColor);
                AnimalLibrary.AnimalAdd(newbird);
            }
            else if (animalName.ToLower() == "monkey")
            {
                Console.Write("What is the monkey's name: ");
                string monkeyName = Console.ReadLine();
                Console.Write("How old is the monkey: ");
                int monkeyAge = Convert.ToInt32(Console.ReadLine());
                Console.Write("What is the monkey's color: ");
                string monkeyColor = Console.ReadLine();

                var newmonkey = new Monkey(monkeyName, monkeyAge, monkeyColor);
                AnimalLibrary.AnimalAdd(newmonkey);

            }
            else
            {
                Console.WriteLine("Please enter a valid animal name");
            }
        }
        //MAIN ANIMAL DELETE METHOD
        private static void MainAnimalDelete()
        {
            Console.Write("Which class do you want to delete an animal from: ");
            string _whichanimal = Console.ReadLine();
            Console.Write("Enter the number of the animal you want to delete: ");
            int _manimalnumber = Convert.ToInt32(Console.ReadLine());
            AnimalLibrary.AnimalDelete(_manimalnumber, _whichanimal);
        }
        //MAIN ANIMAL SOUND METHOD
        private static void MainAnimalSound()
        {
            Console.Write("Which animal's voice do you want to hear: ");
            string _soundname = Console.ReadLine();
            AnimalLibrary.AnimalSound(_soundname);
        }


    }
}
