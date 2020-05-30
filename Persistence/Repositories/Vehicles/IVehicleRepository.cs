using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.Vehicle;

namespace Al_Delal.Api.Repositories.Vehicles
{
   public interface IVehicleRepository
   {

      PagedList<Vehicle> GetVehicles(FilterQuery filterQuery);

      Task<Vehicle> GetVehicle(int? vehicleId);

      Task<int> AddVehicle(Vehicle vehicle);

      Task<int> DeleteVehicle(int? vehicleId);

      Task UpdateVehicle(Vehicle vehicle);
      IQueryable<Vehicle> FindByCondition(Expression<Func<Vehicle, bool>> expression);
      Task<IEnumerable<MasterTable>> GetMasterTable();


   }
}