using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SmartNestAPI.Domain.Entities.Database;
using SmartNestAPI.Domain.Entities.Request;
using SmartNestAPI.Domain.Entities.Response;
using SmartNestAPI.Domain.Interfaces;
using System.Net;

namespace SmartNestAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public UserRes Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
            return _userService.GetUserRecord(clientID);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create([FromBody] UserReq user)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
                user.AuthId = clientID;
                if (_userService.AddUserRecord(user))
                {
                    return Ok("User created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating user!");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserUpdateReq user)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
                if (_userService.UpdateUserRecord(user, clientID))
                {
                    return Ok("User updated successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating user!");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //[HttpDelete("{id}")]
        //public IActionResult DeleteConfirmed(Guid id)
        //{
        //    var data = _userService.GetUserSingleRecord(id);
        //    if (data == null)
        //    {
        //        return NotFound();
        //    }
        //    if (_userService.DeleteUserRecord(id))
        //    {
        //        return Ok("User deleted successfully!");
        //    }
        //    else
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting user!");

        //    }
        //}
    }
}
