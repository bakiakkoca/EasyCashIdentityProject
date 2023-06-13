using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos
{
    public class AppUserRegisterDto
    {
        //ekleme sayfasi olarak dusunelim ekleme sayfasinda neler olabilir?
        //ad,soyad,kullaniciadi,email,sifre,confirmpassword gerekli olabilir

        public string Name   { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }    
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }    







    }
}
