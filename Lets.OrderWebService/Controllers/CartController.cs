﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lets.OrderWebService.Data;
using Lets.OrderWebService.Model;
using Lets.OrderWebService.ViewModel;
using Lets.WebService.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lets.OrderWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ILetsFoodService _foodService;
        private readonly OrderDbContext _context;

        public CartController(OrderDbContext context)
        {
            _context = context;
            _foodService = new LetsFoodService();

        }

        [HttpPost]
        public ActionResult AddToCart(CartViewModel cart)
        {
            var newOrder = new Order
            {
                TotalPrice = cart.TotalPrice,
                Date = new DateTime(2020,05,20),
                UserId = new Guid(),
                UserName = "test"
            };
            _context.Add(newOrder);
            
            foreach (var product in cart.FoodProducts)
            {
                var foodProduct = _context.Products.Where(p => p.Id == product.FoodProduct.Id).FirstOrDefault();
                var orderProduct=new OrderProduct
                {
                    Order = newOrder,
                    Product = foodProduct
                };
                _context.Add(orderProduct);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
