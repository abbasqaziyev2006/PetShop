using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            var sliders = _dbContext.Sliders.ToList();
            var categories = _dbContext.Categories.ToList();
            var products = _dbContext.Products.ToList();
            var productTags = _dbContext.ProductTags.ToList();
            var productImages = _dbContext.ProductImages.ToList();
            var tags = _dbContext.Tags.ToList();

            var homeViewModel = new HomeViewModel
            {
                Sliders = sliders,
                Categories = categories,
                Products = products,
                ProductTags = productTags,
                ProductImages = productImages,
                Tags = tags
            };


            return View(homeViewModel);
        }


    }
}