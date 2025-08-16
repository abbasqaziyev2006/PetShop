using PetShop.DataContext.Entities;

namespace PetShop.ViewComponents
{
    public class HeaderViewModel
    {
        public string? LogoUrl { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public List<Category> Categories { get; set; } = [];
    }
}