using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Ticket_Application
{
    internal class Program
    {
        static List<Company> companies = new List<Company>()
        {
            new Company(1, "Kamil Koc"),
            new Company(2, "Pamukkale"),
            new Company(3, "Ulusoy")
        };

        static List<Bus> buses = new List<Bus>()
        {
           new Bus(1,1,"41 jk 854",40),
           new Bus(2,1,"58 rf 412",40),
           new Bus(3,2,"34 pl 916",40),
           new Bus(4,2,"57 asf 432",40),
           new Bus(5,3,"55 lp 651",40),
           new Bus(6,3,"66 tk 523",40)
        };
        static List<Voyage> voyages = new List<Voyage>()
        {
            Voyage.CreateVoyage(1,1,Convert.ToDateTime("11.13.2024 09:00")),
            Voyage.CreateVoyage(2,2,Convert.ToDateTime("11.14.2024 09:00")),
            Voyage.CreateVoyage(3,3,Convert.ToDateTime("11.13.2024 09:00")),
            Voyage.CreateVoyage(4,4,Convert.ToDateTime("11.14.2024 09:00")),
            Voyage.CreateVoyage(5,6,Convert.ToDateTime("11.14.2024 09:00")),
            Voyage.CreateVoyage(6,5,Convert.ToDateTime("11.15.2024 09:00"))
        };
        static List<Customer> customers = new List<Customer>();

        static List<Reservation> reservations = new List<Reservation>();

        static void Main(string[] args)//MAIN
        {
            bool control = true;

            while (control)
            {
                string choiceResult = Login();
                if (choiceResult == "1")
                {
                    ReservationAdd();
                }
                else if (choiceResult == "2")
                {
                    Console.Write("Enter Your Customer ID: ");
                    int customerid = Convert.ToInt32(Console.ReadLine());
                    ReservationShow(customerid);
                }
                else if (choiceResult == "3")
                {
                    Console.WriteLine("Exiting...");
                    control = false;
                }
                else
                {
                    Console.WriteLine("\nWARNING: Please enter a valid parameter!!!");
                }
            }
            Console.ReadLine();
        }

        private static string Login()//LOGIN METHOD
        {
            Console.WriteLine("1- Make a Resevation");
            Console.WriteLine("2- Show the My Reservation");
            Console.WriteLine("3- Exit");

            Console.Write("\nYour Choice: ");
            string choice = Console.ReadLine();
            return choice;
        }

        public static void SearchVoyage(DateTime date)//SEARCH VOYAGE METHOD
        {
            for (int index = 0; index < voyages.Count; index++)
            {
                var voyage = voyages[index];
                if (date == voyage.VoyageDate)
                {
                    for (int innerIndex = 0; innerIndex < buses.Count; innerIndex++)
                    {
                        var bus = buses[innerIndex];
                        if (voyage.BusId == bus.Id)
                        {
                            for (int k = 0; k < companies.Count; k++)
                            {
                                var company = companies[k];

                                if (bus.CompanyId == company.Id)
                                {
                                    Console.WriteLine("Voyage id: {0}, Voyage Date: {1}, BusPlate: {2}, Company: {3}", voyage.Id, voyage.VoyageDate, bus.PlateNumber, company.Name);
                                }
                            }
                        }
                    }
                }

            }
        }

        public static void CustomerAdd() //CUSTOMER ADD METHOD
        {
            Console.Write("Please enter the your id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (customers.Any(x => x.Id == id))
            {
                Console.WriteLine("\nWARNING: A customer with the same ID already exists!!!");
            }
            else
            {
                Console.Write("Please enter the your identy number: ");
                Int64 identResult = Convert.ToInt64(Console.ReadLine());
                if (customers.Any(x => x.IdentyNumber == identResult))
                {
                    Console.WriteLine("\nWARNING: A customer with the same identy number already exists!!!");
                }
                else
                {
                    Console.Write("Please Enter your name: ");
                    string nameResult = Console.ReadLine();

                    var newcustomer = new Customer(id, identResult, nameResult);
                    customers.Add(newcustomer);
                    Console.WriteLine("\n***INFO: New customer added succesfully***");
                }
            }
        }

        public static void ReservationAdd()//RESERVATION ADD METHOD
        {
            Console.Write("Please enter your user ID: ");
            int firstcustomerid = Convert.ToInt32(Console.ReadLine());

            if (!customers.Any(x => x.Id == firstcustomerid))
            {
                Console.WriteLine("\nWARNING: You are not registered, redirecting you to create a new user...");
                CustomerAdd();


            }
            else if (customers.Any(x => x.Id == firstcustomerid) && !reservations.Any(y => y.CustomerId == firstcustomerid))
            {
                Console.WriteLine("Please enter the date format as \"MM.dd.yyyy HH:mm\"");
                Console.Write("Plase enter a date?: ");
                DateTime date = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("\nAVAILABLE VOYAGES: ");
                SearchVoyage(date);

                Console.Write("\nEnter the voyage number: ");
                int voyageid = Convert.ToInt32(Console.ReadLine());
                if (!voyages.Any(x => x.VoyageDate == date && x.Id == voyageid))
                {
                    Console.WriteLine("\nWARNING: We don't have a trip like this!!!");
                }
                else
                {
                    Console.Write("Enter the seat number: ");
                    int seatnumber = Convert.ToInt32(Console.ReadLine());
                    if (!reservations.Any(x => x.SeatNumber == seatnumber))
                    {

                        if (buses.Any(x => x.SeatCount < seatnumber))
                        {
                            Console.WriteLine("\nWARNING: Our buses consist of 40 seats!!!");
                        }
                        else
                        {
                            Console.Write("Enter your user ID: ");
                            int customerid = Convert.ToInt32(Console.ReadLine());
                            if (reservations.Any(x => x.CustomerId == customerid))
                            {
                                Console.WriteLine("\nWARNING: This user already has a reservation for this voyage!!!");
                            }
                            else
                            {
                                var newReservation = new Reservation(voyageid, seatnumber, customerid);
                                reservations.Add(newReservation);
                                Console.WriteLine("\n***INFO: New reservation created succesfully***");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nWARNING: This seat already taken!!!");
                    }
                }
            }
            else if (customers.Any(x => x.Id == firstcustomerid) && reservations.Any(y => y.CustomerId == firstcustomerid))
            {
                Console.WriteLine("\nWARNING: Each user can make a reservation once!!!");
            }


        }

        public static void ReservationShow(int customerid)//RESERVATION SHOW METHOD
        {
            var customerReservations = reservations.Where(x => x.CustomerId == customerid).ToList();

            if (customerReservations.Any())
            {
                foreach (var reservation in customerReservations)
                {
                    var voyage = voyages.FirstOrDefault(v => v.Id == reservation.VoyageId);

                    if (voyage != null)
                    {
                        var bus = buses.FirstOrDefault(b => b.Id == voyage.BusId);

                        if (bus != null)
                        {
                            var company = companies.FirstOrDefault(c => c.Id == bus.CompanyId);

                            if (company != null)
                            {

                                Console.WriteLine("\nReservation: Company: {0}, BusPlate: {1}, SeatNumber: {2}, Date: {3}", company.Name, bus.PlateNumber, reservation.SeatNumber, voyage.VoyageDate);

                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("\nWARNING: You do not have any reservations!!!");
            }
        }
    }
}




