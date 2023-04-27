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
        public List<int> GetAllEmployeeRoleID()
        {
            return _employeeRepository.GetAllEmployeeRoleID();
        }

        public EmployeeTypeDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(EmployeeTypeDto employeeTypeDto)
        {
            throw new NotImplementedException();
        }

        public void Update(EmployeeTypeDto employeeTypeDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
