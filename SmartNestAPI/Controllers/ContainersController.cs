using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SmartNestAPI.Application.Services;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using System.Net;

namespace SmartNestAPI.Controllers
{
    [Route("api/container")]
    [ApiController]
    [Authorize]
    public class ContainersController : ControllerBase
    {
        private readonly IContainerService _containerService;

        public ContainersController(IContainerService containerService)
        {
            _containerService = containerService;
        }
        [HttpGet]
        public IEnumerable<ContainerRes> Get()
        {
            return _containerService.GetContainerRecords();
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] ContainerReq container)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_containerService.AddContainerRecord(container))
        //        {
        //            return Ok("Container created successfully!");
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating container!");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        [HttpGet("{id}")]
        public ContainerDetailRes Details(Guid id)
        {
            return _containerService.GetContainerSingleRecord(id);
        }

        //[HttpPut]
        //public IActionResult Edit([FromBody] ContainerUpdateReq container)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (_containerService.UpdateContainerRecord(container))
        //        {
        //            return Ok("Container updated successfully!");
        //        }
        //        else
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating container!");
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest(ModelState);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public IActionResult DeleteConfirmed(Guid id)
        //{
        //    var data = _containerService.GetContainerSingleRecord(id);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    if (_containerService.DeleteContainerRecord(id))
        //    {
        //        return Ok("Container deleted successfully!");
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting container!");
        //    }
        //}
    }
}
