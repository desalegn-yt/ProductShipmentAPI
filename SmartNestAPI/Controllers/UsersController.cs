using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public IEnumerable<UserRes> Get()
        {
            return _userService.GetUserRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserReq user)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                user.Id = obj;
                _userService.AddUserRecord(user);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public UserRes Details(Guid id)
        {
            return _userService.GetUserSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserReq user)
        {
            if (ModelState.IsValid)
            {
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
