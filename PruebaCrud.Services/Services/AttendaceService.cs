using AutoMapper;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Services.Services
{
    public class AttendaceService : IAttendaceService
    {
        private readonly IAttendaceRepository _attendaceRepository;
        private readonly IMapper _mapper;

        public AttendaceService(IAttendaceRepository attendaceRepository, IMapper mapper)
        {
            _attendaceRepository = attendaceRepository;
            _mapper = mapper;
        }

        public List<AttendanceDto> GetAll()
        {
            var attendances = _attendaceRepository.GetAll();
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);

            return attendanceDtos;
        }

        public List<AttendanceDto> GetAttendancesByDate(DateTime dateTime)
        {
            var attendances = _attendaceRepository.GetAttendancesByDate(dateTime);
            var attendancesDto = _mapper.Map<List<AttendanceDto>>(attendances);

            return attendancesDto;
        }

        public List<AttendanceDto> GetAttendancesByStore(int storeId)
        {
            var storeAttendances = _attendaceRepository.GetAttendancesByStore(storeId);
            var storeAttendancesDto = _mapper.Map<List<AttendanceDto>>(storeAttendances);

            return storeAttendancesDto;
        }

        public List<EmployeeDto> GetEmployeesAttendance(int id)
        {
            var employeeattendances = _attendaceRepository.GetEmployeesAttendance(id);
            var employeeAttendancesDtos = _mapper.Map<List<EmployeeDto>>(employeeattendances);

            return employeeAttendancesDtos;
        }
    }
}
