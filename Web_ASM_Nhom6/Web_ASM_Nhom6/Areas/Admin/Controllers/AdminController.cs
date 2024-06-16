using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        string urlUser = "http://localhost:29015/api/User";
        string urlOrder = "http://localhost:29015/api/Order";
        [Route("/Admin/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Admin/IndexOrder")]
        public async Task<IActionResult> IndexOrder()
        {
            List<Order> order = new List<Order>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(urlOrder);
            string apiResponse = await response.Content.ReadAsStringAsync();
            order = JsonConvert.DeserializeObject<List<Order>>(apiResponse);
            return View(order);
        }

    }
}
