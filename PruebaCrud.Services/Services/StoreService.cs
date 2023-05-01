using AutoMapper;
using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Services.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreService(IStoreRepository storerepository, IMapper mapper)
        {
            _storeRepository = storerepository;
            _mapper = mapper;
        }

        public StoreDto GetById(int id)
        {
            var store = _storeRepository.GetById(id);
            var storedto = _mapper.Map<StoreDto>(store);
            return storedto;
        }

        public List<StoreDto> GetAll()
        {
            var stores = _storeRepository.GetAll();
            var storesdto = _mapper.Map<List<StoreDto>>(stores);

            return storesdto;
        }

        public void Insert(StoreDto storedto)
        {
            var store = _mapper.Map<Store>(storedto);
            _storeRepository.Insert(store);
        }

        public void Update(StoreDto storedto)
        {
            var store = _mapper.Map<Store>(storedto);
            _storeRepository.Update(store);
        }

        public void Delete(StoreDto storedto)
        {
            var store = _mapper.Map<Store>(storedto);
            _storeRepository.Delete(store);
        }
    }
}
