using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Controllers
{
    public class CategoryController : Controller
    {
        //kết nối API
        private string url = "http://localhost:29015/api/Category";


        //GetALL
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            List<Category> categories = new List<Category>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                }
            }
            return View(categories);
        }
         

        //Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            Category category1 = new Category();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(category),
                    Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(url, content))
                {
                    string apiRes = await response.Content.ReadAsStringAsync();
                    category1 = JsonConvert.DeserializeObject<Category>(apiRes);
                }
            }
            return RedirectToAction("GetCategory");
        }



        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = new Category();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("GetCategory", new List<Category>());
                }
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCategory");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("Delete", new Category { CategoryId = id });
                }
            }
        }

        //Update
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category category = new Category();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("GetCategory", new List<Category>());
                }
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(category),
                    Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{url}/{category.CategoryId}", content);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetCategory");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View(category);
                }
            }
        }


        public IActionResult Index()
        {
            return View();
        }


        //GetID
        public ViewResult GetID() => View();
        [HttpGet]
        public async Task<IActionResult> GetID(int id)
        {
            Category getidcategory = new Category();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(($"{url}/{id}")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        getidcategory = JsonConvert.DeserializeObject<Category>(apiResponse);
                    }
                }
            }
            return View(getidcategory);
        }



    }
}
