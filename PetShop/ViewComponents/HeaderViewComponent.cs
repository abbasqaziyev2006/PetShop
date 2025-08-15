using Microsoft.AspNetCore.Mvc;
using PetShop.DataContext;
using PetShop.DataContext.Entities;

namespace PetShop.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _dbContext;

        public HeaderViewComponent(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var socials = _dbContext.Socials.ToList();
            var websiteInfos = _dbContext.WebsiteInfo.FirstOrDefault();
            var model = new HeaderViewModel
            {
                Socials = socials,
                WebsiteInfos = websiteInfos,

            };
            return View(model);

        }
    }
}
