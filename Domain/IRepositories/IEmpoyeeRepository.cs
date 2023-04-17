using Domain.Entities;

namespace Domain.IRepositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployee(int employeeId);
        void Insert(Employee employee);
        void Update(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
