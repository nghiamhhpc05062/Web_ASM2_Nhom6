
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


        private string url = "http://localhost:29015/api/Restaurant";
        private string urlMenu = "http://localhost:29015/api/Menu";
        private string urlCategory = "http://localhost:29015/api/Category";


        //trang chủ
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Restaurant> restaurants = new List<Restaurant>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(apiResponse);
                }
            }

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urlCategory))
                {
                    string categoryApiResponse = await response.Content.ReadAsStringAsync();
                    var categories = JsonConvert.DeserializeObject<List<Category>>(categoryApiResponse);

                    foreach (var restaurant in restaurants)
                    {
                        var category = categories.FirstOrDefault(c => c.CategoryId == restaurant.CategoryId);
                        if (category != null)
                        {
                            restaurant.Category = category;
                        }
                    }
                }
            }

            return View(restaurants);
        }
        public IActionResult Dangky()
        {
            return View();
        }
        public IActionResult Lienhe()
        {
            return View();
        }


        public async Task<IActionResult> Restaurant(int id)
        {
            Restaurant restaurant = new Restaurant();
            using (var httpclient = new HttpClient())
            {
                using (var response = await httpclient.GetAsync($"{url2}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    restaurant = JsonConvert.DeserializeObject<Restaurant>(apiResponse);
                }
            };
            return View(restaurant);
        }


        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
