using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models.Login
{
	public class LoginViewModel
	{
        [Required(ErrorMessage ="E-Mail Alanı Boş Bırakılamaz.")]
        public string Email { get; set; }
		[Required(ErrorMessage = "Şifre Alanı Boş Bırakılamaz.")]
		public string Password { get; set; }
    }
}
