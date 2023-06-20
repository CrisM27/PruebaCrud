using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IAttendanceService
    {
        void Add(AttendanceDto attendanceDto);
        List<AttendanceDto> GetAll();
        List<AttendanceDto> GetAttendancesByDate(DateTime date);
        List<AttendanceDto> GetAttendancesByStore(int storeId);
        List<EmployeeDto> GetEmployeesAttendance(int id);
    }
}
