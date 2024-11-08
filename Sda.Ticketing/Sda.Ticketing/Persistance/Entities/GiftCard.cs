using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class GiftCard
{
    [Key]
    public int GiftId { get; set; }

    public double PromoNumber { get; set; }

    public float CardBalance { get; set; }

    public int CustomerId { get; set; }

    public int TicketId { get; set; }

    public TicketSystem? TicketSystem { get; set; }
}
