using System;
using System.Collections.Generic;
using System.Linq;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Lets.WebService.Client;

namespace IthsLetsEatFastFood.Controllers
{
    public class CartController : Controller
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        

        private const string sessionKeyCart = "_cart";

        public CartController( UserManager<ApplicationUser> userManager)
        {
           _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
                        

            CartViewModel vm= new CartViewModel();
            vm.FoodProducts = cart;

            vm.TotalPrice = vm.FoodProducts.Sum(fp => fp.FoodProduct.Price * fp.Amount);

            return View(vm);
        }

        public IActionResult Delete(Guid id)
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart).ToList();
            if (cart != null)
            {
                HttpContext.Session.Remove(sessionKeyCart);
                HttpContext.Session.Set(sessionKeyCart, cart.Where(x => x.FoodProduct.Id != id));               
            }            
            return RedirectToAction("Index");

        }
        
        
        [HttpPost]
        public async Task<IActionResult> MyOrder([Bind("TotalPrice, FoodProduct")] CartViewModel cart)
        {
            cart.FoodProducts = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            OrderViewModel viewModel = new OrderViewModel();
            Order order = new Order();
            order.Date = DateTime.Now;
            order.TotalPrice = cart.TotalPrice;
            order.OrderRows = cart.FoodProducts.Select(cartItem => new OrderRow(cartItem)
            {
                Amount = cartItem.Amount,
                FoodProduct = cartItem.FoodProduct
            }).ToList();
            var userIdentity = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.UserId = Guid.Parse(_userManager.GetUserId(User));
           
            viewModel.Order = order;
            var user = await _userManager.GetUserAsync(User);
            viewModel.User = user;
            
           // var productId = order.OrderRows.Select(s => s.FoodProduct.Id);
           //var orderId= order.Id;
                   
            
            return View("OrderSuccess", viewModel);
        }

        public IActionResult OrderSuccess(Order order)
        {
            return View(order);
        }


    }
   
}