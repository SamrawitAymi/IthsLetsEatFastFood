﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;

namespace IthsLetsEatFastFood.Repository
{
    interface IFoodProductRepository
    {
        FoodProduct GetFoodProduct(int Id);
        void GetAll();
       
    }
}
