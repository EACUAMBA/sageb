using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sageb.Database.Entities;
using sageb.Database.Entities.Identity;

namespace sageb.Database
{
    public class SqliteDbContext : IdentityDbContext<User, Role, string>
    {
        public SqliteDbContext(DbContextOptions<SqliteDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; private set; }
        public DbSet<BookOrder> BookOrders { get; private set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<BookOrder>()
                .HasOne(_ => _.User)
                .WithMany(_ => _.BookOrders)
                .HasForeignKey(_ => _.UserId);
            
            modelBuilder.Entity<BookOrder>()
                .HasOne(_ => _.Book)
                .WithMany(_ => _.BookOrders)
                .HasForeignKey(_ => _.BookId);
        }
    }
}