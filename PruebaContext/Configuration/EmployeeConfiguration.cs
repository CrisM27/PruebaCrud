using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PruebaContext.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(e => new { e.ID, e.Name, e.Telephone, e.EmploymentDate, e.EmployeeTypeID }).IsRequired();

            builder
                .Property(e => e.Name).HasMaxLength(50);

            builder
                .Property(e => e.Telephone).HasMaxLength(20);
        }
    }
}
