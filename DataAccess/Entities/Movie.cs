using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public DateTime YearRealise { get; set; }
        public int AgeRestrictions { get; set; }
        public string Description { get; set; }

        public ICollection<Session>? Sessions { get; set; }
    }
}
