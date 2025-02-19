using HardwareBayAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace HardwareBayAPI.Data
{
    public class HardwareDbContext : DbContext
    {
        public HardwareDbContext(DbContextOptions dbContextOptions): base (dbContextOptions) { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}
