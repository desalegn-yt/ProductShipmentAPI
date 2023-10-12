using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using ProductShipmentAPI.Application.Services;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using System.Net;

namespace ProductShipmentAPI.Controllers
{
    [Route("api/userContainer")]
    [ApiController]
    [Authorize]
    public class UserContainersController : ControllerBase
    {
        private readonly IUserContainerService _userContainerService;

        public UserContainersController(IUserContainerService UserContainerService)
        {
            _userContainerService = UserContainerService;
        }
        [HttpGet]
        public IEnumerable<UserContainerRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
            return _userContainerService.GetUserContainerRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserContainerReq UserContainer)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];

                if (_userContainerService.AddUserContainerRecord(UserContainer, clientID))
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
        public UserContainerDetailRes Details(Guid id)
        {
            return _userContainerService.GetUserContainerSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserContainerReq UserContainer)
        {
            if (ModelState.IsValid)
            {
                if (_userContainerService.UpdateUserContainerRecord(UserContainer))
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
            var data = _userContainerService.GetUserContainerSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_userContainerService.DeleteUserContainerRecord(id))
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
