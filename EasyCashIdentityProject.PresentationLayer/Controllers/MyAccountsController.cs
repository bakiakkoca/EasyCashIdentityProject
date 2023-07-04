using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        //normalde metod ismi bestpractice olarak IndexAsync olmali.
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditDto appUserEditDto = new AppUserEditDto();
            appUserEditDto.Name = values.Name;
            appUserEditDto.Surname = values.Surname;
            appUserEditDto.District = values.District;
            appUserEditDto.City = values.City;
            appUserEditDto.ImageUrl = values.ImageUrl;
            appUserEditDto.Email = values.Email;
            appUserEditDto.PhoneNumber = values.PhoneNumber;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto appUserEditDto)
        //normalde metod ismi bestpractice olarak IndexAsync olmali.
        {
            if (appUserEditDto.Password == appUserEditDto.Password)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = appUserEditDto.Name;
                user.Surname = appUserEditDto.Surname;
                user.District = appUserEditDto.District;
                user.City = appUserEditDto.City;
                user.ImageUrl = "deneme";
                user.Email = appUserEditDto.Email;
                user.PhoneNumber = appUserEditDto.PhoneNumber;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    RedirectToAction("Index", "Login");
                }

            }
            return View();
        }
    }
}
