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
                _userService.AddUserRecord(user);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserReq user)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
                user.AuthId = clientID;
                _userService.UpdateUserRecord(user);
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
            var data = _userService.GetUserSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _userService.DeleteUserRecord(id);
            return Ok();
        }
    }
}
