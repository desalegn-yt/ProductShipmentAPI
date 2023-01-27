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
            return _UserPaymentMethodService.GetUserPaymentMethodRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserPaymentMethodReq UserPaymentMethod)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                UserPaymentMethod.Id = obj;
                _UserPaymentMethodService.AddUserPaymentMethodRecord(UserPaymentMethod);
                return Ok();
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
                _UserPaymentMethodService.UpdateUserPaymentMethodRecord(UserPaymentMethod);
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
            var data = _UserPaymentMethodService.GetUserPaymentMethodSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _UserPaymentMethodService.DeleteUserPaymentMethodRecord(id);
            return Ok();
        }
    }
}
