using IthsLetsEatFastFood.ViewModel;

namespace IthsLetsEatFastFood.Services.ChangeService
{
    public interface IOrderService
    {
        void SaveOrder(CartViewModel order);
    }
}
