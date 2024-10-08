using Microsoft.AspNetCore.Mvc;
using web_cake.Models;

namespace web_cake.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            var payment = new Shipping()
            {
                OrderId = 1,
                ShippingCost = 800,
                ShippingMethod = "",
                ShippingStatus = "",
                TrackingNumber = "AA12548549616514"
            };
            return View(payment);
        }
    }
}
