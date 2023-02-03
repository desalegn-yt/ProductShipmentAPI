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
    [Route("api/order")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IEnumerable<OrderRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];

            return _orderService.GetOrderRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] OrderReq order)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                order.Id = obj;
                _orderService.AddOrderRecord(order);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id}")]
        public OrderRes Details(Guid id)
        {
            return _orderService.GetOrderSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] OrderReq order)
        {
            if (ModelState.IsValid)
            {
                _orderService.UpdateOrderRecord(order);
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
            var data = _orderService.GetOrderSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _orderService.DeleteOrderRecord(id);
            return Ok();
        }
    }
}
