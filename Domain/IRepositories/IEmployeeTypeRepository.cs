using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IEmployeeTypeRepository
    {
        List<EmployeeType> GetAll();
        List<int>GetAllEmployeeRoleID();
        EmployeeType GetById(int id);
        void Insert(EmployeeType employeetype);
        void Update(EmployeeType employeetype);
        void DeleteById(int id);
    }
}
