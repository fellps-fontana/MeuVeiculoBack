using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.Models;

namespace MeuVeiculo;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAllUserVehiclesAsync(Guid userId);
    Task<Vehicle> GetByIdAsync(Guid id, Guid userId);
    Task<Vehicle> CreateVehicleAsync(Vehicle vehicle);
    Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle);
    Task DeleteAsync (Vehicle vehicle);
    
}