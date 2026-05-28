using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.MaintenanceLogs;

namespace MeuVeiculo.Services.Interfaces;

public interface IMaintenanceLogService
{
    Task<IEnumerable<MaintenanceLogResponse>> GetAllAsync(Guid vehicleId);
    Task<MaintenanceLogResponse> GetByIdAsync(Guid id, Guid vehicleId);
    Task<MaintenanceLogResponse> CreateAsync(CreateMaintenanceLogRequest request, Guid vehicleId);
    Task<MaintenanceLogResponse> UpdateAsync(CreateMaintenanceLogRequest request, Guid id, Guid vehicleId);
    Task<MaintenanceLogResponse> DeleteAsync(Guid id, Guid vehicleId);
}
