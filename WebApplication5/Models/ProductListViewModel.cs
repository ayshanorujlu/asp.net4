using WebApplication5.Entities;

namespace WebApplication5.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
