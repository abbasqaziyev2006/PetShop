using PetShop.DataContext.Entities;
using PetShop.Models;

namespace PetShop.ViewComponents
{
    public class HeaderViewModel
    {
        public string? ImageUrl { get; set; }
        public List<BasketItemViewModel> BasketItems { get; set; } = [];
    }
}