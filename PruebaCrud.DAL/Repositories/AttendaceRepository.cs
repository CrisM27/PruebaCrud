using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;
using System;

namespace PruebaCrud.DAL.Repositories
{
    public class AttendaceRepository : IAttendaceRepository
    {
        private readonly PruebaCrudContext _context;

        public AttendaceRepository(PruebaCrudContext context)
        {
            _context = context;
        }

        public void Add(Attendance attendance)
        {
            _context.Add(attendance);
            _context.SaveChanges();
        }

        public List<Attendance> GetAll()
        {
            return _context.Attendances.ToList();            
        }

        public List<Attendance> GetAttendancesByDate(DateTime date)
        {
            var attendaces = _context.Attendances
                                        .Where(e => e.AttendanceDate == date)
                                        .ToList();

            return attendaces;
        }

        public List<Attendance> GetAttendancesByStore(int storeId)
        {
            var storeAttendance = _context.Attendances
                                        .Where(e => e.StoreID == storeId)
                                        .ToList();

            return storeAttendance;
        }

        public List<Employee> GetEmployeesAttendance(int id)
        {
            var attendanceRecords = _context.Attendances
                                      .Where(a => a.EmployeeID == id)
                                      .Select(a => a.Employee)
                                      .ToList();
            return attendanceRecords;
        }
    }
}
