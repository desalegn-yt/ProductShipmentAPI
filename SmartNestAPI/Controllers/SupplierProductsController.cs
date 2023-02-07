using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartNestAPI.Application.Services;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using System.Net;

namespace SmartNestAPI.Controllers
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

        [HttpGet("{id}")]
        public SupplierProductRes Details(Guid id)
        {
            return _supplierProductService.GetSupplierProductSingleRecord(id);
        }
    }
}
