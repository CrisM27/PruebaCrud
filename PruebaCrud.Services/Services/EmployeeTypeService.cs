using AutoMapper;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;
using System.Collections.Generic;

namespace PruebaCrud.Services.Services
{
    public class EmployeeTypeService : IEmployeeTypeService
    {
        private readonly IEmployeeTypeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeTypeService(IEmployeeTypeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public List<EmployeeTypeDto> GetAll()
        {
            var employeeTypes = _employeeRepository.GetAll();
            var employeeTypesDto = _mapper.Map<List<EmployeeTypeDto>>(employeeTypes);

            return employeeTypesDto;
        }

        public EmployeeTypeDto GetById(int id)
        {
            var employeeType = _employeeRepository.GetById(id);
            var employeeTypeDto = _mapper.Map<EmployeeTypeDto>(employeeType);
            return employeeTypeDto;
        }

        public void Insert(EmployeeTypeDto employeeTypeDto)
        {
            var employeetypeDto = _mapper.Map<EmployeeType>(employeeTypeDto);
            var employeetype = employeetypeDto;
            _employeeRepository.Insert(employeetype);
        }

        public void Update(EmployeeTypeDto employeeTypeDto)
        {
            var employeetypeDto = _mapper.Map<EmployeeType>(employeeTypeDto);
            var employeetype = employeetypeDto;
            _employeeRepository.Update(employeetype);
        }

        public void Delete(EmployeeTypeDto employeeTypeDto)
        {
            var employeetypeDto = _mapper.Map<EmployeeType>(employeeTypeDto);
            var employeetype = employeetypeDto;
            _employeeRepository.Delete(employeetype);
        }
    }
}
