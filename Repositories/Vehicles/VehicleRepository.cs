using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Data;
using Al_Delal.Api.Models;
using Microsoft.EntityFrameworkCore;
using LinqKit;
using Al_Delal.Api.Helper;
using Al_Delal.Api.Resource.Vehicle;

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
            vehicle.DateAdded = DateTime.Now;
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



      public async Task<Vehicle> GetVehicle(int? vehicleId)
      {
         if (_context != null)
         {
            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == vehicleId);

            return vehicle;
         }
         return null;
      }

      public PagedList<Vehicle> GetVehicles(FilterQuery filterQuery)
      {
         // var masterTable = GetMasterTable();
         var vehicle = _context.Set<Vehicle>().AsNoTracking().OrderByDescending(v => v.DateAdded);

         var result = PagedList<Vehicle>.ToPagedList(vehicle,
                filterQuery.PageNumber,
                filterQuery.PageSize);

         return result;

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

      public IQueryable<Vehicle> FindByCondition(Expression<Func<Vehicle, bool>> expression)
      {
         return _context.Set<Vehicle>()
             .Where(expression)
             .AsNoTracking();
      }

      public async Task<IEnumerable<MasterTable>> GetMasterTable()
      {
         var masterTable = await _context.MasterTables
         .Include(c => c.Color)
         .Include(c => c.Condition)
         .Include(t => t.Transmission)
         .Include(f => f.Fuel)
         .Include(m => m.Make)
         .Include(m => m.Modal)
         .ToListAsync();

         return masterTable;
      }

   }
}