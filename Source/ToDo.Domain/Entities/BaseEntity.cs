using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() {}

    protected BaseEntity(Guid ID)
    {
        this.ID = ID;
    }
    
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    [Key]
    public Guid ID { get; }
}