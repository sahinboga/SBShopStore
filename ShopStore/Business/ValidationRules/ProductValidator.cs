using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
	public class ProductValidator : AbstractValidator<Product>
	{
		public ProductValidator()
		{
			RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adını boş geçemezsiniz");
			RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
			RuleFor(x => x.ProductName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter giriniz");

			RuleFor(x => x.Description).MinimumLength(20).WithMessage("Lütfen en az 20 karakter giriniz");
			RuleFor(x => x.Description).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter giriniz");
		}

	}
}
