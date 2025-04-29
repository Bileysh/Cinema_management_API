namespace Cinema_management_API.Models
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int NumberOfBonuses { get; set; }
        public int? DiscountId { get; set; }
    }
}
