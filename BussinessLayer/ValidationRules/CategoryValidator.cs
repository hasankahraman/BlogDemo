using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez.");

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz.");
            RuleFor(x => x.Description).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz.");

            RuleFor(x => x.Name).MaximumLength(50).WithMessage("En fazla 50 karakter girmelisiniz.");
            RuleFor(x => x.Description).MaximumLength(2500).WithMessage("En fazla 2500 karakter girmelisiniz.");
        }
    }
}
