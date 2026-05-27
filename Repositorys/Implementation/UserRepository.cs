using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.Data;
using MeuVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuVeiculo.Repositorys.Implementation;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<User> CreateUserAsync(User user)
    {
        context.Users.Add(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUserAsync(User user)
    {
        context.Users.Update(user);
        await context.SaveChangesAsync();
        return user;
    }

    public Task DeleteUserAsync(User user)
    {
        context.Users.Remove(user);
        return context.SaveChangesAsync();
    }
    
    public async Task<User?> GetUserByUsernameAsync(string username) =>
        await context.Users.FirstOrDefaultAsync(x => x.Username == username);
}