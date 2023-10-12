using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductShipmentAPI.Application.Services;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using System.Net;

namespace ProductShipmentAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
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
                if (_productService.AddProductRecord(product))
                {
                    return Ok("Product created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating product!");
                }
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
    
    }
}
