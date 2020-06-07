using System;

namespace Lets.OrderWebService.Model
{
    public class OrderProduct
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        public Guid FoodProductId { get; set; }
        public FoodProduct FoodProduct { get; set; }
    }
}
