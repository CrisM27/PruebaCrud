using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IEmployeeRepository
    {
         List<Employee> GetAll();
        Employee GetEmployee(int employeeId);
        void Insert(Employee employee);
        void Update(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
