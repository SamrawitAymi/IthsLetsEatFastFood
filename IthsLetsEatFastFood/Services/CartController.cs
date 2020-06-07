using System;
using System.Collections.Generic;
using System.Linq;
using IthsLetsEatFastFood.Controllers;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Services.QueryService;
using IthsLetsEatFastFood.ViewModel;
using Lets.WebService.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IthsLetsEatFastFood.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";
        public CartController( UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public JsonResult GetCartAmount()
        {
            var currentCartItems = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            if (currentCartItems == null)
            {
                return new JsonResult(0);
            }
            var totalItems = currentCartItems.Sum(cart => cart.Amount);
            return new JsonResult(totalItems);
        }

        [HttpGet]
        public IActionResult AddToCart(Guid id)
        {
            
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
                var getFoodProduct = new QueryService();
                var foodProduct = getFoodProduct.GetProductById(id);
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
            var totalItems = cartItems.Sum(cart => cart.Amount);

            return Ok(totalItems);
        }
    }
}