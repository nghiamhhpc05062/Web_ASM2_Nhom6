using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_ASM_Nhom6.Models;
using Web_ASM_Nhom6.Service;

namespace Web_ASM_Nhom6.Controllers
{
    public class PaymentsController : Controller
    {
        public IActionResult Index()
        {
            SProduct getCart = HttpContext.Session.GetObject<SProduct>("SProduct");
            if (getCart != null)
            {
                return View(getCart.Products);
            }
            else
            {
                return View(new List<Product>());
            }
        }
    }
}
