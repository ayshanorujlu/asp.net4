using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _context;

        public HomeController(ProductDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList().Select(p =>
            {
                return new ProductViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                };
            });

            var categories=_context.Categories.ToList().Select(c =>
            {
                return new CategoryViewModel
                {
                    Title = c.Title
                };
            });

            var vm = new ProductListViewModel
            {
                Products = products,
                Categories=categories
            };
            return View(vm);
           

        }
    }
     

}