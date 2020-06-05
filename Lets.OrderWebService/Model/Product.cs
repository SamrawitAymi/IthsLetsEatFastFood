using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.OrderWebService.Model
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public List<OrderProduct> Orders { get; set; }
    }
}
//get from OrderProduct where orderId==4
//it gives all products with orderId 4. We will get list of ProductsId.
//Each product has price so that we can calculate the price.