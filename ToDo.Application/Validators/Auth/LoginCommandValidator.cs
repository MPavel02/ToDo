using FluentValidation;
using ToDo.Application.Auth.Commands.LoginCommand;
using ToDo.Application.Constants;

namespace ToDo.Application.Validators.Auth;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.Username)
            .NotEmpty()
                .WithMessage(ValidationMessages.UsernameIsRequired);

        RuleFor(c => c.Password)
            .NotEmpty()
                .WithMessage("Пароль обязателен.");
    }
}