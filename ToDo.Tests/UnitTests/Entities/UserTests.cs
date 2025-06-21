using FluentAssertions;
using ToDo.Domain.Entities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.ValueObjects;
using ToDo.Tests.Shared.Note;

namespace ToDo.Tests.UnitTests.Entities;

public class UserTests
{
    private readonly User _user;

    private const string StandardUserName = "Somebody";

    public UserTests()
    {
        var userID = new Guid("a5f88c47-7395-4150-bc55-d85c16812ba4");
        
        _user = new User(userID, Username.From(StandardUserName), DateTime.UtcNow);
    }
    
    [Fact]
    public void ChangeName_NameAndUpdatedDateShouldChange()
    {
        // Arrange
        var newName = Username.From("Новое имя пользователя");
        
        // Act
        _user.ChangeName(newName);
        
        // Assert
        newName.Value.Should().Be(_user.Name.Value);
        _user.UpdatedAt.Should().NotBeNull();
    }
    
    [Fact]
    public void AddNote_ShouldBeOneNote()
    {
        // Arrange
        var note = new NoteTestModelWithoutID("Новая заметка", "Детали заметки");
        
        // Act
        _user.AddNote(note.Title, note.Details);
        
        // Assert
        _user.Notes.Should().HaveCount(1);
        _user.UpdatedAt.Should().BeNull();
    }
    
    [Fact]
    public void UpdateNote_ShouldUpdateNote()
    {
        // Arrange
        var newNote = new NoteTestModelWithoutID("Новая заметка", "Детали заметки");
        
        // Act
        _user.AddNote(newNote.Title, newNote.Details);
        
        var note = _user.Notes.First();
        
        _user.UpdateNote(note.ID, "Новая заметка 2", "Детали заметки 2");
        
        var updatedNote = _user.Notes.First();
        
        // Assert
        _user.Notes.Should().HaveCount(1);
        _user.UpdatedAt.Should().NotBeNull();
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
            _user.UpdateNote(fakeGuid, "Новая заметка 2", "Детали заметки 2"));
        
        // Assert
        exception.Message.Should().Be($"Entity \"{nameof(Note)}\" ({fakeGuid}) not found.");
        _user.UpdatedAt.Should().BeNull();
    }
}