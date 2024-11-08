
using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class OrdersTicket
{
    [Key]
    public int OTID { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public int Quantity { get; set; }

    public float Subtotal { get; set; }

    public float Total { get; set; }

    public float Discount { get; set; }

    public float Tax { get; set; }

    public float TaxRate { get; set; }

    public float Cash { get; set; }

    public float Credit { get; set; }

    public int Status { get; set; }

    public int EmployeeId { get; set; }

    public int VendorId { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
