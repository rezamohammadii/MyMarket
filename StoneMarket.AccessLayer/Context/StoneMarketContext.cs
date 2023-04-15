using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StoneMarket.AccessLayer.Entity;

namespace StoneMarket.AccessLayer.Context
{
    public class StoneMarketContext : DbContext
    {

        //public StoneMarketContext()
        //{ }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost; port=3310;user id=root;password=1qaz!QAZ;database=stonemarket", ServerVersion.Parse("10.10.3"));
        //}

      //  protected readonly IConfiguration configuration;
        //public StoneMarketContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        public StoneMarketContext(DbContextOptions<StoneMarketContext> options)
         : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite(configuration.GetConnectionString("sqlDbString"));
        //}
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; } = null!;
        public DbSet<Permission>  Permissions { get; set; } = null!;
        public DbSet<ProductGallery>  ProductGalleries { get; set; } = null!;
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Setting> Settings { get; set; }


    }
}
