using Microsoft.AspNetCore.Mvc;

namespace sageb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
