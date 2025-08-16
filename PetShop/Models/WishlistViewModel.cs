using Microsoft.AspNetCore.Mvc;

namespace PetShop.Models
{
    public class WishlistViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
