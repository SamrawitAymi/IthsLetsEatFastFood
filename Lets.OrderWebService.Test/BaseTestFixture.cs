using Lets.OrderWebService.Data;
using Microsoft.EntityFrameworkCore;

namespace Lets.OrderWebService.Test
{
    public class BaseTestFixture
    {
        protected DbContextOptions<OrderDbContext> ContextOptions { get; }

        public BaseTestFixture(DbContextOptions<OrderDbContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();

        }

        private void Seed()
        {
          
            using (var context = new OrderDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var mockFoodList = new MockFoodProductRepository();
                var foodList = mockFoodList.FoodProducts();


                foreach (var foodProduct in foodList)
                {

                    context.Add(foodProduct);
                }
                context.SaveChanges();
                }
           
        }
    }
}
