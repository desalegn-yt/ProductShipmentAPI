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
    [Route("api/userAddress")]
    [ApiController]
    [Authorize]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _userAddresservice;

        public UserAddressController(IUserAddressService UserAddresservice)
        {
            _userAddresservice = UserAddresservice;
        }
        [HttpGet]
        public IEnumerable<UserAddressRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];

            return _userAddresservice.GetUserAddressRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserAddressReq user)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
                if (_userAddresservice.AddUserAddressRecord(user, clientID))
                {
                    return Ok("User address created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating user address!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public UserAddressRes Details(Guid id)
        {
            return _userAddresservice.GetUserAddressSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserAddressReq user)
        {
            if (ModelState.IsValid)
            {
                if (_userAddresservice.UpdateUserAddressRecord(user))
                {
                    return Ok("User address updated successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating user address!");
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
            var data = _userAddresservice.GetUserAddressSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_userAddresservice.DeleteUserAddressRecord(id))
            {
                return Ok("User address deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting user address!");
            }
        }
    }
}
