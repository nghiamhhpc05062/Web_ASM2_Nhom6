using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;
using Web_ASM_Nhom6.Models;
using Web_ASM_Nhom6.Service;

namespace Web_ASM_Nhom6.Controllers
{
    public class CartController : Controller
    {

        private readonly string url = "http://localhost:29015/api/Product";
        public async Task<IActionResult> Index()
        {
            if(SUser.User == null)
            {
                return RedirectToAction("Login", "Login");
            }
            int? productId = HttpContext.Session.GetInt32("ProductId");
            List<Product> listPro = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listPro = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }

            var prod = listPro.SingleOrDefault(a => a.ProductId == productId);
            SProduct sproduct = HttpContext.Session.GetObject<SProduct>("SProduct");
            if (sproduct == null)
            {
                sproduct = new SProduct();
                sproduct.Products = new List<Product>();
            }
            if (prod != null && !sproduct.Products.Any(p => p.ProductId == prod.ProductId))
            {
                sproduct.Products.Add(prod);
                HttpContext.Session.SetObject("SProduct", sproduct);
            }

            return View(sproduct);
        }
        public IActionResult getProductId(int id)
        {
            HttpContext.Session.SetInt32("ProductId", id);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            SProduct sproduct = HttpContext.Session.GetObject<SProduct>("SProduct");
            if (sproduct != null)
            {
                sproduct.Products.RemoveAll(product => product.ProductId == id);
                HttpContext.Session.SetObject("SProduct", sproduct);
            }
            return RedirectToAction("Index");
        }
    }
}
