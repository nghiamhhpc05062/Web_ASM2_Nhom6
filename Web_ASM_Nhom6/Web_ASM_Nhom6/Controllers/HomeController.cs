
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;
using static System.Net.WebRequestMethods;

namespace Web_ASM_Nhom6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        private string url = "http://localhost:29015/api/Product";
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> products = new List<Product>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }

            return View(products);
        }

        public IActionResult GioiThieu()
        {
            return View();
        }

        


        //public ViewResult Information() => View();
        //[HttpPost]
        //public async Task<IActionResult> Information(int id)
        //{
        //    Product products = new Product();

        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("http://localhost:29015/api/Products" + id))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                products = JsonConvert.DeserializeObject<Product>(apiResponse);
        //            }
        //            else
        //            {
        //                ViewBag.StatusCode = response.StatusCode;
        //            }
        //        }
        //    }

        //    return View(products);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Information(int id)
        //{
        //    List<Product> products = new List<Product>();

        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("http://localhost:29015/api/Products/" + id))
        //        {
        //            if (response.IsSuccessStatusCode)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                products = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
        //            }
        //        }
        //    }

        //    return View(products);
        //}




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
