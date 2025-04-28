using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Session Session { get; set; }
        public int Place { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        public User? User { get; set; }

    }
}
