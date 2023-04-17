using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PruebaContext.Configuration
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder
               .Property(e => new { e.ID, e.EmployeeRole, e.Salary }).IsRequired();

            builder
                .Property(e => e.EmployeeRole).HasMaxLength(50);

            builder
                .Property(e => e.Salary).HasMaxLength(12);

            builder
                .HasMany(e => e.Employees)
                .WithOne(e => e.EmployeeType)
                .HasForeignKey(e => e.EmployeeTypeID)
                .HasPrincipalKey(e => e.ID);
        }
    }
}
