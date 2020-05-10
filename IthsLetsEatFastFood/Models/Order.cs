using System;
using System.Collections.Generic;

namespace IthsLetsEatFastFood.Models
{
    public class Order
    {
        public Order()
        {
            OrderRows = new List<OrderRow>();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public List<OrderRow> OrderRows { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
