using Microsoft.AspNetCore.Mvc;

namespace Web_ASM_Nhom6.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        [Route("/Admin/")]
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Index
    }
}
