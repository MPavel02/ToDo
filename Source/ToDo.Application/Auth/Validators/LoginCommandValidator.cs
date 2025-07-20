using FluentValidation;
using ToDo.Application.Auth.Commands;
using ToDo.Application.Constants;

namespace ToDo.Application.Auth.Validators;

internal class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.Username)
            .NotEmpty()
                .WithMessage(ValidationMessages.UsernameIsRequired);

        RuleFor(c => c.Password)
            .NotEmpty()
                .WithMessage(ValidationMessages.PasswordIsRequired);
    }
}