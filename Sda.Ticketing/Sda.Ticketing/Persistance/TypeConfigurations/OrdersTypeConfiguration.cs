using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Persistance.TypeConfigurations;

public class OrdersTypeConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.HasOne(order => order.ProductInventory)
            .WithMany(productInventory => productInventory.Orders)
            .HasForeignKey(order => order.ProductId)
            .IsRequired(true);

        builder.HasOne(order => order.OrdersTicket)
            .WithMany(ordersTicket => ordersTicket.Orders)
            .HasForeignKey(order => order.OTID)
            .IsRequired(true);
    }
}
