using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Domain.Entities;

namespace PruebaCrud.DAL.Configuration
{
    public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder
                .ToTable("Attendance")
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
                .Property(e => e.StoreID)
                .HasColumnName("Store_ID")
                .IsRequired();

            builder
                .Property(e => e.EmployeeID)
                .HasColumnName("Employee_ID")
                .IsRequired();

            builder
                .Property(e => e.AttendanceDate)
                .HasColumnName("Attendance_Date")
                .IsRequired();
        }
    }
}
