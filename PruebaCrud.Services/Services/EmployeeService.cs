using AutoMapper;
using Domain.IRepositories;
using PruebaCrud.DAL.Repositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaCrud.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.DeleteEmployee(employeeId);
        }

        public EmployeeDto GetEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public List<EmployeeDto> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public void Insert(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeDto employee)
        {
            throw new NotImplementedException();
        }
    }
}
