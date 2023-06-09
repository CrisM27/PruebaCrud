﻿using Microsoft.EntityFrameworkCore;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;

namespace PruebaCrud.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly PruebaCrudContext _context;
        public EmployeeRepository(PruebaCrudContext context)
        {
            _context = context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.Include(e => e.EmployeeType).ToList();
        }

        public Employee GetEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            //var employee = _context.Employees.FirstOrDefault(x=>x.ID == employeeId);
            _context.ChangeTracker.Clear();
            return employee;   
        }

        public void Insert(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
