namespace Domain.Entities
{
    public class Attendance
    {
        public int StoreID { get; set; }
        public Store Store { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
