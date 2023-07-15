using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models.Role;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/UserRole/")]
    public class UserRoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public UserRoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var userList = _userManager.Users.ToList();
            return View(userList);
        }

        [HttpGet]
        [Route("UserRoleList/{id}")]
        public async Task<IActionResult> UserRoleList(int id)
        {
            var role = _roleManager.Roles.ToList();
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"] = user.Id;
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModel = new List<RoleAssignViewModel>();
            foreach (var item in role)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.Exist = userRoles.Contains(item.Name);

                roleAssignViewModel.Add(model);
            }
            return View(roleAssignViewModel);
        }
        [HttpPost]
        [Route("UserRoleList/{id}")]
        public async Task<IActionResult> UserRoleList(List<RoleAssignViewModel> model)
        {
            var userId =(int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
           foreach (var item in model)
            {
                if(item.Exist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
                
            }
            return RedirectToAction("Index");
        }
    }
}
