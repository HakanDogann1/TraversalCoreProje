using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;
using TraversalCoreProje.Models.Password;

namespace TraversalCoreProje.Controllers
{
    public class PasswordChangeViewModel : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeViewModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            var smtpClient = new SmtpClient();
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Mail);
            string passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordTokenUrl = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId= user.Id,
                token=passwordToken,
            },HttpContext.Request.Scheme);
            var smtpClient = new SmtpClient();
            return View();
        }
    }
}
