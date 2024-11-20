using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Ticket_Application
{
    internal class Bus
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string PlateNumber { get; set; }
        public int SeatCount { get; set; }
        public Bus(int id,int companyid,string platenumber, int seatcount)
        {
            Id = id;
            CompanyId = companyid;
            PlateNumber = platenumber;
            SeatCount = seatcount;
        }
    }
}
