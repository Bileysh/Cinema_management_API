using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int NumberOfBonuses { get; set; }

        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public ICollection<Sales>? Sales { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
