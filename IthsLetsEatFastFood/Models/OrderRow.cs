using IthsLetsEatFastFood.ViewModel;

namespace IthsLetsEatFastFood.Models
{
    public class OrderRow
    {
        
        public OrderRow(CartItem cartItem)
        {
            Amount = cartItem.Amount;
            FoodProduct = cartItem.FoodProduct;
        }
        public OrderRow() { }
        public FoodProduct FoodProduct { get; set; }
        public int Amount { get; set; }
     
    }
}
