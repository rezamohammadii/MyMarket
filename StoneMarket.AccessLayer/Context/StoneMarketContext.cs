using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoneMarket.AccessLayer.Entity;

namespace StoneMarket.AccessLayer.Context
{
    public class StoneMarketContext : DbContext
    {
        public StoneMarketContext(DbContextOptions<StoneMarketContext> options)
            : base(options)
        {
        }
        public StoneMarketContext()
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost; port=3310;user=admin;password=V7McNe8g!D7wQrcg;database=mymarket");
        }

        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public DbSet<Permission>  Permissions { get; set; } = null!;
        public DbSet<Store>  Stores { get; set; } = null!;
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StoreCategory> StoreCategories { get; set; }

        public DbSet<Setting> Settings { get; set; }


    }
}
