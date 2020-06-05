using System;
using System.Collections.Generic;
using Lets.WebService.Model;
using Lets.WebService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Lets.WebService.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodProductController : ControllerBase
    {
        private readonly IFoodProductRepository _foodProductRepository;
        public FoodProductController()
        {
            _foodProductRepository = new MockFoodProductRepository();
        }

        [HttpGet]
        public IList<FoodProduct> Get()
        {
            return _foodProductRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<FoodProduct> GetById(Guid id)
        {
            var foodProduct = _foodProductRepository.GetFoodProById(id);
            if (foodProduct == null)
            {
                return NotFound();
            }
            return Ok(foodProduct);
        }

        [HttpDelete("{id}")]
        public void DeleteById(Guid id)
        {
            var foodProduct = _foodProductRepository.DeleteById(id);
            if (foodProduct == null)
            {
                NotFound();
            }
            
        }

        //public FoodProduct AddToCart()
        //{

        //}


        //[HttpGet("{id}/file")]
        //public async Task<IActionResult> GetDocument(int id)
        //{
        //    _logger.LogInformation("GetDocument with ID {Id} by user '{User}'", id, User.Identity.Name);

        //    var fileData = await _rawFileStore.GetRawFileDataById(id).ConfigureAwait(false);

        //    return File(fileData, "application/octet-stream");
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetDocumentObject(int id)
        //{
        //    _logger.LogInformation("GetDocumentObject with ID {Id} by user '{User}'", id, User.Identity.Name);

        //    var file = await _rawFileStore.GetRawFileById(id).ConfigureAwait(false);

        //    return Ok(file);
        //}

        //[HttpGet("list")]
        //public async Task<IActionResult> GetListOfDocumentObjects([FromBody] RawFileRequest rawFile)
        //{

        //    //_logger.LogInformation($"GetDocumentObjects of {rawFile.Ids} by user '{User.Identity.Name}'");


        //    var files = await _rawFileStore.GetListOfRawFiles(rawFile.Ids).ConfigureAwait(false);

        //    return Ok(files);

        //}

        //[HttpPost("")]
        //public async Task<IActionResult> CreateDocument([FromBody]RawFileRequest rawFile)
        //{
        //    _logger.LogInformation("CreateDocument '{FileName}' (size:{FileSize}) by user '{User}'",
        //        rawFile.FileName,
        //        rawFile.FileData?.Length,
        //        User.Identity.Name);

        //    var id = await _rawFileStore.AddRawFile(
        //        new RawFile
        //        {
        //            FileName = rawFile.FileName,
        //            FileData = rawFile.FileData
        //        },
        //        User.Identity.Name).ConfigureAwait(false);

        //    return Ok(id);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteDocument(int id)
        //{
        //    _logger.LogInformation("DeleteDocument with ID {Id} by user '{User}'", id, User.Identity.Name);

        //    await _rawFileStore.DeleteRawFile(id, User.Identity.Name).ConfigureAwait(false);

        //    return Ok();
        //}
    }
}