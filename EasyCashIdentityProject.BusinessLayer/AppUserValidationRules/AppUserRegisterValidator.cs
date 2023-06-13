using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.AppUserValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
    {
        //FluentValidation icin AbstractValidator miras almaliyiz.
        //AppUserRegisterDto referance olarak ekledik buraya 

        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30).MinimumLength(5).WithMessage("Ad alani bos gecilmez. Max=32 Min=5 karakter olmalidir");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alani bos gecilmez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanici adi alani bos gecilmez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alani bos gecilmez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre alani bos gecilmez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Sifre tekrar alani bos gecilmez");
            RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Sifreler eslesmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lutfen gecerli mail adresi giriniz");
   
        
        
        
        }





    }
}
