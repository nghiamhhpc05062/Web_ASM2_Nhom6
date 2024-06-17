using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;


namespace Web_ASM_Nhom6.Controllers
{
    [Area("Admin")]
    public class UserAdminController : Controller
    {
        //kết nối API
        private string urluser = "http://localhost:29015/api/User";


        [Route("/User/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(urluser))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }
            return View(users);
        }


        [Route("/User/Add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [Route("/User/SaveAdd")]
        [HttpPost]
        public async Task<IActionResult> SaveAdd(User user)
        {
            User user1 = new User();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(urluser, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user1 = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            TempData["SuccessMessage"] = "Người dùng đã được thêm thành công!";
            return RedirectToAction("GetAll");
        }


        //Update
        [HttpGet]
        [Route("/User/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            User user = new User();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{urluser}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("GetAll", new List<User>());
                }
            }
            return View(user);
        }

        [HttpPost]
        [Route("/User/SavEdit")]
        public async Task<IActionResult> SavEdit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{urluser}/{user.UserId}", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Người dùng đã được sửa thành công!";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View(user);
                }
            }
        }

    }
}
