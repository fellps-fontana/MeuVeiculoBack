using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVeiculo.Data;
using MeuVeiculo.Models;    
using Microsoft.EntityFrameworkCore;

namespace MeuVeiculo.Repositorys.Implementation;

public class FuelLogRepository(AppDbContext context) : IFuelLogRepository
{
    public async Task<IEnumerable<FuelLog>> GetAllVehicleFuelLogsAsync(Guid vehicleId) =>
        await context.FuelLogs
            .Where(f => f.VehicleId == vehicleId)
            .ToListAsync();

    public async Task<FuelLog?> GetByIdAsync(Guid id, Guid vehicleId) =>
        await context.FuelLogs
            .FirstOrDefaultAsync(f => f.Id == id && f.VehicleId == vehicleId);

    public async Task<FuelLog> CreateFuelLogAsync(FuelLog fuelLog)
    {
        await context.FuelLogs.AddAsync(fuelLog);
        await context.SaveChangesAsync();
        return fuelLog;
    }

    public async Task<FuelLog> UpdateFuelLogAsync(FuelLog fuelLog)
    {
        context.FuelLogs.Update(fuelLog);
        await context.SaveChangesAsync();
        return fuelLog;
    }

    public async Task DeleteAsync(FuelLog fuelLog)
    {
        context.FuelLogs.Remove(fuelLog);
        await context.SaveChangesAsync();
    }
}
