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
    [Route("api/shoppingList")]
    [ApiController]
    [Authorize]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListsController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet]
        public IEnumerable<ShoppingListRes> Get()
        {
            var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];

            return _shoppingListService.GetShoppingListRecords(clientID);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ShoppingListReq shoppingList)
        {
            if (ModelState.IsValid)
            {
                var clientID = Request.Headers[HeaderNames.Authorization].ToString().Split(" ")[1].Split(".")[0];
                if (_shoppingListService.AddShoppingListRecord(shoppingList, clientID))
                {
                    return Ok("ShoppingList created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating ShoppingList!");

                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpGet("{id}")]
        public ShoppingListRes Details(Guid id)
        {
            return _shoppingListService.GetShoppingListSingleRecord(id);
        }
    }
}
