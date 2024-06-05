using Microsoft.AspNetCore.Mvc;

namespace vizeui.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
