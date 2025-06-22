using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Auth.Commands.LoginCommand;
using ToDo.Application.Auth.Commands.RegisterCommand;
using ToDo.Application.Models.Auth;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class AuthController(IMediator mediator) : ApiBaseController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelDto request, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new LoginCommand
        {
            Username = request.Username,
            Password = request.Password
        }, cancellationToken);
        return result.Success ? Ok(result) : Unauthorized(result.Error);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] LoginModelDto request, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new RegisterCommand
        {
            Username = request.Username,
            Password = request.Password
        }, cancellationToken);
        return result.Success ? Ok(result) : BadRequest(result.Error);
    }
    
    [HttpGet("secure")]
    [Authorize]
    public IActionResult Secure()
    {
        return Ok(new { Message = $"Привет, {User.Identity?.Name}!" });
    }
    
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly()
    {
        return Ok(new { Message = "Привет, администратор!" });
    }
}