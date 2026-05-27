using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeuVeiculo.Models;

namespace MeuVeiculo;

public interface IFuelLogRepository
{
    Task<IEnumerable<FuelLog>> GetAllVehicleFuelLogsAsync(Guid vehicleId);
    Task<FuelLog?> GetByIdAsync(Guid id, Guid vehicleId);
    Task<FuelLog> CreateFuelLogAsync(FuelLog fuelLog);
    Task<FuelLog> UpdateFuelLogAsync(FuelLog fuelLog);
    Task DeleteAsync(FuelLog fuelLog);
}
