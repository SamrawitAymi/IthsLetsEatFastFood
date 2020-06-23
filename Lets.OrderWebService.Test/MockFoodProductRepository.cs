using Lets.OrderWebService.Model;
using System;
using System.Collections.Generic;

namespace Lets.OrderWebService.Test
{
    public class MockFoodProductRepository
    {
        public List<FoodProduct> FoodProducts()
        {
            var foodProducts = new List<FoodProduct>() {
                 new FoodProduct{

                    Id = Guid.NewGuid(),
                    Name = "Pizza",
                    Price = (decimal)49.99,
                    ImageUrl = "https://www.themediterraneandish.com/wp-content/uploads/2020/02/falafel-recipe-10-1024x1536.jpg",
                    Description = "Special"
                },
                 new FoodProduct

                {
                    Id =Guid.NewGuid(),
                    Name = "Broccoli Cheddar Soup",
                    Description = "Butter,yellow onion, carrot,broccoli, garlic, flour,chicken, " +
                                       "beer, milk, Cheddar cheese,Salt and black pepper to taste,Tabasco sauce, Parmesan crisps",
                    Price = 79.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2018/02/Broccoli-Cheddar-Soup-LEAD-3-600x840.jpg"

                    }
            };

            return foodProducts;
        }

    }
}