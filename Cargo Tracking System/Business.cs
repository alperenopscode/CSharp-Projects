using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CargoTrackingSystem
{
    internal class Business
    {
        public static void CargoConnection(Cargo cargo)
        {
            string cargoFileContent = CargoFileCreate(cargo);
            DirectoryTransactions.CargoWrite(cargoFileContent);
        }

        public static string CargoFileCreate(Cargo cargo)
        {
            string cargoFile = $"- Sender Name: {cargo.SenderName} | - Receiver Name: {cargo.ReceiverName} | - Sender City: {cargo.SenderCity} |- Delivery City: {cargo.DeliveryCity} | - Cargo Weight: {cargo.CargoWeight} KG | - Cargo Type: {cargo.CargoType} | - Cargo Price: {cargo.CargoPrice}USD \n";

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Cargo Informations:\n");
            Console.WriteLine($"- Sender Name: {cargo.SenderName} | - Receiver Name: {cargo.ReceiverName} | - Sender City: {cargo.SenderCity}| - Delivery City: {cargo.DeliveryCity} | - Cargo Weight: {cargo.CargoWeight} KG | - Cargo Type: {cargo.CargoType} | - Cargo Price: {cargo.CargoPrice}USD");
            Console.ResetColor();

            return cargoFile;
        }
    }

    public static class DirectoryTransactions // Directory Transactions Class
    {
        static string folder = @"c:/CargoDirectory";
        static string file = @"c:/CargoDirectory/cargo.txt";

        static void DirectoryControl() // Directory Control Method
        {
            try
            {
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);

                if (!File.Exists(file))
                {
                    using (File.Create(file)) { }
                    File.AppendAllText(file, "==== CARGO LOG START ====\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Directory or file creation failed: " + ex.Message);
            }
        }

        public static void CargoWrite(string cargoData) // Cargo File Write Method
        {
            DirectoryControl();

            try
            {
                if (Directory.Exists(folder) && File.Exists(file))
                {
                    File.AppendAllText(file, cargoData);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
        }

        public static void CargoDelete(string senderName, string receiverName) //Cargo Delete Method
        {
            if (Directory.Exists(folder) && File.Exists(file))
            {
                try
                {
                    var allLines = File.ReadAllLines(file).ToList();

                    var filteredLines = allLines.Where(line =>
                        !(line.Contains($"Sender Name: {senderName}") && line.Contains($"Receiver Name: {receiverName}")
                    )).ToList();

                    if (allLines.Count == filteredLines.Count)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("No matching cargo found. Nothing was deleted.");
                        Console.ResetColor();
                        return;
                    }

                    File.WriteAllLines(file, filteredLines);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Cargo deleted successfully.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error deleting cargo: " + ex.Message);
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cargo file or directory does not exist.");
                Console.ResetColor();
            }
        }
        public static void CargoView() // Cargo View Method
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                var allLines = File.ReadAllLines(file).ToList();

                foreach (var line in allLines)
                {
                    Console.WriteLine(line);
                }
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!!No record found, please try after entering the record!!!");
                Console.ResetColor();
            }
        }
    }
}
