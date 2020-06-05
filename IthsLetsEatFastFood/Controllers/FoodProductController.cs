using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using IthsLetsEatFastFood.ViewModel;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Net.Http;
using Lets.WebService.Client;

namespace IthsLetsEatFastFood.Controllers
{
    public class FoodProductController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILetsFoodService _foodService;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";

        public FoodProductController( ILetsFoodService foodService,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _foodService = foodService;
        }


        public IActionResult Index()
        {
            return View(_foodService.GetProductList());                    
        }
 
       [Authorize]
        public IActionResult AddToCart(Guid id)
        {
           
            //var apiService = Service.AddToCart(id);
            var currentCartItems = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            var userSessionId = HttpContext.Session.Get<Guid>(sessionKeyUserId);
            var actualUserId = Guid.Parse(_userManager.GetUserId(User));


           // _foodService.AddToCart(currentCartItem);

            List<CartItem> cartItems = new List<CartItem>();

            
            if (currentCartItems != null)
            {
                cartItems = currentCartItems;
                if (userSessionId != actualUserId)
                {
                    currentCartItems = null;
                    HttpContext.Session.Clear();
                    cartItems = new List<CartItem>();

                }

                HttpContext.Session.Set<Guid>(sessionKeyUserId, actualUserId);
              
            }
            if (currentCartItems != null && currentCartItems.Any(fp => fp.FoodProduct.Id == id))
            {
                int foodProductIndex = currentCartItems.FindIndex(fp => fp.FoodProduct.Id == id);
                currentCartItems[foodProductIndex].Amount += 1;
                cartItems = currentCartItems;
            }
            else
            {
                var foodProduct = _foodService.GetProductById(id);
                CartItem newCartItem = new CartItem()
                {
                    FoodProduct = new Models.FoodProduct {
                        Id=foodProduct.Id,
                        Description=foodProduct.Description,
                        ImageUrl=foodProduct.ImageUrl,
                        Name=foodProduct.Name,
                        Price=(decimal)foodProduct.Price
                    },
                    Amount = 1
                };
                cartItems.Add(newCartItem);
            }
            
            HttpContext.Session.Set<List<CartItem>>(sessionKeyCart, cartItems);

            return RedirectToAction("Index");
        }


    }


    // "https://www.c-sharpcorner.com/article/session-state-in-asp-net-core-and-mvc-core/"
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default :
                                  JsonConvert.DeserializeObject<T>(value);
        }
    }
}