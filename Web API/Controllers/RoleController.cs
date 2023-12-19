using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost("create-role")]
        public IActionResult CreateRole(RoleDto role) 
        {
            var result = _roleService.Add(role);
            if(result.Success == true)
            {
                return Ok();
            }
            return BadRequest();
            
        }

        [HttpPost("delete-role")]
        public IActionResult DeleteRole(RoleDto role)
        {
            var result = _roleService.Delete(role);
            if (result.Success == true)
            {
                return Ok();
            }
            return BadRequest();

        }


    }
}
