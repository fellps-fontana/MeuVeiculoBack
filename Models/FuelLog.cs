using System;

namespace MeuVeiculo.Models;

public class FuelLog
{
    public FuelLog(Guid vehicleId, DateTime date, decimal liters, decimal totalCost, decimal pricePerLiter, int odometer, string station, bool fullTank)
    {
        Id = Guid.NewGuid();
        VehicleId = vehicleId;
        Date = date;
        Liters = liters;
        TotalCost = totalCost;
        PricePerLiter = pricePerLiter;
        Odometer = odometer;
        Station = station;
        FullTank = fullTank;
    }

    public Guid Id { get; set; }
    public Guid VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;
    public DateTime Date { get; set; }
    public decimal Liters { get; set; }
    public decimal TotalCost { get; set; }
    public decimal PricePerLiter { get; set; }
    public int Odometer { get; set; }
    public string Station { get; set; } = string.Empty;
    public bool FullTank { get; set; }
}