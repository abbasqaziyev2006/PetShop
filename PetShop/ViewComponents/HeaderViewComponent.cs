using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var logo = await _dbContext.Logos.FirstOrDefaultAsync();
            var contactInfo = await _dbContext.ContactInfos.FirstOrDefaultAsync();
            var categories = await _dbContext.Categories.ToListAsync();

            var model = new HeaderViewModel
            {
                LogoUrl = logo?.LogoPath,
                Phone = contactInfo?.Phone ?? string.Empty,
                Email = contactInfo?.Email ?? string.Empty,
                Categories = categories
            };

            return View(model);
        }
    }
}

