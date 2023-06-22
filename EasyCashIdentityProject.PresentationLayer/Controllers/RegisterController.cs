using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

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
                Random random = new Random();
				int code;
				code = random.Next(100000, 1000000);
				AppUser appUser = new AppUser()
                
                {
                    //burada appUserin ait propertieslere atamalar yapciaz
                    UserName = appUserRegisterDto.Username,
                    Name = appUserRegisterDto.Name,
                    Surname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    ConfirmCode = code

                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded) //buraya kadar gelirse sayfaya yonlendiricez
                {

                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Easy Cash Admin", "bkakkoca@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", appUser.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodybuilder = new BodyBuilder();
                    bodybuilder.TextBody = "Kayit islemini gerceklestirmek icin onay kodunuz" + code;
                    mimeMessage.Body = bodybuilder.ToMessageBody();

                    mimeMessage.Subject = "Easy Cash Onay Kodu";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("bkakkoca@gmail.com", "nrbqogiedrkzyqdr");
                    client.Disconnect(true);

                    TempData["Mail"] = appUserRegisterDto.Email;

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
