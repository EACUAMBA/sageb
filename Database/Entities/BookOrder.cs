using System.ComponentModel.DataAnnotations;
using sageb.Database.Entities.Identity;

namespace sageb.Database.Entities;

public class BookOrder
{
    [Key]
    public int? Id { get; set; }
    public Book? Book { get; set; }
    public int? BookId { get; set; }
    public User? User { get; set; }
    public string? UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime GivenAt { get; set; }
    public DateTime ReturnedAt { get; set; }
    
    [EnumDataType(enumType: typeof(BookOrderState))]
    public BookOrderState State { get; set; }
}