using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;
using PetShop.Models;

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
            var socials = _dbContext.Socials.ToList();
            var bio = _dbContext.WebsiteInfo.FirstOrDefault();
            var model = new FooterViewModel
            {
                Socials = socials,
                Bio = bio

            };
            return View(model);
        }
    }
}
