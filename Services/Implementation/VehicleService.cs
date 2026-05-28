using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVeiculo.DTOs.Vehicles;
using MeuVeiculo.Models;
using MeuVeiculo.Services.Interfaces;

namespace MeuVeiculo.Services.Implementation;

public class VehicleService(IVehicleRepository repository) : IVeihicleService
{
    public async Task<IEnumerable<VehicleResponse>> GetAllAsync(Guid userId)
    {
        var vehicles = await repository.GetAllUserVehiclesAsync(userId);
        return vehicles.Select(MapToResponse);
    }

    public async Task<VehicleResponse> GetByIdAsync(Guid vehicleId, Guid userId)
    {
        var vehicle = await repository.GetByIdAsync(vehicleId, userId)
            ?? throw new KeyNotFoundException($"Vehicle with id {vehicleId} not found");
        return MapToResponse(vehicle);
    }

    public async Task<VehicleResponse> CreateAsync(CreateVehicleRequest request, Guid userId)
    {
        var vehicle = new Vehicle(
            request.Name,
            request.Model,
            request.Plate ?? string.Empty,
            request.Type,
            request.Year,
            request.FuelType,
            userId
        );
        var created = await repository.CreateVehicleAsync(vehicle);
        return MapToResponse(created);
    }

    public async Task<VehicleResponse> UpdateAsync(UpdateVehicleRequest request, Guid userId, Guid vehicleId)
    {
        var existing = await repository.GetByIdAsync(vehicleId, userId)
            ?? throw new KeyNotFoundException($"Vehicle with id {vehicleId} not found");
        existing.Model = request.Model ?? existing.Model;
        existing.Year = request.Year ?? existing.Year;
        existing.Plate = request.Plate ?? existing.Plate;
        existing.Type = request.Type ?? existing.Type;
        existing.Fuel = request.FuelType ?? existing.Fuel;
        var updated = await repository.UpdateVehicleAsync(existing);
        return MapToResponse(updated);
    }

    public async Task DeleteAsync(Guid vehicleId, Guid userId)
    {
        var vehicle = await repository.GetByIdAsync(vehicleId, userId)
            ?? throw new KeyNotFoundException($"Vehicle with id {vehicleId} not found");
        await repository.DeleteAsync(vehicle);
    }

    private static VehicleResponse MapToResponse(Vehicle v) => new(
        v.Id,
        v.Name,
        v.Model,
        v.Year,
        v.Plate,
        v.Type.ToString(),
        v.Fuel.ToString()
    );
}
