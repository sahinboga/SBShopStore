using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
	public class MemberValidator:AbstractValidator<Member>
	{
		public MemberValidator()
		{
			RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adınızı boş geçemezsiniz");
			RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadınızı boş geçemezsiniz");
			RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
			RuleFor(x => x.FirstName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz");
			RuleFor(x => x.LastName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
			RuleFor(x => x.LastName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz");
			RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş geçemezsiniz");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Soyadınızı boş geçemezsiniz");
			RuleFor(x => x.Password).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
			RuleFor(x => x.Password).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz");

		}
	}
}
