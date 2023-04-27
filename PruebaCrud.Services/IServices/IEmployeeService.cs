using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();
        EmployeeDto GetEmployee(int employeeId);
        void Insert(EmployeeDto employeeDto);
        void Update(EmployeeDto employeeDto);
        void DeleteEmployee(EmployeeDto employeeDto);
    }
}
