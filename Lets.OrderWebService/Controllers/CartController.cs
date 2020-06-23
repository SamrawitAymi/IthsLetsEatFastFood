using System;
using System.Linq;
using Lets.OrderWebService.Data;
using Lets.OrderWebService.Model;
using Lets.OrderWebService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lets.OrderWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKeyAuth]
    public class CartController : ControllerBase
    {       
        private readonly OrderDbContext _context;
        public CartController(OrderDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public Order AddToCart(CartViewModel cart)
        {
            var newOrder = new Order
            {
                TotalPrice = cart.TotalPrice,
                Date = DateTime.UtcNow,
                UserId = new Guid(),
                UserName = "ApplicationUser"
            };
            _context.Add(newOrder);
            
            foreach (var product in cart.FoodProducts)
            {
                var foodProduct = _context.FoodProducts.Where(p => p.Name == product.FoodProduct.Name).FirstOrDefault();
                if (foodProduct !=null)
                {
                    var orderProduct = new OrderProduct
                    {
                        Order = newOrder,
                        FoodProduct = foodProduct
                    };
                    _context.Add(orderProduct);
                    _context.SaveChanges();

                    return newOrder;
                }
                
            }

            return null;
            
        }

        
    }
}
