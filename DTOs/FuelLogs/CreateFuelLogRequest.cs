using System;

namespace MeuVeiculo.DTOs.FuelLogs;

public record CreateFuelLogRequest(
    DateOnly Date,
    decimal Liters,
    decimal TotalCost,
    int? Odometer,
    string? Station,
    bool FullTank
);
// PricePerLiter is calculated by the backend: TotalCost / Liters
