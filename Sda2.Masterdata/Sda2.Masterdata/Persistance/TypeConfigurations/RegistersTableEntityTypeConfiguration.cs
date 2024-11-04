using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Persistance.TypeConfigurations;

public class RegistersTableEntityTypeConfiguration : IEntityTypeConfiguration<RegistersTable>
{
    public void Configure(EntityTypeBuilder<RegistersTable> builder)
    {
        builder.HasOne(register => register.OpenEmployee)
            .WithMany(employeeInfo => employeeInfo.OpenRegisters)
            .HasForeignKey(register => register.OpenEmpId)
            .IsRequired(false);

        builder.HasOne(register => register.CloseEmployee)
            .WithMany(employeeInfo => employeeInfo.CloseRegisters)
            .HasForeignKey(register => register.CloseEmpId)
            .IsRequired(false);

        builder.HasOne(register => register.DropEmployee)
            .WithMany(employeeInfo => employeeInfo.DropRegisters)
            .HasForeignKey(register => register.DropEmpId)
            .IsRequired(false);
    }
}