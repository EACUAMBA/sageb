using Microsoft.AspNetCore.Mvc;

namespace sageb.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LivrosEmprestados()
        {
            return View();
        }

        public IActionResult DetalhesDaConta()
        {
            return View();
        }
    }
}
