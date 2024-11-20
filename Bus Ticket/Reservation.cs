using Bus_Ticket_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Ticket_Application
{
    internal class Reservation
    {
        public int Id { get; set; }
        public int VoyageId { get; set; }
        public int SeatNumber { get; set; }
        public int CustomerId { get; set; }

        private static Random R = new Random();
        public Reservation(int voyageid, int seatnumber, int customerid)
        {
            Id = R.Next(1, 50);
            VoyageId = voyageid;
            SeatNumber = seatnumber;
            CustomerId = customerid;
        }
    }
}


