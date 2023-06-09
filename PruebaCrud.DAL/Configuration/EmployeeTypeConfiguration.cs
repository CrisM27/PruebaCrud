﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaCrud.Domain.Entities;

namespace PruebaCrud.DAL.Configuration
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<EmployeeType>
    {
        public void Configure(EntityTypeBuilder<EmployeeType> builder)
        {
            builder
                .ToTable("Employee_Type")
                .HasKey(e => e.EmployeeTypeID);

            builder
                .HasMany(e => e.Employees)
                .WithOne(e => e.EmployeeType)
                .HasForeignKey(e => e.EmployeeTypeID);

            builder
               .Property(e => e.EmployeeTypeID)
               .HasColumnName("Employee_Type_ID")
               .IsRequired();

            builder
               .Property(e => e.EmployeeRole)
               .HasColumnName("Employee_Role")
               .IsRequired();

            builder
                .Property(e => e.EmployeeRole).HasMaxLength(50);

            builder
               .Property(e => e.Salary)
               .HasColumnName("Salary")
               .IsRequired();
            builder
                .Property(e => e.Salary).HasMaxLength(12);
            builder
                .Property(e => e.Salary)
                .HasColumnType("decimal");
        }
    }
}
