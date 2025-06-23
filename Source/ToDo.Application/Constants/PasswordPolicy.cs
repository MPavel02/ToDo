namespace ToDo.Application.Constants;

public static class PasswordPolicy
{
    public const string PasswordRegular = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
    
    public const int MinLength = 6;
}