using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVeiculo.Data;
using MeuVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuVeiculo.Repositorys.Implementation;

public class MaintenanceLogRepository(AppDbContext context) : IMaintenanceLogRepository
{
    public async Task<IEnumerable<MaintenanceLog>> GetAllVehicleMaintenanceLogsAsync(Guid vehicleId) =>
        await context.MaintenanceLogs
            .Where(m => m.VehicleId == vehicleId)
            .ToListAsync();

    public async Task<MaintenanceLog?> GetByIdAsync(Guid id, Guid vehicleId) =>
        await context.MaintenanceLogs
            .FirstOrDefaultAsync(m => m.Id == id && m.VehicleId == vehicleId);

    public async Task<MaintenanceLog> CreateMaintenanceLogAsync(MaintenanceLog log)
    {
        await context.MaintenanceLogs.AddAsync(log);
        await context.SaveChangesAsync();
        return log;
    }

    public async Task<MaintenanceLog> UpdateMaintenanceLogAsync(MaintenanceLog log)
    {
        context.MaintenanceLogs.Update(log);
        await context.SaveChangesAsync();
        return log;
    }

    public async Task DeleteAsync(MaintenanceLog log)
    {
        context.MaintenanceLogs.Remove(log);
        await context.SaveChangesAsync();
    }
}
