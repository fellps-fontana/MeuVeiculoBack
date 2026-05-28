using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.Auth;
using MeuVeiculo.Models;
using MeuVeiculo.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MeuVeiculo.Services.Implementation;

public class UserService(IUserRepository repository, IConfiguration configuration) : IUserService
{
    public async Task<LoginResponse> RegisterAsync(LoginRequest request)
    {
        var existing = await repository.GetUserByUsernameAsync(request.Username);
        if (existing is not null)
            throw new InvalidOperationException("Username already taken");

        var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var user = new User(request.Username, hash);
        await repository.CreateUserAsync(user);
        return new LoginResponse(GenerateToken(user), user.Username);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        var user = await repository.GetUserByUsernameAsync(request.Username)
            ?? throw new UnauthorizedAccessException("Invalid credentials");

        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid credentials");

        return new LoginResponse(GenerateToken(user), user.Username);
    }

    private string GenerateToken(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username)
        };
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
