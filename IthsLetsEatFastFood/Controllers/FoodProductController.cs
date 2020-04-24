using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using Microsoft.AspNetCore.Mvc;

namespace IthsLetsEatFastFood.Controllers
{
    public class FoodProductController : Controller
    {

        
        public IActionResult Index()
        {
            List<FoodProduct> foodProducts = new List<FoodProduct>();
            FoodProduct foodProduct = new FoodProduct()
            {

                Id = new Guid(),
                Name = "Broccoli Cheddar Soup",
                Description = "Butter,yellow onion, carrot,broccoli, garlic, flour,chicken, " +
                       "beer, milk, Cheddar cheese,Salt and black pepper to taste,Tabasco sauce, Parmesan crisps",
                Price = 79.99M,
                ImageUrl = "https://i0.wp.com/www.eatthis.com/wp-content/uploads/2019/01/healthy-broccoli-chedder-soup.jpg?resize=640%2C360&ssl=1"
            };
            foodProducts.Add(foodProduct);
            ViewData["FoodProds"] = foodProducts;


            return View();
        }

        public IActionResult AddToCart(Guid id)
        {
            var cart = Request.Cookies.SingleOrDefault(c=>c.Key=="Cart");
            string cartContent = "";
            if (cart.Value  != null)
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