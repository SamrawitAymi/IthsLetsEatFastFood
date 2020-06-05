using Lets.OrderWebService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.OrderWebService.Data
{
    public class OrderDbContext: DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<FoodProduct> FoodProducts { get; set; }     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>().HasKey(o=>o.Id);

            modelBuilder.Entity<FoodProduct>().HasKey(p=>p.Id);

            modelBuilder.Entity<OrderProduct>().HasKey(op=> new { op.OrderId, op.FoodProductId});
            modelBuilder.Entity<OrderProduct>().HasOne(o => o.Order).WithMany(p=>p.Products);
            modelBuilder.Entity<OrderProduct>().HasOne(p => p.FoodProduct).WithMany(o => o.Orders);
        }
    }
}
