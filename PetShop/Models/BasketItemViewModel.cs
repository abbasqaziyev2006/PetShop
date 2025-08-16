namespace PetShop.Models
{
    public class BasketItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Count { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
