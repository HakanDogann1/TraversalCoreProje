using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(IDestinationService destinationService, IReservationService reservationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _reservationService = reservationService;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetByFilter(x=>x.AppUserID==hasUser.Id);
            return View(values);
        }

        public IActionResult MyOldReservation()
        {
            return View();
        }

        public async Task<IActionResult> MyApprovedReservation()
        {
            var hasUser =await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetByApprovedReservation(hasUser.Id);
           
            return View(values);
        }
        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> list = (from x in _destinationService.TGetList()
                                         select new SelectListItem
                                         {
                                             Text = x.City,
                                             Value = x.DestinationID.ToString(),
                                         }).ToList();

            ViewBag.List = list;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.Status = "Onay Bekliyor...";
            reservation.AppUserID=hasUser.Id;
            _reservationService.TInsert(reservation);
            return RedirectToAction("Index", "Profile");
        }
    }
}
