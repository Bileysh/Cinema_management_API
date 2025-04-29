namespace Cinema_management_API.Models
{
    public class ResponseUserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public int NumberOfBonuses { get; set; }
        public string PromotionalOffer { get; set; }
        public int DiscountForRegularCustomers { get; set; }

    }
}
