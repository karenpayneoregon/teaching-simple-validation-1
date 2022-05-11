using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCoreLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreLibrary.Data
{
    public class ExampleContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        private static string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=EF.DataAnnotations;Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
