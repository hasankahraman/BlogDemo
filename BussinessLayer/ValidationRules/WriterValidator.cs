using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanını boş bırakamazsınız.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanını boş bırakamazsınız.");
            RuleFor(x => x.About).NotEmpty().WithMessage("Hakkında alanını boş bırakamazsınız.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan alanını boş bırakamazsınız.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanını boş bırakamazsınız.");

            RuleFor(x => x.Email).EmailAddress();

            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            RuleFor(x => x.About).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            RuleFor(x => x.Title).MinimumLength(2).WithMessage("En az 2 karakter giriniz.");
            
        }
    }
}
