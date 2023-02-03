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
    [Route("api/userAddress")]
    [ApiController]
    [Authorize]
    public class UserAddressController : ControllerBase
    {
        private readonly IUserAddressService _UserAddresservice;

        public UserAddressController(IUserAddressService UserAddresservice)
        {
            _UserAddresservice = UserAddresservice;
        }
        [HttpGet]
        public IEnumerable<UserAddressRes> Get()
        {
            return _UserAddresservice.GetUserAddressRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserAddressReq user)
        {
            if (ModelState.IsValid)
            {
                if (_UserAddresservice.AddUserAddressRecord(user))
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
            return _UserAddresservice.GetUserAddressSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserAddressReq user)
        {
            if (ModelState.IsValid)
            {
                if (_UserAddresservice.UpdateUserAddressRecord(user))
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
            var data = _UserAddresservice.GetUserAddressSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_UserAddresservice.DeleteUserAddressRecord(id))
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
