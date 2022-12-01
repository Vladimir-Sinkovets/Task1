using ImportFilesToSqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ImportFilesToSqlServer
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestTask;Trusted_Connection=True;");
        }
    }
}
