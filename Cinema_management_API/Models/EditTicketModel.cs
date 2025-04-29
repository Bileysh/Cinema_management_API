namespace Cinema_management_API.Models
{
    public class EditTicketModel
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public int Place { get; set; }
        public string Status { get; set; }
    }
}
