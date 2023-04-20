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
                .ToTable("Employee")
                .HasKey(e => e.EmployeeID);

            builder
                .Property(e => e.EmployeeID)
                .HasColumnName("Employee_ID")
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasColumnName("Employee_Name")
                .IsRequired();

            builder
                .Property(e => e.Name)
                .HasMaxLength(50);

            builder
                .Property(e => e.EmployeeTypeID)
                .HasColumnName("Employee_Type_ID")
                .IsRequired();

            builder
                .Property(e => e.Telephone)
                .HasColumnName("Telephone")
                .IsRequired();

            builder
                .Property(e => e.Telephone)
                .HasMaxLength(20);

            builder
                .Property(e => e.EmploymentDate)
                .HasColumnName("Employment_Date")
                .IsRequired();
        }
    }
}
