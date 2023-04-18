using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IAttendaceRepository
    {
        List<Attendance> GetAllAttendances();
        Attendance GetAttendanceByDate(DateTime dateTime);
        Attendance GetAttendanceByStore(int storeId);
        List<Employee> GetEmployeeAttendance(Employee id);
    }
}
