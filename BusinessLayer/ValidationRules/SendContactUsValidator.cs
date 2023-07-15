using DtoLayer.DTOs.Contact;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class SendContactUsValidator:AbstractValidator<SendMessageDto>
    {
        public SendContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Mesaj içerik alanı boş geçilemez");
        }
    }
}
