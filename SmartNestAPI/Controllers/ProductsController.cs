using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using System.Net;

namespace SmartNestAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<ProductRes> Get()
        {
            return _productService.GetProductRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductReq product)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                product.Id = obj;
                _productService.AddProductRecord(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public ProductRes Details(Guid id)
        {
            return _productService.GetProductSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] ProductReq product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProductRecord(product);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var data = _productService.GetProductSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _productService.DeleteProductRecord(id);
            return Ok();
        }
    }
}
