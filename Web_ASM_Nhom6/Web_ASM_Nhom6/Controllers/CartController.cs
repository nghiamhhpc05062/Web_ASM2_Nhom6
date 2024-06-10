using Microsoft.AspNetCore.Mvc;

namespace Web_ASM_Nhom6.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddToCart()
        {
            return View();
        }
    }
}
