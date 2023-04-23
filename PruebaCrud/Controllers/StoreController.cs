using Microsoft.AspNetCore.Mvc;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _service;
        public StoreController(IStoreService service)
        {
            _service = service;            
        }
        public IActionResult Index()
        {
            var storeList = _service.GetAll();
            return View(storeList);
        }
    }
}
