using MeuVeiculo.Enums;

namespace MeuVeiculo.Models;

public class Vehicle
{
    public Vehicle(string name , string model, string plate, VehicleType type, int year, FuelType fuel)
    {
        Id = Guid.NewGuid();
        Plate = plate;
        Type = type;
        Year = year;
        Fuel = fuel;
        Name = name;
        Model = model;
        
    }
    public Guid Id { get; set; }
    public string Name {get; set;}
    public string Model {get; set;} 
    public string Plate  { get; set; }
    public VehicleType Type { get; set; }
    public int Year { get; set; }
    public FuelType Fuel { get; set; }
     
     
}