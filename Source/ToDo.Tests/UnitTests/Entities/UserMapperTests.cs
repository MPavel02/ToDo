using FluentAssertions;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.ValueObjects;
using ToDo.Tests.Shared.Note;

namespace ToDo.Tests.UnitTests.Entities;

public class UserMapperTests
{
    private readonly UserDomain _userDomain =
        UserDomain.Create(Username.From(StandardUserName), string.Empty);

    private const string StandardUserName = "Somebody";

    [Fact]
    public void ChangeName_NameAndUpdatedDateShouldChange()
    {
        // Arrange
        var newName = Username.From("Новое имя пользователя");
        
        // Act
        _userDomain.ChangeName(newName);
        
        // Assert
        newName.Value.Should().Be(_userDomain.Username.Value);
        _userDomain.UpdatedAt.Should().NotBeNull();
    }
    
    [Fact]
    public void AddNote_ShouldBeOneNote()
    {
        // Arrange
        var note = new NoteTestModelWithoutID("Новая заметка", "Детали заметки");
        
        // Act
        _userDomain.AddNote(note.Title, note.Details);
        
        // Assert
        _userDomain.Notes.Should().HaveCount(1);
        _userDomain.UpdatedAt.Should().NotBeNull();
    }
    
    [Fact]
    public void UpdateNote_ShouldUpdateNote()
    {
        // Arrange
        var newNote = new NoteTestModelWithoutID("Новая заметка", "Детали заметки");
        
        // Act
        _userDomain.AddNote(newNote.Title, newNote.Details);
        
        var note = _userDomain.Notes.First();
        
        _userDomain.UpdateNote(note.ID, "Новая заметка 2", "Детали заметки 2");
        
        var updatedNote = _userDomain.Notes.First();
        
        // Assert
        _userDomain.Notes.Should().HaveCount(1);
        _userDomain.UpdatedAt.Should().NotBeNull();
        updatedNote.Title.Should().Be(note.Title);
        updatedNote.Details.Should().Be(note.Details);
    }
    
    [Fact]
    public void UpdateNote_ShouldNotUpdate()
    {
        // Arrange
        var fakeGuid = Guid.NewGuid();
        
        // Act
        var exception = Assert.Throws<NotFoundException>(() => 
            _userDomain.UpdateNote(fakeGuid, "Новая заметка 2", "Детали заметки 2"));
        
        // Assert
        exception.Message.Should().Be($"Entity \"{nameof(NoteDomain)}\" ({fakeGuid}) not found.");
        _userDomain.UpdatedAt.Should().BeNull();
    }
}