using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_cake.Models;
using web_cake.Data;

namespace web_cake.Controllers
{
    public class CartController : Controller
    {

        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int id = 1;
            var cart = await _context.GetCart(id);

            return View(cart);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(int CustomerId, int ProductId, int quantity)
        {
            var cart = await _context.EditCart( "Del",1,ProductId,0);

            if (cart == null)
            {
                return NotFound();
            }

            return View("~/Views/Cart/Index.cshtml",cart);
        }


        [HttpPost("UpdateCart")]
        public async Task<IActionResult> UpdateCart([FromBody] CartUpdate request)
        {
            var cart = await _context.EditCart("Upd", 1, request.ProductId, request.Quantity);


            return Json(new { success = true });
        }

        [HttpPost("CheckOut")]
        public async Task<IActionResult> CheckOut(int CustomerId, int ProductId, int quantity)
        {
            var cart = await _context.EditCart("Del", 1, ProductId, 0);


            return Redirect("~/Payment");
        }
    }
}
