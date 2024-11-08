using Microsoft.EntityFrameworkCore;
using Sda.Ticketing.Persistance.Entities;
using Sda.Ticketing.Persistance.TypeConfigurations;

namespace Sda.Ticketing.Persistance;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions
      <AppDbContext> options)
          : base(options)
    {
    }

    public virtual DbSet<GiftCard> GiftCards { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<OrdersTicket> OrdersTickets { get; set; }

    public virtual DbSet<ProductInventory> ProductInventories { get; set; }

    public virtual DbSet<ReturnTable> ReturnTables { get; set; }

    public virtual DbSet<TicketSystem> TicketSystems { get; set; }

    public virtual DbSet<VendorInfo> VendorInfos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrdersTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProductInventoryTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TicketSystemTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}