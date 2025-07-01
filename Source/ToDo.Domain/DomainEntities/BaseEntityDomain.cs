using System.ComponentModel.DataAnnotations;

namespace ToDo.Domain.DomainEntities;

public abstract class BaseEntityDomain
{
    protected BaseEntityDomain(Guid ID)
    {
        this.ID = ID;
    }
    
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    [Key]
    public Guid ID { get; }
}