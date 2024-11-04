using System.ComponentModel.DataAnnotations;

namespace Sda2.Masterdata.Persistance.Entities;

public class Store
{
    [Key]
    public int SID { get; set; }

    [Required]
    [StringLength(50)]
    public required string CompanyName { get; set; }

    public ICollection<EmployeeInfo> EmployeeInfos { get; set; } = new List<EmployeeInfo>();
}
