using PruebaCrud.Domain.Entities;
using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IAttendaceService
    {
        List<AttendanceDto> GetAll();
        List<AttendanceDto> GetAttendancesByDate(DateTime dateTime);
        List<AttendanceDto> GetAttendancesByStore(int storeId);
        List<EmployeeDto> GetEmployeesAttendance(int id);
    }
}
