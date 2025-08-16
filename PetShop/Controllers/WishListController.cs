using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;
using PetShop.DataContext;

namespace PetShop.Controllers
{
    public class WishlistController : Controller
    {
        private readonly AppDbContext _dbContext;

        public WishlistController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}