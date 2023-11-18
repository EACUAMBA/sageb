using sageb.Database.Entities;

namespace sageb.Controllers.Home;

public class ViewBookModel
{
    public Book? Book { get; set; }
    public bool Ordered { get; set; } = false;
    public bool CanOrder { get; set; } = true;

}