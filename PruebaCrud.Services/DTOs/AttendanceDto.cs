﻿namespace PruebaCrud.Services.DTOs
{
    public class AttendanceDto
    {
        public int StoreID { get; set; }
        public StoreDto Store { get; set; }
        public int EmployeeID { get; set; }
        public EmployeeDto Employee { get; set; }
        public DateTime AttendanceDate { get; set; }
    }
}
