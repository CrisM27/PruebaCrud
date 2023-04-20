using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IAttendaceRepository
    {
        List<Attendance> GetAllAttendances();
        List<Attendance> GetAttendancesByDate(DateTime dateTime);
        List<Attendance> GetAttendancesByStore(int storeId);
        List<Employee> GetEmployeesAttendance(int id);
    }
}
