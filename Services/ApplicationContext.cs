using Microsoft.EntityFrameworkCore;
using MyFirstAzureWebApp.Models;

namespace MyFirstAzureWebApp.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=first-servertest.postgres.database.azure.com;Database=postgres;Port=5432;User Id=postgres@first-servertest;Password=IosifStalin2;Ssl Mode=Require;");
        }
    }
}
