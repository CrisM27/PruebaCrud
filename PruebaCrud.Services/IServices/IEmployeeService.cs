using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();
        EmployeeDto GetEmployee(int employeeId);
        void Insert(EmployeeDto employeedto);
        void Update(EmployeeDto employeedto);
        void DeleteEmployee(int employeeId);
    }
}
