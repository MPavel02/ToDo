namespace ToDo.Domain.Entities;

public class Note : BaseEntityWithDates
{
    protected Note() {}
    
    public Note(
        Guid ID,
        Guid userID,
        string title,
        string details,
        DateTime createdAt)
        : base(ID, createdAt)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException($"Значение свойства {nameof(Title)} не может быть пустым.", nameof(Title));
        }

        if (string.IsNullOrWhiteSpace(details))
        {
            throw new ArgumentException($"Значение свойства {nameof(Details)} не может быть пустым.", nameof(Details));
        }
        
        if (userID == Guid.Empty)
        {
            throw new ArgumentException("Идентификатор пользователя не может быть пустым", nameof(UserID));
        }
        
        UserID = userID;
        Title = title;
        Details = details;
    }
    
    /// <summary>
    /// Название заметки.
    /// </summary>
    public string Title { get; private set; }
    
    /// <summary>
    /// Описание заметки.
    /// </summary>
    public string Details { get; private set; }
    
    public Guid UserID { get; private set; }
    public User User { get; private set; }

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