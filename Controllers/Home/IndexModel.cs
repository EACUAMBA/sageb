using sageb.Database.Entities;

namespace sageb.Controllers.Home;

public readonly record struct IndexModel(List<Book> Books);