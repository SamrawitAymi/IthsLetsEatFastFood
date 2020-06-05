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
        public Guid FoodProductId { get; set; }
        public FoodProduct FoodProduct { get; set; }
    }
}
