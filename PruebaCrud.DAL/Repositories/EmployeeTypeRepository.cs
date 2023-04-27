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

        public List<int> GetAllEmployeeRoleID()
        {
            var employeeRoleList = _context.EmployeeTypes.Select(e => e.EmployeeTypeID);
            return employeeRoleList.ToList();

        }
        public EmployeeType GetById(int id)
        {
            var employeetype = _context.EmployeeTypes.FirstOrDefault(e => e.EmployeeTypeID == id);
            return employeetype;
        }

        public void Insert(EmployeeType employeetype)
        {
            _context.EmployeeTypes.Add(employeetype);
            _context.SaveChanges();
        }

        public void Update(EmployeeType employeetype)
        {
            _context.EmployeeTypes.Update(employeetype);
            _context.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var employee = _context.EmployeeTypes.FirstOrDefault(e => e.EmployeeTypeID == id);
            if (employee != null)
            {
                _context.EmployeeTypes.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}
