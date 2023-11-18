using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sageb.Database.Entities;
using sageb.Database.Entities.Identity;

namespace sageb.Data
{
    public class SqliteDbContext : IdentityDbContext<User, Role, string>
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }

    }
}
