using MediatR;
using ToDo.Application.Models.Auth;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Auth.Commands.Handlers;

internal class RegisterCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService)
    : IRequestHandler<RegisterCommand, AuthResult>
{
    public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var username = Username.From(request.Username);
        
        var user = await userRepository.GetByNameAsync(username, cancellationToken);

        if (user is not null)
            throw new DuplicateEntityException<Guid>(nameof(UserDomain), user.ID);
        
        var newUser = UserDomain.Create(username, passwordHasher.Hash(request.Password));
        
        await userRepository.AddAsync(newUser, cancellationToken);
        
        var token = tokenService.GenerateToken(newUser);
        
        return new AuthResult { Token = token };
    }
}