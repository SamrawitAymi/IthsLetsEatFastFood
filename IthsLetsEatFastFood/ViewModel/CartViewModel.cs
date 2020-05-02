using IthsLetsEatFastFood.Models;
using System.Collections.Generic;
namespace IthsLetsEatFastFood.ViewModel
{
    public class CartViewModel
    {
        public List<(int amount, FoodProduct foodProduct)> FoodProducts { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
