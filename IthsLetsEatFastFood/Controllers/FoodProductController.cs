using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using IthsLetsEatFastFood.Repository;

namespace IthsLetsEatFastFood.Controllers
{
    public class FoodProductController : Controller
    {
        private IFoodProductRepository _foodProductRepository;

        public FoodProductController(IFoodProductRepository foodProductRepository)
        {

            _foodProductRepository = foodProductRepository;

        }

        public IActionResult Index()
        {
            var foodProducts = _foodProductRepository.GetAll();
            return View(foodProducts);
           
        }
 
       // [Autohorize]
        public IActionResult AddToCart(Guid id)
        {
            var cart = Request.Cookies.SingleOrDefault(c => c.Key == "Cart");
            string cartContent = "";
            if (cart.Value != null)
            {
                cartContent = cart.Value;
                cartContent += "," + id;

            }
            else
            {
                cartContent += "," + id;
            }

            Response.Cookies.Append("Cart", cartContent);

            return RedirectToAction("Index");
        }


    } 
}