using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.MaintenanceLogs;
using MeuVeiculo.Models;
using MeuVeiculo.Services.Interfaces;

namespace MeuVeiculo.Services.Implementation;

public class MaintenanceLogService(IMaintenanceLogRepository repository) : IMaintenanceLogService
{
    public async Task<IEnumerable<MaintenanceLogResponse>> GetAllAsync(Guid vehicleId)
    {
        var logs = await repository.GetAllVehicleMaintenanceLogsAsync(vehicleId);
        return logs.Select(MapToResponse);
    }

    public async Task<MaintenanceLogResponse> GetByIdAsync(Guid id, Guid vehicleId)
    {
        var log = await repository.GetByIdAsync(id, vehicleId)
            ?? throw new KeyNotFoundException($"MaintenanceLog with id {id} not found");
        return MapToResponse(log);
    }

    public async Task<MaintenanceLogResponse> CreateAsync(CreateMaintenanceLogRequest request, Guid vehicleId)
    {
        var log = new MaintenanceLog
        {
            Id = Guid.NewGuid(),
            VehicleId = vehicleId,
            Date = request.Date,
            Category = request.Category,
            Description = request.Description,
            Price = request.Price,
            Mechanic = request.Mechanic ?? string.Empty,
            NextDueDate = request.NextDueDate,
            NextDueOdometer = request.NextDueOdometer
        };
        var created = await repository.CreateMaintenanceLogAsync(log);
        return MapToResponse(created);
    }

    public async Task<MaintenanceLogResponse> UpdateAsync(CreateMaintenanceLogRequest request, Guid id, Guid vehicleId)
    {
        var log = await repository.GetByIdAsync(id, vehicleId)
            ?? throw new KeyNotFoundException($"MaintenanceLog with id {id} not found");
        log.Date = request.Date;
        log.Category = request.Category;
        log.Description = request.Description;
        log.Price = request.Price;
        log.Mechanic = request.Mechanic ?? log.Mechanic;
        log.NextDueDate = request.NextDueDate ?? log.NextDueDate;
        log.NextDueOdometer = request.NextDueOdometer;
        var updated = await repository.UpdateMaintenanceLogAsync(log);
        return MapToResponse(updated);
    }

    public async Task<MaintenanceLogResponse> DeleteAsync(Guid id, Guid vehicleId)
    {
        var log = await repository.GetByIdAsync(id, vehicleId)
            ?? throw new KeyNotFoundException($"MaintenanceLog with id {id} not found");
        await repository.DeleteAsync(log);
        return MapToResponse(log);
    }

    private static MaintenanceLogResponse MapToResponse(MaintenanceLog m) => new(
        m.Id,
        m.Date,
        m.Category.ToString(),
        m.Description,
        m.Price,
        m.Mechanic,
        m.NextDueDate,
        m.NextDueOdometer
    );
}
