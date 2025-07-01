using System.ComponentModel.DataAnnotations;

namespace ToDo.DAL.Core.Entities;

public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор сущности.
    /// </summary>
    [Key]
    public Guid ID { get; set; }
}