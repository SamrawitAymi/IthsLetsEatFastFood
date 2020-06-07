using Lets.WebService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lets.WebService.Data
{
    public class FoodProductDbContext:DbContext
    {
        public FoodProductDbContext(DbContextOptions<FoodProductDbContext> options)
           : base(options)
        {
        }
        public DbSet<FoodProduct> FoodProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodProduct>().HasKey(p => p.Id);
        }
    }
}