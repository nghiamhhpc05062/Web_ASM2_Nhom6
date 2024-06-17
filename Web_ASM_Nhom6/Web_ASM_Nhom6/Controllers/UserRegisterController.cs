using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
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
            var httpclient = new HttpClient();

            //get
            List<User> checkuser = new List<User>();
            var response1 = await httpclient.GetAsync(url);

            string apiRes1 = await response1.Content.ReadAsStringAsync();
            checkuser = JsonConvert.DeserializeObject<List<User>>(apiRes1);

            var exits = checkuser.SingleOrDefault(x => x.Email.Equals(user.Email));

            if (exits == null)
            {
                //add
                User user1 = new User();

                StringContent content = new StringContent(JsonConvert.SerializeObject(user),
                Encoding.UTF8, "application/json");
                var response = await httpclient.PostAsync("http://localhost:29015/api/User", content);

                string apiRes = await response.Content.ReadAsStringAsync();
                user1 = JsonConvert.DeserializeObject<User>(apiRes);

                return RedirectToAction("Login", "Login");
            }
            TempData["LoginSuccess"] = "False";
            return View();
        }
    }
}
