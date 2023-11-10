using Microsoft.EntityFrameworkCore;
using sageb.Models;

namespace sageb.Data
{
    public class ConexaoDbContext : DbContext
    {
        public ConexaoDbContext(DbContextOptions<ConexaoDbContext> options) : base(options) { }

        public DbSet<LivrosModel> Livros { get; set; }
        public DbSet<UsuarioModel> usuarios { get; set; }

        public DbSet<StudentModel> students { get; set; }

        public DbSet<AdministratorModel> administrators { get; set; }
    }
}
