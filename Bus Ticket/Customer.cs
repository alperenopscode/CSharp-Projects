using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Ticket_Application
{
    internal class Customer
    {
        public int Id { get; set; }
        public Int64 IdentyNumber { get; set; }
        public string Name { get; set; }
        public Customer(int id, Int64 idnumber, string name)
        {
            Id = id;
            IdentyNumber = idnumber;
            Name = name;
        }
    }
}
