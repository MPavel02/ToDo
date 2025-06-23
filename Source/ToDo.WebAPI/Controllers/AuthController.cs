using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Auth.Commands.LoginCommand;
using ToDo.Application.Auth.Commands.RegisterCommand;
using ToDo.Application.Models.Auth;

namespace ToDo.WebAPI.Controllers;

public class AuthController(IMediator mediator) : ApiBaseController
{
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
}