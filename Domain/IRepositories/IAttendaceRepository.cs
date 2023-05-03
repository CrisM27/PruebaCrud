using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IAttendaceRepository
    {
        void Add(Attendance attendance);
        List<Attendance> GetAll();
        List<Attendance> GetAttendancesByDate(DateTime date);
        List<Attendance> GetAttendancesByStore(int storeId);
        List<Employee> GetEmployeesAttendance(int id);
    }
}
