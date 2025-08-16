using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShop.DataContext;
using PetShop.Models;
using PetShop.DataContext;
using PetShop.Models;


namespace PetShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ShopController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var products = _dbContext.Products.Take(3).ToList();
            var categories = _dbContext.Categories.ToList();
            ViewBag.ProductCount = _dbContext.Products.Count();


            var shopViewModel = new ShopViewModel
            {
                Products = products,
                Categories = categories
            };

            return View(shopViewModel);
        }

        public IActionResult Partial(int skip)
        {
            var products = _dbContext.Products.Skip(skip).Take(3).ToList();
            var categories = _dbContext.Categories.ToList();

            var productPartialViewModel = new ProductPartialViewModel
            {
                Products = products,
                Categories = categories
            };

            return PartialView("_ProductsPartial", productPartialViewModel);

        }


    }
}