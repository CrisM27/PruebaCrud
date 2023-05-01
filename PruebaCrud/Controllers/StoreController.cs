using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PruebaCrud.Services.DTOs;
using PruebaCrud.Services.IServices;

namespace PruebaCrud.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreService _service;
        private readonly INotyfService _toastNotification;
        public StoreController(IStoreService service, INotyfService toastNotification)
        {
            _service = service;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var storeList = _service.GetAll();
            return View(storeList);
        }

        public IActionResult AddStore()
        {
            var store = new StoreDto();
            return PartialView("./_AddStore",store);
        }

        [HttpPost]
        public IActionResult AddStore(StoreDto store)
        {
            _service.Insert(store);
            _toastNotification.Success("A new store has been added.");
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditStore(int id)
        {
            var store = _service.GetById(id);
            return PartialView("./_EditStore", store);
        }

        [HttpPost]
        public IActionResult UpdateStore(StoreDto store)
        {
            _service.Update(store);
            _toastNotification.Success("Changes has been saved.");
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteStore(StoreDto store)
        {
            _service.Delete(store);
            _toastNotification.Success("The store has been deleted successfully.");
            _service.GetAll();
            return RedirectToAction("Index");
        }
    }
}
