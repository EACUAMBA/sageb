using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sageb.Database.Entities;

namespace sageb.Data
{
    public class SqliteDbContext : IdentityDbContext<User, Role, string>
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options) { }

    }
}
