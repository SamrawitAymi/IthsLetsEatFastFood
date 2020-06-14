using IthsLetsEatFastFood.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IthsLetsEatFastFood.Services.QueryService
{
    public class QueryService : IQueryService
    {
        public IEnumerable<FoodProduct> GetProductList()
        {
            using (var httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                httpClient.BaseAddress = new Uri("http://localhost:8080/api/FoodProduct");
                httpClient.DefaultRequestHeaders.Add("ApiKey", "letsApi get service access Key");
                var response = httpClient.GetAsync($"{httpClient.BaseAddress}").GetAwaiter().GetResult();
               
               if(!response.IsSuccessStatusCode)
                    Console.WriteLine(" request is not succesfull!");
                return JsonConvert.DeserializeObject<IEnumerable<FoodProduct>>(response.Content.ReadAsStringAsync().Result);
            }
        }

        public FoodProduct GetProductById(Guid id)
        {
            using (var httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {              
                httpClient.BaseAddress = new Uri("http://localhost:8080/api/FoodProduct");
                httpClient.DefaultRequestHeaders.Add("ApiKey", "letsApi get service access Key");
                var response = httpClient.GetAsync($"{httpClient.BaseAddress}/{id}").GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                    Console.WriteLine(" request is not succesfull!");
                return JsonConvert.DeserializeObject<FoodProduct>(response.Content.ReadAsStringAsync().Result);
            }
        }



    }
}
