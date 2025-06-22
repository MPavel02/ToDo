using MediatR;
using ToDo.Application.Models.Auth;
using ToDo.Domain.Entities;
using ToDo.Domain.Enums;
using ToDo.Domain.Exceptions;
using ToDo.Domain.Repositories;
using ToDo.Domain.Services;
using ToDo.Domain.ValueObjects;

namespace ToDo.Application.Auth.Commands.RegisterCommand;

public class RegisterCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService)
    : IRequestHandler<RegisterCommand, AuthResult>
{
    public async Task<AuthResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByNameAsync(request.Username, cancellationToken);

        if (user is not null)
            throw new DuplicateEntityException<Guid>(nameof(User), user.ID);
        
        var newUser = new User(
            Guid.NewGuid(),
            Username.From(request.Username),
            passwordHasher.Hash(request.Password),
            RoleTypes.User,
            DateTime.UtcNow);
        
        await userRepository.AddAsync(newUser, cancellationToken);
        
        var token = tokenService.GenerateToken(newUser);
        
        return new AuthResult { Success = true, Token = token, UserID = newUser.ID };
    }
}