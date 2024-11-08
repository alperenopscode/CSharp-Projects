using System;
using System.Collections.Generic;
using System.Linq;

namespace Contacts_Application
{
    internal class Program
    {
        static Dictionary<string, string> contacts = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            bool control = true;
            Console.WriteLine("***** Welcome to Contacts *****");

            while (control)
            {
                string choice = Choice();
                switch (choice)
                {
                    case "1":
                        AddPeople();
                        break;
                    case "2":
                        DeletePeople();
                        break;
                    case "3":
                        ContactView();
                        break;
                    case "4":
                        Console.WriteLine("Please click the enter");
                        control = false;
                        break;
                    default:
                        Console.WriteLine("WARNING: Please use selection numbers");
                        break;
                }
            }
            Console.ReadLine();
        }

        private static string Choice()
        {
            Console.WriteLine("\n1- Add new person");
            Console.WriteLine("2- Delete person");
            Console.WriteLine("3- View contacts");
            Console.WriteLine("4- Exit");

            Console.Write("\nYour Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }

        // ADD PEOPLE METHOD
        private static void AddPeople()
        {
            Console.Write("\nEnter the name to save to the contact: ");
            string name = Console.ReadLine().ToLower();

            Console.Write("Enter the number to save to the contact: ");
            string number = Console.ReadLine();

            if (!string.IsNullOrEmpty(name))
            {
                if (!string.IsNullOrEmpty(number) && number[0] == '0' && number[1] == '5' && number.Length == 11 && number.All(char.IsDigit))
                {
                    contacts.Add(name, number);
                    Console.WriteLine("\nINFO: New person was added to contact");
                }
                else
                {
                    Console.WriteLine("\nWARNING: Enter the number correctly, the number must start with 0 and continue with 5");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: The first letter of the name must be capitalized!!!");
            }
        }

        // DELETE PEOPLE METHOD
        private static void DeletePeople()
        {
            Console.Write("\nWhich person do you want to delete: ");
            string nameResult = Console.ReadLine().ToLower();

            if (contacts.ContainsKey(nameResult))
            {
                contacts.Remove(nameResult);
                Console.WriteLine("\nINFO: Person successfully deleted");
            }
            else
            {
                Console.WriteLine("\n WARNING: There is no such person in Contacts");
            }
        }

        // VIEW CONTACT METHOD
        private static void ContactView()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("\n WARNING: There are no people in Contacts");
            }
            else
            {
                Console.WriteLine("- CONTACTS -");
                foreach (var item in contacts)
                {
                    Console.WriteLine("Person's Name: {0}, Number: {1}", item.Key, item.Value);
                }
            }
        }
    }
}
