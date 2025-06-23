using FluentValidation;
using ToDo.Application.Auth.Commands.RegisterCommand;
using ToDo.Application.Constants;

namespace ToDo.Application.Auth.Validators;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(c => c.Username)
            .NotEmpty()
                .WithMessage(ValidationMessages.UsernameIsRequired);

        RuleFor(c => c.Password)
            .Matches(PasswordPolicy.PasswordRegular)
                .WithMessage("Пароль должен содержать минимум 6 символов, " +
                             "а также должен содержать верхний и нижний регистр латинских букв и " +
                             "должен содержать цифры.");
    }
}