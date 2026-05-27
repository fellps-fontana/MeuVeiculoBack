using System;
using MeuVeiculo.Enums;

namespace MeuVeiculo.DTOs.MaintenanceLogs;

public record CreateMaintenanceLogRequest(
    DateOnly Date,
    CategoryType Category,
    string Description,
    decimal Price,
    string? Mechanic,
    DateOnly? NextDueDate,
    int? NextDueOdometer
);
