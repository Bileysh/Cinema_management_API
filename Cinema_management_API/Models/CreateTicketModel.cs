namespace Cinema_management_API.Models
{
    public class CreateTicketModel
    {
        public int SessionId { get; set; }
        public int Place { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }

    }
}
