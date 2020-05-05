using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IthsLetsEatFastFood.Models
{
    public class FoodProduct
    {
        public Guid Id { get; set;}
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
