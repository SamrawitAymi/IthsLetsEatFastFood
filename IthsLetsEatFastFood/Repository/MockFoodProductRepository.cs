﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;


namespace IthsLetsEatFastFood.Repository
{
    //public class MockFoodProductRepository: IFoodProductRepository
    //{
    //    private List<FoodProduct> _foodProductList;

    //    public MockFoodProductRepository()
    //    {
    //        InitData();
    //    }
        
    //    public List<FoodProduct> InitData()
    //    {
    //        _foodProductList = new List<FoodProduct>();
    public class MockFoodProductRepository: IFoodProductRepository
    {
        private List<FoodProduct> foodProducts = new List<FoodProduct>();
        public MockFoodProductRepository()
        {
            FoodProduct foodProduct = new FoodProduct();
            foodProducts = new List<FoodProduct>()
            {
                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Broccoli Cheddar Soup",
                    Description = "Butter,yellow onion, carrot,broccoli, garlic, flour,chicken, " +
                                       "beer, milk, Cheddar cheese,Salt and black pepper to taste,Tabasco sauce, Parmesan crisps",
                    Price = 79.99M,
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.the-girl-who-ate-everything.com%2Fpanera-broccoli-cheese-soup%2F&psig=AOvVaw2QKPLwsJX-LizWkyktTe4s&ust=1588669815242000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCODLzrHumekCFQAAAAAdAAAAABAM"
                },
                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Cheeseburger",
                    Description = "Becon,onion, Beef,Salad, tomato, cheese",
                    Price = 69.99M,
                    ImageUrl = "https://www.pngfuel.com/free-png/akvdc"
                },
                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Pasta",
                    Description = "butter,shallot,garlic, tomato paste,red pepper flakes,vodka,Kosher salt,pasta, penne " +
                                "or rigatoni,,heavy cream, Parmesan, Basil",
                    Price = 89.99M,
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/190226-vodka-sauce-horizontal-329-1551912836.jpg?crop=0.972xw:0.969xh;0.0226xw,0.0260xh&resize=640:*"
                },
                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Fried Chicken Wings",
                    Description = "chicken, flour, Parmesan cheese, paprika, dry mustard, " +
                        "dried oregano, crumbled,salt, black pepper,milk, Peanut oil",
                    Price = 89.99M,
                    ImageUrl = "https://www.jessicagavin.com/wp-content/uploads/2014/01/buttermilk-fried-chicken-11-600x900.jpg"
                },

                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Pizza",
                    Description = "chicken, chilli sauce,black pepper, salt, vinegar, soy sause, garlic, olive, piza sause, mozzarella cheese," +
                        " oregano, mushrooms, tomato, capsicum, flour, yeast,egg, oil",
                    Price = 99.99M,
                    ImageUrl = "https://www.pakistanichefrecipes.com/wp-content/uploads/2018/04/Chicken-Fajita-Pizza-500x500.jpg"
                },

                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Salad",
                    Description = "Seafrost Salt and Pepper Squid,Soy sauce,Mirin,Mixed salad leaves,Wakame seaweed",
                    Price = 39.99M,
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.unileverfoodsolutions.com.au%2Frecipe%2Fsalt-and-pepper-squid-salad-R0064938.html&psig=AOvVaw3fyiZlmH3HVNLRWEOJP1kj&ust=1588604247870000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJjF2576l-kCFQAAAAAdAAAAABAK"
                },

                new FoodProduct()
                {
                    Id = new Guid(),
                    Name = "Vegan Sandwich",
                    Description = "slices bread-toasted,slices tomato,light mayonnaise mixed with wasabi,iceberg lettuce leaves,mozzarella cheese",
                    Price = 59.99M,
                    ImageUrl = "https://c.ndtvimg.com/uv4mhm28_sandwich_625x300_31_July_18.jpg"
                },

            };
            foodProducts.Add(foodProduct);
            
        }

        public IEnumerable<FoodProduct> GetAll()
        {
            return foodProducts;
        }

        
        public FoodProduct GetFoodProById(Guid id)
        {
            return foodProducts.Where(f => f.Id == id).FirstOrDefault();
        }
    }
}
