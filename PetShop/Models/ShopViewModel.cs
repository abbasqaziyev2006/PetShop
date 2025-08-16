using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    public class ShopViewModel
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Tag> Tags { get; set; } = new List<Tag>();  
    }

}

