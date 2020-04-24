using System.Collections.Generic;
using System.Threading.Tasks;
using Al_Delal.Api.Data;
using Al_Delal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Al_Delal.Api.Repositories.Vehicles
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _context;
        public VehicleRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);

        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            var vehicle = await _context.Vehicles.Include(v => v.Photos).FirstOrDefaultAsync(v => v.Id == id);

            return vehicle;
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            var vehicles = await _context.Vehicles.Include(v => v.Photos).ToListAsync();

            return vehicles;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}