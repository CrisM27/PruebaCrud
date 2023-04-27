using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IEmployeeTypeService
    {
        List<EmployeeTypeDto> GetAll();
        List<int> GetAllEmployeeRoleID();
        EmployeeTypeDto GetById(int id);
        void Insert(EmployeeTypeDto employeetypedto);
        void Update(EmployeeTypeDto employeetypedto);
        void DeleteById(int id);
    }
}
