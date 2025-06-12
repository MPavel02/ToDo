using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Mappers;
using ToDo.Application.Users.Commands.DeleteUser;
using ToDo.Application.Users.Queries.GetAllUsers;
using ToDo.Application.Users.Queries.GetUserByID;
using ToDo.Domain.Models.User;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class UsersController(IMediator mediator) : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto createUserDto, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(createUserDto.Map(), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByID(Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetUserByIDQuery { ID = id };
        var result = await mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
    {
        var query = new GetUserListQuery();
        var result = await mediator.Send(query, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto, CancellationToken cancellationToken = default)
    {
        await mediator.Send(updateUserDto.Map(), cancellationToken);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteUserCommand { ID = id };
        await mediator.Send(command, cancellationToken);
        
        return NoContent();
    }
}