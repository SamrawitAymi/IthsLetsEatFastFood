using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IthsLetsEatFastFood.Controllers
{
    public class OrderController : Controller
    {

        private readonly IFoodProductRepository _foodProductRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";


        public OrderController(IFoodProductRepository foodProductRepository, UserManager<ApplicationUser> userManager)
        {
            _foodProductRepository = foodProductRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}