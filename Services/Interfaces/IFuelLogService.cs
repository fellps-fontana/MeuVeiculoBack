using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.FuelLogs;

namespace MeuVeiculo.Services.Interfaces;

public interface IFuelLogService
{
    Task<IEnumerable<FuelLogResponse>> GetAllAsync(Guid vehicleId);
    Task<FuelLogResponse> GetByIdAsync(Guid id, Guid vehicleId);
    Task<FuelLogResponse> CreateAsync(CreateFuelLogRequest request, Guid vehicleId);
    Task<FuelLogResponse> UpdateAsync(CreateFuelLogRequest request, Guid id, Guid vehicleId);
    Task<FuelLogResponse> DeleteAsync(Guid id, Guid vehicleId);
}
