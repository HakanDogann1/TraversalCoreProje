using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models.Register
{
	public class RegisterViewModel
	{
        [Required(ErrorMessage ="Kullanıcı Adı Alanı Boş Geçilemez")]
        public string UserName { get; set; }
		[Required(ErrorMessage = "Telefon Numarası Alanı Boş Geçilemez")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Mail Alanı Boş Geçilemez")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "Şifre Alanı Boş Geçilemez")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Şifre Tekrar Alanı Boş Geçilemez")]
		[Compare(nameof(Password),ErrorMessage ="Girdiğiniz şifre birbiri ile uyuşmuyor.")]
		public string PasswordConfirm { get; set; }
	}
}
