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
    public class ReviewController : Controller
    {
        //kết nối API
        private string urlreview = "http://localhost:29015/api/Review";


        [Route("/Review/GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Review> reviews = new List<Review>();
            using (var httpClient = new HttpClient())
            {
                using (var rp = await httpClient.GetAsync(urlreview))
                {
                    string ap = await rp.Content.ReadAsStringAsync();
                    reviews = JsonConvert.DeserializeObject<List<Review>>(ap);
                }
            }
            return View(reviews);
        }

        [Route("/Review/Edit")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Review review = new Review();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{urlreview}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    review = JsonConvert.DeserializeObject<Review>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("GetAll", new List<Review>());
                }
            }
            return View(review);
        }

        [Route("/Review/SaveEdit")]
        [HttpPost]
        public async Task<IActionResult> SaveEdit(Review review)
        {
            if (!ModelState.IsValid)
            {
                return View(review);
            }

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(review),
                    Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{urlreview}/{review.ReviewId}", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Danh mục đã được sửa thành công!";
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View(review);
                }
            }
        }

    }
}
