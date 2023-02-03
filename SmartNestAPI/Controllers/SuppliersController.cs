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
                if (_SupplierService.AddSupplierRecord(supplier))
                {
                    return Ok("Supplier created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating supplier!");
                }
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
                if (_SupplierService.UpdateSupplierRecord(supplier))
                {
                    return Ok("Supplier updated successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating supplier!");
                }
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
            if (_SupplierService.DeleteSupplierRecord(id))
            {
                return Ok("Supplier deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting supplier!");
            }
        }
    }
}
