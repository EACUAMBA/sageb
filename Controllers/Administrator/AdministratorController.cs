using Microsoft.AspNetCore.Mvc;
using sageb.Data;
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
            List<BookModel> bookModelList = this._sqliteDbContext.Books.ToList().Select(this.ToBookModel).ToList();
            return View(bookModelList);
        }
        public IActionResult AdcionarLivros()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AdcionarLivro(BookModel bookModel)
        {
            _logger.LogInformation("Saving Book {Book}", bookModel);

            if (!ModelState.IsValid)
            {
                return View("AdcionarLivros", bookModel);
            }

            Book book = new Book();
            book.Title = bookModel.Title;
            book.Author = bookModel.Author;
            book.Quantity = bookModel.Quantity;
            book.PageQuantity = bookModel.PageQuantity;
            book.PublishDate = bookModel.PublishDate;

            _sqliteDbContext.Books.Add(book);
            _sqliteDbContext.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Administrator");
        }

        [HttpGet]
        public IActionResult RemoverLivro(int id)
        {
            _sqliteDbContext.Books
                .Where(x => x.Id == id)
                .ToList()
                .ForEach(x => _sqliteDbContext.Books.Remove(x));

            _sqliteDbContext.SaveChanges();
            return RedirectToAction(actionName: "Index", controllerName: "Administrator");
        }
        public IActionResult ListaAlunos()
        {
            return View();
        }
        public IActionResult AdcionarAlunos()
        {
            return View();
        }
        public IActionResult RemoverAluno()
        {
            return View();
        }
        public IActionResult Devolucoes()
        {
            return View();
        }


        public BookModel ToBookModel(Book book)
        {
            return new BookModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Quantity = book.Quantity,
                PageQuantity = book.PageQuantity,
                PublishDate = book.PublishDate,
            };
        }


    }
}
