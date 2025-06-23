using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.ValueObjects;

namespace ToDo.Domain.Entities;

public class User : BaseEntityWithDates
{
    private readonly List<Note> _notes = [];
    
    protected User() {}
    
    public User(
        Guid ID,
        Username username,
        string passwordHash,
        RoleTypes role,
        DateTime createdAt)
        : base(ID, createdAt)
    {
        Username = username;
        PasswordHash = passwordHash;
        Role = role;
    }
    
    /// <summary>
    /// Хэш пароля пользователя.
    /// </summary>
    public string PasswordHash { get; private set; }
    
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public RoleTypes Role { get; private set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public Username Username { get; private set; }
    
    /// <summary>
    /// Заметки пользователя.
    /// </summary>
    public IReadOnlyCollection<Note> Notes => _notes.AsReadOnly();

    /// <summary>
    /// Изменяет имя пользователя.
    /// </summary>
    /// <param name="name">Новое имя пользователя.</param>
    public void ChangeName(Username name)
    {
        Username = name;
        SetUpdatedAt(DateTime.UtcNow);
    }

    /// <summary>
    /// Добавляет заметку.
    /// </summary>
    /// <param name="title">Название заметки.</param>
    /// <param name="details">Детали заметки.</param>
    public void AddNote(string title, string details)
    {
        _notes.Add(new Note(Guid.NewGuid(), ID, title, details, DateTime.UtcNow));
    }
    
    /// <summary>
    /// Обновляет заметку.
    /// </summary>
    /// <param name="noteID">Идентификатор заметки.</param>
    /// <param name="title">Название заметки.</param>
    /// <param name="details">Детали заметки.</param>
    public void UpdateNote(Guid noteID, string title, string details)
    {
        var note = _notes.FirstOrDefault(note => note.ID == noteID);

        if (note is null)
            throw new NotFoundException(nameof(Note), noteID);

        note.Update(title, details);
        SetUpdatedAt(DateTime.UtcNow);
    }
}