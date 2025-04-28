using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }

        public ICollection<Ticket>? Tickets { get; set; }
    }
}
