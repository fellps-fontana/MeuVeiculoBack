using System;
using MeuVeiculo.Enums;

namespace MeuVeiculo.Models;

public class MaintenanceLog
{
    public Guid Id { get; set; }
    public DateOnly Date { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public Guid VehicleId { get; set; }
    public CategoryType Category { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Mechanic { get; set; } = string.Empty;
    public DateOnly? NextDueDate { get; set; }
    public int? NextDueOdometer { get; set; }
}
