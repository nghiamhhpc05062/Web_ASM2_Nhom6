﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_ASM_Nhom6.Models;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;
using Web_ASM_Nhom6.Service;

namespace Web_ASM_Nhom6.Controllers
{
    public class UserController : Controller
    {
        // URL của API
        private readonly string url = "http://localhost:29015/api/User";

        [HttpGet]
        public async Task<IActionResult> Thongtin()
        {
            if(SUser.User == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View(); // Chuyển người dùng tới view
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid || model.NewPassword != model.ConfirmPassword)
            {
                ViewBag.ErrorMessage = "Thông tin không hợp lệ hoặc mật khẩu không khớp.";
                return View(model);
            }

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await httpClient.PutAsync($"{url}/ChangePassword", content); // Cập nhật endpoint tùy theo API của bạn
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.SuccessMessage = "Đổi mật khẩu thành công.";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Có lỗi xảy ra. Vui lòng thử lại.";
                    return View(model);
                }
            }
        }
        [HttpGet]
        public IActionResult ChangeAddress()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ChangeAddress(ChangeAddressModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.ErrorMessage = "Thông tin không hợp lệ.";
        //        return View(model);
        //    }

        //    using (var httpClient = new HttpClient())
        //    {
        //        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        //        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //        var response = await httpClient.PutAsync($"{url}/ChangeAddress", content); // Cập nhật endpoint tùy theo API của bạn
        //        if (response.IsSuccessStatusCode)
        //        {
        //            ViewBag.SuccessMessage = "Địa chỉ đã được cập nhật thành công.";
        //            return View();
        //        }
        //        else
        //        {
        //            ViewBag.ErrorMessage = "Có lỗi xảy ra. Vui lòng thử lại.";
        //            return View(model);
        //        }
        //    }
        //}
    }
}

