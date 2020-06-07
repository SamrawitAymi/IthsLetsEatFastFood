using IthsLetsEatFastFood.Models;
using System;
using System.Collections.Generic;

namespace IthsLetsEatFastFood.Services.QueryService
{
    public interface IQueryService
    {
        IEnumerable<FoodProduct> GetProductList();
        FoodProduct GetProductById(Guid id);
    }
}
