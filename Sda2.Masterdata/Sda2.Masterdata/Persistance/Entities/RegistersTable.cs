using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Sda2.Masterdata.Persistance.Entities;

public class RegistersTable
{
    [Key]
    public int RegisterId { get; set; }

    public float OpenTotal { get; set; } = 0;

    public float CloseTotal { get; set; } = 0;

    public int RegisterNum { get; set; } = 0;

    public int? OpenEmpId { get; set; }

    public EmployeeInfo? OpenEmployee { get; set; }

    public int? CloseEmpId { get; set; }

    public EmployeeInfo? CloseEmployee { get; set; }

    public DateTime OpenTime { get; set; }

    public DateTime CloseTime { get; set; }

    public DateTime DropTime { get; set; }

    public int? DropEmpId { get; set; }

    public EmployeeInfo? DropEmployee { get; set; }

    public float DropTotal { get; set; } = 0;

    [StringLength(100)]
    public string Note { get; set; } = string.Empty;
}
