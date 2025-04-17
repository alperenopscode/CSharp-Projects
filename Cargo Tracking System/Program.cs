using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cargo_Tracking_System;

namespace CargoTrackingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Cargo Tracking System.\n");
            bool control = true;

            while (control)
            {
                string choiceResult = RedirectionScreen();
                switch (choiceResult)
                {
                    case "1":
                        CargoTransactions.CargoRegistration();
                        break;
                    case "2":
                        CargoTransactions.CargoDelete();
                        break;
                    case "3":
                        DirectoryTransactions.CargoView();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(1000);
                        control = false;
                        break;
                    default:
                        Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                        break;
                }
            }

        }
        public static string RedirectionScreen() // Redirection Screen Method
        {
            Console.WriteLine("1- Enter a new cargo.");
            Console.WriteLine("2- Delete a cargo.");
            Console.WriteLine("3- All Cargo View");
            Console.WriteLine("4- Exit");

            Console.Write("Your Choice: ");
            string choice = Console.ReadLine();

            Console.Clear();
            return choice;
        }

    }

    class CargoTransactions // Cargo Transaction Class
    {
        public static void CargoRegistration() // Cargo Registration Method
        {
            Console.Write("Enter the sender name: ");
            string senderName = Console.ReadLine().ToLower();

            Console.Write("Enter recipient name information: ");
            string receiverName = Console.ReadLine().ToLower();

            Console.Write("Enter the cargo sender city: ");
            string senderCity = Console.ReadLine().ToLower();

            Console.Write("Enter the cargo delivery city: ");
            string deliveryCity = Console.ReadLine().ToLower();

            Console.Write("Enter the cargo weight (KG): ");
            double cargoWeight = Convert.ToDouble(Console.ReadLine());
            Console.Clear();

            string[,] cargoTypes = {
                { "1", "Fragile" },
                { "2", "Perishable" },
                { "3", "Hazardous" },
                { "4", "Valuable" },
                { "5", "Express" }
            };

            Console.WriteLine("What's the cargo type?");
            for (int i = 0; i < cargoTypes.GetLength(0); i++)
            {
                Console.WriteLine($"{cargoTypes[i, 0]} - {cargoTypes[i, 1]}");
            }

            Console.Write("Your Choice: ");
            string choice = Console.ReadLine();

            string selectedcargoType = "Unknown";
            for (int i = 0; i < cargoTypes.GetLength(0); i++)
            {
                if (cargoTypes[i, 0] == choice)
                {
                    selectedcargoType = cargoTypes[i, 1];
                    break;
                }
            }
            Console.Clear();

            var validator = new CargoInputValidator(senderName, receiverName, senderCity, deliveryCity, cargoWeight, selectedcargoType);

        }
        public static void CargoDelete() // Cargo Delete Method
        {
            Console.Write("What is the sender name of the cargo you want to delete: ");
            string senderName = Console.ReadLine();
            Console.Write("What is the recipient name of the shipment you want to delete: ");
            string receiverName = Console.ReadLine();

            Console.Clear();
            CargoInputValidator.ValidateCargoDeletion(senderName, receiverName);
        }
    }
}
