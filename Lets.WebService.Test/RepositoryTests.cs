using Lets.WebService.Model;
using Lets.WebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Lets.WebService.Test
{
    public class RepositoryTests
    {
        [Fact]
        public void GetFoodProductByID_Returns_Product()
        {
            var foodProductsRepository = new MockFoodProductRepository();
            var foodProduct = foodProductsRepository.GetFoodProById(Guid.Empty);
            Assert.Equal(Guid.Empty, foodProduct.Id);
        }
        [Fact]
        public void GetAllFoodProduct_Returns_ListOfProduct()
        {
            var foodProductsRepository = new MockFoodProductRepository();
             var foodProducts = foodProductsRepository.GetAll();
            //var foodProduct = foodProductsRepository.GetAll();
            Assert.IsType<List<FoodProduct>>(foodProducts).ToList();
        }

    }
}
