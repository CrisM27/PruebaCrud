namespace Domain.Entities
{
    public class EmployeeType
    {
        public int EmployeeTypeID { get; set; }
        public string EmployeeRole { get; set; }
        public decimal Salary { get; set; }

        public List<Employee> Employees { get; }
    }
}
