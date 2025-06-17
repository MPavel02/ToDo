using ToDo.Domain.ValueObjects;

namespace ToDo.Domain.Entities;

public class User : BaseEntity
{
    private readonly List<Note> _notes = [];
    
    protected User() {}
    
    public User(
        Guid ID,
        Username name,
        DateTime createdAt,
        DateTime? updatedAt = null)
        : base(ID, createdAt, updatedAt)
    {
        Name = name;
    }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public Username Name { get; private set; }
    
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
        Name = name;
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
            return;
        
        note.Update(title, details);
        SetUpdatedAt(DateTime.UtcNow);
    }
}