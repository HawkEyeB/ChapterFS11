using Microsoft.EntityFrameworkCore;
using ChapterFS11.Models;
using Microsoft.Identity.Client;

namespace ChapterFS11.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext() {}

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source = DESKTOP-LANT3M9\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true");
                //optionsBuilder.UseSqlServer("Data Source = DESKTOP-LANT3M9\\SQLEXPRESS; initial catalog = Chapter; user id = sa; password = Espanha1*x");
                optionsBuilder.UseSqlServer("Data Source = DESKTOP-LANT3M9\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true; TrustServerCertificate = True");

            }
        }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
