namespace Domain.Entities
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public IList<Attendance> EmployeeAttendance { get; set; }
    }
}
