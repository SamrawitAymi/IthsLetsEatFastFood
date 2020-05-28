using Lets.WebService.Model;
using System;
using System.Collections.Generic;

namespace Lets.WebService.Repository
{
    public interface IFoodProductRepository
    {
        FoodProduct GetFoodProById(Guid id);
        IList<FoodProduct> GetAll();
        FoodProduct DeleteById(Guid id);

    }
}
