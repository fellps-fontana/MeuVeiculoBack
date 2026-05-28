using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.FuelLogs;
using MeuVeiculo.Models;
using MeuVeiculo.Services.Interfaces;

namespace MeuVeiculo.Services.Implementation;

public class FuelLogService(IFuelLogRepository repository) : IFuelLogService
{
    public async Task<IEnumerable<FuelLogResponse>> GetAllAsync(Guid vehicleId)
    {
        var logs = await repository.GetAllVehicleFuelLogsAsync(vehicleId);
        return logs.Select(MapToResponse);
    }

    public async Task<FuelLogResponse> GetByIdAsync(Guid id, Guid vehicleId)
    {
        var log = await repository.GetByIdAsync(id, vehicleId)
            ?? throw new KeyNotFoundException($"FuelLog with id {id} not found");
        return MapToResponse(log);
    }

    public async Task<FuelLogResponse> CreateAsync(CreateFuelLogRequest request, Guid vehicleId)
    {
        var pricePerLiter = request.TotalCost / request.Liters;
        var log = new FuelLog(
            vehicleId,
            request.Date.ToDateTime(TimeOnly.MinValue),
            request.Liters,
            request.TotalCost,
            pricePerLiter,
            request.Odometer,
            request.Station ?? string.Empty,
            request.FullTank
        );
        var created = await repository.CreateFuelLogAsync(log);
        return MapToResponse(created);
    }

    public async Task<FuelLogResponse> UpdateAsync(CreateFuelLogRequest request, Guid id, Guid vehicleId)
    {
        var log = await repository.GetByIdAsync(id, vehicleId)
            ?? throw new KeyNotFoundException($"FuelLog with id {id} not found");
        log.Date = request.Date.ToDateTime(TimeOnly.MinValue);
        log.Liters = request.Liters;
        log.TotalCost = request.TotalCost;
        log.PricePerLiter = request.TotalCost / request.Liters;
        log.Odometer = request.Odometer ?? log.Odometer;
        log.Station = request.Station ?? log.Station;
        log.FullTank = request.FullTank;
        var updated = await repository.UpdateFuelLogAsync(log);
        return MapToResponse(updated);
    }

    public async Task<FuelLogResponse> DeleteAsync(Guid id, Guid vehicleId)
    {
        var log = await repository.GetByIdAsync(id, vehicleId)
            ?? throw new KeyNotFoundException($"FuelLog with id {id} not found");
        await repository.DeleteAsync(log);
        return MapToResponse(log);
    }

    private static FuelLogResponse MapToResponse(FuelLog f) => new(
        f.Id,
        DateOnly.FromDateTime(f.Date),
        f.Liters,
        f.TotalCost,
        f.PricePerLiter,
        f.Odometer,
        f.Station,
        f.FullTank
    );
}
