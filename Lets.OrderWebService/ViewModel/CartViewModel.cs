using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.OrderWebService.ViewModel
{
    public class CartViewModel
    {
        public List<CartItem> FoodProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
