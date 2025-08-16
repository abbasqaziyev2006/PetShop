using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    public class FooterViewModel
    {
        public string? LogoUrl { get; set; }
        public List<Social> Socials { get; set; } = [];
        public Bio? Bios { get; internal set; }
    }
}