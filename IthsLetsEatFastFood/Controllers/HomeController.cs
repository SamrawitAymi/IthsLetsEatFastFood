using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Repository;

namespace IthsLetsEatFastFood.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFoodProductRepository _foodProductRepository;

        public HomeController(ILogger<HomeController> logger, IFoodProductRepository foodProductRepository)
        {
            _logger = logger;
            _foodProductRepository = foodProductRepository;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
