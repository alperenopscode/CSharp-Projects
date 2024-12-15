using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Registration_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mainDirectory;
            mainDirectory = @"c:\FactoryDirectory";

        BACKTOTOP:
            if (System.IO.Directory.Exists(mainDirectory))
            {
                bool control = true;
                while (control)
                {
                    string choiceResult = Login();
                    switch (choiceResult)
                    {
                        case "1":
                            Console.Clear();
                            Employees.AddEmployee();
                            break;
                        case "2":
                            Console.Clear();
                            Employees.DeleteEmployee();
                            break;
                        case "3":
                            Console.Clear();
                            Employees.UpdateEmployee();
                            break;
                        case "4":
                            Console.Clear();
                            Console.WriteLine("\nINFO: Logging out!!!");
                            control = false;
                            break;
                        default:
                            Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: The file system required for the program to run is missing, so it is being recreated!!!");
                //Main Directory Created
                System.IO.Directory.CreateDirectory(mainDirectory);
                //Subdirectory Created
                Directory.CreateDirectory(Path.Combine(mainDirectory, "Desinger"));
                Directory.CreateDirectory(Path.Combine(mainDirectory, "Production"));
                Directory.CreateDirectory(Path.Combine(mainDirectory, "Tester"));

                goto BACKTOTOP;
            }


        }
        private static string Login()//Login Method
        {
            Console.WriteLine("1- Add an employee");
            Console.WriteLine("2- Delete an employee");
            Console.WriteLine("3- Update an employee");
            Console.WriteLine("4- Exit");

            Console.Write("\nYour Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
    }
}
