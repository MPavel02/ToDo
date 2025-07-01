namespace ToDo.Domain.DomainEntities;

public class NoteDomain : BaseEntityDomainWithDates
{
    private NoteDomain(
        Guid ID,
        DateTime createdAt,
        DateTime? updatedAt,
        Guid userID,
        string title,
        string details)
        : base(ID, createdAt, updatedAt)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException($"Значение свойства {nameof(Title)} не может быть пустым.", nameof(Title));
        }

        if (string.IsNullOrWhiteSpace(details))
        {
            throw new ArgumentException($"Значение свойства {nameof(Details)} не может быть пустым.", nameof(Details));
        }
        
        if (userID.Equals(Guid.Empty))
        {
            throw new ArgumentException("Идентификатор пользователя не может быть пустым", nameof(UserID));
        }
        
        UserID = userID;
        Title = title;
        Details = details;
    }
    
    public static NoteDomain Create(
        Guid userID,
        string title,
        string details) 
        => new(Guid.NewGuid(), DateTime.UtcNow, null, userID, title, details);
    
    public static NoteDomain LoadFromDb(
        Guid ID,
        DateTime createdAt,
        DateTime? updatedAt,
        Guid userID,
        string title,
        string details)
    {
        return new NoteDomain(
            ID,
            createdAt,
            updatedAt,
            userID,
            title,
            details);
    }
    
    /// <summary>
    /// Название заметки.
    /// </summary>
    public string Title { get; private set; }
    
    /// <summary>
    /// Описание заметки.
    /// </summary>
    public string Details { get; private set; }
    
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserID { get; }

    /// <summary>
    /// Обновляет заметку.
    /// </summary>
    /// <param name="title">Название заметки.</param>
    /// <param name="details">Детали заметки.</param>
    public void Update(string title, string details)
    {
        Title = title;
        Details = details;
        SetUpdatedAt(DateTime.UtcNow);
    }
}