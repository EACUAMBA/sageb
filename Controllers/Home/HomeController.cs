using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sageb.Database;
using sageb.Database.Entities;
using sageb.Database.Entities.Identity;

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

            ViewBookModel viewBookModel = new ViewBookModel() { Book = book, CanOrder = this.CanOrderBook(bookId)};
            return View(viewBookModel);
        }

        public IActionResult Order(int bookId)
        {
            Book? book = this._sqliteDbContext.Books.ToList().Find(book => book.Id.Equals(bookId));

            if (book == null)
            {
                return View("ViewBook");
            }

            User user = this._sqliteDbContext.Users.FirstOrDefault(user =>
                user.UserName.Equals(HttpContext.User.Identity!.Name))!;

            BookOrder bookOrder = new BookOrder()
            {
                Book = book,
                BookId = bookId,
                User = user,
                UserId = user.Id,
                CreatedAt = DateTime.Now,
                State = BookOrderState.Pending
            };

            this._sqliteDbContext.BookOrders.Add(bookOrder);
            this._sqliteDbContext.SaveChanges();

            ViewResult view = (ViewResult)this.ViewBook(bookId);

            ViewBookModel viewBook = (ViewBookModel)view.Model!;

            viewBook.Ordered = true;

            return View("ViewBook", viewBook);
        }

        public bool CanOrderBook(int bookId)
        {
            User user = _sqliteDbContext.Users.Include(user => user.BookOrders).FirstOrDefault(user =>
                user.UserName != null && user.UserName.Equals(HttpContext.User.Identity!.Name))!;
            
            Book book = this._sqliteDbContext.Books.ToList().FirstOrDefault(book => book.Id.Equals(bookId))!;

            BookOrder? bo = user.BookOrders
                .Where(order => order.BookId.Equals(bookId))
                .FirstOrDefault(order => !order.State.Equals(BookOrderState.BookReturned));

            return bo == null;

        }
    }
}