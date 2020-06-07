using Lets.WebService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.WebService.Service
{
    public interface IReadChangeProduct
    {
        FoodProduct GetFoodProById(Guid id);
        IList<FoodProduct> GetAll();
        FoodProduct DeleteById(Guid id);
        void InsertProduct(FoodProduct foodProduct);
        void UpdateProduct(FoodProduct foodProduct);
    }
}
