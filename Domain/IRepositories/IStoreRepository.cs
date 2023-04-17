using PruebaCrud.Domain.Entities;

namespace PruebaCrud.Domain.IRepositories
{
    public interface IStoreRepository
    {
        List<Store> GetAll();
        Store GetById(int id);

        void Insert (Store store);
        void Update (Store store);
        void Delete (int storeid);
    }
}
