using MediatR;
using ToDo.Application.Models.Auth;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;

namespace ToDo.Application.Auth.Commands.LoginCommand;

public class LoginCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService) : IRequestHandler<LoginCommand, AuthResult>
{
    public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByNameAsync(request.Username, cancellationToken);

        if (user is null || !passwordHasher.Verify(request.Password, user.PasswordHash))
            return new AuthResult { Success = false, Error = "Неверный логин или пароль." };
        
        var token = tokenService.GenerateToken(user);

        return new AuthResult
        {
            Success = true,
            Token = token,
            UserID = user.ID
        };
    }
}