using FluentValidation;
using ToDo.Application.Auth.Commands.LoginCommand;

namespace ToDo.Application.Validators.Auth;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.Username)
            .NotEmpty().WithMessage("Имя пользователя обязательно.");;

        RuleFor(c => c.Password)
            .NotEmpty()
            .MinimumLength(4).WithMessage("Пароль должен содержать не менее 4 символов.");
    }
}