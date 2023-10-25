using Microsoft.AspNetCore.Mvc;

namespace sageb.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
