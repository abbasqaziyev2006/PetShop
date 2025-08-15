using PetShop.DataContext.Entities;

namespace PetShop.ViewComponents
{
    public class HeaderViewModel
    {
        public string? LogoUrl { get; set; }
        public List<Social> Socials { get; set; } = [];
        public WebsiteInfo? Bio { get; set; }
    }
}