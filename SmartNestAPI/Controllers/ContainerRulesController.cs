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
    [Route("api/containerRule")]
    [ApiController]
    [Authorize]
    public class ContainerRulesController : ControllerBase
    {
        private readonly IContainerRuleService _containerRuleService;

        public ContainerRulesController(IContainerRuleService containerRuleService)
        {
            _containerRuleService = containerRuleService;
        }

        [HttpGet]
        public IEnumerable<ContainerRuleRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];

            return _containerRuleService.GetContainerRuleRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ContainerRuleReq containerRule)
        {
            if (ModelState.IsValid)
            {
                if (_containerRuleService.AddContainerRuleRecord(containerRule))
                {
                    return Ok("ContainerRule created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating ContainerRule!");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id}")]
        public ContainerRuleRes Details(Guid id)
        {
            return _containerRuleService.GetContainerRuleSingleRecord(id);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var data = _containerRuleService.GetContainerRuleSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_containerRuleService.DeleteContainerRuleRecord(id))
            {
                return Ok("ContainerRule deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting user containerRule!");
            }
        }
    }
}
