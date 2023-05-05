namespace PruebaCrud.Services.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int EmployeeTypeID { get; set; }
        public EmployeeTypeDto EmployeeType { get; set; }
    }
}
