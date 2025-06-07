
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;  
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text; 
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;


[Tags("Authentication")]
[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService authService): ControllerBase 
{

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(UserDto request) {

        var user = await authService.RegisterAsync(request);
        
        if(user is null){   
            return BadRequest("Username already exists");
        }
        // if(user.Role == ""){
        //     return BadRequest("Role does not exists");
        // }

        return Ok(user);


    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login(UserLoginDto request) {

        var result = await authService.LoginAsync(request);
        if(result is null){
            return BadRequest("Invalid username or password");
        }

        return Ok(result);

    }

    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
    {
        var result = await authService.RefreshTokenAsync(request);
        if(result is null || result.AccessToken is null || result.RefreshToken is null)
        {
            return Unauthorized("Invalid refresh token");
        }

        return Ok(result);
    }

    [Authorize]
    [HttpGet]
    public IActionResult AuthenticatedOnlyEndpoint()
    {
        return Ok("You are authenticated");
    }

    [Authorize(Roles = "admin")]
    [HttpGet("admin-only")]
    public IActionResult AdminOnlyEndpoint()
    {
        return Ok("You are an admin");
    }



}