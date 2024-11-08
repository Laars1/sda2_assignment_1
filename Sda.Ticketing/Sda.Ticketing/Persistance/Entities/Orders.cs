using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class Orders
{
    [Key]
    public int OID { get; set; }

    public int StockAmount { get; set; }

    public int OTID { get; set; }

    public OrdersTicket? OrdersTicket { get; set; }

    public int ProductId { get; set; }

    public ProductInventory? ProductInventory { get; set; }
}
