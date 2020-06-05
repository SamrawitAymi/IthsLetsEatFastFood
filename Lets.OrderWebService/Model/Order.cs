using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.OrderWebService.Model
{
    public class Order
    {
        //public Order()
        //{
        //    OrderRows = new List<OrderRow>();
        //}
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<OrderProduct> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
