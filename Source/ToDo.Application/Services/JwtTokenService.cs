﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ToDo.Application.Models.Settings;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.Services;

namespace ToDo.Application.Services;

public class JwtTokenService(IOptions<JwtOptions> options) : ITokenService
{
    private readonly JwtOptions _settings = options.Value;
    
    public string GenerateToken(UserDomain userDomain)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userDomain.ID.ToString()),
            new Claim(ClaimTypes.Name, userDomain.Username.Value),
            new Claim(ClaimTypes.Role, userDomain.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.TokenPrivateKey));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _settings.Issuer,
            audience: _settings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_settings.ExpiryMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}