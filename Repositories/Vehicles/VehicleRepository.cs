using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
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

      public async Task<int> AddVehicle(Vehicle vehicle)
      {
         if (_context != null)
         {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();

            return vehicle.Id;
         }

         return 0;
      }

      public async Task<int> DeleteVehicle(int? vehicleId)
      {
         int result = 0;

         if (_context != null)
         {
            //Find the post for specific post id
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(x => x.Id == vehicleId);

            if (vehicle != null)
            {
               //Delete that vehicle
               _context.Vehicles.Remove(vehicle);

               //Commit the transaction
               result = await _context.SaveChangesAsync();
            }
            return result;
         }

         return result;
      }

      public IQueryable<Vehicle> FindAll()
      {
         return _context.Set<Vehicle>()
               .AsNoTracking();
      }

      public async Task<Vehicle> GetVehicle(int? vehicleId)
      {
         if (_context != null)
         {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == vehicleId);

            return vehicle;
         }
         return null;
      }

      public PagedList<Vehicle> GetVehicles(VehicleParameters vehicleParameters)
      {
         if (_context != null)
         {
           	return PagedList<Vehicle>.ToPagedList(FindAll().OrderBy(v => v.Year),
	      	vehicleParameters.PageNumber,
		      vehicleParameters.PageSize);
            /*  var vehicles = await _context.Vehicles.ToListAsync();

             return vehicles; */
         }

         return null;
      }

      public async Task UpdateVehicle(Vehicle vehicle)
      {
         if (_context != null)
         {
            //Delete that vehicle
            _context.Vehicles.Update(vehicle);

            //Commit the transaction
            await _context.SaveChangesAsync();
         }
      }
   }
}