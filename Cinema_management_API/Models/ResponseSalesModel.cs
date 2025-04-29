using DataAccess.Entities;

namespace Cinema_management_API.Models
{
    public class ResponseSalesModel
    {
        public int UserId { get; set; }
        public int AmountOfTickets { get; set; }
        public int SumOfPayment { get; set; }

        public DateTime DatePurchase { get; set; }
    }
}
