using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Models;

namespace PruebaContext.Configuration
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder
                .Property(e => new { e.StoreID, e.EmployeeID, e.AttendanceDate }).IsRequired();

            builder
                .HasKey(e => new { e.StoreID, e.EmployeeID, e.AttendanceDate });

            builder
                .HasAlternateKey(e => new { e.EmployeeID, e.AttendanceDate });
        }
    }
}
