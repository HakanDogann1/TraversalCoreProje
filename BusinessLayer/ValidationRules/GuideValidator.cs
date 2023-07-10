using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator:AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad Soyad Alanı Boş Bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Ad Soyad Alanı Minimum 5 Karakter Olmalıdır.");
            RuleFor(x => x.Name).MaximumLength(45).WithMessage("Ad Soyad Alanı Maximum 45 Karakter Olamlıdır.");
        }
    }
}
