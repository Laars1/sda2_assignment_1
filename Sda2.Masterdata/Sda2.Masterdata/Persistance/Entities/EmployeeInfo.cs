using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sda2.Masterdata.Persistance.Entities;

public class EmployeeInfo
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    [StringLength(50)]
    public required string Email { get; set; }

    [Required]
    [StringLength(60)]
    public required string Password { get; set; }

    [Required]
    public int PinNumber { get; set; }

    [Required]
    [StringLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }

    [Required]
    public double UserId { get; set; }

    [Required]
    public double PhoneNumber { get; set; }

    [Required]
    public double Snn { get; set; }

    [Required]
    [StringLength(50)]
    public required string StreetAddress { get; set; }

    [Required]
    [StringLength(50)]
    public required string City { get; set; }

    [Required]
    [StringLength(2)]
    public required string State { get; set; }

    [Required]
    public int ZipCode { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    [StringLength(50)]
    public required string CompanyName { get; set; }

    [NotMapped]
    public int AmountOfStores { get; set; }

    [Required]
    public int UserType { get; set; }

    public ICollection<CustomerInfo> Customers { get; set; } = new List<CustomerInfo>();

    public ICollection<Store> Stores { get; set; } = new List<Store>();

    public ICollection<RegistersTable> OpenRegisters { get; set; } = new List<RegistersTable>();

    public ICollection<RegistersTable> CloseRegisters { get; set; } = new List<RegistersTable>();

    public ICollection<RegistersTable> DropRegisters { get; set; } = new List<RegistersTable>();
}
