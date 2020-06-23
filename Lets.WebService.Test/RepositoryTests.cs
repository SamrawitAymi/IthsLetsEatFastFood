
using Lets.WebService.Model;
using Lets.WebService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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
            Assert.IsType<List<Model.FoodProduct>>(foodProducts).ToList();
        }

        [Fact]
        public void DeleteFoodProductByID_Returns_Product()
        {
            var foodProduct = _foodProductRepository.DeleteById(Guid.Empty);
            Assert.Equal(Guid.Empty, foodProduct.Id);
        }

        [Fact]
        public void InsertFoodProduct_Returns_AddNewProduct()
        {
            FoodProduct newFoodProduct = new FoodProduct {
                Id = new Guid(),
                Name = "Falafel",
                Price = (decimal)49.99,
                ImageUrl = "https://www.themediterraneandish.com/wp-content/uploads/2020/02/falafel-recipe-10-1024x1536.jpg",
                Description = "Special"
            };
           
            int productCount = _foodProductRepository.GetAll().Count();
            Assert.Equal(8, productCount);// Verify the expected Number pre-insert
            

            //// try saving our new product
            _foodProductRepository.InsertProduct(newFoodProduct);

            //// demand a recount
            productCount = _foodProductRepository.GetAll().Count;
            Assert.Equal(9, productCount); // Verify the expected Number post-insert

            
        }

    }
}
