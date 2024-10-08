using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_cake.Data;

namespace web_cake.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.GetProductsAsync(""); // 確保這個方法能正確獲取所有產品
            return View(products);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Cart(int CustomerId,int ProductId,int quantity)
        {
            var cart = await _context.EditCart("Add",1, ProductId, quantity);

            if (cart == null)
            { 
                return NotFound();
            }

            return Redirect("~/Cart");
        }

    }
}
