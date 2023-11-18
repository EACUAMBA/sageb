using Microsoft.AspNetCore.Mvc;
using sageb.Database;

namespace sageb.Controllers.Administrator.Book;

public class BookController : Controller
{
    private readonly SqliteDbContext _sqliteDbContext;
    private readonly ILogger<AdministratorController> _logger;

    public BookController(
        SqliteDbContext sqliteDbContext,
        ILogger<AdministratorController> logger)
    {
        _sqliteDbContext = sqliteDbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<BookModel> bookModelList = this._sqliteDbContext.Books.ToList().Select(this.ToBookModel).ToList();
        
        return View("~/Views/Administrator/Book/Index.cshtml",bookModelList);
    }

    [HttpPost]
    public IActionResult AdcionarLivro(BookModel bookModel)
    {
        _logger.LogInformation("Saving Book {Book}", bookModel);

        if (!ModelState.IsValid)
        {
            return null;
        }

        Database.Entities.Book book = new Database.Entities.Book();
        book.Title = bookModel.Title;
        book.Author = bookModel.Author;
        book.Quantity = bookModel.Quantity;
        book.PageQuantity = bookModel.PageQuantity;
        book.PublishDate = bookModel.PublishDate;

        _sqliteDbContext.Books.Add(book);
        _sqliteDbContext.SaveChanges();

        return RedirectToAction(actionName: "Index", controllerName: "Book");
    }

    [HttpGet]
    public IActionResult DeleteBook(int id)
    {
        _sqliteDbContext.Books
            .Where(x => x.Id == id)
            .ToList()
            .ForEach(x => _sqliteDbContext.Books.Remove(x));

        _sqliteDbContext.SaveChanges();

        return RedirectToAction(actionName: "Index", controllerName: "Book");
    }

    public BookModel ToBookModel(Database.Entities.Book book)
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