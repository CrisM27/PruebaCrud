namespace PruebaCrud.Services.DTOs
{
    public class AttendanceDto
    {
        public int StoreID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; } = DateTime.Now.Date;
    }
}
