using Microsoft.AspNetCore.Mvc;
using sageb.Database;
using sageb.Database.Entities;

namespace sageb.Controllers.Administrator
{
    public class AdministratorController : Controller
    {

        private readonly SqliteDbContext _sqliteDbContext;
        private readonly ILogger<AdministratorController> _logger;

        public AdministratorController(
            SqliteDbContext sqliteDbContext,
            ILogger<AdministratorController> logger)
        {
            _sqliteDbContext = sqliteDbContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            int booksCount = this._sqliteDbContext.Books.ToList().Count;

            IndexModel indexModel = new IndexModel()
            {
                BooksCount = booksCount
            };
            return View(indexModel);
        }
        
        public IActionResult GoToDefaultArea()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
