using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        //UserManager Identity gelen bir classtir.
        //<> yazacagim user ya identity user yada onu miras alan AppUser sinifi olucak

        //CTOR
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        //class tikladim CTRL + . tikladim ctoru otomatik olusturdum

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            //appuserregisterdto verdik suan sadece onunla islem yapicagim icin
            //onu verdim sonradan bu degisebilir sadece isime yarayacak ve kullanacaklarimi
            //aliyorum

            if (ModelState.IsValid) //modelstate gecerliyse FluentValidation gectiyse tamamen
            {
                AppUser appUsr = new AppUser()
                {
                    //burada appUserin ait propertieslere atamalar yapciaz
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email

                };
                var result = await _userManager.CreateAsync(appUsr, appUserRegisterDto.Password);
                if (result.Succeeded) //buraya kadar gelirse sayfaya yonlendiricez
                {
                    return RedirectToAction("Index", "ConfirmMail");
                    //sey gibi dusunebilirsin mailinize gonderdigimiz kodu girin diye.. 
                }
                else //parola yanlis girerse neden yanlis girdigini gorucez
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }

            }
            return View(); //hata olursa hatayi donucek





        }
    }
}
