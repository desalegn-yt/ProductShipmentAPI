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
    [Route("api/supplier")]
    [ApiController]
    [Authorize]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService _SupplierService;

        public SuppliersController(ISupplierService SupplierService)
        {
            _SupplierService = SupplierService;
        }
        [HttpGet]
        public IEnumerable<SupplierRes> Get()
        {
            return _SupplierService.GetSupplierRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] SupplierReq supplier)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                supplier.Id = obj;
                _SupplierService.AddSupplierRecord(supplier);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public SupplierRes Details(Guid id)
        {
            return _SupplierService.GetSupplierSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] SupplierReq supplier)
        {
            if (ModelState.IsValid)
            {
                _SupplierService.UpdateSupplierRecord(supplier);
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
            var data = _SupplierService.GetSupplierSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _SupplierService.DeleteSupplierRecord(id);
            return Ok();
        }
    }
}
