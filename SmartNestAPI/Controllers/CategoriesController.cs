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
    [Route("api/category")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService CategoryService)
        {
            _categoryService = CategoryService;
        }
        [HttpGet]
        public IEnumerable<CategoryRes> Get()
        {
            return _categoryService.GetCategoryRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryReq category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.AddCategoryRecord(category))
                {
                    return Ok("Container created successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while creating category!");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("{id}")]
        public CategoryRes Details(Guid id)
        {
            return _categoryService.GetCategorySingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] CategoryReq category)
        {
            if (ModelState.IsValid)
            {
                if (_categoryService.UpdateCategoryRecord(category))
                {
                    return Ok("category updated successfully!");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while updating category!");
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
            var data = _categoryService.GetCategorySingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            if (_categoryService.DeleteCategoryRecord(id))
            {
                return Ok("User category deleted successfully!");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while deleting user category!");
            }
        }
    }
}
