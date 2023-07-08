using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.HasUser = hasUser.Name + " " + hasUser.Surname;
            ViewBag.Image =  hasUser.ImageUrl;
            ViewBag.Phone = hasUser.PhoneNumber;
            ViewBag.Mail = hasUser.Email;
            return View();
        }

        public IActionResult GuideList()
        {
            return View();
        }
    }
}
