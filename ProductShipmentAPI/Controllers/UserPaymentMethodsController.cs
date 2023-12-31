﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using ProductShipmentAPI.Application.Services;
using ProductShipmentAPI.Domain.Entities.Database;
using ProductShipmentAPI.Domain.Entities.Request;
using ProductShipmentAPI.Domain.Entities.Response;
using ProductShipmentAPI.Domain.Interfaces;
using System.Net;

namespace ProductShipmentAPI.Controllers
{
    [Route("api/userPaymentMethod")]
    [ApiController]
    [Authorize]
    public class UserPaymentMethodsController : ControllerBase
    {
        private readonly IUserPaymentMethodService _userPaymentMethodService;

        public UserPaymentMethodsController(IUserPaymentMethodService UserPaymentMethodService)
        {
            _userPaymentMethodService = UserPaymentMethodService;
        }
        [HttpGet]
        public IEnumerable<UserPaymentMethodRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
            return _userPaymentMethodService.GetUserPaymentMethodRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserPaymentMethodReq UserPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
                if (_userPaymentMethodService.AddUserPaymentMethodRecord(UserPaymentMethod, clientID))
                {
                    return Ok("Payment method created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating payment method!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public UserPaymentMethodRes Details(Guid id)
        {
            return _userPaymentMethodService.GetUserPaymentMethodSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserPaymentMethodReq UserPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                if(_userPaymentMethodService.UpdateUserPaymentMethodRecord(UserPaymentMethod))
                {
                    return Ok("Payment method updated successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating payment method!");
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
            var data = _userPaymentMethodService.GetUserPaymentMethodSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_userPaymentMethodService.DeleteUserPaymentMethodRecord(id))
            {
                return Ok("Payment method deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting payment method!");
            }
        }
    }
}
