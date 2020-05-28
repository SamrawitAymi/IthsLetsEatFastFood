using System;
using System.Collections.Generic;
using System.Text;

namespace Lets.WebService.Client
{
    public interface ILetsFoodService
    {
        IEnumerable<FoodProduct> GetProductList();

        FoodProduct GetProductById(Guid id);


    }
}
