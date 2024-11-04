using System.ComponentModel.DataAnnotations;

namespace Sda2.Masterdata.Persistance.Entities;

public class CustomerInfo
{
    [Key]
    public int CustomerId { get; set; }

    [Required]
    [StringLength(50)]
    public required string Email { get; set; }

    [Required]
    [StringLength(60)]
    public required string Password { get; set; }

    [Required]
    [StringLength(50)]
    public required string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public required string LastName { get; set; }

    [Required]
    public double PhoneNumber { get; set; }

    [Required]
    public float Rewards { get; set; }

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
    public required int ZipCode { get; set; }

    public int EmployeeId { get; set; }

    public EmployeeInfo? EmployeeInfo { get; set; }

}
