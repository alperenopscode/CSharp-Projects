using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Factory_Registration_System
{
    internal class Employees
    {
        private static string userResult;
        public static void AddEmployee()//Add Employee Method
        {
        BACKTOTOP:
            Console.Write("Which department do you want to add employees to: ");
            userResult = Console.ReadLine().ToLower();
            if (!string.IsNullOrEmpty(userResult) && userResult == "desinger")
                Desinger.desingerAdd();
            else if (!string.IsNullOrEmpty(userResult) && userResult == "production")
                Production.productionAdd();
            else if (!string.IsNullOrEmpty(userResult) && userResult == "tester")
                Tester.testerAdd();
            else
            {
                Console.WriteLine("\nWARNING:You entered wrong!!!");
                goto BACKTOTOP;
            }
        }
        public static void DeleteEmployee()//Delete Employee Method
        {
        BACKTOTOP:
            Console.Write("Which department do you want to delete employees from: ");
            userResult = Console.ReadLine().ToLower();
            if (!string.IsNullOrEmpty(userResult) && userResult == "desinger")
                Desinger.desingerDelete();
            else if (!string.IsNullOrEmpty(userResult) && userResult == "production")
                Production.productionDelete();
            else if (!string.IsNullOrEmpty(userResult) && userResult == "tester")
                Tester.testerDelete();
            else
            {
                Console.WriteLine("\nWARNING:You entered wrong!!!");
                goto BACKTOTOP;
            }
        }
        public static void UpdateEmployee()//Update Employee Method
        {
        BACKTOTOP:
            Console.Write("\nINFO: Which department employee do you want to update: ");
            userResult = Console.ReadLine().ToLower();
            if (!string.IsNullOrEmpty(userResult) && userResult == "desinger")
                Desinger.desingerUpdate();
            else if (!string.IsNullOrEmpty(userResult) && userResult == "production")
                Production.productionUpdate();
            else if (!string.IsNullOrEmpty(userResult) && userResult == "tester")
                Tester.testerUpdate();
            else
            {
                Console.WriteLine("\nWARNING:You entered wrong!!!");
                goto BACKTOTOP;
            }

        }
    }
    static class Desinger //Desinger Class
    {
        private static int DesingerID { get; set; }
        private static string DesingerName { get; set; }
        private static string DesingerPhone { get; set; }
        private static string DesingerAdress { get; set; }

        public static void desingerAdd()//Desinger Add Method
        {
        DESINGERINFO:
            Console.Write("\nWhat is the ID of the DESINGER: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                DesingerID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Desinger\" + DesingerID + ".txt";
                if (!File.Exists(filePath))
                {
                    Console.Write("\nWhat is the Name of the DESINGER: ");
                    DesingerName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(DesingerName))
                    {
                        Console.Write("\nWhat is the Phone number of the DESINGER, without 0: ");
                        DesingerPhone = Console.ReadLine();
                        if (!string.IsNullOrEmpty(DesingerPhone))
                        {
                            Console.Write("\nWhat is the Adress of the DESINGER: ");
                            DesingerAdress = Console.ReadLine();
                            if (!string.IsNullOrEmpty(DesingerAdress))
                            {
                                File.Create(filePath).Close();

                                string[] DesingerInfo = { "ID:" + DesingerID, "Name: " + DesingerName, "Phone Number: " + DesingerPhone, "Adress: " + DesingerAdress };
                                File.WriteAllLines(filePath, DesingerInfo);
                                Console.Clear();
                                Console.WriteLine("\nINFO: File was created and information was saved");
                            }
                            else
                            {
                                Console.WriteLine("\nWARNING: Adress cannot be empty!!!");
                                goto DESINGERINFO;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWARNING: Phone Number cannot be empty!!!");
                            goto DESINGERINFO;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: Name cannot be empty!!!");
                        goto DESINGERINFO;
                    }
                }
                else
                {
                    Console.WriteLine("\nWARNING: There is already such an employee!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING:ID cannot be empty!!!");
                goto DESINGERINFO;
            }
        }
        public static void desingerDelete()//Desinger Delete Method
        {
            Console.Write("\nEnter the ID of the DESINGER you want to delete: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                DesingerID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Desinger\" + DesingerID + ".txt";
                if (File.Exists(filePath))
                {
                    Console.Clear();
                    Console.WriteLine("\nINFO: File is deleted");
                    File.Delete(filePath);
                }
                else
                {
                    Console.WriteLine("\nWARNING: There is no employee belonging to this id!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
            }

        }
        public static void desingerUpdate()//Desinger Update Method
        {
            Console.Write("\nEnter the ID of the DESINGER you want to update: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                DesingerID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Desinger\" + DesingerID + ".txt";
                if (File.Exists(filePath))
                {
                    string[] fileContent = File.ReadAllLines(filePath);
                    Console.WriteLine("\n*** Information of worker ***");
                    foreach (string line in fileContent)
                    {
                        Console.WriteLine(line);
                    }

                BACKTOTOP:
                    Console.Write("\nWhat information do you want to update(phone,adress) , Type CANCEL to exit the update: ");
                    string userResult = Console.ReadLine().ToLower();
                    if (!string.IsNullOrEmpty(userResult) && userResult == "phone")
                    {
                        Console.Write("\nNew Phone (without 0): ");
                        DesingerPhone = Console.ReadLine();
                        fileContent[2] = $"Phone: {DesingerPhone}";
                        File.WriteAllLines(filePath, fileContent);
                        Console.Clear();
                        Console.WriteLine("\nINFO: The phone has been updated successfully");
                        goto BACKTOTOP;
                    }
                    else if (!string.IsNullOrEmpty(userResult) && userResult == "adress")
                    {
                        Console.Write("\nNew Adress: ");
                        DesingerAdress = Console.ReadLine();
                        fileContent[3] = $"Adress: {DesingerAdress}";
                        File.WriteAllLines(filePath, fileContent);
                        Console.Clear();
                        Console.WriteLine("\nINFO: The adress has been updated successfully");
                        goto BACKTOTOP;
                    }
                    else if (userResult == "cancel")
                    {
                        Console.Clear();
                        Console.WriteLine("\nINFO: Exited from update screen!!!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nWarning: You wrote an incorrect or incomplete transaction!!!");
                        goto BACKTOTOP;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: There is no such employee!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
            }

        }
    }
    static class Production//Production Class
    {
        private static int ProductionID { get; set; }
        private static string ProductionName { get; set; }
        private static string ProductionPhone { get; set; }
        private static string ProductionAdress { get; set; }

        public static void productionAdd()//Production Add Method
        {
        PRODUCTIONINFO:
            Console.Write("\nWhat is the ID of the PRODUCTION: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                ProductionID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Production\" + ProductionID + ".txt";
                if (!File.Exists(filePath))
                {
                    Console.Write("\nWhat is the Name of the PRODUCTION: ");
                    ProductionName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(ProductionName))
                    {
                        Console.Write("\nWhat is the Phone number of the PRODUCTION, without 0: ");
                        ProductionPhone = Console.ReadLine();
                        if (!string.IsNullOrEmpty(ProductionPhone))
                        {
                            Console.Write("\nWhat is the Adress of the PRODUCTION: ");
                            ProductionAdress = Console.ReadLine();
                            if (!string.IsNullOrEmpty(ProductionAdress))
                            {
                                File.Create(filePath).Close();

                                string[] ProductionInfo = { "ID:" + ProductionID, "Name: " + ProductionName, "Phone Number: " + ProductionPhone, "Adress: " + ProductionAdress };
                                File.WriteAllLines(filePath, ProductionInfo);
                                Console.Clear();
                                Console.WriteLine("\nINFO: File was created and information was saved");
                            }
                            else
                            {
                                Console.WriteLine("\nWARNING: Adress cannot be empty!!!");
                                goto PRODUCTIONINFO;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWARNING: Phone Number cannot be empty!!!");
                            goto PRODUCTIONINFO;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: Name cannot be empty!!!");
                        goto PRODUCTIONINFO;
                    }
                }
                else
                {
                    Console.WriteLine("\nWARNING: There is already such an employee!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
                goto PRODUCTIONINFO;
            }
        }
        public static void productionDelete()//Production Delete Method
        {
            Console.Write("\nINFO: Enter the ID of the PRODUCTION you want to delete: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                ProductionID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Production\" + ProductionID + ".txt";
                if (File.Exists(filePath))
                {
                    Console.Clear();
                    Console.WriteLine("\nINFO: File is deleted");
                    File.Delete(filePath);
                }
                else
                {
                    Console.WriteLine("\nWARNING: There is no employee belonging to this id!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
            }

        }
        public static void productionUpdate()//Production Update Method
        {
            Console.Write("\nINFO: Enter the ID of the PRODUCTION you want to update: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                ProductionID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Production\" + ProductionID + ".txt";
                if (File.Exists(filePath))
                {
                    string[] fileContent = File.ReadAllLines(filePath);
                    Console.WriteLine("\n*** Information of worker ***");
                    foreach (string line in fileContent)
                    {
                        Console.WriteLine(line);
                    }

                BACKTOTOP:
                    Console.Write("\nWhat information do you want to update(phone,adress) , Type CANCEL to exit the update: ");
                    string userResult = Console.ReadLine().ToLower();
                    if (!string.IsNullOrEmpty(userResult) && userResult == "phone")
                    {
                        Console.Write("\nNew Phone (without 0): ");
                        ProductionPhone = Console.ReadLine();
                        fileContent[2] = $"Phone: {ProductionPhone}";
                        File.WriteAllLines(filePath, fileContent);
                        Console.Clear();
                        Console.WriteLine("\nINFO: The phone has been updated successfully");
                        goto BACKTOTOP;
                    }
                    else if (!string.IsNullOrEmpty(userResult) && userResult == "adress")
                    {
                        Console.Write("\nNew Adress: ");
                        ProductionAdress = Console.ReadLine();
                        fileContent[3] = $"Adress: {ProductionAdress}";
                        File.WriteAllLines(filePath, fileContent);
                        Console.Clear();
                        Console.WriteLine("\nINFO: The adress has been updated successfully");
                        goto BACKTOTOP;
                    }
                    else if (userResult == "cancel")
                    {
                        Console.Clear();
                        Console.WriteLine("\nINFO: Exited from update screen!!!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nWarning: You wrote an incorrect or incomplete transaction!!!");
                        goto BACKTOTOP;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: There is no such employee!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
            }
        }
    }
    static class Tester//Tester Class
    {
        private static int TesterID { get; set; }
        private static string TesterName { get; set; }
        private static string TesterPhone { get; set; }
        private static string TesterAdress { get; set; }
        public static void testerAdd()//Tester Add Method
        {
        TESTERINFO:
            Console.Write("\nWhat is the ID of the TESTER: ");
            string ID = Console.ReadLine();

            if (!string.IsNullOrEmpty(ID))
            {
                TesterID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Tester\" + TesterID + ".txt";
                if (!File.Exists(filePath))
                {
                    Console.Write("\nWhat is the Name of the TESTER: ");
                    TesterName = Console.ReadLine();
                    if (!string.IsNullOrEmpty(TesterName))
                    {
                        Console.Write("\nWhat is the Phone number of the TESTER, without 0: ");
                        TesterPhone = Console.ReadLine();
                        if (!string.IsNullOrEmpty(TesterPhone))
                        {
                            Console.Write("\nWhat is the Adress of the TESTER: ");
                            TesterAdress = Console.ReadLine();
                            if (!string.IsNullOrEmpty(TesterAdress))
                            {
                                File.Create(filePath).Close();

                                string[] TesterInfo = { "ID:" + TesterID, "Name: " + TesterName, "Phone Number: " + TesterPhone, "Adress: " + TesterAdress };
                                File.WriteAllLines(filePath, TesterInfo);
                                Console.Clear();
                                Console.WriteLine("\nINFO: File was created and information was saved");
                            }
                            else
                            {
                                Console.WriteLine("\nWARNING: Adress cannot be empty!!!");
                                goto TESTERINFO;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nWARNING: Phone Number cannot be empty!!!");
                            goto TESTERINFO;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: Name cannot be empty!!!");
                        goto TESTERINFO;
                    }
                }
                else
                {
                    Console.WriteLine("\nWARNING: There is already such an employee!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
                goto TESTERINFO;
            }
        }
        public static void testerDelete()//Tester Delete Method
        {
            Console.Write("\nEnter the ID of the TESTER you want to delete: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                TesterID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Tester\" + TesterID + ".txt";
                if (File.Exists(filePath))
                {
                    Console.Clear();
                    Console.WriteLine("\nINFO: File is deleted");
                    File.Delete(filePath);
                }
                else
                {
                    Console.WriteLine("\nWARNING: There is no employee belonging to this id!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
            }
        }
        public static void testerUpdate()//Tester Update Method
        {
            Console.Write("\nINFO: Enter the ID of the TESTER you want to update: ");
            string ID = Console.ReadLine();
            if (!string.IsNullOrEmpty(ID))
            {
                TesterID = Convert.ToInt32(ID);
                string filePath = @"c:\FactoryDirectory\Tester\" + TesterID + ".txt";
                if (File.Exists(filePath))
                {
                    string[] fileContent = File.ReadAllLines(filePath);
                    Console.WriteLine("\n*** Information of worker ***");
                    foreach (string line in fileContent)
                    {
                        Console.WriteLine(line);
                    }

                BACKTOTOP:
                    Console.Write("\nWhat information do you want to update(phone,adress) , Type CANCEL to exit the update: ");
                    string userResult = Console.ReadLine().ToLower();
                    if (!string.IsNullOrEmpty(userResult) && userResult == "phone")
                    {
                        Console.Write("\nNew Phone (without 0): ");
                        TesterPhone = Console.ReadLine();
                        fileContent[2] = $"Phone: {TesterPhone}";
                        File.WriteAllLines(filePath, fileContent);
                        Console.Clear();
                        Console.WriteLine("\nINFO: The phone has been updated successfully");
                        goto BACKTOTOP;
                    }
                    else if (!string.IsNullOrEmpty(userResult) && userResult == "adress")
                    {
                        Console.Write("\nNew Adress: ");
                        TesterAdress = Console.ReadLine();
                        fileContent[3] = $"Adress: {TesterAdress}";
                        File.WriteAllLines(filePath, fileContent);
                        Console.Clear();
                        Console.WriteLine("\nINFO: The adress has been updated successfully");
                        goto BACKTOTOP;
                    }
                    else if (userResult == "cancel")
                    {
                        Console.Clear();
                        Console.WriteLine("\nINFO: Exited from update screen!!!");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\nWarning: You wrote an incorrect or incomplete transaction!!!");
                        goto BACKTOTOP;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nWARNING: There is no such employee!!!");
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: ID cannot be empty!!!");
            }
        }
    }
}
