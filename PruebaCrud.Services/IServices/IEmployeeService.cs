using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetEmployees();
        EmployeeDto GetEmployee(int employeeId);
        void Insert(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void DeleteEmployee(int employeeId);
    }
}
