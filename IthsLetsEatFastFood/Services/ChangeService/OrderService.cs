
using IthsLetsEatFastFood.Models;
using IthsLetsEatFastFood.Services.QueryService;
using IthsLetsEatFastFood.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IthsLetsEatFastFood.Services.ChangeService
{
    public class OrderService :IOrderService
    {
        //public void AddToCart(CartViewModel cart)
        //{

        //    using (var httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
        //    {
        //        httpClient.BaseAddress = new Uri("http://localhost:8080/api/FoodProduct");
        //        var response = httpClient.GetAsync($"{httpClient.BaseAddress}/{cart}").GetAwaiter().GetResult();

        //        if (!response.IsSuccessStatusCode)
        //            Console.WriteLine(" request is not succesfull!");
        //        JsonConvert.DeserializeObject<FoodProduct>(response.Content.ReadAsStringAsync().Result);
        //    }
        //}
        public void SaveOrder(CartViewModel order)
        {

            var json = JsonConvert.SerializeObject(order, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true }))
            {
                httpClient.BaseAddress = new Uri("https://localhost:44396/api/Cart");
                var response = httpClient.PostAsync($"{httpClient.BaseAddress}",stringContent).GetAwaiter().GetResult();

                if (response.StatusCode == HttpStatusCode.OK)
                    Console.WriteLine("Saved succesfully!");

            }
        }

    }
}
