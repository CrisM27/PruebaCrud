﻿using AutoMapper;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Services.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendaceRepository;
        private readonly IMapper _mapper;

        public AttendanceService(IAttendanceRepository attendaceRepository, IMapper mapper)
        {
            _attendaceRepository = attendaceRepository;
            _mapper = mapper;
        }

        public void Add(AttendanceDto attendanceDto)
        {
            var attendance = _mapper.Map<Attendance>(attendanceDto);
            _attendaceRepository.Add(attendance);
        }

        public List<AttendanceDto> GetAll()
        {
            var attendances = _attendaceRepository.GetAll();
            var attendanceDtos = _mapper.Map<List<AttendanceDto>>(attendances);

            return attendanceDtos;
        }

        public List<AttendanceDto> GetAttendancesByDate(DateTime date)
        {
            var attendances = _attendaceRepository.GetAttendancesByDate(date);
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
