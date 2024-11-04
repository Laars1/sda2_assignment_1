using Microsoft.EntityFrameworkCore;
using Sda2.Cart.Persistance.Entites;
using Sda2.Cart.Persistance.TypeConfigurations;

namespace Sda2.Cart.Persistance;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
    {
    }

    public virtual DbSet<CartInprogress> CartInprogress { get; set; }
    public virtual DbSet<Entites.Cart> Carts { get; set; }
    public virtual DbSet<ItemList> ItemLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CartInprogressEntityTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}