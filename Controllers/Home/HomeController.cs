using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sageb.Data;
using sageb.Database.Entities;

namespace sageb.Controllers.Home
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly SqliteDbContext _sqliteDbContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            SqliteDbContext sqliteDbContext,
            ILogger<HomeController> logger)
        {
            _sqliteDbContext = sqliteDbContext;
            _logger = logger;
        }
        
        public IActionResult Index()
        {
            
            return View(new IndexModel(Books: this._sqliteDbContext.Books.ToList()));
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult GoToAdministrationArea()
        {
            return RedirectToAction("Index", "Administrator");
        }

        public IActionResult ViewBook(int bookId)
        {
            Book? book = this._sqliteDbContext.Books.ToList().Find(book => book.Id.Equals(bookId));

            if (book == null)
            {
                return View("Index");
            }

            ViewBookModel viewBookModel = new ViewBookModel(Book: book);
            return View(viewBookModel);

        }
    }
}
