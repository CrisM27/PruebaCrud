using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Domain.Entities;

namespace PruebaCrud.DAL.Configuration
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder
                .HasMany(e => e.Employees)
                .WithOne(e => e.EmployeeType)
                .HasForeignKey(e => e.EmployeeTypeID)
                .HasPrincipalKey(e => e.EmployeeTypeID);

            builder
               .Property(e => e.EmployeeTypeID).IsRequired();

            builder
               .Property(e => e.EmployeeRole).IsRequired();
            builder
                .Property(e => e.EmployeeRole).HasMaxLength(50);

            builder
               .Property(e => e.Salary).IsRequired();
            builder
                .Property(e => e.Salary).HasMaxLength(12);




        }
    }
}
