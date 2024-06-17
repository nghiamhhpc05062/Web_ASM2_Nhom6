using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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


        //Update
        [HttpGet]
        [Route("/Order/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            Order order = new Order();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{urlOrder}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    order = JsonConvert.DeserializeObject<Order>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("GetAll", new List<Order>());
                }
            }
            return View(order);
        }

        [HttpPost]
        [Route("/User/SaveEdit")]
        public async Task<IActionResult> SaveEdit(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(order),
                    Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{urlOrder}/{order.OrderId}", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Đơn hàng đã được sửa thành công!";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View(order);
                }
            }
        }
    }
}
