using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Controllers;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Repository;
using IthsLetsEatFastFood.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IthsLetsEatFastFood.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFoodProductRepository _foodProductRepository;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";
        public ShoppingCartController(IFoodProductRepository foodProductRepository, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _foodProductRepository = foodProductRepository;
        }

        public IActionResult AddToCart(Guid id)
        {
            //var apiService = Service.AddToCart(id);
            var currentCartItems = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            var userSessionId = HttpContext.Session.Get<Guid>(sessionKeyUserId);
            var actualUserId = Guid.Parse(_userManager.GetUserId(User));

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
                var foodProduct = _foodProductRepository.GetFoodProById(id);
                CartItem newCartItem = new CartItem()
                {
                    FoodProduct = foodProduct,
                    Amount = 1
                };
                cartItems.Add(newCartItem);
            }

            HttpContext.Session.Set<List<CartItem>>(sessionKeyCart, cartItems);

            return Ok();
        }
    }
}