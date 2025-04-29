using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Sales
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AmountOfTickets { get; set; }
        public int SumOfPayment { get; set; }
        public DateTime DatePurchase { get; set; }
    }
}
