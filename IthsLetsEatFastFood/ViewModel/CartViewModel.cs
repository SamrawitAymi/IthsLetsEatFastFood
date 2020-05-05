using IthsLetsEatFastFood.Models;
using System.Collections.Generic;
namespace IthsLetsEatFastFood.ViewModel
{
    public class CartViewModel
    {
        public List<CartItem> FoodProducts { get; set; }
        //public List<(int amount, FoodProduct foodProduct)> FoodProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class CartItem
    {
        public FoodProduct FoodProduct { get; set; }
        public int Amount { get; set; }
    }
}
