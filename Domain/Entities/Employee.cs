namespace Domain.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int EmployeeTypeID { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public IList<Attendance> EmployeeAttendance { get; set; }
    }
}
