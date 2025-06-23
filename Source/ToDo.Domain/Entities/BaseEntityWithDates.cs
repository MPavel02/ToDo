namespace ToDo.Domain.Entities;

public class BaseEntityWithDates : BaseEntity
{
    private const string ErrorText = "Дата создания не может быть больше чем дата обновления.";

    protected BaseEntityWithDates() {}

    protected BaseEntityWithDates(Guid ID, DateTime createdAt)
        : base(ID)
    {
        CreatedAt = createdAt;
    }
    
    /// <summary>
    /// Дата и время создания.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    /// Дата и время редактирования.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }

    public virtual void SetUpdatedAt(DateTime updatedAt)
    {
        if (CreatedAt >= updatedAt)
            throw new ArgumentException(ErrorText);
        
        UpdatedAt = updatedAt;
    }
}