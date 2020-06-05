using Lets.WebService.Model;
using Lets.WebService.Client;
using Lets.WebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
//using FoodProduct = Lets.WebService.Client.FoodProduct;

namespace Lets.WebService.Test
{
    public class RepositoryTests
    {
        private readonly IFoodProductRepository _foodProductRepository;
        //private readonly ILetsFoodService _foodService;
        public RepositoryTests()
        {
            _foodProductRepository = new MockFoodProductRepository();
            //_foodService = new LetsFoodService(); 
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
            Assert.IsType<List<Model.FoodProduct>>(foodProducts).ToList();
        }

        [Fact]
        public void DeleteFoodProductByID_Returns_Product()
        {
            var foodProduct = _foodProductRepository.DeleteById(Guid.Empty);
            Assert.Equal(Guid.Empty, foodProduct.Id);
        }

        //[Fact]
        //public void AddToCartFoodProducts_Returns_ProductsInCart()
        //{
        //    var foodProducts = _.AddToCart(Guid.Empty);
        //    Assert.Equal(Guid.Empty, foodProducts.Id);
        //}
    }
}
