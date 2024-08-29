using Microsoft.EntityFrameworkCore;
using MobileStoreManager.Entities;

namespace MobileStoreManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        { 
        }
        
        public DbSet<Roles> Roles { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Brands> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
