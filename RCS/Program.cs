using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool control = true;

            while (control)
            {
                string choiceResult = LoginScreen();

                switch (choiceResult)
                {
                    case "1":
                        CarsTransactions.CarsAdd();
                        break;

                    case "2":
                        CarsTransactions.CarsDelete();
                        break;

                    case "3":
                        Business.CarView();
                        break;

                    case "4":
                        Console.WriteLine("Exiting...");
                        control = false;
                        break;

                    default:
                        Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                        break;
                }
            }
        }
        static string LoginScreen()
        {
            Console.WriteLine("1- Cars Add");
            Console.WriteLine("2- Cars Remove");
            Console.WriteLine("3- Cars View");
            Console.WriteLine("4- Exit");

            Console.Write("Your Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
