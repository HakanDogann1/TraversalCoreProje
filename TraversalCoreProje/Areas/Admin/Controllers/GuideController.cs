using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        public IActionResult Aktif(int id)
        {
            var value = _guideService.TGetByID(id);
            value.Status = true;
            _guideService.TUpdate(value);
            return RedirectToAction("Index");
        }

        public IActionResult Pasif(int id)
        {
            var value = _guideService.TGetByID(id);
            value.Status = false;
            _guideService.TUpdate(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            var value = validationRules.Validate(guide);
            if (value.IsValid)
            {
                guide.Status = true;
                _guideService.TInsert(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in value.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var value = _guideService.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            _guideService.TUpdate(guide);
            return RedirectToAction("Index");
        }
    }
}
