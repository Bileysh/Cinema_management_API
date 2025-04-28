

namespace Cinema_management_API.Models
{
    public class EditMovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public DateTime YearRealise { get; set; }
        public int AgeRestrictions { get; set; }
        public string Description { get; set; }
    }
}
