using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var products = _dbContext.Products.Include(x => x.Category).Include(pt => pt.ProductTags).ThenInclude(t => t.Tag).Take(3).ToList();

            var categories = _dbContext.Categories.ToList();
            var tags = _dbContext.Tags.ToList();

            ViewBag.ProductCount = _dbContext.Products.Count();

            var shopViewModel = new ShopViewModel
            {
                Products = products
            };

            return View(shopViewModel);
        }

        public IActionResult Partial(int skip)
        {
            var products = _dbContext.Products.Include(x => x.Category).Include(pt => pt.ProductTags).ThenInclude(t => t.Tag).Skip(skip).Take(3).ToList();

            return PartialView("_ProductPartialLoadMore", products);
        }


        public IActionResult Details(int id)
        {
            var product = _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Images)
                .Include(p => p.ProductTags).ThenInclude(pt => pt.Tag)
                .FirstOrDefault(p => p.Id == id);

            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Wishlist()
        {
            var wishlistIds = GetWishlistIds();
            var products = _dbContext.Products
                .Include(p => p.Images)
                .Include(p => p.Category)
                .Where(p => wishlistIds.Contains(p.Id))
                .ToList();

            return View(products);
        }

        public IActionResult AddToWishlist(int productId)
        {
            var wishlistIds = GetWishlistIds();
            if (!wishlistIds.Contains(productId)) wishlistIds.Add(productId);
            SaveWishlist(wishlistIds);
            return Json(new { success = true });
        }

        public IActionResult RemoveFromWishlist(int productId)
        {
            var wishlistIds = GetWishlistIds();
            wishlistIds.Remove(productId);
            if (wishlistIds.Count == 0) Response.Cookies.Delete("Wishlist");
            else SaveWishlist(wishlistIds);
            return RedirectToAction("Wishlist");
        }

        private List<int> GetWishlistIds()
        {
            var cookie = Request.Cookies["Wishlist"];
            return string.IsNullOrEmpty(cookie) ? new List<int>() : cookie.Split(',').Select(int.Parse).ToList();
        }

        private void SaveWishlist(List<int> ids)
        {
            Response.Cookies.Append("Wishlist", string.Join(",", ids),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(30) });
        }
    }
}

