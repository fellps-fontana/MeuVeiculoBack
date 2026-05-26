namespace MeuVeiculo.Models;

public class FuelLog
{
    public Guid Id { get; set; }
    public Vehicle Vehicle { get; set; }
    public DateTime Date { get; set; }
    public int Liters { get; set; }
    public decimal TotalCost {get; set;}
    public Decimal PricePerLiter {get; set;}
    public decimal Odometer {get; set;}
    public string Station {get; set;}
    public Boolean FullTank {get; set;}
    public FuelLog(Vehicle vehicle, DateTime date, int liters, decimal totalCost, decimal pricePerLiter, int odometer, string station, Boolean fullTank)
    {
        Id = Guid.NewGuid();
        Vehicle = vehicle;
        Date = date;
        Liters = liters;
        TotalCost = totalCost;
        PricePerLiter = pricePerLiter;
        Odometer = odometer;
        Station = station;
        FullTank = fullTank;
    }
    

}