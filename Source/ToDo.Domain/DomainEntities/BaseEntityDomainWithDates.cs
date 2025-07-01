namespace ToDo.Domain.DomainEntities;

public class BaseEntityDomainWithDates : BaseEntityDomain
{
    private const string ErrorText = "Дата создания не может быть больше чем дата обновления.";

    protected BaseEntityDomainWithDates(Guid ID, DateTime createdAt, DateTime? updatedAt)
        : base(ID)
    {
        CreatedAt = createdAt;
        
        if (CreatedAt >= updatedAt)
            throw new ArgumentException(ErrorText);
        
        UpdatedAt = updatedAt;
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