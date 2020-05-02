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

        public FoodProductController()
        {

            _foodProductRepository = new MockFoodProductRepository();

        }

        //public JsonResult Index()
        //{
        //   return _foodProductRepository.GetFoodProduct(Guid Id).Name;
        //}
        public IActionResult Index()
        {

            MockFoodProductRepository t = new MockFoodProductRepository();

            ViewData["FoodProds"]= t.InitData();

            return View();
        }

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