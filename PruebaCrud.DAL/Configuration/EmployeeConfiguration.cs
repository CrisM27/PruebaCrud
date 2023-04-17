using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Domain.Entities;

namespace PruebaCrud.DAL.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .HasKey(e => e.EmployeeID);
            builder
                .Property(e => e.EmployeeID).IsRequired();

            builder
                .Property(e => e.Name).IsRequired();
            builder
                .Property(e => e.Name).HasMaxLength(50);

            builder
                .Property(e => e.Telephone).IsRequired();
            builder
                .Property(e => e.Telephone).HasMaxLength(20);

            builder
                .Property(e => e.EmploymentDate).IsRequired();
        }
    }
}
