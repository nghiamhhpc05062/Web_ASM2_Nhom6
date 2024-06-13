using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Web_ASM_Nhom6.Models;

namespace Web_ASM_Nhom6.Controllers
{
	public class ShowRestaurantController : Controller
	{
		public string url2 = "http://localhost:29015/api/Restaurant";
		public async Task<IActionResult> ShowRestaurant(int id)
		{
			Restaurant restaurant = new Restaurant();
			using (var httpclient = new HttpClient())
			{
				using (var response = await httpclient.GetAsync($"{url2}/{id}"))
				{
					string apiResponse = await response.Content.ReadAsStringAsync();
					restaurant = JsonConvert.DeserializeObject<Restaurant>(apiResponse);
				}
			};
			return View(restaurant);
		}
	}
}
