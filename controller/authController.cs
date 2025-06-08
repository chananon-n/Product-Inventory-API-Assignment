
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;



[Tags("Authentication")]
[Route("api/auth")]
[Produces("application/json")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    /// <summary>
    /// Register new user.
    /// </summary>
    /// <response code="201">Returns the newly created user</response>
    /// <response code="400">If the user is null</response>
    [HttpPost("register")]
    public async Task<ActionResult<User>> Register([FromBody] UserDto request)
    {

        try
        {
            var user = await authService.RegisterAsync(request);
            return StatusCode(201, user);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Login by username and password.
    /// </summary>
    /// <response code="200">Returns the user</response>
    /// <response code="400">If the user is null</response>
    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login([FromBody] UserLoginDto request)
    {
        try
        {
            var result = await authService.LoginAsync(request);
            return Ok(result);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }



    }

    /// <summary>
    /// Refresh user's jwt token.
    /// </summary>
    /// <response code="200">Returns the newly created token</response>
    /// <response code="400">If the token is null</response>
    [HttpPost("refresh-token")]
    public async Task<ActionResult<TokenResponseDto>> RefreshToken([FromQuery] RefreshTokenRequestDto request)
    {
        var result = await authService.RefreshTokenAsync(request);
        if (result is null || result.AccessToken is null || result.RefreshToken is null)
        {
            return Unauthorized("Invalid refresh token");
        }

        return Ok(result);
    }


    /// <summary>
    /// Check authenticated.
    /// </summary>
    [Authorize]
    [HttpGet]
    public IActionResult AuthenticatedOnlyEndpoint()
    {
        return Ok("You are authenticated");
    }

}