using Lets.OrderWebService.ViewModel;
using Lets.WebService.Client;
using System;

namespace Lets.OrderWebService.Model
{
    public class OrderProduct
    {
        //public OrderProduct(CartItem cartItem)
        //{
        //    Amount = cartItem.Amount;
        //    FoodProduct = cartItem.FoodProduct;
        //}
        //public OrderProduct() { }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
