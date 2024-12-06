using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Calculator");
            while (true)
            {
                Console.Write("\nPlease enter the first number: ");
                string firstnum = Console.ReadLine();
                if (!string.IsNullOrEmpty(firstnum) && double.TryParse(firstnum, out double num1))
                {
                    Console.Write("Please enter a process (+,-,*,/): ");
                    string process = Console.ReadLine();

                    Console.Write("Please enter the second number: ");
                    string secondnum = Console.ReadLine();
                    if (!string.IsNullOrEmpty(secondnum) && double.TryParse(secondnum, out double num2))
                    {
                        Process(num1, process, num2);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nWARNING: The input must be a number and cannot be empty!!!");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: The input must be a number and cannot be empty!!!");
                }
            }

            Console.ReadLine();
        }
        private static void Process(double num1, string process, double num2)
        {
            if (!string.IsNullOrEmpty(process))
            {
                double result = 0;

                if (process == "+")
                {
                    result = num1 + num2;
                    Console.WriteLine("\n*** Result {0} {1} {2} = {3} ***", num1, process, num2, result);

                }
                else if (process == "-")
                {
                    result = num1 - num2;
                    Console.WriteLine("\n*** Result {0} {1} {2} = {3} ***", num1, process, num2, result);
                }
                else if (process == "*")
                {
                    result = num1 * num2;
                    Console.WriteLine("\n*** Result {0} {1} {2} = {3} ***", num1, process, num2, result);
                }
                else if (process == "/")
                {
                    if (num2 == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\nWARNING: Number cannot be divided by 0!!!");
                    }

                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine("\n*** Result {0} {1} {2} = {3} ***", num1, process, num2, result);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: You entered the wrong parameter, please enter one of (+,-,*,/)!!!");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nWARNING: Parametre connot be empty!!!");
            }
        }
    }
}
