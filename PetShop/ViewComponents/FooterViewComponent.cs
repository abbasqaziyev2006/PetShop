using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;
using PetShop.DataContext.Entities;
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
            var websiteInfos = _dbContext.WebsiteInfo.FirstOrDefault();
            var model = new FooterViewModel
            {
                Socials = socials,
                WebsiteInfos = websiteInfos

            };
            return View(model);
        }
    }
}
