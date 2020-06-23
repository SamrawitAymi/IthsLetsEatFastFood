using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Lets.WebService.Data;
using Lets.WebService.Model;
using Lets.WebService.Repository;
using Lets.WebService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Lets.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodProductController : ControllerBase
    {
        private readonly FoodProductDbContext _dbContext;
        private readonly IReadChangeProduct _readChangeProduct;
        public FoodProductController(FoodProductDbContext context, IReadChangeProduct readFoodProduct )
        {
            _dbContext = context;
            _readChangeProduct = readFoodProduct;
        }

        [HttpGet]
        public IList<FoodProduct> Get()
        {
            return _readChangeProduct.GetAll();
            
        }

        [HttpGet("{id}")]
        public ActionResult<FoodProduct> GetById(Guid id)
        {
            var foodProduct = _readChangeProduct.GetFoodProById(id);
            if (foodProduct == null)
            {
                return NotFound();
            }
            return Ok(foodProduct);
        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
            var foodProduct = _readChangeProduct.DeleteById(id);
            if (foodProduct == null)
            {
                NotFound();
            }
            _dbContext.SaveChanges();
        }

        [HttpPut]
        public IActionResult Put([FromBody] FoodProduct foodProduct)
        {
            if (foodProduct != null)
            {
                using (var scope = new TransactionScope())
                {
                    _readChangeProduct.UpdateProduct(foodProduct);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }


    }
}