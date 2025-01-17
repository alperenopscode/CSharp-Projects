using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Caffe_Sales_System
{
    internal class Program
    {
        public static List<(string Product, (decimal Small, decimal Medium, decimal Large) Price)> HotCoffe = new List<(string Product, (decimal Small, decimal Medium, decimal Large) Price)>
        {
            ("Caffe Latte", (3.00m, 4.00m, 5.00m)),
            ("Cappuccino", (3.25m, 4.25m, 5.25m)),
            ("Americano", (2.50m, 3.50m, 4.50m)),
            ("Caramel Macchiato", (3.75m, 4.75m, 5.75m)),
            ("Mocha", (4.00m, 5.00m, 6.00m))
        };
        public static List<(string Product, (decimal Small, decimal Medium, decimal Large) Price)> IceCoffe = new List<(string Product, (decimal Small, decimal Medium, decimal Large) Price)>
        {
            ("Iced Caffè Latte", (3.50m, 4.50m, 5.50m)),
            ("Iced Americano", (2.75m, 3.75m, 4.75m)),
            ("Cold Brew", (3.00m, 5.00m, 6.00m)),
            ("Iced Caramel Macchiato", (3.95m, 4.95m, 5.95m)),
            ("Iced Mocha", (4.00m, 5.00m, 6.00m))
        };


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            DirectoryProcess.DirectoryControl();

            bool control = true;
            while (control)
            {
                string chocieResult = ChoiceScreen();
                switch (chocieResult)
                {
                    case "1":
                        CoffeChoice(chocieResult);
                        break;
                    case "2":
                        CoffeChoice(chocieResult);
                        break;
                    case "3":
                        control = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("\nWARNING: Invalid choice, please try again!!!");
                        break;
                }
            }
        }
        static string ChoiceScreen()//Coffe Choice Screen Method
        {
            Console.WriteLine("1- Hot Coffe");
            Console.WriteLine("2- Ice Coffe");
            Console.WriteLine("3- Exit.");

            Console.Write("Your Choice: ");
            string choice = Console.ReadLine()?.Trim();
            return choice;
        }
        static void CoffeChoice(string coffe)//Coffe Choice Method
        {
            Console.Clear();
            switch (coffe)
            {
                case "1":
                    int i = 1;
                    foreach (var item in HotCoffe)
                    {
                        Console.WriteLine($"{i}.{item.Product} : Small: {item.Price.Small} | Medium: {item.Price.Medium} | Large: {item.Price.Large}");
                        i++;
                    }
                    Console.Write("\nWhich coffee would you like to drink (3): ");
                    string hotNumber = Console.ReadLine()?.Trim();
                    if (int.TryParse(hotNumber, out int hotSelected) && hotSelected > 0 && hotSelected <= HotCoffe.Count)
                    {
                        var hotCoffe = HotCoffe[hotSelected - 1];

                        Console.WriteLine("Please select a size: Small, Medium, or Large");
                        string size = Console.ReadLine()?.Trim().ToLower();
                        decimal price = 0;
                        int verify = 0;

                        switch (size)
                        {
                            case "small":
                                price = hotCoffe.Price.Small;
                                verify = 1;
                                break;
                            case "medium":
                                price = hotCoffe.Price.Medium;
                                verify = 1;
                                break;
                            case "large":
                                price = hotCoffe.Price.Large;
                                verify = 1;
                                break;
                            default:
                                Console.WriteLine("\nWARNING: You entered incorrectly or incompletely!!!");
                                verify = 0;
                                break;
                        }
                        Console.Write("What is your name: ");
                        string name = Console.ReadLine()?.Trim();
                        if (verify > 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Your Coffe : {hotCoffe.Product}, Size: {size} , Price: {price}");
                            Console.ForegroundColor = ConsoleColor.White;

                            string sales = $"- Name : {name} | Coffe : {hotCoffe.Product} | Size: {size} | Price: {price}" + "\n";
                            DirectoryProcess.FileWrite(sales);
                        }
                    }
                    else
                        Console.WriteLine("\nWARNING: You entered incorrectly or incompletely!!!");
                    break;

                case "2":
                    int j = 1;
                    foreach (var item in IceCoffe)
                    {
                        Console.WriteLine($"{j}.{item.Product} : Small: {item.Price.Small} | Medium: {item.Price.Medium} | Large: {item.Price.Large}");
                        j++;
                    }
                    Console.Write("\nWhich coffee would you like to drink (3): ");
                    string iceNumber = Console.ReadLine()?.Trim();
                    if (int.TryParse(iceNumber, out int iceSelected) && iceSelected > 0 && iceSelected <= IceCoffe.Count)
                    {
                        var iceCoffe = IceCoffe[iceSelected - 1];

                        Console.WriteLine("Please select a size: Small, Medium, or Large");
                        string size = Console.ReadLine()?.Trim().ToLower();
                        decimal price = 0;
                        int verify = 0;

                        switch (size)
                        {
                            case "small":
                                price = iceCoffe.Price.Small;
                                verify = 1;
                                break;
                            case "medium":
                                price = iceCoffe.Price.Medium;
                                verify = 1;
                                break;
                            case "large":
                                price = iceCoffe.Price.Large;
                                verify = 1;
                                break;
                            default:
                                Console.WriteLine("\nWARNING: You entered incorrectly or incompletely!!!");
                                verify = 0;
                                break;
                        }
                        Console.Write("What is your name: ");
                        string name = Console.ReadLine()?.Trim();
                        if (verify > 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Your Coffe : {iceCoffe.Product}, Size: {size} , Price: {price}");
                            Console.ForegroundColor = ConsoleColor.White;

                            string sales = $"- Name : {name} | Coffe : {iceCoffe.Product} | Size: {size} | Price: {price}" + "\n";
                            DirectoryProcess.FileWrite(sales);
                        }
                    }
                    else
                        Console.WriteLine("\nWARNING: You entered incorrectly or incompletely!!!");
                    break;
                default:
                    Console.WriteLine("\nWARNING: You entered incorrectly or incompletely!!!");
                    break;
            }

        }

    }
}
static class DirectoryProcess //Directory Process Class
{
    static string folder = @"c:/Caffe Sales";
    static string file = @"c:/Caffe Sales/Sales.txt";
    public static void DirectoryControl()
    {
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
        if (!File.Exists(file))
            File.Create(file);
    }
    public static void FileWrite(string sales)
    {
        if (Directory.Exists(folder) && File.Exists(file))
        {
            File.AppendAllText(file, sales);
        }
    }
}


