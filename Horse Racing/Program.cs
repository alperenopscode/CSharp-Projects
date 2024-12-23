using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorseRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Horse Racing");
            bool control = true;

            while (control)
            {
                string choiceResult = Login();
                switch (choiceResult)
                {
                    case "1":
                        HorseRacing();
                        Console.Clear();
                        break;
                    case "2":
                        Console.WriteLine("\nExiting...");
                        control = false;
                        break;
                    default:
                        Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                        break;
                }
            }
        }
        private static string Login()//Login Method
        {
            Console.WriteLine("\n1- Horse Racing");
            Console.WriteLine("2- Exit");

            Console.Write("\nYour Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }
        private static void HorseRacing()//Horse Racing Method
        {
            Console.WriteLine("\nHORSES: ");
            Console.WriteLine("1- Secretariat (ABD)");
            Console.WriteLine("2- Frankel (England)");
            Console.WriteLine("3- Black Caviar (Australia)");
            Console.WriteLine("4- Deep Impact (Japan)");

            Console.WriteLine("\nYou can only choose one horse!!!");
            Console.Write("\nPlease enter the number of your chosen horse (1-4): ");

            if (!int.TryParse(Console.ReadLine(), out int horseNumber) || horseNumber < 1 || horseNumber > 4)
            {
                Console.WriteLine("Invalid input! Please restart the program and enter a number between 1 and 4.");
                return;
            }

            string[] horses = { "Secretariat", "Frankel", "Black Caviar", "Deep Impact" };
            int[] horseScore = new int[4];

            string chosenHorse = horses[horseNumber - 1];

            Random random = new Random();

            for (int round = 1; round <= 5; round++)
            {
                Console.WriteLine($"\n--- ROUND {round} ---");

                for (int i = 0; i < horses.Length; i++)
                {
                    int randomPoints = random.Next(1, 51);
                    horseScore[i] += randomPoints;
                    Console.WriteLine($"{horses[i]} gained {randomPoints} points (Total: {horseScore[i]})");
                }
                Thread.Sleep(1500);
            }

            Console.WriteLine("\n*** FINAL SCORES ***");
            for (int i = 0; i < horses.Length; i++)
            {
                Console.WriteLine($"{horses[i]}: {horseScore[i]} points");
            }

            int highestScore = horseScore.Max();
            int horseIndex = Array.IndexOf(horseScore, highestScore);
            string winningHorse = horses[horseIndex];

            if (chosenHorse == winningHorse)
                Console.WriteLine("\nCongratulations! Your horse won the race!");
            else
                Console.WriteLine("\nSorry, your horse lost the race.");

            Console.ReadLine();
        }
    }
}

