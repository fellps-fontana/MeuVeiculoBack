using System.Threading.Tasks;
using MeuVeiculo.DTOs.Auth;

namespace MeuVeiculo.Services.Interfaces;

public interface IUserService
{
    Task<LoginResponse> RegisterAsync(LoginRequest request);
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
