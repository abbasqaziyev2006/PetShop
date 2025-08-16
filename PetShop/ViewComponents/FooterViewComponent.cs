using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;

namespace PetShop.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public FooterViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}