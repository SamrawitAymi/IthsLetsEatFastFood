using System;
using System.Collections.Generic;
using System.Linq;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Repository;
using IthsLetsEatFastFood.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IthsLetsEatFastFood.Controllers
{
    public class CartController : Controller
    {
        private readonly IFoodProductRepository _foodProductRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        private const string sessionKeyCart = "_cart";
        private const string sessionKeyUserId = "_userId";

        public CartController(IFoodProductRepository foodProductRepository, UserManager<ApplicationUser> userManager)
        {
            _foodProductRepository = foodProductRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
            var products = _foodProductRepository.GetAll();

            CartViewModel vm = new CartViewModel();
            vm.FoodProducts = cart;


            vm.TotalPrice = vm.FoodProducts.Sum(fp => fp.FoodProduct.Price * fp.Amount);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> MyOrder([Bind("TotalPrice, FoodProduct")] CartViewModel cart)
        {
            OrderViewModel viewModel = new OrderViewModel();
            Order order = new Order();
            order.Date = DateTime.Now;
            order.TotalPrice = cart.TotalPrice;
            var userIdentity = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.UserId = Guid.Parse(_userManager.GetUserId(User));
            order.OrderRows = cart.FoodProducts.Select(cartItem => new OrderRow(cartItem)
            {
                Amount = cartItem.Amount,
                FoodProduct = cartItem.FoodProduct
            }).ToList();
            //foreach (var cartItem in cart.FoodProducts)
            //{
            //    order.OrderRows.Add((OrderRow)cartItem);
            //}
            viewModel.Order = order;
            var user = await _userManager.GetUserAsync(User);
            viewModel.User = user;
            return View("OrderSuccess", viewModel);
        }

        public IActionResult OrderSuccess(Order order)
        {
            return View(order);
        }
    }
        //[HttpPost]
        //public async Task<IActionResult> MyOrder([Bind("TotalPrice, FoodProduct")] CartViewModel cart)
        //{
        //    OrderViewModel viewModel = new OrderViewModel();
        //    Order order = new Order();
        //    order.Date = DateTime.Now;
        //    order.TotalPrice = cart.TotalPrice;
        //    var userIdentity = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    order.UserId = Guid.Parse(_userManager.GetUserId(User));
        //    order.OrderRows = cart.FoodProducts.Select(cartItem => new OrderRow(cartItem)).ToList();
        //    viewModel.Order = order;
        //    var user = await _userManager.GetUserAsync(User);
        //    viewModel.User = user;
        //    return View("OrderSuccess", viewModel);
        //}
        //var currentCartItems = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
        //var userSessionId = HttpContext.Session.Get<Guid>(sessionKeyUserId);
        //var actualUserId = Guid.Parse(_userManager.GetUserId(User));

        //List<CartItem> cartItems = new List<CartItem>();

        //if (currentCartItems != null)
        //{
        //    cartItems = currentCartItems;
        //    if (userSessionId != actualUserId)
        //    {
        //        currentCartItems = null;
        //        HttpContext.Session.Clear();
        //        cartItems = new List<CartItem>();

        //    }

        //    HttpContext.Session.Set<Guid>(sessionKeyUserId, actualUserId);
        //}
        //if (currentCartItems != null && currentCartItems.Any(fp => fp.FoodProduct.Id == id))
        //{
        //    int foodProductIndex = currentCartItems.FindIndex(fp => fp.FoodProduct.Id == id);
        //    currentCartItems[foodProductIndex].Amount += 1;
        //    cartItems = currentCartItems;
        //}
        //else
        //{
        //    var foodProduct = _foodProductRepository.GetFoodProById(id);
        //    CartItem newCartItem = new CartItem()
        //    {
        //        FoodProduct = foodProduct,
        //        Amount = 1
        //    };
        //    cartItems.Add(newCartItem);
        //}

        //HttpContext.Session.Set<List<CartItem>>(sessionKeyCart, cartItems);

        //var totalCartItems = currentCartItems.Sum(fp => fp.Amount);
        //return Ok(totalCartItems);
    

    //[HttpGet]
    //public JsonResult GetCartAmount()
    //{
    //    var currentCartItems = HttpContext.Session.Get<List<CartItem>>(sessionKeyCart);
    //    var totalCartItems = currentCartItems.Sum(fp => fp.Amount);
    //    return new JsonResult(totalCartItems);
    //}


    //public IActionResult Index(decimal amount)
    //{
    //    var cart = Request.Cookies.SingleOrDefault(c => c.Key == "Cart");
    //    var cartIds = cart.Value.Split(',', StringSplitOptions.RemoveEmptyEntries);
    //    var foodProducts = _foodProductRepository.GetAll();

    //    CartViewModel vm = new CartViewModel();
    //    vm.FoodProducts = new List<CartItem>();

    //    foreach (String id in cartIds)
    //    {
    //        var guid = Guid.Parse(id);
    //        if (vm.FoodProducts.Count > 0 && vm.FoodProducts.Any(pr => pr.FoodProduct?.Id == guid))
    //        {
    //            int foodProductIdx = vm.FoodProducts.FindIndex(fp => fp.FoodProduct.Id == guid);
    //            vm.FoodProducts[foodProductIdx].Amount += 1;
    //        }
    //        else
    //        {
    //            var fp = _foodProductRepository.GetFoodProById(guid);
    //            if (fp != null)
    //            {
    //                vm.FoodProducts.Add(new CartItem() { Amount = 1, FoodProduct = fp });
    //            }
    //        }
    //    }
    //    vm.TotalPrice = vm.FoodProducts.Sum(fp => fp.FoodProduct.Price * fp.Amount);
    //    return View(vm);
    //}




    


}