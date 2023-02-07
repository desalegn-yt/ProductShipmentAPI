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
