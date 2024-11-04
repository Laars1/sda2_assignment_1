using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda2.Cart.Persistance.Entites;

namespace Sda2.Cart.Persistance.TypeConfigurations;

public class CartInprogressEntityTypeConfiguration : IEntityTypeConfiguration<CartInprogress>
{
    public void Configure(EntityTypeBuilder<CartInprogress> builder)
    {
        builder.HasMany(cartInprogress => cartInprogress.Carts)
            .WithOne(cart => cart.CartInprogress)
            .HasForeignKey(cart => cart.CID)
            .IsRequired(true);

        builder.HasMany(cartInprogress => cartInprogress.Carts)
            .WithOne(itemList => itemList.CartInprogress)
            .HasForeignKey(itemList => itemList.CID)
            .IsRequired(true);
    }
}
