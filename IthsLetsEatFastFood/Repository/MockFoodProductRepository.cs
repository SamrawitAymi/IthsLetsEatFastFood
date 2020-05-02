using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IthsLetsEatFastFood.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace IthsLetsEatFastFood.Repository
{
    public class MockFoodProductRepository: IFoodProductRepository
    {
        private List<FoodProduct> _foodProductList;

        public MockFoodProductRepository()
        {
            InitData();
        }
        
        public List<FoodProduct> InitData()
        {
            _foodProductList = new List<FoodProduct>();
            _foodProductList.Add(new FoodProduct()
                {
                    Id = new Guid(),
                    id = 1,
                    Name = "Broccoli Cheddar Soup",
                    Description = "Butter,yellow onion, carrot,broccoli, garlic, flour,chicken, " +
                                   "beer, milk, Cheddar cheese,Salt and black pepper to taste,Tabasco sauce, Parmesan crisps",
                    Price = 79.99M,
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodnetwork.com%2Frecipes%2Ffood-network-kitchen%2Fbroccoli-cheddar-soup-recipe-1973722&psig=AOvVaw2wCQ_GV_9c3K3SmGxrJr5o&ust=1588514479307000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJCW_d6rlekCFQAAAAAdAAAAABAW"
                });
            _foodProductList.Add(new FoodProduct()
                    {
                            Id = new Guid(),
                            id = 2,
                            Name = "Broccoli Cheddar Soup",
                            Description = "Butter,yellow onion, carrot,broccoli, garlic, flour,chicken, " +
                                        "beer, milk, Cheddar cheese,Salt and black pepper to taste,Tabasco sauce, Parmesan crisps",
                            Price = 79.99M,
                            ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.foodnetwork.com%2Frecipes%2Ffood-network-kitchen%2Fbroccoli-cheddar-soup-recipe-1973722&psig=AOvVaw2wCQ_GV_9c3K3SmGxrJr5o&ust=1588514479307000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCJCW_d6rlekCFQAAAAAdAAAAABAW"
                        });
            _foodProductList.Add(new FoodProduct()
                    {
                        Id = new Guid(),
                        id = 3,
                        Name = "Pasta",
                        Description = "butter,shallot,garlic, tomato paste,red pepper flakes,vodka,Kosher salt,pasta, penne " +
                                "or rigatoni,,heavy cream, Parmesan, Basil",
                        Price = 89.99M,
                        ImageUrl = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/190226-vodka-sauce-horizontal-329-1551912836.jpg?crop=0.972xw:0.969xh;0.0226xw,0.0260xh&resize=640:*"
                    });

            return _foodProductList;
        }
        public void GetAll()
        {
            InitData();
        }

        public FoodProduct GetFoodProduct(int id)
        {
            return _foodProductList.Where(f => f.id == id).FirstOrDefault();          
        }


      
    }
}
