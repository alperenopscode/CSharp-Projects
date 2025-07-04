using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car_System
{
    public abstract class Cars//CARS CLASS
    {
        public string CarBrand { get; private set; }
        public string CarModel { get; private set; }
        public string CarYear { get; private set; }
        public string CarFuelType { get; private set; }
        public string CarBodyType { get; private set; }
        public string CarGearboxType { get; private set; }
        public decimal CarPrice { get; protected set; }

        public Cars(string brand, string model, string year, string fueltype, string bodytype, string gearboxtype)
        {
            CarBrand = brand;
            CarModel = model;
            CarYear = year;
            CarFuelType = fueltype;
            CarBodyType = bodytype;
            CarGearboxType = gearboxtype;
        }

        public abstract void CarPriceCalculator();
    }

    class CarsTransactions//CARS TRANSACTION CLASS
    {
        public static void CarsAdd()//CARS ADD METHOD
        {
            Console.Clear();
            Console.Write("Please enter the CAR BRAND of you want add (Ford): ");
            string brand = Console.ReadLine().ToLower();

            Console.Write("Please enter the CAR MODEL of you want add (Fiesta): ");
            string model = Console.ReadLine().ToLower();

            Console.Write("Please enter the CAR YEAR of you want add (2012): ");
            string year = Console.ReadLine().ToLower();

            //FUELS
            Console.Clear();
            string[,] fuels =
{
                { "1", "Gas" },
                { "2", "Diesel" },
            };
            Console.Write("\nFuel List: ");
            for (int i = 0; i < fuels.GetLength(0); i++)
            {
                Console.WriteLine($"{fuels[i, 0]} - {fuels[i, 1]}");
            }
            Console.Write("\nPlease enter the CAR FUEL TYPE of you want add (1 or 2): ");
            string fuelchoice = Console.ReadLine();

            string selectedfuel = "Unknown";
            for (int i = 0; i < fuels.GetLength(0); i++)
            {
                if (fuels[i, 0] == fuelchoice)
                {
                    selectedfuel = fuels[i, 1];
                    break;
                }
            }

            //BODYTYPES
            Console.Clear();
            string[,] bodytypes =
            {
                { "1", "Sedan" },
                { "2", "Hatchback" },
                { "3", "Wagon" },
                { "4", "Suv" },
            };
            Console.Write("\nBody Types List: ");
            for (int i = 0; i < bodytypes.GetLength(0); i++)
            {
                Console.WriteLine($"{bodytypes[i, 0]} - {bodytypes[i, 1]}");
            }
            Console.Write("Please enter the CAR BODY TYPE of you want add(1,2,3,4): ");
            string bodychoice = Console.ReadLine();

            string selectedbodytype = "Unknown";
            for (int i = 0; i < bodytypes.GetLength(0); i++)
            {
                if (bodytypes[i, 0] == bodychoice)
                {
                    selectedbodytype = bodytypes[i, 1];
                    break;
                }

            }

            //GEARBOXTYPES
            Console.Clear();
            string[,] gearboxtypes =
            {
                { "1", "Automatic" },
                { "2", "Manuel" },
            };
            Console.Write("\nGear Box Types: ");
            for (int i = 0; i < gearboxtypes.GetLength(0); i++)
            {
                Console.WriteLine($"{gearboxtypes[i, 0]} - {gearboxtypes[i, 1]}");
            }
            Console.Write("Please enter the CAR GEARBOX TYPE of you want add(1 or 2): ");
            string gearchoice = Console.ReadLine();

            string selectedgearbox = "Unknown";
            for (int i = 0; i < gearboxtypes.GetLength(0); i++)
            {
                if (gearboxtypes[i, 0] == gearchoice)
                {
                    selectedgearbox = gearboxtypes[i, 1];
                    break;
                }

            }

            bool isValid = Validation.CarAddValidation(brand, model, year, selectedfuel, selectedbodytype, selectedgearbox);
            if (!isValid)
                return;

            switch (selectedbodytype)
            {
                case "Sedan":
                    var sedan = new Sedan(brand, model, year, selectedfuel, selectedbodytype, selectedgearbox);
                    Business.CarAdd(sedan);
                    break;
                case "Hatchback":
                    var hatchback = new Hatchback(brand, model, year, selectedfuel, selectedbodytype, selectedgearbox);
                    Business.CarAdd(hatchback);
                    break;
                case "Wagon":
                    var wagon = new Wagon(brand, model, year, selectedfuel, selectedbodytype, selectedgearbox);
                    Business.CarAdd(wagon);
                    break;
                case "Suv":
                    var suv = new Wagon(brand, model, year, selectedfuel, selectedbodytype, selectedgearbox);
                    Business.CarAdd(suv);
                    break;
                case "Unknown":
                    Console.WriteLine("Please make the selections in the list!!!");
                    break;
            }
        }
        public static void CarsDelete()//CARS DELETE METHOD
        {
            Console.Clear();
            string[,] bodytypes =
            {
                { "1", "Sedan" },
                { "2", "Hatchback" },
                { "3", "Wagon" },
                { "4", "Suv" },
            };
            for(int i = 0; i < bodytypes.GetLength(0); i++)
            {
                Console.WriteLine($"{bodytypes[i,0]} - {bodytypes[i,1]}");
            }
            Console.Write("Please enter the CAR BODY TYPE of you want delete(1,2,3,4): ");
            string bodychoice = Console.ReadLine();
           
            string selectedbodytype = "Unknown";
            for (int i = 0; i < bodytypes.GetLength(0); i++)
            {
                if (bodytypes[i, 0] == bodychoice)
                {
                    selectedbodytype = bodytypes[i, 1];
                    break;
                }
            }

            Console.Write("Please enter the CAR BRAND of you want delete: ");
            string carbrand = Console.ReadLine().ToLower();

            Console.Write("Please enter the CAR MODEL of you want delete: ");
            string carmodel = Console.ReadLine().ToLower();

            bool isValid = Validation.CarDeleteValidation(carbrand, carmodel, selectedbodytype);
            if (!isValid)
                return;
            else
                Business.CarDelete(carbrand, carmodel, selectedbodytype);
        }
    }
    class Sedan : Cars//SEDAN CLASS
    {
        public Sedan(string brand, string model, string year, string fueltype, string bodytype, string gearboxtype)//SEDAN CTOR
            : base(brand, model, year, fueltype, bodytype, gearboxtype)
        {
            CarPriceCalculator();
        }

        public override void CarPriceCalculator()//SEDAN CAR PRICE CALCULATOr
        {
            int basePrice = 1450;

            if (CarBodyType == "Sedan" && CarGearboxType == "Auomatic")
                CarPrice += (decimal)(basePrice * 2.5);
            else if (CarBodyType == "Sedan" && CarGearboxType == "Manuel")
                CarPrice += (decimal)(basePrice * 1.5);
        }
    }
    class Hatchback : Cars//HATCHBACK CLASS
    {
        public Hatchback(string brand, string model, string year, string fueltype, string bodytype, string gearboxtype)//HATCHBACK CTOR
            : base(brand, model, year, fueltype, bodytype, gearboxtype)
        {
            CarPriceCalculator();
        }
        public override void CarPriceCalculator()//HATCHBACK CAR PRICE CALCULATOR
        {
            double basePrice = 1200;
            if (CarBodyType == "Hatchback" && CarGearboxType == "Automatic")
                CarPrice += (decimal)(basePrice * 2.5);
            else if (CarBodyType == "Hatchback" && CarGearboxType == "Manuel")
                CarPrice += (decimal)(basePrice * 1.5);
        }
    }
    class Wagon : Cars//WAGON CLASS
    {
        public Wagon(string brand, string model, string year, string fueltype, string bodytype, string gearboxtype)//WAGON CTOR
            : base(brand, model, year, fueltype, bodytype, gearboxtype)
        {
            CarPriceCalculator();
        }
        public override void CarPriceCalculator()//WAGON CAR PRICE CALCULATOR
        {
            double basePrice = 1800;
            if (CarBodyType == "Wagon" && CarGearboxType == "Automatic")
                CarPrice += (decimal)(basePrice * 2.5);
            else if (CarBodyType == "Wagon" && CarGearboxType == "Manuel")
                CarPrice += (decimal)(basePrice * 1.5);
        }
    }
    class Suv : Cars//SUV CLASS
    {
        public Suv(string brand, string model, string year, string fueltype, string bodytype, string gearboxtype)//SUV CTOR
            : base(brand, model, year, fueltype, bodytype, gearboxtype)
        {
            CarPriceCalculator();
        }
        public override void CarPriceCalculator()//SUV CAR PRICE CALCULATOR
        {
            double basePrice = 2250;

            if (CarBodyType == "Suv" && CarGearboxType == "Automatic")
                CarPrice += (decimal)(basePrice * 2.5);
            else if (CarBodyType == "Suv" && CarGearboxType == "Manuel")
                CarPrice += (decimal)(basePrice * 1.5);
        }
    }
}
