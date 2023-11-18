using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sageb.Database;
using sageb.Database.Entities.Identity;

namespace sageb.Controllers.Administrator.BookOrder;

public class BookOrderController : Controller
{
    
    private readonly SqliteDbContext _sqliteDbContext;
    private readonly ILogger<BookOrderController> _logger;

    public BookOrderController(
        SqliteDbContext sqliteDbContext,
        ILogger<BookOrderController> logger)
    {
        _sqliteDbContext = sqliteDbContext;
        _logger = logger;
    }

    public IActionResult Index()
    {
        User user = _sqliteDbContext.Users.Include(user => user.BookOrders).FirstOrDefault(user =>
            user.UserName != null && user.UserName.Equals(HttpContext.User.Identity!.Name))!;
        
        List<BookOrderModel> bookModelList = this._sqliteDbContext
            .BookOrders
            .Include(order => order.User)
            .Include(order => order.Book)
            .Where(order => order.UserId!.Equals(user.Id))
            .ToList()
            .Select(this.toBookOrderModel)
            .ToList();

        IndexModel indexModel = new IndexModel() { BookOrderModels = bookModelList };
        
        return View("~/Views/Administrator/BookOrder/Index.cshtml",indexModel);
    }

    public BookOrderModel toBookOrderModel(Database.Entities.BookOrder bookOrder)
    {
        return new BookOrderModel()
        {
            Id = bookOrder.Id,
            Book = bookOrder.Book,
            BookId = bookOrder.BookId,
            User = bookOrder.User,
            UserId = bookOrder.UserId,
            State = bookOrder.State,
            CreatedAt = bookOrder.CreatedAt,
            GivenAt = bookOrder.GivenAt,
            ReturnedAt = bookOrder.ReturnedAt,
        };
    }
}