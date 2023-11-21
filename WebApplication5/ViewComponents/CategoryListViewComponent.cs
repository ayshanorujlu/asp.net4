using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ProductDbContext _context;

        public CategoryListViewComponent(ProductDbContext context)
        {
            _context = context;
        }

        public ViewViewComponentResult Invoke()
        {
            var categories= _context.Categories.ToList().Select(c =>
            {
                return new CategoryViewModel
                {
                    Title = c.Title
                };
            });
            return View(
                new CategoryListViewModel
                {
                    Categories=categories.ToList()
                }

                );
        }
    }
}
