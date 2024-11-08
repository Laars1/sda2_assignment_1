using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class ProductInventory
{
    [Key]
    public int ProductId { get; set; }

    [StringLength(50)]
    public string Brand { get; set; } = string.Empty;

    [StringLength(50)]
    public string Description { get; set; } = string.Empty;

    [StringLength(50)]
    public string ProductName { get; set; } = string.Empty;

    [StringLength(50)]
    public string ProductType { get; set; } = string.Empty;

    [StringLength(50)]
    public string ProductSubType { get; set; } = string.Empty;

    public float UnitPrice { get; set; }

    public float Cost { get; set; }

    public int StockIn { get; set; }

    public int VendorId { get; set; }

    public VendorInfo? VendorInfo { get; set; }

    public ICollection<Orders> Orders { get; set; } = new List<Orders>();
}
