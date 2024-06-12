
﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;


namespace Web_ASM_Nhom6.Controllers
{
    public class ProductController : Controller
    {

        private string url = "http://localhost:29015/api/Product";
        private string urlmenu = "http://localhost:29015/api/Menu";
        private string urlrestaurant = "http://localhost:29015/api/Restaurant";


        [HttpGet]
        public async Task<IActionResult> Index(string search, decimal? minPrice, decimal? maxPrice, string city)
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

            // Filter by search keyword
            if (!string.IsNullOrEmpty(search))
            {
                foreach (var keyword in search.Split(' '))
                {
                    products = products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
                }
            }

            // Filter by price range
            if (minPrice.HasValue)
            {
                products = products.Where(p => p.Price >= minPrice.Value).ToList();
            }

            if (maxPrice.HasValue)
            {
                products = products.Where(p => p.Price <= maxPrice.Value).ToList();
            }

            return View(products);
        }


        //Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Product product, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();

                if (Array.Exists(extensions, e => e == extension))
                {
                    var fileName = Guid.NewGuid() + extension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Product", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Set the image URL
                    product.Image = "/image/Product/" + fileName;
                }
                else
                {
                    ViewBag.Error = "Invalid file type. Please upload an image file.";
                    return View(product);
                }
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(product),
                        Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync(url, content))
                    {
                        string apiRes = await response.Content.ReadAsStringAsync();
                        product = JsonConvert.DeserializeObject<Product>(apiRes);
                    }
                }

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }



        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product products = new Product();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("Index", new List<Category>());
                }
            }
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.DeleteAsync($"{url}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("Delete", new Product { ProductId = id });
                }
            }
        }

        //Update
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product products = new Product();
            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{url}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    products = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                    return View("Index", new List<Product>());
                }
            }
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product, IFormFile ImageFile)
        {
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();

                if (Array.Exists(extensions, e => e == extension))
                {
                    var fileName = Guid.NewGuid() + extension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/Product", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Set the image URL
                    product.Image = "/image/Product/" + fileName;
                }
                else
                {
                    ViewBag.Error = "Invalid file type. Please upload an image file.";
                    return View(product);
                }


                if (!ModelState.IsValid)
                {
                    return View(product);
                }

                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(product),
                        Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PutAsync($"{url}/{product.ProductId}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "API Error: " + response.ReasonPhrase);
                        return View(product);
                    }
                }
            }
            return View(product);
        }



        //Information thông tin sản phẩm
        public ViewResult Information() => View();
        [HttpGet]
        public async Task<IActionResult> Information(int id)
        {
            Product getidproduct = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(($"{url}/{id}")))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        getidproduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                    }
                }
            }



            return View(getidproduct);
        }


    }
}
