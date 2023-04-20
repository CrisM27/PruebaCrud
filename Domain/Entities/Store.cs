namespace PruebaCrud.Domain.Entities
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Attendance> EmployeeAttendance { get; set; }
    }
}
