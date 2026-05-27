using MeuVeiculo.Enums;

namespace MeuVeiculo.DTOs.Vehicles;

public record CreateVehicleRequest(
    string Name,
    string Brand,
    string Model,
    int Year,
    string? Plate,
    VehicleType Type,
    FuelType FuelType
);
