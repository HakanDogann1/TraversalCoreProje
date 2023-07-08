using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Member.Models.Profile;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public ProfileController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if(hasUser == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
            }
            var profile = new ProfileViewModel()
            {
                Email = hasUser.Email,
                Gender = hasUser.Gender,
                Name = hasUser.Name,
                Surname = hasUser.Surname,
                Username = hasUser.UserName,
                Phone=hasUser.PhoneNumber
            };
            return View(profile);
        }
        [HttpPost]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if(model.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extantion = Path.GetExtension(model.Image.FileName);

                var ImageName = Guid.NewGuid() + extantion;
                var savelocation = resource + "/wwwroot/userimages/" + ImageName;
                var stream = new FileStream(savelocation,FileMode.Create);
                await model.Image.CopyToAsync(stream);
                hasUser.ImageUrl = ImageName;
            }

            hasUser.Surname = model.Surname;
            hasUser.Name = model.Name;
            hasUser.Gender = model.Gender;
            hasUser.Email = model.Email;
            hasUser.UserName = model.Name;
            hasUser.PhoneNumber = model.Phone;
           
            var result = await _userManager.UpdateSecurityStampAsync(hasUser);
            if(result.Succeeded)
            {
                ModelState.AddModelError("", "Güncelleme işlemi gerçekleştirilemedi");
                return View();
            }
            return RedirectToAction("Index","Destination");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                
                return View();
            }
            var hasUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = await _userManager.ChangePasswordAsync(hasUser,model.PasswordOld,model.Password);
            if (!value.Succeeded)
            {
                return View();
            }

            return View();
        }
    }
}
