
using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Areas.Member.Models.Profile
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage ="Eski şifrenizi giriniz")]
        public string PasswordOld { get; set; }
        [Required(ErrorMessage ="Şifre alanı boş bırakılamaz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre Tekrar alanı boş bırakılamaz")]
        [Compare(nameof(Password), ErrorMessage ="Şifre ile şifre tekrarı aynı değil")]
        public string PasswordConfirm { get; set; }
    }
}
