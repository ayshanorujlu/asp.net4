using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication5.Data;

namespace WebApplication5.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly ProductDbContext _context;

        public IndexModel(ProductDbContext context)
        {
            _context = context;
        }

        public List<Entities.Product> Products { get; set; }
        public void OnGet(string info = "")
        {
            Products = _context.Products.ToList();
            Info = info;
        }

        public string Info { get; set; }

        [BindProperty]
        public Entities.Product Product { get; set; }

        public IActionResult OnPost()
        {
            _context.Products.Add(Product);
            _context.SaveChanges();
            Info = $"{Product.Name} added successfully";
            return RedirectToPage("Index", new {info=Info});
        }

        public IActionResult OnPostDelete(int id)
        {
            var recentProduct = _context.Products.Find(id);
            if (recentProduct == null)
            {
                return NotFound();
            }

            _context.Products.Remove(recentProduct);
            Info = $"{recentProduct.Name} deleted successfully";
            _context.SaveChanges();

            return RedirectToPage("Index", new { info = Info });
        }
    }
}
