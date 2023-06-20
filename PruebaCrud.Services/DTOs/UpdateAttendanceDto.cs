namespace PruebaCrud.Services.DTOs
{
    public class UpdateAttendanceDto
    {
        public int StoreID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
