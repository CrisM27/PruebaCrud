using Domain.Entities;
using PruebaContext;

namespace PruebaRepository
{
    public class EmployeeRepository
    {
        private readonly PruebaCrudContext _ctx;

        public EmployeeRepository(PruebaCrudContext ctx)
        {
            _ctx = ctx;
        }

        public void Insert(Employee employee) 
        {
            _ctx.Employees.Add(employee);
        }
    }
}