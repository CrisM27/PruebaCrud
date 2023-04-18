using AutoMapper;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.Mapping
{
    public class PruebaCrudProfile : Profile
    {
        public PruebaCrudProfile()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Store, StoreDto>().ReverseMap();
            CreateMap<EmployeeType, EmployeeTypeDto>().ReverseMap();
        }
    }
}
