using PruebaCrud.Domain.Entities;
using PruebaCrud.Domain.IRepositories;

namespace PruebaCrud.DAL.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly PruebaCrudContext _context;

        public StoreRepository(PruebaCrudContext context)
        {
            _context = context;
        }

        public List<Store> GetAll()
        {
            return _context.Stores.ToList();
        }

        public Store GetById(int id)
        {
            var store = _context.Stores.FirstOrDefault(x=>x.StoreID == id);
            return store;
        }

        public void Insert(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public void Update(Store store)
        {
            _context.Stores.Update(store);
            _context.SaveChanges();
        }

        public void Delete(Store store)
        {
            if (store != null)
            {
                _context.Stores.Remove(store);
                _context.SaveChanges();
            }
        }
    }
}
