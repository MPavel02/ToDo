namespace ToDo.WebAPI.Models.User;

public readonly record struct UpdateUserDto(
    Guid ID,
    string Username);