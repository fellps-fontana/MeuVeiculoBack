using System;

namespace MeuVeiculo.DTOs.MaintenanceLogs;

public record MaintenanceLogResponse(
    Guid Id,
    DateOnly Date,
    string Category,
    string Description,
    decimal Price,
    string? Mechanic,
    DateOnly? NextDueDate,
    int? NextDueOdometer
);
