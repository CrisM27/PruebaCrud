using AutoMapper;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

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

        public List<EmployeeDto> GetAll()
        {
            var employees = _employeeRepository.GetAll();
            var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);

            return employeesDto;
        }

        public EmployeeDto GetEmployee(int employeeId)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void Insert(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Insert(employee);
        }

        public void Update(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.Update(employee);
        }
        public void DeleteEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepository.DeleteEmployee(employee);
        }
    }
}
