using Microsoft.AspNetCore.Identity;

namespace TraversalCoreProje.Models.Register
{
	public class ErrorDescriberViewModel:IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresUpper",
				Description = "Şifreniz en az 1 küçük karakter içermelidir."
			};
		}

		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresLower",
				Description = "Şifreniz en az 1 büyük karakter içermelidir."
			};
		}

		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Code = "PasswordTooShort",
				Description = "Şifreniz en az 6 karakter olmalıdır."
			};
		}

		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "Şifreniz en az 1 harf içermelidir."
			};
		}
	}
}
