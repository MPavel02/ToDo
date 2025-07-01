using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.ValueObjects;

namespace ToDo.Domain.DomainEntities;

public class UserDomain : BaseEntityDomainWithDates
{
    private readonly List<NoteDomain> _notes;
    
    private UserDomain(
        Guid ID,
        DateTime createdAt,
        DateTime? updatedAt,
        Username username,
        string passwordHash,
        RoleTypes role,
        IReadOnlyCollection<NoteDomain> notes)
        : base(ID, createdAt, updatedAt)
    {
        Username = username;
        PasswordHash = passwordHash;
        Role = role;
        _notes = notes.ToList();
    }
    
    public static UserDomain Create(
        Username username,
        string passwordHash)
        => new(
            Guid.NewGuid(),
            DateTime.UtcNow,
            null,
            username,
            passwordHash,
            RoleTypes.User,
            []);
    
    public static UserDomain LoadFromDb(
        Guid ID,
        DateTime createdAt,
        DateTime? updatedAt,
        Username username,
        string passwordHash,
        RoleTypes role,
        IReadOnlyCollection<NoteDomain> notes)
    {
        return new UserDomain(
            ID,
            createdAt,
            updatedAt,
            username,
            passwordHash,
            role,
            notes);
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
    public IReadOnlyCollection<NoteDomain> Notes => _notes.AsReadOnly();

    /// <summary>
    /// Изменяет имя пользователя.
    /// </summary>
    /// <param name="name">Новое имя пользователя.</param>
    public void ChangeName(Username name)
    {
        // TODO: Проверки входных параметров
        
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
        _notes.Add(NoteDomain.Create(ID, title, details));
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
            throw new NotFoundException(nameof(NoteDomain), noteID);

        note.Update(title, details);
        SetUpdatedAt(DateTime.UtcNow);
    }
}