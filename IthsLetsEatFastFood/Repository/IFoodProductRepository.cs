using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;

namespace IthsLetsEatFastFood.Repository
{
    public interface IFoodProductRepository
    {
        FoodProduct GetFoodProById(Guid id);
        IEnumerable<FoodProduct> GetAll();
        FoodProduct DeleteById(Guid id);

        //void DeleteById(Guid id);
       
    }
}
