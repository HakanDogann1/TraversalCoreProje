using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

       
        public IActionResult Index()
        {
            var values = _reservationService.TGetList();
            return View(values);
        }
  
        public IActionResult Approve(int id)
        {
           _reservationService.TApprove(id);
            return RedirectToAction("Index", "Reservation");
        }
        public IActionResult Cancel(int id)
        {
            _reservationService.TCancel(id);
            return RedirectToAction("Index","Reservation");
        }
    }
}
