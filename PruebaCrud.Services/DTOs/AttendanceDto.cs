namespace PruebaCrud.Services.DTOs
{
    public class AttendanceDto
    {
        public int StoreID { get; set; }
        public StoreDto StoreDto { get; set; }
        public int EmployeeID { get; set; }
        public EmployeeDto EmployeeDto { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
