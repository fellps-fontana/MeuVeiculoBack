using System;
using System.Collections.Generic;
using MeuVeiculo.Enums;

namespace MeuVeiculo.Models;

public class Vehicle
{
    public Vehicle(string name, string model, string plate, VehicleType type, int year, FuelType fuel, Guid userId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Model = model;
        Plate = plate;
        Type = type;
        Year = year;
        Fuel = fuel;
        UserId = userId;
        FuelLogs = new List<FuelLog>();
        MaintenanceLogs = new List<MaintenaceLog>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
    public string Plate { get; set; }
    public VehicleType Type { get; set; }
    public int Year { get; set; }
    public FuelType Fuel { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<FuelLog> FuelLogs { get; set; }
    public ICollection<MaintenaceLog> MaintenanceLogs { get; set; }
}