using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PruebaCrud.DAL.Configuration
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder
                .HasKey(e => new { e.StoreID, e.EmployeeID, e.AttendanceDate });

            builder
                .HasAlternateKey(e => new { e.EmployeeID, e.AttendanceDate });

            builder
                .HasOne(e => e.Store)
                .WithMany(e => e.EmployeeAttendance)
                .HasForeignKey(e => e.StoreID);

            builder
                .HasOne(e => e.Employee)
                .WithMany(e => e.EmployeeAttendance)
                .HasForeignKey(e => e.EmployeeID);

            builder
                .Property(e => e.StoreID).IsRequired();

            builder
                .Property(e => e.EmployeeID).IsRequired();

            builder
                .Property(e => e.AttendanceDate).IsRequired();
        }
    }
}
