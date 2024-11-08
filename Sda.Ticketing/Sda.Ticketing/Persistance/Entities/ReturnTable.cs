using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class ReturnTable
{
    [Key]
    public int RTID { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public float Refunds { get; set; }

    public float Exchanges { get; set; }

    public int TicketId { get; set; }

    public TicketSystem? TicketSystem { get; set; }
}
