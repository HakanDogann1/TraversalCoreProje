using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models.Admin.User;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var hasUser = _userManager.Users.ToList();
           var userList = hasUser.ToList().Select(x=>new UserViewModel
           {
               Gender = x.Gender,
               Id = x.Id,
               Name = x.Name,
               Mail=x.Email,
               Phone=x.PhoneNumber,
               Surname=x.Surname,
               UserName=x.UserName,
           }).ToList();
            return View(userList);
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var hasUser = _userManager.Users.FirstOrDefault(x => x.Id == id);
          var result =  await _userManager.DeleteAsync(hasUser);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Kullanıcı Silinemedi");
                return View();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserViewModel model)
        {
            var hasUser =await _userManager.FindByIdAsync(model.Id.ToString());
            AppUser appUser = new AppUser()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Mail,
                PhoneNumber = model.Phone,
                Gender = model.Gender,
                UserName = model.UserName,
            };
            var result = await _userManager.UpdateAsync(appUser);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Güncelleme işlemi başarısız");
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
