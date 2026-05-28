using System;

namespace MeuVeiculo.DTOs.Vehicles;

public record VehicleResponse(
    Guid Id,
    string Name,
    string Model,
    int Year,
    string? Plate,
    string Type,
    string FuelType
);
