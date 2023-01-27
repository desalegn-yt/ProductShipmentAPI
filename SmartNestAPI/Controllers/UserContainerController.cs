﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return _UserContainerService.GetUserContainerRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserContainerReq UserContainer)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                UserContainer.Id = obj;
                _UserContainerService.AddUserContainerRecord(UserContainer);
                return Ok();
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
                _UserContainerService.UpdateUserContainerRecord(UserContainer);
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
            var data = _UserContainerService.GetUserContainerSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _UserContainerService.DeleteUserContainerRecord(id);
            return Ok();
        }
    }
}