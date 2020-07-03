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
         // remov it
         var vehicle = _context.Set<Vehicle>().AsNoTracking();
         var result = PagedList<Vehicle>.ToPagedList(vehicle.OrderByDescending(v => v.DateAdded),
                filterQuery.PageNumber,
                filterQuery.PageSize);

         return result;


         /*          
                  // var vehicle = _context.Set<Vehicle>().AsNoTracking();
                  var vehicle = _context.Vehicles.AsQueryable().AsNoTracking();
                  // Create a PredicateBuilder for contrcuting dynamic query
                  var predicate = PredicateBuilder.New<Vehicle>();
                  // Url dcode the query string and get GetVehicles Model queries array
                  var modelQueries = new string[] { };
                  if (!string.IsNullOrEmpty(filterQuery.Model)) modelQueries = filterQuery.Model.Split(' ');

                  // Url dcode the query string and get  get GetVehicles Make queries array
                  var makeQueries = new string[] { };
                  if (!string.IsNullOrEmpty(filterQuery.Make)) makeQueries = filterQuery.Make.Split(' ');
                  // Url dcode the query string and get  get GetVehicles Make queries array
                  var transmissionQueries = new string[] { };
                  if (!string.IsNullOrEmpty(filterQuery.Transmission)) transmissionQueries = filterQuery.Transmission.Split(' ');

                  // add vehicle queries
                  if (modelQueries.Length > 0)
                  {
                     var modelPredicate = PredicateBuilder.New<Vehicle>();
                     foreach (string model in modelQueries)
                     {
                        // Remove hyphens from model
                        var originalModel = model.Replace("-", " ");
                        // Apply SQL OR to find Vehicles with all specified model
                        modelPredicate = modelPredicate.Or(v => v.Model == originalModel);

                     }
                     predicate = predicate.And(modelPredicate);

                  }

                  if (makeQueries.Length > 0)
                  {
                     var makePredicate = PredicateBuilder.New<Vehicle>();
                     foreach (string make in makeQueries)
                     {
                        // Remove hyphens from make
                        var originalMake = make.Replace("-", " ");
                        // Apply SQL OR to find Vehicles with all specified make
                        makePredicate = makePredicate.Or(v => v.Make == originalMake);

                     }
                     predicate = predicate.And(makePredicate);

                  }

                  if (transmissionQueries.Length > 0)
                  {
                     var transmissionPredicate = PredicateBuilder.New<Vehicle>();
                     foreach (string transmission in transmissionQueries)
                     {
                        // Remove hyphens from transmission
                        var originaltransmission = transmission.Replace("-", " ");
                        // Apply SQL OR to find Vehicles with all specified transmission
                        transmissionPredicate = transmissionPredicate.Or(v => v.Transmission == originaltransmission);

                     }
                     predicate = predicate.And(transmissionPredicate);

                  }

                  // Add the predicate  to the query
                  vehicle = vehicle.Where(predicate);

                  // Dont inlcude the predicate builder if no filter exists
                  if (AppUtill.IsObjectNullOrEmpty(filterQuery)) vehicle = _context.Vehicles.AsQueryable().AsNoTracking();


                  var result = PagedList<Vehicle>.ToPagedList(vehicle.OrderByDescending(v => v.DateAdded),
                         filterQuery.PageNumber,
                         filterQuery.PageSize);

                  return result;

          */

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