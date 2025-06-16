using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Notes.Commands.CreateNote;
using ToDo.Application.Notes.Commands.DeleteNote;
using ToDo.Application.Notes.Commands.UpdateNote;
using ToDo.Application.Notes.Queries.GetAllNotes;
using ToDo.Application.Notes.Queries.GetNoteByID;
using ToDo.WebAPI.Models.Note;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class NoteController(IMediator mediator) : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteDto request, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CreateNoteCommand
        {
            Title = request.Title,
            Details = request.Details,
            UserID = request.UserID
        }, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByID(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetNoteByIDQuery(id), cancellationToken);
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllByID(Guid userID, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new GetNoteListQuery
        {
            UserID = userID
        }, cancellationToken);
        
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateNoteDto request, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateNoteCommand
        {
            ID = request.ID,
            Title = request.Title,
            Details = request.Details,
            UserID = request.UserID
        }, cancellationToken);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteNoteDto request, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new DeleteNoteCommand
        {
            ID = id,
            UserID = request.UserID
        }, cancellationToken);
        
        return NoContent();
    }
}