using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetShop.DataContext;
using PetShop.Models;
using PetShop.ViewComponents;
using static PetShop.Controllers.BasketController;

namespace PetShop.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public const string BASKET_Key = "basket";
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logo = await _dbContext.Logos.FirstOrDefaultAsync();
            var basketItems = GetBasket();
            var headerViewModel = new HeaderViewModel
            {
                ImageUrl = logo?.LogoUrl,
                BasketItems = basketItems
            };


            return View(headerViewModel);
        }
        public List<BasketItemViewModel> GetBasket()
        {
            var basketCookie = Request.Cookies[BASKET_Key];
            var basket = new List<BasketItem>();
            if (!string.IsNullOrEmpty(basketCookie))
            {
                basket = JsonConvert.DeserializeObject<List<BasketItem>>(basketCookie) ?? [];
            }

            var basketItemViewModel = new List<BasketItemViewModel>();
            foreach (var item in basket)
            {
                var product = _dbContext.Products.Find(item.ProductId);
                if (product == null) continue;
                {
                    basketItemViewModel.Add(new BasketItemViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Price = product.Price,
                        Count = item.Count,

                    });
                }
            }
            return basketItemViewModel;
        }
    }
}