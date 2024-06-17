using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_ASM_Nhom6.Models;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;
using Web_ASM_Nhom6.Service;
using System.Linq;

namespace Web_ASM_Nhom6.Controllers
{
    public class UserController : Controller
    {
        // URL của API
        private readonly string url = "http://localhost:29015/api/User";
        private readonly string urlOrderItem = "http://localhost:29015/api/OrderItem";
        private readonly string urlOrder = "http://localhost:29015/api/Order";
        private readonly string urlProduct = "http://localhost:29015/api/Product";

        [HttpGet]
        public IActionResult Thongtin()
        {
            if (SUser.User == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid || model.NewPassword != model.ConfirmPassword)
            {
                ViewData["ChagePass"] = "Null";
                return View(model);
            }

            using (var httpClient = new HttpClient())
            {
                SUser.User.Password = model.NewPassword;
                var content = new StringContent(JsonConvert.SerializeObject(SUser.User), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                
                var response = await httpClient.PutAsync($"{url}/{SUser.User.UserId}", content);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["ChagePass"] = "Succsess";
                    return View();
                }
                else
                {
                    ViewData["ChagePass"] = "NotSuccsess";
                    return View(model);
                }
            }
        }
        public IActionResult ChangeAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeAddress(ChangeAddress AddressChange)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ChagePass"] = "Null";
                return View(AddressChange);
            }

            using (var httpClient = new HttpClient())
            {
                SUser.User.Address = AddressChange.Address;
                var content = new StringContent(JsonConvert.SerializeObject(SUser.User), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PutAsync($"{url}/{SUser.User.UserId}", content);
                if (response.IsSuccessStatusCode)
                {
                    ViewData["ChagePass"] = "Succsess";
                    return RedirectToAction("Thongtin");
                }
                else
                {
                    ViewData["ChagePass"] = "NotSuccsess";
                    return View(AddressChange);
                }
            }
        }

        public async Task<IActionResult> Histori()
        {
            var httpClient = new HttpClient();

            var orderItemsTask = httpClient.GetStringAsync(urlOrderItem);
            var ordersTask = httpClient.GetStringAsync(urlOrder);
            var productsTask = httpClient.GetStringAsync(urlProduct);

            await Task.WhenAll(orderItemsTask, ordersTask, productsTask);

            var orderItems = JsonConvert.DeserializeObject<List<OrderItem>>(await orderItemsTask);
            var orders = JsonConvert.DeserializeObject<List<Order>>(await ordersTask);
            var products = JsonConvert.DeserializeObject<List<Product>>(await productsTask);

            var listOrderUser = orders.Where(order => order.UserId == SUser.User.UserId).ToList();

            var listOrderItemOrder = orderItems.Where(item => listOrderUser.Any(order => order.OrderId == item.OrderId)).ToList();

            var listProduct = products.Where(prod => listOrderItemOrder.Any(orderItem => orderItem.ProductId == prod.ProductId)).ToList();

            SHistori.Orders = listOrderUser;
            SHistori.OrderItems = listOrderItemOrder;
            SHistori.Products = listProduct;

            return View();
        }

    }
}

