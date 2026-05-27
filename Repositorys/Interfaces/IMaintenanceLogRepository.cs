using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.Models;

namespace MeuVeiculo;

public interface IMaintenanceLogRepository
{
    Task<IEnumerable<MaintenanceLog>> GetAllVehicleMaintenanceLogsAsync(Guid vehicleId);
    Task<MaintenanceLog?> GetByIdAsync(Guid id, Guid vehicleId);
    Task<MaintenanceLog> CreateMaintenanceLogAsync(MaintenanceLog log);
    Task<MaintenanceLog> UpdateMaintenanceLogAsync(MaintenanceLog log);
    Task DeleteAsync(MaintenanceLog log);
}
