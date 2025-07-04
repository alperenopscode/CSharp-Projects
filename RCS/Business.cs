using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car_System
{
    internal class Business//BUSINESS CLASS
    {
        private static List<Sedan> Sedans = new List<Sedan>();
        private static List<Hatchback> Hatchbacks = new List<Hatchback>();
        private static List<Wagon> Wagons = new List<Wagon>();
        private static List<Suv> Suvs = new List<Suv>();
        public static void CarAdd(Cars car)//CAR ADD METHOD
        {
            Console.Clear();
            if (car is Sedan sedan)
            {
                Sedans.Add(sedan);
                Console.WriteLine("Added new SEDAN car");
            }
            else if (car is Hatchback hatchback)
            {
                Hatchbacks.Add(hatchback);
                Console.WriteLine("Added new HATCHBACK car");
            }
            else if (car is Wagon wagon)
            {
                Wagons.Add(wagon);
                Console.WriteLine("Added new WAGON car");
            }
            else if (car is Suv suv)
            {
                Suvs.Add(suv);
                Console.WriteLine("Added new SUV car");
            }
            else
                Console.WriteLine("Vehicle type not recognized!!!");
        }
        public static void CarDelete(string carbrand, string carmodel, string bodytype)//CAR DELETE METHOD
        {
            Console.Clear();
            switch (bodytype)
            {
                case "Sedan":
                    var sedanToRemove = Sedans.FirstOrDefault(c => c.CarBrand.ToLower() == carbrand && c.CarModel.ToLower() == carmodel);
                    if (sedanToRemove != null)
                    {
                        Sedans.Remove(sedanToRemove);
                        Console.WriteLine("Sedan car successfully DELETED.");
                    }
                    else
                        Console.WriteLine("Sedan car not found!!!");
                    break;

                case "Hatchback":
                    var hatchbackToRemove = Hatchbacks.FirstOrDefault(h => h.CarBrand == carbrand && h.CarModel == carmodel);
                    if (hatchbackToRemove != null)
                    {
                        Hatchbacks.Remove(hatchbackToRemove);
                        Console.WriteLine("Hatcback car successfully DELETED");
                    }
                    else
                        Console.WriteLine("Hatchback car not found!!!");
                    break;

                case "Wagon":
                    var wagonToRemove = Wagons.FirstOrDefault(w => w.CarBrand == carbrand && w.CarModel == carmodel);
                    if (wagonToRemove != null)
                    {
                        Wagons.Remove(wagonToRemove);
                        Console.WriteLine("Wagon car successfully DELETED.");
                    }
                    else
                        Console.WriteLine("Wagon car not found!!!");
                    break;

                case "Suv":
                    var suvToRemove = Suvs.FirstOrDefault(s => s.CarBrand == carbrand && s.CarModel == carmodel);
                    if (suvToRemove != null)
                    {
                        Suvs.Remove(suvToRemove);
                        Console.WriteLine("Suv car successfully DELETED.");
                    }
                    else
                        Console.WriteLine("Suv car not found!!!");
                    break;

                case "Unknown":
                    Console.WriteLine("Please make the selections in the list!!!");
                    break;
            }
        }
        public static void CarView()//CAR VIEW METHOD
        {
            Console.Clear();
            string[,] Models =
            {
                {"1","SEDAN"},
                {"2","HATCHBACK"},
                {"3","WAGON"},
                {"4","SUV"}
            };

            for (int i = 0; i < Models.GetLength(0); i++)
            {
                Console.WriteLine($"{Models[i, 0]} - {Models[i, 1]}");
            }
            Console.Write("Please enter the vehicle model you want to view: ");

            int choiceModel = Convert.ToInt32(Console.ReadLine());

            switch (choiceModel)
            {
                case 1:
                    foreach (Cars s in Sedans)
                    {
                        Console.WriteLine($"Brand: {s.CarBrand}, Model: {s.CarModel}, Year: {s.CarYear}, FuelType: {s.CarFuelType}, BodyType: {s.CarBodyType}, GearBox: {s.CarGearboxType}, CarPrice: {s.CarPrice}");
                    }
                    break;
                case 2:
                    foreach (Cars h in Hatchbacks)
                    {
                        Console.WriteLine($"Brand: {h.CarBrand}, Model: {h.CarModel}, Year: {h.CarYear}, FuelType: {h.CarFuelType}, BodyType: {h.CarBodyType}, GearBox: {h.CarGearboxType}, CarPrice: {h.CarPrice}");
                    }
                    break;
                case 3:
                    foreach (Cars w in Wagons)
                    {
                        Console.WriteLine($"Brand: {w.CarBrand}, Model: {w.CarModel}, Year: {w.CarYear}, FuelType: {w.CarFuelType}, BodyType: {w.CarBodyType}, GearBox: {w.CarGearboxType}, CarPrice: {w.CarPrice}");
                    }
                    break;
                case 4:
                    foreach (Cars s in Suvs)
                    {
                        Console.WriteLine($"Brand: {s.CarBrand}, Model: {s.CarModel}, Year: {s.CarYear}, FuelType: {s.CarFuelType}, BodyType: {s.CarBodyType}, GearBox: {s.CarGearboxType}, CarPrice: {s.CarPrice}");
                    }
                    break;
                default:
                    Console.WriteLine("Vehicle model not defined!!!");
                    break;
            }
        }

    }
}
