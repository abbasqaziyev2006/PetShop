using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    public class ShopViewModel
    {
        public List<Product> Products { get; internal set; }
        public List<Category> Categories { get; internal set; }
        public List<Tag> Tags { get; internal set; }
    }
}
