using Microsoft.EntityFrameworkCore;
using MyFirstAzureWebApp.Models;

namespace MyFirstAzureWebApp.Services
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SQL8003.site4now.net;Initial Catalog=db_a98204_b1skeetz;User Id=db_a98204_b1skeetz_admin;Password=damirenergy07");
        }
    }
}
