using ToDo.DAL.Core.Entities;
using ToDo.Domain.Enums;

namespace ToDo.DAL.Entities;

/// <summary>
/// Модель пользователя.
/// </summary>
public sealed class User : BaseEntityWithDates
{
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public RoleTypes Role { get; set; }
    public List<Note> Notes { get; set; } = [];
}