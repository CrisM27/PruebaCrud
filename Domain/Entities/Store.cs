namespace PruebaCrud.Domain.Entities
{
    public class Store
    {
        public int StoreID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Address { get; set; }

        public List<Attendance> EmployeeAttendance { get; set; }
    }
}
