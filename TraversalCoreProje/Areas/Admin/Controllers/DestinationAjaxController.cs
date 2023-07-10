using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationAjaxController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationAjaxController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DestinationList()
        {
            var values = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult DestinationAdd(Destination destination)
        {
            destination.Status = true;
            _destinationService.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetByID(int DestinationID)
        {
            var value = _destinationService.TGetByID(DestinationID);
            var json = JsonConvert.SerializeObject(value);
            return Json(json);
        }
        public IActionResult DestinationDelete(int DestinationID)
        {
            var value = _destinationService.TGetByID(DestinationID);
            _destinationService.TDelete(value);
            return NoContent();
        }
        [HttpPost]
        public IActionResult DestinationUpdate(Destination destination)
        {
            _destinationService.TUpdate(destination);
            var result = JsonConvert.SerializeObject(destination);
            return Json(result);
        }
    }
}
