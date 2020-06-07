using Lets.WebService.Data;
using Lets.WebService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.WebService.Service
{
    public class ReadChangeFoodProduct : IReadChangeProduct
    {
        private readonly FoodProductDbContext _dbContext;

        public ReadChangeFoodProduct(FoodProductDbContext context)
        {
            _dbContext = context;
        }

        public FoodProduct DeleteById(Guid id)
        {
            FoodProduct foodProduct = new FoodProduct();
            try
            {
                foodProduct = _dbContext.FoodProducts.Where(f => f.Id == id).FirstOrDefault();
                if (foodProduct != null)
                {
                    _dbContext.Remove(foodProduct);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return foodProduct;
        }

        public IList<FoodProduct> GetAll()
        {
            var foodProducts = _dbContext.FoodProducts.ToList();
            return foodProducts;
        }

        public FoodProduct GetFoodProById(Guid id)
        {
            return _dbContext.FoodProducts.Where(f => f.Id == id).FirstOrDefault();

        }


        public void InsertProduct(FoodProduct foodProduct)
        {
            _dbContext.Add(foodProduct);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(FoodProduct foodProduct)
        {
            _dbContext.Entry(foodProduct).State = EntityState.Modified;
            Save();
        }
    }
}
