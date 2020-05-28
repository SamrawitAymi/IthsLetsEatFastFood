using Lets.WebService.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;



namespace Lets.WebService.Repository
{
    
    public class MockFoodProductRepository: IFoodProductRepository
    {
        private List<FoodProduct> foodProducts = new List<FoodProduct>();
        public MockFoodProductRepository()
        {
            FoodProduct foodProduct = new FoodProduct();
            foodProducts = new List<FoodProduct>()
            {
                new FoodProduct
                {
                    Id =Guid.NewGuid(),
                    Name = "Broccoli Cheddar Soup",
                    Description = "Butter,yellow onion, carrot,broccoli, garlic, flour,chicken, " +
                                       "beer, milk, Cheddar cheese,Salt and black pepper to taste,Tabasco sauce, Parmesan crisps",
                    Price = 79.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2018/02/Broccoli-Cheddar-Soup-LEAD-3-600x840.jpg"

                    },
                new FoodProduct
                {
                    Id = Guid.NewGuid(),
                    Name = "Cheeseburger",
                    Description = "Becon,onion, Beef,Salad, tomato, cheese",
                    Price = 69.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2019/04/Stovetop-Cheeseburgers-hero1_v2-600x841.jpg"
                },
                new FoodProduct
                {
                    Id = Guid.NewGuid(),
                    Name = "Pasta",
                    Description = "butter,shallot,garlic, tomato paste,red pepper flakes,vodka,Kosher salt,pasta, penne " +
                                "or rigatoni,,heavy cream, Parmesan, Basil",
                    Price = 89.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2012/02/pasta-carbonara-vertical-a-1200-600x892.jpg"
                },
                new FoodProduct
                {
                    Id = Guid.NewGuid(),
                    Name = "Fried Chicken Wings",
                    Description = "chicken, flour, Parmesan cheese, paprika, dry mustard, " +
                        "dried oregano, crumbled,salt, black pepper,milk, Peanut oil",
                    Price = 89.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2019/09/Cacio-e-Pepe-Chicken-Wings-Lead-8-600x840.jpg"
                },

                new FoodProduct
                {
                    Id = Guid.NewGuid(),
                    Name = "Pizza",
                    Description = "chicken, chilli sauce,black pepper, salt, vinegar, soy sause, garlic, olive, piza sause, mozzarella cheese," +
                        " oregano, mushrooms, tomato, capsicum, flour, yeast,egg, oil",
                    Price = 99.99M,
                    ImageUrl = "https://www.pakistanichefrecipes.com/wp-content/uploads/2018/04/Chicken-Fajita-Pizza-500x500.jpg"
                },

                new FoodProduct
                {
                    Id = Guid.NewGuid(),
                    Name = "Salad",
                    Description = "Seafrost Salt and Pepper Squid,Soy sauce,Mirin,Mixed salad leaves,Wakame seaweed",
                    Price = 39.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2007/10/waldorf-salad-vertical-a3-1500-600x837.jpg"
                },

                new FoodProduct
                {
                    Id = Guid.NewGuid(),
                    Name = "Vegan Sandwich",
                    Description = "slices bread-toasted,slices tomato,light mayonnaise mixed with wasabi,iceberg lettuce leaves,mozzarella cheese",
                    Price = 59.99M,
                    ImageUrl = "https://www.simplyrecipes.com/wp-content/uploads/2019/10/Vegan-Lentil-Sloppy-LEAD-1-600x840.jpg"
                }
            };
            foodProducts.Add(foodProduct);
            
        }

        public FoodProduct DeleteById(Guid id)
        {
            FoodProduct foodProduct = new FoodProduct();
            try
            {
                foodProduct = foodProducts.Where(fp => fp.Id == id).FirstOrDefault();
                if (foodProduct != null)
                {
                    foodProducts.Remove(foodProduct); 
                    
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
            return foodProducts;
        }
                
        public FoodProduct GetFoodProById(Guid id)
        {
            return foodProducts.Where(f => f.Id == id).FirstOrDefault();
        }

    }
}
