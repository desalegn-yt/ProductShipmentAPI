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
    [Route("api/containerLog")]
    [ApiController]
    [Authorize]
    public class ContainerLogsController : ControllerBase
    {
        private readonly IContainerLogService _containerLogService;

        public ContainerLogsController(IContainerLogService ContainerLogService)
        {
            _containerLogService = ContainerLogService;
        }

        [HttpGet]
        public IEnumerable<ContainerLogRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];

            return _containerLogService.GetContainerLogRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContainerLogReq containerLog)
        {
            if (ModelState.IsValid)
            {
                if (_containerLogService.AddContainerLogRecord(containerLog))
                {
                    return Ok("ContainerLog created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating ContainerLog!");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id}")]
        public ContainerLogRes Details(Guid id)
        {
            return _containerLogService.GetContainerLogSingleRecord(id);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var data = _containerLogService.GetContainerLogSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_containerLogService.DeleteContainerLogRecord(id))
            {
                return Ok("ContainerLog deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting user ContainerLog!");
            }
        }
    }
}
