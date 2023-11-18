using System.ComponentModel.DataAnnotations;
using sageb.Database.Entities;
using sageb.Database.Entities.Identity;

namespace sageb.Controllers.Administrator.BookOrder;

public class BookOrderModel
{
    public int? Id { get; set; }
    public Database.Entities.Book? Book { get; set; }
    public int? BookId { get; set; }
    public User? User { get; set; }
    public string? UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? GivenAt { get; set; }
    public DateTime? ReturnedAt { get; set; }
    
    [EnumDataType(enumType: typeof(BookOrderState))]
    public BookOrderState State { get; set; }
}