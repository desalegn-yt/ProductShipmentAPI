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
    [Route("api/UserPaymentMethod")]
    [ApiController]
    [Authorize]
    public class UserPaymentMethodsController : ControllerBase
    {
        private readonly IUserPaymentMethodService _UserPaymentMethodService;

        public UserPaymentMethodsController(IUserPaymentMethodService UserPaymentMethodService)
        {
            _UserPaymentMethodService = UserPaymentMethodService;
        }
        [HttpGet]
        public IEnumerable<UserPaymentMethodRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
            return _UserPaymentMethodService.GetUserPaymentMethodRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserPaymentMethodReq UserPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                if (_UserPaymentMethodService.AddUserPaymentMethodRecord(UserPaymentMethod))
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
            return _UserPaymentMethodService.GetUserPaymentMethodSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] UserPaymentMethodReq UserPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                if(_UserPaymentMethodService.UpdateUserPaymentMethodRecord(UserPaymentMethod))
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
            var data = _UserPaymentMethodService.GetUserPaymentMethodSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_UserPaymentMethodService.DeleteUserPaymentMethodRecord(id))
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
