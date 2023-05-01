using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IEmployeeTypeRepository
    {
        List<EmployeeType> GetAll();
        EmployeeType GetById(int id);
        void Insert(EmployeeType employeeType);
        void Update(EmployeeType employeeType);
        void Delete(EmployeeType employeeType);
    }
}
