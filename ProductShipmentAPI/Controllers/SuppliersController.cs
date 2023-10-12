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
    [Route("api/supplier")]
    [ApiController]
    [Authorize]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _supplierService;

        public SuppliersController(ISupplierService SupplierService)
        {
            _supplierService = SupplierService;
        }
        [HttpGet]
        public IEnumerable<SupplierRes> Get()
        {
            return _supplierService.GetSupplierRecords();
        }

        [HttpGet("{id}")]
        public SupplierRes Details(Guid id)
        {
            return _supplierService.GetSupplierSingleRecord(id);
        }
    }
}
