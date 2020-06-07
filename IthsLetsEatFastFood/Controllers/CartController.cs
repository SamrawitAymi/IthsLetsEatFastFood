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
using IthsLetsEatFastFood.Services.ChangeService;

namespace IthsLetsEatFastFood.Controllers
{
    public class CartController : Controller
    {
       
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        

        private const string sessionKeyCart = "_cart";

        public CartController( UserManager<ApplicationUser> userManager, IOrderService orderService)
        {
           _userManager = userManager;
            _orderService = orderService;
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

            //save to the database through order service
            _orderService.SaveOrder(cart);

           return View("OrderSuccess", viewModel);
        }

        public IActionResult OrderSuccess(Order order)
        {
            return View(order);
        }


    }
   
}