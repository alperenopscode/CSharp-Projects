using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_A_Car_System
{
    public class Validation//VALIDATION CLASS
    {
        public static bool CarAddValidation(string brand, string model, string year, string fueltype, string bodytype, string gearboxtype)//CAR ADD VALIDATION METHOD
        {
            if (string.IsNullOrWhiteSpace(brand) || brand.Length < 3 || brand.Any(char.IsDigit))
            {
                Console.WriteLine("CAR BRAND cannot be empty, shorter than 3 letters, or contain numbers.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(model) || model.Length < 2)
            {
                Console.WriteLine("CAR MODEL cannot be empty, shorter than 5 letters");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(year) || year.Length < 3 || year.Length > 5)
            {
                Console.WriteLine("CAR YEAR cannot be empty, shorter than 3 or longer than 5 characters.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(fueltype) || fueltype.Length < 3 || fueltype.Any(char.IsDigit))
            {
                Console.WriteLine("CAR FUEL TYPE cannot be empty, shorter than 3 letters, or contain numbers.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(bodytype) || bodytype.Length < 3 || bodytype.Any(char.IsDigit))
            {
                Console.WriteLine("CAR BODY TYPE cannot be empty, shorter than 3 letters, or contain numbers.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(gearboxtype) || gearboxtype.Length < 3 || gearboxtype.Any(char.IsDigit))
            {
                Console.WriteLine("CAR GEARBOX TYPE cannot be empty, shorter than 3 letters, or contain numbers.");
                return false;
            }

            return true;
        }
        public static bool CarDeleteValidation(string brand, string model, string bodytype)//CAR DELETE VALIDATION METHOD
        {
            if (string.IsNullOrWhiteSpace(brand) || brand.Length < 3 || brand.Any(char.IsDigit))
            {
                Console.WriteLine("CAR BRAND cannot be empty, shorter than 3 letters, or contain numbers.");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(model) || model.Length < 2)
            {
                Console.WriteLine("CAR MODEL cannot be empty, shorter than 5 letters");
                return false;
            }
            else if (string.IsNullOrWhiteSpace(bodytype) || bodytype.Length < 3 || bodytype.Any(char.IsDigit))
            {
                Console.WriteLine("CAR BODY TYPE cannot be empty, shorter than 3 letters, or contain numbers.");
                return false;
            }
            return true;
        }
    }
}
