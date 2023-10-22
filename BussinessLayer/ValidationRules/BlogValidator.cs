using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator() 
        {
            RuleFor(x=> x.Title).NotEmpty().WithMessage("Başlık boş geçilemez.");
            RuleFor(x=> x.Content).NotEmpty().WithMessage("İçerik boş geçilemez.");

            RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz.");
            RuleFor(x => x.Content).MinimumLength(2).WithMessage("En az 2 karakter girmelisiniz.");

            RuleFor(x => x.Title).MaximumLength(50).WithMessage("En fazla 50 karakter girmelisiniz.");
            RuleFor(x => x.Content).MaximumLength(2500).WithMessage("En fazla 2500 karakter girmelisiniz.");
        }
    }
}
