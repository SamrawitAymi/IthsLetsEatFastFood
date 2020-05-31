﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Lets.WebService.Client
{
    public class LetsFoodService : ILetsFoodService
    {

        public IEnumerable<FoodProduct> GetProductList() 
        {
            IEnumerable<FoodProduct> products = new List<FoodProduct>();
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri("http://localhost:53884/api");
                var apiClient = new LetsApiClient(client);
                products = apiClient.FoodProductAllAsync().GetAwaiter().GetResult();

                if (products.Any())
                    Console.WriteLine("successfull request is done!");
            }

            return products;
        }

        public FoodProduct GetProductById(Guid id)
        {
            FoodProduct product = new FoodProduct();
            using (var handler = new HttpClientHandler())
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri("http://localhost:53884/api/id");
                var apiClient = new LetsApiClient(client);
                product = apiClient.FoodProductAsync(id).GetAwaiter().GetResult();

                if (product !=null)
                    Console.WriteLine("successfull request is done!");
            }

            return product;
        }


        //public FoodProduct AddToCart(Guid id)
        //{

        //}



    }
}