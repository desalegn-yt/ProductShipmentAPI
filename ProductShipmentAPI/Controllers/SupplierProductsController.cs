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
    [Route("api/supplierProduct")]
    [ApiController]
    [Authorize]
    public class SupplierProductsController : ControllerBase
    {
        private readonly ISupplierProductService _supplierProductService;

        public SupplierProductsController(ISupplierProductService supplierProductService)
        {
            _supplierProductService = supplierProductService;
        }
        [HttpGet]
        public IEnumerable<SupplierProductRes> Get()
        {
            return _supplierProductService.GetSupplierProductRecords();
        }

        [HttpGet("{id}/{categoryId?}")]
        public SupplierProductRes Details(Guid id, Guid? categoryId)
        {
            return _supplierProductService.GetSupplierProductSingleRecord(id, categoryId);
        }
    }
}
