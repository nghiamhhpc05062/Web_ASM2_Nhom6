using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.Extensions.Logging;
using Twilio;
using System;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Microsoft.AspNetCore.Http;
using Web_ASM_Nhom6.Service;

namespace Web_ASM_Nhom6.Controllers
{
    public class LoginController : Controller
    {
        string url = "http://localhost:29015/api/User";
        private readonly ILogger<LoginController> _logger;
        private readonly TwilioService _twilioService;
        public LoginController(ILogger<LoginController> logger, TwilioService twilioService)
        {
            _logger = logger;
            _twilioService = twilioService;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string apiResponse = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(apiResponse);

            return View(users);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            List<User> users = new List<User>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string apiResponse = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
            var isSuccsess = users.SingleOrDefault(a => a.Email.Equals(username) && a.Password.Equals(password));
            if (isSuccsess == null)
            {
                TempData["LoginSuccess"] = "False";
                return View();
            }
            else if (isSuccsess.role.Equals("admin"))
            {
                return RedirectToAction("Index");
            }
            else if (isSuccsess.role.Equals("restaurant"))
            {
                //return RedirectToAction("RestaurantIndex");
            }
            return Ok();
        }
        
        public async Task SingInWithGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task SignInWithFacebook()
        {
            await HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("FacebookResponse")
            });
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            var emailClaim = result.Principal.FindFirst(ClaimTypes.Email);
            if (emailClaim == null)
            {
                return RedirectToAction("Login");
            }

            List<User> users = new List<User>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string apiResponse = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(apiResponse);
            var isSuccsess = users.FirstOrDefault(u => u.Email == emailClaim.Value);

            if (isSuccsess == null)
            {
                return RedirectToAction("Login");
            }
            else if (isSuccsess.role.Equals("admin"))
            {
                return RedirectToAction("Index");
            }
            else if (isSuccsess.role.Equals("restaurant"))
            {
                //return RedirectToAction("RestaurantIndex");
            }
            return RedirectToAction("Login");
        }        

        public async Task<IActionResult> FacebookResponse()
        {
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (!result.Succeeded)
                return BadRequest();

            List<User> users = new List<User>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            string apiResponse = await response.Content.ReadAsStringAsync();
            users = JsonConvert.DeserializeObject<List<User>>(apiResponse);


            var emailClaim = result.Principal.FindFirst(ClaimTypes.Email);
            if (emailClaim == null)
            {
                return RedirectToAction("Login");
            }

            
            var isSuccsessEmail = users.FirstOrDefault(u => u.Email == emailClaim?.Value);

            if (isSuccsessEmail == null)
            {
                return RedirectToAction("Login");
            }
            else if (isSuccsessEmail.role.Equals("admin"))
            {
                return RedirectToAction("Index");
            }
            else if (isSuccsessEmail.role.Equals("restaurant"))
            {
                //return RedirectToAction("RestaurantIndex");
            }
            return RedirectToAction("Login");
        }


        public IActionResult SignInWithPhoneNumber()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignInWithPhoneNumber(string toPhoneNumber)
        {
            var otp = GenerateOtp();
            var message = $"Your verification code is {otp}";

            _twilioService.SendSms(toPhoneNumber, message);

            HttpContext.Session.SetString("OTP", otp);

            return Ok("SMS sent successfully!");
        }
        private string GenerateOtp()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
