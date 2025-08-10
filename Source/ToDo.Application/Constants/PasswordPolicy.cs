namespace ToDo.Application.Constants;

internal static class PasswordPolicy
{
    public const string PasswordRegular = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
}