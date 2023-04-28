using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetcoreCrudBaseApi.Domains.Services;
using NetcoreCrudBaseApi.Infrastructure.Auth;
using NetcoreCrudBaseApi.Infrastructure.Responses;

namespace NetcoreCrudBaseApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly AuthTokenService _authTokenService;
    public AuthController(UserService userService, AuthTokenService authTokenService)
    {
        _userService = userService;
        _authTokenService = authTokenService;
    }
    /// <summary>
    /// Resquest token user
    /// </summary>
    /// <param name="resquest">Object with data authentication</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Request was successful</response>
    /// <response code="400">Request has errors</response>   
    [AllowAnonymous]
    [HttpPost("token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]    
    public IActionResult RequestAuthToken([FromBody] AuthRequestDto request)
    {
        var user = _userService.GetUserByLoginAndPassword(request.Login, request.Password);
        if (user == null) return BadRequest(ResponseErrors.InvalidCredentials());

        var token = _authTokenService.CreateTokenUser(user);
        return Ok(AuthResponse.emitToken(token));
    }
}
