namespace Cinema_management_API.Models
{
    public class ResponseTicketModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int HallName { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public int Price { get; set; }
        public int Place { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

    }
}
