using System;

namespace MeuVeiculo.DTOs.FuelLogs;

public record FuelLogResponse(
    Guid Id,
    DateOnly Date,
    decimal Liters,
    decimal TotalCost,
    decimal PricePerLiter,
    int? Odometer,
    string? Station,
    bool FullTank
);
