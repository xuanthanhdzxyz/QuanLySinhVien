using Microsoft.AspNetCore.Mvc;

namespace QuanLySinhVien.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}