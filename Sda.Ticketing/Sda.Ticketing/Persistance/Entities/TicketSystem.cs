using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class TicketSystem
{
    [Key]
    public int TicketId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    [StringLength(50)]
    public string CompanyName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public float Subtotal { get; set; }

    public float Total { get; set; }

    public float Cost { get; set; }

    public float Discount { get; set; }

    public float Tax { get; set; }

    public float TaxRate { get; set; }

    public float Cash { get; set; }

    public float Credit { get; set; }

    public int CartPurchase { get; set; }

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public ICollection<ReturnTable> ReturnTables { get; set; } = new List<ReturnTable>();

    public ICollection<GiftCard> GiftCards { get; set; } = new List<GiftCard>();
}
