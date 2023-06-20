namespace PruebaCrud.Services.DTOs
{
    public class AddEmployeeDto
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public DateTime EmploymentDate { get; set; }
        public int EmployeeTypeID { get; set; }
    }
}
