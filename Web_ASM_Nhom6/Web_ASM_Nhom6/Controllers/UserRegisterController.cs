using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Controllers
{
    public class UserRegisterController : Controller
    {

        public string url = "http://localhost:29015/api/User/";

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            User user1 = new User();
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user),
                    Encoding.UTF8, "application/json");
                using (var response = await httpclient.PostAsync("http://localhost:29015/api/User", content))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    user1 = JsonConvert.DeserializeObject<User>(apiRes);
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
