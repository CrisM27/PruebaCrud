using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PruebaCrud.Domain.Entities;
using System.Reflection;

namespace PruebaCrud.DAL
{
    public class PruebaCrudContext : DbContext
    {
        public PruebaCrudContext(DbContextOptions<PruebaCrudContext> options) : base(options)
        {

        }

        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=.;Initial Catalog=CRUD;Integrated Security=True;TrustServerCertificate=true;")
                .EnableSensitiveDataLogging();
        }
    }
}
