using MeuVeiculo.Enums;

namespace MeuVeiculo.Models;

public class MaintenaceLog
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public Guid VehicleId { get; set; }
    public CategoryType Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Mechanic  { get; set; }
    public DateTime NextDueDat {get; set;}
    public int? NextDueOdometer {get; set;}
    
}