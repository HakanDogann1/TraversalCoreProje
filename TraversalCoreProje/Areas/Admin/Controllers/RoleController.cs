using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models.Role;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList().Select(x=>new RoleListViewModel
            {
                RoleID=x.Id,
                RoleName=x.Name,
            }).ToList();
          
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleViewModel model)
        {
            var appRole = new AppRole()
            {
                Name = model.RoleName
            };
            var result =await _roleManager.CreateAsync(appRole);
            if(!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Rol eklenemedi...");
                return View();
            }
            return RedirectToAction("Index","Role");
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role=_roleManager.Roles.FirstOrDefault(x=>x.Id==id);
            var result =await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Rol silinemedi...");
                return View();
            }
            return RedirectToAction("Index", "Role");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
          
            var role = _roleManager.Roles.FirstOrDefault(y=>y.Id==id);
           
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole model)
        {
           var role = _roleManager.Roles.FirstOrDefault(x=>x.Id== model.Id);
            role.Id = model.Id;
            role.Name = model.Name;
            var result = await _roleManager.UpdateAsync(role);
            if(!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Rol güncellenemedi...");
                return View();
            }

            return RedirectToAction("Index","Role");
        }
    }
}
