using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Repository;
using IthsLetsEatFastFood.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IthsLetsEatFastFood.Controllers
{
    public class CartController : Controller
    {
        private readonly IFoodProductRepository _foodProductRepository;
        public CartController(IFoodProductRepository foodProductRepository)
        {
            _foodProductRepository = foodProductRepository;
        }
        public IActionResult Index(decimal amount)
        {
            var cart = Request.Cookies.SingleOrDefault(c => c.Key == "Cart");
            var cartIds = cart.Value.Split(',');
            var foodProducts = _foodProductRepository.GetAll();

            CartViewModel vm = new CartViewModel();
            vm.FoodProducts = new List<CartItem>();

            foreach (String id in cartIds)
            {
                var guid = Guid.Parse(id);
                if (vm.FoodProducts.Count > 0 && vm.FoodProducts.Any(pr => pr.FoodProduct?.Id == guid))
                {
                    int foodProductIdx = vm.FoodProducts.FindIndex(fp => fp.FoodProduct.Id == guid);
                    vm.FoodProducts[foodProductIdx].Amount += 1;
                }
                else
                {
                    var fp = _foodProductRepository.GetFoodProById(guid);
                    if (fp != null)
                    {
                        vm.FoodProducts.Add(new CartItem() { Amount = 1, FoodProduct = fp });
                    }
                }
            }
            vm.TotalPrice = vm.FoodProducts.Sum(fp => fp.FoodProduct.Price * fp.Amount);

            //ViewBag.cartList = vm.TotalPrice;
            return View(vm);
        }

        [HttpPost]
        public IActionResult MyOrder([Bind("TotalPrice", "FoodProduct")] CartViewModel vm)
        {
            return View();
        }

    }
}