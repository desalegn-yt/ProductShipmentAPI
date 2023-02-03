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
    [Route("api/UserContainer")]
    [ApiController]
    [Authorize]
    public class UserContainersController : ControllerBase
    {
        private readonly IUserContainerService _UserContainerService;

        public UserContainersController(IUserContainerService UserContainerService)
        {
            _UserContainerService = UserContainerService;
        }
        [HttpGet]
        public IEnumerable<UserContainerRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
            return _UserContainerService.GetUserContainerRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserContainerReq UserContainer)
        {
            if (ModelState.IsValid)
            {
                if (_UserContainerService.AddUserContainerRecord(UserContainer))
                {
                    return Ok("User container created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating user container!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public UserContainerRes Details(Guid id)
        {
            return _UserContainerService.GetUserContainerSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserContainerReq UserContainer)
        {
            if (ModelState.IsValid)
            {
                if (_UserContainerService.UpdateUserContainerRecord(UserContainer))
                {
                    return Ok("User container updated successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating user container!");
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
            var data = _UserContainerService.GetUserContainerSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_UserContainerService.DeleteUserContainerRecord(id))
            {
                return Ok("User container deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting user container!");
            }
        }
    }
}
