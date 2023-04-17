using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IStoreServices
    {
        List<StoreDto> GetAll();
        StoreDto GetById(int id);
        void Insert(StoreDto storedto);
        void Update(StoreDto storedto);
        void Delete(int storeid);
    }
}
