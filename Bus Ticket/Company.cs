using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_Ticket_Application
{
    internal class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Company(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
