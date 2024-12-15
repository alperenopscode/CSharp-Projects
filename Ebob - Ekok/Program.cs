using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebob___Ekok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool control = true;
            Console.WriteLine("*** Welcome to the ebob-ekok finding program ***");

            while (control)
            {
                string choiceResult = Login();
                switch (choiceResult)
                {
                    case "1":
                        EbobEkok();
                        break;
                    case "2":
                        control = false;
                        Console.WriteLine("\nExiting...");
                        break;
                    default:
                        Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                        break;
                }
            }
        }
        private static string Login() //Login Method
        {
            Console.WriteLine("\n1- Ebob");
            Console.WriteLine("2- Exit");

            Console.Write("\nYour Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }

        private static void EbobEkok() //Ebob - Ekok Method
        {

            Console.Write("\nPlease enter first number: ");
            string firstnum = Console.ReadLine();
            if (!string.IsNullOrEmpty(firstnum) && int.TryParse(firstnum, out int num1))
            {
                Console.Write("\nPlease enter second number: ");
                string secondnum = Console.ReadLine();
                if (!string.IsNullOrEmpty(secondnum) && int.TryParse(secondnum, out int num2))
                {
                    int ebob = 1;

                    for (int i = 1; i <= Math.Min(num1, num2); i++)
                    {
                        if (num1 % i == 0 && num2 % i == 0)
                        {
                            ebob = i;
                        }
                    }
                    int ekok = (num1 * num2) / ebob;
                    Console.WriteLine("\n*** Result = Ebob: {0}, Ekok: {1} ***", ebob, ekok);

                }
                else
                {
                    Console.WriteLine("\nWARNING: You entered an incorrect or missing parameter!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: You entered an incorrect or missing parameter!!!");
            }
        }

    }
}
