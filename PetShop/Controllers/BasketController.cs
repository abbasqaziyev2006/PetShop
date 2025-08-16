using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShop.DataContext;

namespace PetShop.Controllers
{
    public class BasketController : Controller
    {
        public const string BASKET_Key = "basket";
        private readonly AppDbContext _dbContext;

        public BasketController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddToBasket(int? id)
        {
            if (id == null) return BadRequest();

            if (_dbContext.Products.Find(id) == null) return BadRequest();

            var basket = GetBasket();
            var existBasketItemIndex = basket.FindIndex(x => x.ProductId == id);

            if (existBasketItemIndex == -1) basket.Add(new BasketItem { ProductId = id.Value });
            else basket[existBasketItemIndex].Count++;

            var jsonBasket = JsonConvert.SerializeObject(basket);

            Response.Cookies.Append(BASKET_Key, jsonBasket);

            return RedirectToAction("Index", "Home");

        }







        public List<BasketItem> GetBasket()
        {
            var basketCookie = Request.Cookies[BASKET_Key];
            var basket = new List<BasketItem>();
            if (!string.IsNullOrEmpty(basketCookie))
            {
                basket = JsonConvert.DeserializeObject<List<BasketItem>>(basketCookie) ?? [];
            }
            return basket;
        }

        public class BasketItem
        {
            public int ProductId { get; set; }
            public int Count { get; set; } = 1;
        }



    }

}