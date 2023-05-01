using PruebaCrud.Services.DTOs;

namespace PruebaCrud.Services.IServices
{
    public interface IStoreService
    {
        List<StoreDto> GetAll();
        StoreDto GetById(int id);
        void Insert(StoreDto storedto);
        void Update(StoreDto storedto);
        void Delete(StoreDto storedto);
    }
}
