using MediatR;
using ToDo.Application.Models.Auth;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Auth.Commands.Handlers;

internal class LoginCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService) : IRequestHandler<LoginCommand, AuthResult>
{
    public async Task<AuthResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByNameAsync(Username.From(request.Username), cancellationToken);

        if (user is null)
            throw new NotFoundException(nameof(UserDomain), request.Username);

        if (!passwordHasher.Verify(request.Password, user.PasswordHash))
            throw new IncorrectFieldException("Неверный пароль", nameof(request.Password));
        
        var token = tokenService.GenerateToken(user);

        return new AuthResult { Token = token };
    }
}