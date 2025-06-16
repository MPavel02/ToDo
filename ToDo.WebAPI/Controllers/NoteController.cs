using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Mappers;
using ToDo.Application.Notes.Commands.DeleteNote;
using ToDo.Application.Notes.Queries.GetAllNotes;
using ToDo.Application.Notes.Queries.GetNoteByID;
using ToDo.Domain.Models.Note;

namespace ToDo.WebAPI.Controllers;

[Route("api/v1/[controller]")]
public class NoteController(IMediator mediator) : ApiBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateNoteDto createNoteDto, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(createNoteDto.Map(), cancellationToken);
        
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
    public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto, CancellationToken cancellationToken = default)
    {
        await mediator.Send(updateNoteDto.Map(), cancellationToken);
        
        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, [FromBody] DeleteNoteDto deleteNoteDto, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new DeleteNoteCommand
        {
            ID = id,
            UserID = deleteNoteDto.UserID
        }, cancellationToken);
        
        return NoContent();
    }
}