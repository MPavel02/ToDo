using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Entities;

public abstract class BaseEntity
{
    private const string ErrorText = "Дата создания не может быть больше чем дата обновления.";

    protected BaseEntity() {}

    protected BaseEntity(Guid ID, DateTime createdAt, DateTime? updatedAt = null)
    {
        this.ID = ID;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
    
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    [Key]
    public Guid ID { get; }
    
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