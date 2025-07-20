using FluentValidation;
using ToDo.Application.Auth.Commands;
using ToDo.Application.Constants;

namespace ToDo.Application.Auth.Validators;

internal class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    private const string PasswordMatchesMessage = "Пароль должен содержать минимум 6 символов, " +
                                                  "а также должен содержать верхний и нижний регистр латинских букв и " +
                                                  "должен содержать цифры.";
    
    public RegisterCommandValidator()
    {
        RuleFor(c => c.Username)
            .NotEmpty()
                .WithMessage(ValidationMessages.UsernameIsRequired);

        RuleFor(c => c.Password)
            .NotEmpty()
                .WithMessage(ValidationMessages.PasswordIsRequired)
            .Matches(PasswordPolicy.PasswordRegular)
                .WithMessage(PasswordMatchesMessage);
    }
}