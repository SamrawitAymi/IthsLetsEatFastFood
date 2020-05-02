using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IthsLetsEatFastFood.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index(decimal amount)
        {
            var cart = Request.Cookies.SingleOrDefault(c => c.Key == "Cart");
            List<FoodProduct> foodProducts = new List<FoodProduct>();
            FoodProduct foodProduct = new FoodProduct() 
            {
                Id = new Guid(),
                Name = "Broccoli Cheddar Soup",
                Price = 79.99M
               
            };
            foodProducts.Add(foodProduct);
          //  ViewData["Product"] = foodProducts;
            ViewBag.Product = foodProducts;

            CartViewModel vm = new CartViewModel()
            {
                
                TotalPrice = foodProduct.Price * amount
            };
            ViewBag.cartList = vm.TotalPrice;
            return View();
        }
    }
}