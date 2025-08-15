using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    public class FooterViewModel
    {
        public List<Social> Socials { get; set; } = [];
        public WebsiteInfo? Bio { get; set; }
    }
}