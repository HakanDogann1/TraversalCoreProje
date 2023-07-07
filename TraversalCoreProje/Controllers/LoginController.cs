using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProje.Models.Login;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel model)
		{
			var hasUser =await _userManager.FindByEmailAsync(model.Email);
			if (hasUser == null)
			{
				ModelState.AddModelError("", "Kullanıcı bulunamadı");
			}
			if (!ModelState.IsValid)
			{
				return View();
			}
			var value =await _signInManager.PasswordSignInAsync(hasUser, model.Password,false,false);
			if(!value.Succeeded)
			{
				ViewBag.v1 = "a";
				return View();
			}
			return RedirectToAction("Index","Destination");
		}
	}
}
