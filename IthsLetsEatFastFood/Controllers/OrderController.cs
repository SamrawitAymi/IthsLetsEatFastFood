using IthsLetsEatFastFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IthsLetsEatFastFood.Controllers
{
    public class OrderController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        //private const string sessionKeyCart = "_cart";
        //private const string sessionKeyUserId = "_userId";


        public OrderController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}