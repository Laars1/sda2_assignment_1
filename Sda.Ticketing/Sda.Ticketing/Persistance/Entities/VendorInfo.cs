using System.ComponentModel.DataAnnotations;

namespace Sda.Ticketing.Persistance.Entities;

public class VendorInfo
{
    [Key]
    public int VendorId { get; set; }

    [StringLength(50)]
    public string CompanyName { get; set; } = string.Empty;

    [StringLength(100)]
    public string Department { get; set; } = string.Empty;

    [StringLength(50)]
    public string StreetAddress { get; set; } = string.Empty;

    [StringLength(50)]
    public string City { get; set; } = string.Empty;

    [StringLength(2)]
    public string State { get; set; } = string.Empty;

    public int ZipCode { get; set; }

    public double PhoneNumber { get; set; }

    public double? FaxNumber { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = string.Empty;

    public ICollection<ProductInventory> ProductInventories { get; set; } = new List<ProductInventory>();
}