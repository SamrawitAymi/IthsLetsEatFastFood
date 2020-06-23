using Lets.OrderWebService.ViewModel;

namespace Lets.OrderWebService.Repository
{
    public interface IFoodProductRepository
    {
        public CartViewModel AddToCart(CartViewModel cart);
    }
}