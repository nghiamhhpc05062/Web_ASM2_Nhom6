using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        string urlUser = "http://localhost:29015/api/User";
        [Route("/Admin/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Admin/IndexUser")]
        public async Task<IActionResult> IndexUser()
        {
            List<User> users = new List<User>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(urlUser);
            string apiResponse = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
            return View(users);
        }
        public IActionResult CreateUser()
        {
            return View();
        }

    }
}
