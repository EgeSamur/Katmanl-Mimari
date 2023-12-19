using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Business.Abstract;
using Project.Business.Concrete;
using Project.Common.Utilities.Results;
using Project.DTO;
using Project.Entities.Entities;

namespace Web_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : Controller
{
    public readonly IAuthService _authService;
    public readonly IRefreshTokenService _refreshTokenService;

    public AuthController(IAuthService authService, IRefreshTokenService refreshTokenService)
    {
        _authService = authService;
        _refreshTokenService = refreshTokenService;
    }

    [HttpPost("login")]
    public IActionResult Login(UserForLoginDto userForLoginDto)
    {
       var result = _authService.Login(userForLoginDto);
        if(result.Success == true)
        {
            return Ok(result);
        }
        else { return BadRequest(); }
    }
    [HttpPost("register")]
    public IActionResult Register(UserForRegisterDto userForRegisterDto)
    {
        var result = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
        return Ok(result);
    }
    [HttpPost("refreshToken")]
    public IActionResult RefreshToken([FromBody] string refreshToken) 
    {
        var result = (_refreshTokenService.RefreshToken(refreshToken));
        if(result.Success == true)
        {
            return Ok(result);
        }
        return BadRequest();
    }

    [HttpGet("test")]
    [Authorize]
    public IActionResult Test()
    {
        return Ok();
    }
}
