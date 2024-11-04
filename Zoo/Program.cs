using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hayvanatbahcesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool control = true;
            while (control)
            {
                string choice = Choice();
                switch (choice)
                {
                    case "1":
                        AnimalLibrary.AllAnimalShow();
                        break;
                    case "2":
                        BaseAddAnimal();
                        break;
                    case "3":
                        control = false;
                        break;

                }
            }

            Console.ReadLine();
        }
        private static string Choice()
        {
            Console.WriteLine("\nWelcome to the zoo. Please select an action");
            Console.WriteLine("1- Show the all animals");
            Console.WriteLine("2- Add a animal");
            Console.WriteLine("3- Pleace press the 'q' button for exit");
            Console.WriteLine("");

            string choice = Console.ReadLine();
            return choice;
        }
        private static AnimalLibrary newlibrary = null;
        private static void BaseAddAnimal()
        {
            if (newlibrary == null)
            {
                newlibrary = new AnimalLibrary();
            }
            Console.Write("\nWhich you want add animal: ");
            string animalname = Console.ReadLine();
            if (animalname == "dog" || animalname == "Dog")
            {
                Console.Write("\nWhat will the dog be called?: ");
                string newdogname = Console.ReadLine();
                Console.Write("\nHow old is the dog?: ");
                int newdogage = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nHow many legs does a dog have?: ");
                int newdoglegs = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nWhat dogs color?: ");
                string newdogcolor = Console.ReadLine();

                var newdog = new Dog(newdogname, newdogage, newdoglegs, newdogcolor);
                newlibrary.Getanimal(newdog);
                newlibrary.AnimalAdd();
            }
            else if (animalname == "bird" || animalname == "Bird")
            {
                Console.Write("\nWhat will the bird be called?: ");
                string newbirdname = Console.ReadLine();
                Console.Write("\nHow old is the bird?: ");
                int newbirdage = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nHow many legs does a bird have?: ");
                int newbirdlegs = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nWhat bird color?: ");
                string newbirdcolor = Console.ReadLine();

                var newbird = new Bird(newbirdname, newbirdage, newbirdlegs, newbirdcolor);
                newlibrary.Getanimal(newbird);
                newlibrary.AnimalAdd();
            }
            else if (animalname == "monkey" || animalname == "monkey")
            {
                Console.Write("\nWhat will the monkey be called?: ");
                string newmonkeyname = Console.ReadLine();
                Console.Write("\nHow old is the monkey?: ");
                int newmonkeyage = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nHow many legs does a monkey have?: ");
                int newmonkeylegs = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nWhat is the length of the monkey's tail?");
                int newmonkeytail = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nWhat monkey color?: ");
                string newmonkeycolor = Console.ReadLine();


                var newmonkey = new Monkey(newmonkeyname, newmonkeyage, newmonkeylegs, newmonkeytail, newmonkeycolor);
                newlibrary.Getanimal(newmonkey);
                newlibrary.AnimalAdd();
            }
            else
            {
                Console.WriteLine("Please write the animal name correctly");
            }
        }

    }
}
