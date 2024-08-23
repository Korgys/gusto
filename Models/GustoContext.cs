using Gusto.Orders;
using Gusto.Products;
using Gusto.Shops;
using Microsoft.EntityFrameworkCore;

namespace Gusto.Models;

public class GustoContext : DbContext
{
    public GustoContext(DbContextOptions<GustoContext> options)
        : base(options)
    {
    }

    public DbSet<Shop> Shops { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuration des clés étrangères
        modelBuilder.Entity<Shop>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Shop)
            .HasForeignKey(p => p.ShopId);
    }
}
