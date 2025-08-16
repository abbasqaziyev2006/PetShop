using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    public class ProductPartialViewModel
    {
        public List<Category> Categories { get; set; } = [];
        public List<Product> Products { get; set; } = [];
    }
}