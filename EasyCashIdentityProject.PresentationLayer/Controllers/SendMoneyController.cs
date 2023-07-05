using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager; //sisteme authentice olan kullaniciyi yakalamam lazim
        private readonly ICustomerAccountProcessService _customerAccountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomer)
        {
            var context = new Context();

            var user = await _userManager.FindByNameAsync(User.Identity.Name); //kullanici artik elimde
            var receiverAccountNumberID = context.CustomerAccounts
                .Where(x => x.CustomerAccountNumber == sendMoneyForCustomer.ReceiverAccountNumber)
                .Select(y => y.CustomerAccountID)
                .FirstOrDefault();

            sendMoneyForCustomer.SenderID = user.Id; //gonderici id
            sendMoneyForCustomer.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            sendMoneyForCustomer.ProcessType = "Havale";
            sendMoneyForCustomer.ReceiverID = receiverAccountNumberID;

            return RedirectToAction("Index", "deneme");

        }
    }
}
