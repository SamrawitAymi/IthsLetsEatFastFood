using Lets.OrderWebService.Controllers;
using Lets.OrderWebService.Data;
using Lets.OrderWebService.Model;
using Lets.OrderWebService.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;

namespace Lets.OrderWebService.Test
{
    public class CartControllerTest :BaseTestFixture
    {
        public CartControllerTest()
       : base(new DbContextOptionsBuilder<OrderDbContext>().UseInMemoryDatabase("Filename=Test.db").Options)
        {

        }


        [Fact]
        public void Can_Save_Order_In_Database()
        {
            var cart = new CartItem
            {
                FoodProduct = new FoodProduct
                {
                    Id = new Guid(),
                    Description = "food description",
                    ImageUrl = "www.test.com",
                    Name = "Pizza",
                    Price = 95
                },
                Amount = 1
            };
            var cartList = new List<CartItem>();
            cartList.Add(cart);
            var cartVM = new CartViewModel { FoodProducts = cartList, TotalPrice = 95 };

            var cartController = new CartController(new OrderDbContext(ContextOptions));
            var order= cartController.AddToCart(cartVM);
            Assert.Equal(1,cart.Amount);
            Assert.Equal("Pizza",cart.FoodProduct.Name);
            Assert.Single(order.Products);
        }

        [Fact]
        public void Failed_to_save_order_For_not_existing_Products()
        {
            var cart = new CartItem
            {
                FoodProduct = new FoodProduct
                {
                    Id = new Guid(),
                    Description = "food description",
                    ImageUrl = "www.test.com",
                    Name = "falefel",
                    Price = 95
                },
                Amount = 1
            };
            var cartList = new List<CartItem>();
            cartList.Add(cart);
            var cartVM = new CartViewModel { FoodProducts = cartList, TotalPrice = 95 };

            var cartController = new CartController(new OrderDbContext(ContextOptions));
            var order = cartController.AddToCart(cartVM);
            
            Assert.Null(order);
        }
    }
}
