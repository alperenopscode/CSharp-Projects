using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CargoTrackingSystem;

namespace Cargo_Tracking_System
{
    internal class CargoInputValidator
    {
        public string VSenderName { get; private set; }
        public string VReceiverName { get; private set; }
        public string VSenderCity { get; private set; }
        public string VDeliveryCity { get; private set; }
        public double VCargoWeight { get; private set; }
        public string VCargoType { get; private set; }

        public CargoInputValidator(string senderName, string receiverName, string senderCity, string deliveryCity, double cargoWeight, string selectedCargoType)
        {
            VSenderName = senderName;
            VReceiverName = receiverName;
            VSenderCity = senderCity;
            VDeliveryCity = deliveryCity;
            VCargoWeight = cargoWeight;
            VCargoType = selectedCargoType;
            ValidateCargoCreation();
        }

        public void ValidateCargoCreation() //Validate Cargo Creation Method
        {
            if (string.IsNullOrWhiteSpace(VSenderName) || VSenderName.Length < 3 || VSenderName.Any(char.IsDigit))
            {
                Console.WriteLine("Sender name cannot be empty, shorter than 3 letters, or contain numbers.");
            }
            else if (string.IsNullOrWhiteSpace(VReceiverName) || VReceiverName.Length < 3 || VReceiverName.Any(char.IsDigit))
            {
                Console.WriteLine("Receiver name cannot be empty, shorter than 3 letters, or contain numbers.");
            }
            else if (string.IsNullOrWhiteSpace(VSenderCity) || VSenderCity.Any(char.IsDigit))
            {
                Console.WriteLine("Sender city cannot be empty or contain numbers.");
            }
            else if (string.IsNullOrWhiteSpace(VDeliveryCity) || VDeliveryCity.Any(char.IsDigit))
            {
                Console.WriteLine("Delivery city cannot be empty or contain numbers.");
            }
            else if (VCargoWeight <= 0 || !double.TryParse(VCargoWeight.ToString(), out _))
            {
                Console.WriteLine("Cargo weight must be a positive number.");
            }
            else
            {
                switch (VCargoType)
                {
                    case "Fragile":
                        var fragileCargo = new FragileCargo(VSenderName, VReceiverName, VSenderCity, VDeliveryCity, VCargoWeight, VCargoType);
                        break;
                    case "Perishable":
                        var perishableCargo = new PerishableCargo(VSenderName, VReceiverName, VSenderCity, VDeliveryCity, VCargoWeight, VCargoType);
                        break;
                    case "Hazardous":
                        var hazardousCargo = new HazardousCargo(VSenderName, VReceiverName, VSenderCity, VDeliveryCity, VCargoWeight, VCargoType);
                        break;
                    case "Valuable":
                        var valuableCargo = new ValuableCargo(VSenderName, VReceiverName, VSenderCity, VDeliveryCity, VCargoWeight, VCargoType);
                        break;
                    case "Express":
                        var expressCargo = new ExpressCargo(VSenderName, VReceiverName, VSenderCity, VDeliveryCity, VCargoWeight, VCargoType);
                        break;
                    default:
                        Console.WriteLine("Unknown cargo type selected. A generic cargo object will be created with maximum fee.");
                        var unknownCargo = new UnknownCargo(VSenderName, VReceiverName, VSenderCity, VDeliveryCity, VCargoWeight, VCargoType);
                        break;
                }
            }
        }

        public static void ValidateCargoDeletion(string senderName, string receiverName) //Validate Cargo Deletion Method
        {
            if (string.IsNullOrWhiteSpace(senderName) || senderName.Length < 3 || senderName.Any(char.IsDigit))
            {
                Console.WriteLine("Sender name cannot be empty, shorter than 3 letters, or contain numbers.");
            }
            else if (string.IsNullOrWhiteSpace(receiverName) || receiverName.Length < 3 || receiverName.Any(char.IsDigit))
            {
                Console.WriteLine("Receiver name cannot be empty, shorter than 3 letters, or contain numbers.");
            }
            else
            {
                DirectoryTransactions.CargoDelete(senderName, receiverName);
            }
        }
    }
}
