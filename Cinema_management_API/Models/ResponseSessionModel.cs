

namespace Cinema_management_API.Models
{
    public class ResponseSessionModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int HallId { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}
