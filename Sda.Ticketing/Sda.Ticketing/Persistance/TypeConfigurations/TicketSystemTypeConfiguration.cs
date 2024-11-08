using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda.Ticketing.Persistance.Entities;

namespace Sda.Ticketing.Persistance.TypeConfigurations;

public class TicketSystemTypeConfiguration : IEntityTypeConfiguration<TicketSystem>
{
    public void Configure(EntityTypeBuilder<TicketSystem> builder)
    {
        builder.HasMany(ticketSystem => ticketSystem.GiftCards)
            .WithOne(giftCard => giftCard.TicketSystem)
            .HasForeignKey(giftCard => giftCard.TicketId)
            .IsRequired(true);

        builder.HasMany(ticketSystem => ticketSystem.ReturnTables)
            .WithOne(refundTable => refundTable.TicketSystem)
            .HasForeignKey(refundTable => refundTable.TicketId)
            .IsRequired(true);
    }
}