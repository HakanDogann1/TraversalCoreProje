using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProje.Models.Register;

namespace TraversalCoreProje.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}

			AppUser appUser = new AppUser()
			{
				UserName = model.UserName,
				PhoneNumber = model.Phone,
				Email = model.Mail
			};
			var value = await _userManager.CreateAsync(appUser,model.PasswordConfirm);
			if (!value.Succeeded)
			{
				foreach (var item in value.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
				return View();
			}
			return RedirectToAction("Index", "Login");
		}
	}
}
