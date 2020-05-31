
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
        private readonly IFoodProductRepository _foodProductRepository;
        public RepositoryTests()
        {
            _foodProductRepository = new MockFoodProductRepository();
        }
        [Fact]
        public void GetFoodProductByID_Returns_Product()
        {
            var foodProduct = _foodProductRepository.GetFoodProById(Guid.Empty);
            Assert.Equal(Guid.Empty, foodProduct.Id);
        }

        [Fact]
        public void GetAllFoodProduct_Returns_ListOfProduct()
        {
             var foodProducts = _foodProductRepository.GetAll();
            Assert.IsType<List<FoodProduct>>(foodProducts).ToList();
        }

        [Fact]
        public void DeleteFoodProductByID_Returns_Product()
        {
            var foodProduct = _foodProductRepository.DeleteById(Guid.Empty);
            Assert.Equal(Guid.Empty, foodProduct.Id);
        }



    }
}
