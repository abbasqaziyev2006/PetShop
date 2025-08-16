using PetShop.DataContext.Entities;

namespace PetShop.ViewComponents
{
    public class HeaderViewModel
    {
        public Bio? Bios { get; set; }
        public List<Slider> Sliders { get; set; } = [];
        public List<Social> Socials { get; set; } = [];
    }
}