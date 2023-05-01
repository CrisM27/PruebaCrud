using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IEmployeeTypeService
    {
        List<EmployeeTypeDto> GetAll();
        EmployeeTypeDto GetById(int id);
        void Insert(EmployeeTypeDto employeetypedto);
        void Update(EmployeeTypeDto employeetypedto);
        void Delete(EmployeeTypeDto employeetypedto);
    }
}
