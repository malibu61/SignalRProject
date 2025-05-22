using FluentValidation;
using SignalR.DtoLayer.BookingDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinnesLayer.ValidationRules.BookingValidations
{
	public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
	{
		public CreateBookingValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim kısmı boş geçilemez!");
			RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon kısmı boş geçilemez!");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail kısmı boş geçilemez!");
			RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı kısmı boş geçilemez!");
			RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih kısmı boş geçilemez!");


			RuleFor(x=>x.Name).MinimumLength(5).WithMessage("İsim kısmı en az 5 karakter olmalıdır!").MaximumLength(50).WithMessage("İsim kısmı en fazla 50 karakter olmalıdır!");

			RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama kısmı en fazla 500 karakter olmalıdır!");

			RuleFor(x => x.Mail).EmailAddress().WithMessage("Lütfen geçerli bir e-mail adresi giriniz!");
		}
	}
}
