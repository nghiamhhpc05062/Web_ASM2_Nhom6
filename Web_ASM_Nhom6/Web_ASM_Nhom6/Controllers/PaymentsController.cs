using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;
using Web_ASM_Nhom6.Service;

namespace Web_ASM_Nhom6.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly string urlOrderItem = "http://localhost:29015/api/OrderItem";
        private readonly string urlOrder = "http://localhost:29015/api/Order";
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

        [HttpPost]
        public async Task<IActionResult> SaveOrder([FromBody] SOrder orders)
        {
            if (orders == null || orders.Products == null || orders.Products.Count == 0)
            {
                return BadRequest("Invalid order data.");
            }
            var dateTime = DateTime.Now;
            var order = new Order()
            {
                UserId = SUser.User.UserId,
                OrderDate = dateTime,
                TotalAmount = orders.Total,
                Status = "Đang xử lý",
                PaymentMethod = "Tiền mặt",
                DeliveryPerson = "Đăng cute =))",
                DeliveryStatus = "Đang giao",
                DeliveryDate = dateTime,

            };
            var httpClient = new HttpClient();
            StringContent orderContent = new StringContent(JsonConvert.SerializeObject(order),
                                             Encoding.UTF8, "application/json");
            var responseOrder = await httpClient.PostAsync(urlOrder, orderContent);
            responseOrder.EnsureSuccessStatusCode();

            var responseSuccess = await responseOrder.Content.ReadAsStringAsync();
            var orderId = JsonConvert.DeserializeObject<Order>(responseSuccess);
            var abc = orderId.OrderId;
            foreach (var product in orders.Products)
            {
                var orderItem = new OrderItem()
                {
                    ProductId = product.ProductId,
                    Quantity = product.ProdQuantity,
                    Price = product.ProdPrice,
                    OrderId = orderId.OrderId,
                };

                StringContent orderItemContent = new StringContent(JsonConvert.SerializeObject(orderItem),
                                                     Encoding.UTF8, "application/json");
                var responseOrderItem = await httpClient.PostAsync(urlOrderItem, orderItemContent);
                responseOrderItem.EnsureSuccessStatusCode();
            }
            return Json(new { redirectUrl = Url.Action("Index", "Home") });
        }
    }
}
