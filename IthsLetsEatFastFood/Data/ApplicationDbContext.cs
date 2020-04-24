using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IthsLetsEatFastFood.Models;

namespace IthsLetsEatFastFood.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<IthsLetsEatFastFood.Models.FoodProduct> FoodProduct { get; set; }
    }
}
