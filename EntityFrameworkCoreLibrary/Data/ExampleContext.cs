using EntityFrameworkCoreLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLibrary.Data
{
    public class ExampleContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// For production place in appsettings.json
        /// </summary>
        private static readonly string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=EF.DataAnnotations;Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
