using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.Vehicles;

namespace MeuVeiculo.Services.Interfaces;

public interface IVeihicleService
{
    Task<IEnumerable<VehicleResponse>> GetAllAsync(Guid userId);
    Task<VehicleResponse> GetByIdAsync(Guid vehicleId, Guid userId);
    Task<VehicleResponse> CreateAsync(CreateVehicleRequest request, Guid userId);
    Task<VehicleResponse> UpdateAsync(UpdateVehicleRequest request, Guid userId, Guid vehicleId);
    Task DeleteAsync(Guid vehicleId, Guid userId);
}
