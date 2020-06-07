
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IthsLetsEatFastFood.Services.ChangeService
{
    public class OrderService
    {
        public void AddToCart(CartViewModel cart)
        {
            
            using (var httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                httpClient.BaseAddress = new Uri("http://localhost:8080/api/FoodProduct");
                var response = httpClient.GetAsync($"{httpClient.BaseAddress}/{cart}").GetAwaiter().GetResult();

                if (!response.IsSuccessStatusCode)
                    Console.WriteLine(" request is not succesfull!");
                JsonConvert.DeserializeObject<FoodProduct>(response.Content.ReadAsStringAsync().Result);
            }



        }
    }
}
