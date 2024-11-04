using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sda2.Masterdata.Persistance.Entities;

namespace Sda2.Masterdata.Persistance.TypeConfigurations;

public class EmployeeInfoEntityTypeConfiguration : IEntityTypeConfiguration<EmployeeInfo>
{
    public void Configure(EntityTypeBuilder<EmployeeInfo> builder)
    {
        builder.HasMany(employeeInfo => employeeInfo.Customers)
            .WithOne(customerInfo => customerInfo.EmployeeInfo)
            .HasForeignKey(customerInfo => customerInfo.EmployeeId);

        builder.HasMany(employeeInfo => employeeInfo.Stores)
            .WithMany(store => store.EmployeeInfos);
    }
}
