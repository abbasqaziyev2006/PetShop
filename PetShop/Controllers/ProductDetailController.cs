using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;
using PetShop.Models;
using PetShop.DataContext;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductDetailsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var sliders = _dbContext.Sliders.ToList();
            var categories = _dbContext.Categories.ToList();
            var products = _dbContext.Products.ToList();

            var productDetailsViewModel = new ProductDetailsViewModel
            {
                Sliders = sliders,
                Categories = categories,
                Products = products
            };

            return View(productDetailsViewModel);
        }
    }
}