using Microsoft.EntityFrameworkCore;
using Sda2.Masterdata.Persistance.Entities;
using Sda2.Masterdata.Persistance.TypeConfigurations;

namespace Sda2.Masterdata.Persistance;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
    {
    }

    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }
    public virtual DbSet<CustomerInfo> CustomerInfos { get; set; }
    public virtual DbSet<Store> Stores { get; set; }
    public virtual DbSet<RegistersTable> RegistersTables { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EmployeeInfoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new RegistersTableEntityTypeConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
