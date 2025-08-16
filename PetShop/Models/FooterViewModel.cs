using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    public class FooterViewModel
    {
        public string? LogoUrl { get; set; }
        public List<Social> Socials { get; set; } = [];
        public WebsiteInfo? WebsiteInfos { get; set; }
    }
}