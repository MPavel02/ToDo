using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Users.Commands.DeleteUser;
using ToDo.Application.Users.Commands.UpdateUser;
using ToDo.Application.Users.Queries.GetAllUsers;
using ToDo.Application.Users.Queries.GetUserByID;
using ToDo.WebAPI.Models.User;

namespace ToDo.WebAPI.Controllers;

[Authorize]
public class UsersController(IMediator mediator) : ApiBaseController
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByID(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetUserByIDQuery(id), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetUserListQuery(), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto request, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateUserCommand
        {
            ID = request.ID,
            Username = request.Username,
            Notes = request.Notes
        }, cancellationToken);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new DeleteUserCommand(id), cancellationToken);
        
        return NoContent();
    }
}