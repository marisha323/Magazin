using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Magazin.Models
{
    public class MagazinContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Imeg> Imegs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketsProduct> BasketsProducts { get; set; }
        public DbSet<Zamovlenay> Zamovlenays { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BasketsProduct>()
                .HasOne(bp => bp.Product)
                .WithOne(p => p.BasketsProduct)
                .HasForeignKey<BasketsProduct>(bp => bp.ProductId);

            modelBuilder.Entity<BasketsProduct>()
               .HasOne(bp => bp.Basket)
               .WithOne(p => p.BasketsProduct)
               .HasForeignKey<BasketsProduct>(bp => bp.BasketId);
        }


        public MagazinContext(DbContextOptions<MagazinContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
