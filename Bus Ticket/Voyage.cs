using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Ticket_Application
{
    internal class Voyage
    {
        public int Id { get; private set; }
        public int BusId { get; private set; }
        public DateTime VoyageDate { get; private set; }
        private Voyage(int id, int busid, DateTime date)
        {
            Id = id;
            BusId = busid;
            VoyageDate = date;
        }
        public static Voyage CreateVoyage(int id, int busid, DateTime date)
        {
            return new Voyage(id, busid, date);
        }
    }
}
