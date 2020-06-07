using IthsLetsEatFastFood.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IthsLetsEatFastFood.Services.QueryService
{
    public class QueryService
    {
        public IEnumerable<FoodProduct> GetProductList()
        {
            using (var httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                httpClient.BaseAddress = new Uri("http://localhost:8080/api/FoodProduct");
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
                var response = httpClient.GetAsync($"{httpClient.BaseAddress}/{id}").GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                    Console.WriteLine(" request is not succesfull!");
                return JsonConvert.DeserializeObject<FoodProduct>(response.Content.ReadAsStringAsync().Result);
            }
        }



    }
}
