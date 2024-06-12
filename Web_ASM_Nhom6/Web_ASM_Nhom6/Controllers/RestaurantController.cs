﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly string _restaurantUrl = "http://localhost:29015/api/Restaurant";
        private readonly string _categoryUrl = "http://localhost:29015/api/Category";

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            List<Category> categories = new List<Category>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_categoryUrl))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        categories = JsonConvert.DeserializeObject<List<Category>>(apiResponse);
                    }
                    else
                    {
                        ViewBag.Error = $"Error: {response.StatusCode}";
                    }
                }
            }

            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Restaurant restaurant, IFormFile ImageFile)
        {
            // Handle file upload
            if (ImageFile != null && ImageFile.Length > 0)
            {
                var extensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var extension = Path.GetExtension(ImageFile.FileName).ToLower();

                if (Array.Exists(extensions, e => e == extension))
                {
                    var fileName = Guid.NewGuid() + extension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    // Set the image URL
                    restaurant.Image = "/iamge/" + fileName;
                }
                else
                {
                    ViewBag.Error = "Định dạng tệp không hợp lệ. Vui lòng tải lên một tệp hình ảnh.";
                    return View(restaurant);
                }
            }

            // Ensure all required data is present before sending to API
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        StringContent content = new StringContent(JsonConvert.SerializeObject(restaurant), Encoding.UTF8, "application/json");

                        using (var response = await httpClient.PostAsync(_restaurantUrl, content))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                TempData["SuccessMessage"] = "Chúc mừng, đăng ký thành công!";
                                return RedirectToAction("Add");
                            }
                            else
                            {
                                ViewBag.Error = $"Lỗi: {response.StatusCode}";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Đã xảy ra lỗi khi gửi dữ liệu đến API: " + ex.Message;
                }
            }

            return View(restaurant);
        }

    }
}
