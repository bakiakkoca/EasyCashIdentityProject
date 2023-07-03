using EasyCashIdentityProject.EntityLayer.Concrete;
using EasyCashIdentityProject.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;

		public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, false, true);
			//kullanici username ve password dogrumu diye bakti dogruysa
			//kullaniciyi hatirlayalim mi diye sordu false dedik
			//5-10kez hatali giris yaparsa sisteme girmesini 5dk ornek olarak engelleyelim mi dedi true dedik
			if (result.Succeeded)
			{
				var user = await _userManager.FindByNameAsync(loginViewModel.Username);
				//name gore name isimli kisinin tum bilgilerini getirdi EmailConfirmed kontrol etmemiz lazim
                if (user.EmailConfirmed == true)
                {
                    return RedirectToAction("Index", "MyAccounts");
					//kontrol ettik emailconfirmed islemini yapmissa profiline gidicek yapmadiysa yapmasi lazim
                }
				//else lutfen mail adresinizi onaylayin
            }
			//kullanici adi veya sifre hatali
			return View();
		}
	}
}
