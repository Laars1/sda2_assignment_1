using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Persistance.TypeConfigurations;

public class ProductInventoryTypeConfiguration : IEntityTypeConfiguration<ProductInventory>
{
    public void Configure(EntityTypeBuilder<ProductInventory> builder)
    {
        builder.HasOne(productInventory => productInventory.VendorInfo)
            .WithMany(vendorInfo => vendorInfo.ProductInventories)
            .HasForeignKey(productInventory => productInventory.VendorId)
            .IsRequired(true);
    }
}