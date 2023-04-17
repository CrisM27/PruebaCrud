using Domain.Entities;
using Microsoft.EntityFrameworkCore;
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
    }
}
