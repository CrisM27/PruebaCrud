using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;

namespace PruebaCrud.DAL.Repositories
{
    public class EmployeeTypeRepository : IEmployeeTypeRepository
    {
        private readonly PruebaCrudContext _context;

        public EmployeeTypeRepository(PruebaCrudContext context)
        {
            _context = context;
        }
        public List<EmployeeType> GetAll()
        {
           return _context.EmployeeTypes.ToList();
        }

        public EmployeeType GetById(int id)
        {
            var employeetype = _context.EmployeeTypes.FirstOrDefault(e => e.EmployeeTypeID == id);
            return employeetype;
        }

        public void Insert(EmployeeType employeeType)
        {
            _context.EmployeeTypes.Add(employeeType);
            _context.SaveChanges();
        }

        public void Update(EmployeeType employeeType)
        {
            _context.EmployeeTypes.Update(employeeType);
            _context.SaveChanges();
        }
        public void Delete(EmployeeType employeeType)
        {
            if (employeeType != null)
            {
                _context.EmployeeTypes.Remove(employeeType);
                _context.SaveChanges();
            }
        }
    }
}
