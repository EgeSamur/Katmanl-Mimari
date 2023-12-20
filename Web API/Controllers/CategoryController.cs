using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.DTO;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create-category")]
        public IActionResult CreateCatogory([FromBody] CategoryDto categoryDto)
        {
            var result = _categoryService.Add(categoryDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();

        }
        [HttpPost("delete-category")]
        public IActionResult DeleteCatogory([FromBody] CategoryDto categoryDto)
        {
            var result = _categoryService.Delete(categoryDto);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpGet("list-categories")]
        public IActionResult ListCatogories()
        {
            var result = _categoryService.ListCategories();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

    }
}
