using IthsLetsEatFastFood.ViewModel;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace IthsLetsEatFastFood.Services.ChangeService
{
    public class OrderService :IOrderService
    {
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
