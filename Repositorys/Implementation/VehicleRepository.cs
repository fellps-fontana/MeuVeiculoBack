using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeuVeiculo.Data;
using MeuVeiculo.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuVeiculo.Repositorys.Implementation;

public class VehicleRepository(AppDbContext context) : IVehicleRepository
{
    public async Task<IEnumerable<Vehicle>> GetAllUserVehiclesAsync(Guid userId) =>
        await context.Vehicles
            .Where(x => x.UserId == userId)
            .ToListAsync();

    

    public async Task<Vehicle?> GetByIdAsync (Guid id, Guid userId)=>
        await context.Vehicles
            .FirstOrDefaultAsync(v => v.Id == id && v.UserId == userId);

    

    public async Task<Vehicle> CreateVehicleAsync(Vehicle vehicle)
    {
        context.Vehicles.AddAsync(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public async Task<Vehicle> UpdateVehicleAsync(Vehicle vehicle)
    {
        context.Vehicles.Update(vehicle);
        await context.SaveChangesAsync();
        return vehicle;
    }

    public Task DeleteAsync(Vehicle vehicle)
    {
        context.Vehicles.Remove(vehicle);
        return context.SaveChangesAsync();
    }
}