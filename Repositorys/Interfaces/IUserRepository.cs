using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.Models;

namespace MeuVeiculo;

public interface IUserRepository
{
    Task<User> CreateUserAsync (User user);
    Task<User> UpdateUserAsync (User user);
    Task DeleteUserAsync (User user);

    Task<User?> GetUserByUsernameAsync(string username);
}