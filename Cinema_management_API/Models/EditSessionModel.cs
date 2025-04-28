

namespace Cinema_management_API.Models
{
    public class EditSessionModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int HallId { get; set; }
        public DateTime DateStart { get; set; }
        public TimeSpan TimeStart { get; set; }
        public int Price { get; set; }
        public string Status { get; set; }
    }
}
