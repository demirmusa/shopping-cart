using Microsoft.EntityFrameworkCore;
using ShoppingCart.EntityFrameworkCore.Campaigns;
using ShoppingCart.EntityFrameworkCore.Categories;
using ShoppingCart.EntityFrameworkCore.Products;

namespace ShoppingCart.EntityFrameworkCore
{
    public class ShoppingCartDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }

        public ShoppingCartDbContext(DbContextOptions<ShoppingCartDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>()
                .HasIndex(b => b.CategoryId);
        }
    }
}
