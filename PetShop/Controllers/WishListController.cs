using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.DataContext;

public class WishlistController : Controller
{
    private readonly AppDbContext _dbContext;

    public WishlistController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var wishlist = GetWishlist();
        var products = _dbContext.Products
            .Where(p => wishlist.Contains(p.Id))
            .ToList();
        return View(products);
    }

    public IActionResult AddToWishlist(int id)
    {
        var wishlist = GetWishlist();
        if (!wishlist.Contains(id))
            wishlist.Add(id);

        SaveWishlist(wishlist);
        return RedirectToAction("Index", "Wishlist");
    }

    public IActionResult RemoveFromWishlist(int id)
    {
        var wishlist = GetWishlist();
        if (wishlist.Contains(id))
            wishlist.Remove(id);

        SaveWishlist(wishlist);
        return RedirectToAction("Index", "Wishlist");
    }

    private List<int> GetWishlist()
    {
        var wishlistCookie = Request.Cookies["wishlist"];
        if (string.IsNullOrEmpty(wishlistCookie))
            return new List<int>();
        return JsonConvert.DeserializeObject<List<int>>(wishlistCookie)!;
    }

    private void SaveWishlist(List<int> wishlist)
    {
        var cookieOptions = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
        Response.Cookies.Append("wishlist", JsonConvert.SerializeObject(wishlist), cookieOptions);
    }
}
